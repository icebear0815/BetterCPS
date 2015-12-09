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

                ScanLists allScanLists = new ScanLists();
                allScanLists.ScanListsFromRawData(data, DEBUG);

                Zones allZones = new Zones();
                allZones.ZonesFromRawData(data, DEBUG);

                Channels allChannels = new Channels();
                allChannels.ChannelsFromRawData(data, DEBUG);

                String channelCSV = allChannels.toCSV(allContacts, allRXGroups, allScanLists, allZones);
                Console.WriteLine(channelCSV);
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
            DEBUG = ((MenuItem)sender).Checked;
        }
    }
}
