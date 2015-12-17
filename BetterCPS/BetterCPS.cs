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
        /*Contacts allContacts;
        RXGroups allRXGroups;
        ScanLists allScanLists;
        Zones allZones;
        Channels allChannels;*/

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
            cp.Debug = DEBUG;
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void channelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cp.AllChannels != null)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllLines(saveFileDialog1.FileName, cp.AllChannels.ToCSV(cp.AllContacts, cp.AllRXGroups, cp.AllScanLists, cp.AllZones), Encoding.UTF8);
                    //
                    System.IO.File.WriteAllLines(saveFileDialog1.FileName+".SL_GUID", cp.AllScanLists.ToCSV(cp.AllChannels, true), Encoding.UTF8);
                    System.IO.File.WriteAllLines(saveFileDialog1.FileName+".ZN_GUID", cp.AllZones.ToCSV(cp.AllChannels, true), Encoding.UTF8);
                }
            }
            else
            {
                MessageBox.Show(this, "Kein Codeplug geöffnet!");
            }
        }

        private void saveCodeplugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "You do this at your own risk!\nThe author of this software is not responsible for any damage to your hardware!") == DialogResult.OK)
            {
                if (saveFileDialog2.ShowDialog() == DialogResult.OK)
                    System.IO.File.WriteAllBytes(saveFileDialog2.FileName, cp.RawData);
            }
        }

        private void channelsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                String[] csvData = System.IO.File.ReadAllLines(openFileDialog2.FileName, Encoding.UTF8);
                cp.AllChannels.FromCSV(csvData, cp.AllContacts, cp.AllRXGroups, cp.AllScanLists, cp.AllZones, cp.Debug);
                //
                csvData = System.IO.File.ReadAllLines(openFileDialog2.FileName + ".ZN_GUID", Encoding.UTF8);
                cp.AllZones.FromCSV(csvData, cp.AllChannels, true);
                csvData = System.IO.File.ReadAllLines(openFileDialog2.FileName + ".SL_GUID", Encoding.UTF8);
                cp.AllScanLists.FromCSV(csvData, cp.AllChannels, true);
            }
        }

        private void zonesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cp.AllZones != null)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllLines(saveFileDialog1.FileName, cp.AllZones.ToCSV(cp.AllChannels), Encoding.UTF8);
                }
            }
            else
            {
                MessageBox.Show(this, "Kein Codeplug geöffnet!");
            }
        }

        private void scanListsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cp.AllScanLists != null)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllLines(saveFileDialog1.FileName, cp.AllScanLists.ToCSV(cp.AllChannels), Encoding.UTF8);
                }
            }
            else
            {
                MessageBox.Show(this, "Kein Codeplug geöffnet!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String guid = textBox1.Text;
            idOutLabel.Text = ""+cp.AllChannels.getIdByGUID(guid);
            nameOutLabel.Text = ""+cp.AllChannels.getObjectByGUID(guid).Name;
        }
    }
}
