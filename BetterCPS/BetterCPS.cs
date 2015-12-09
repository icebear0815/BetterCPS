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
        private  bool DEBUG = false;
        Codeplug cp = null;
        Contacts allContacts;
        RXGroups allRXGroups;
        ScanLists allScanLists;
        Zones allZones;
        Channels allChannels;

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
                
                allContacts = new Contacts();
                allContacts.ContactsFromRawData(data, DEBUG);

                allRXGroups = new RXGroups();
                allRXGroups.RXGroupsFromRawData(data, DEBUG);

                allScanLists = new ScanLists();
                allScanLists.ScanListsFromRawData(data, DEBUG);

                allZones = new Zones();
                allZones.ZonesFromRawData(data, DEBUG);

                allChannels = new Channels();
                allChannels.ChannelsFromRawData(data, DEBUG);

                //String channelCSV = allChannels.toCSV(allContacts, allRXGroups, allScanLists, allZones);
                //Console.WriteLine(channelCSV);
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

        private void checkStateChanged(object sender, EventArgs e)
        {
            DEBUG = ((ToolStripMenuItem)sender).Checked;
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void channelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (allChannels != null)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllText(saveFileDialog1.FileName, allChannels.toCSV(allContacts, allRXGroups, allScanLists, allZones));
                }
            }
            else
            {
                MessageBox.Show(this, "Kein Codeplug geöffnet!");
            }
        }
    }
}
