using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BetterCPS.Channel;
using BetterCPS.Contact;
using BetterCPS.ScanList;
using BetterCPS.Zone;
using BetterCPS.RXGroup;

namespace BetterCPS
{
    public partial class BetterCPS : Form
    {
        private const bool DEBUG = false;
        Codeplug cp = null;
        public BetterCPS()
        {
            InitializeComponent();
            cp = new Codeplug();
        }

        private void exit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openCodeplug(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                byte[] data = System.IO.File.ReadAllBytes(openFileDialog1.FileName);
                cp.RawData = data;
                Console.WriteLine("Read " + data.Length + " bytes. OK.");

                int offset = 0x1f025;
                int dataWidth = 64;
                
                Contacts allContacts = new Contacts();
                allContacts.ContactsFromRawData(data, DEBUG);

                RXGroups allRXGroups = new RXGroups();
                allRXGroups.RXGroupsFromRawData(data, DEBUG);

                Channels allChannels = new Channels();
                allChannels.ChannelsFromRawData(data, DEBUG);

                

                // S C A N - L I S T
                Console.WriteLine("S C A N - L I S T");
                offset = ScanListObject.offset;
                dataWidth = ScanListObject.Length;
                for (int i = 0; i < 1; i++)
                {
                    String hex;
                    byte[] oneChannel = new byte[dataWidth];
                    for (int j = 0; j < dataWidth; j++)
                    {
                        byte value = data[offset + j];
                        oneChannel[j] = value;
                        hex = string.Format("{0:X2}", value);
                        Console.Write(hex + " ");
                    }
                    Console.WriteLine();
                    offset += dataWidth;
                    ScanListObject ce = new ScanListObject();
                    ce.RawData = oneChannel;
                    Console.WriteLine(ce.toString());
                }
            }
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            /*if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                byte[] data = System.IO.File.ReadAllBytes(openFileDialog1.FileName);
                
                Console.WriteLine("Read "+data.Length+" bytes. OK.");
            }*/
        }
    }
}
