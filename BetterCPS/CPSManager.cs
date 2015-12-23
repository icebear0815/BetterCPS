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
    public partial class CPSManager : Form
    {
        Codeplug cp = null;

        public CPSManager()
        {
            Console.WriteLine("Version: "+typeof(CPSManager).Assembly.GetName().Version.ToString());
            //DBAccess.GetInstance();
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
            Debug.GetInstance().DebugOn = ((ToolStripMenuItem)sender).Checked;
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
                    System.IO.File.WriteAllLines(saveFileDialog1.FileName, cp.AllChannels.ToCSV(cp.AllContacts, cp.AllRXGroups, cp.AllScanLists, cp.AllZones, false), Encoding.UTF8);
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
                String znPath = openFileDialog2.FileName + ".ZN_GUID";
                if (!System.IO.File.Exists(znPath))
                {
                    MessageBox.Show("Can't find " + znPath + " ! Please select file location!");
                    openFileDialog2.FileName = "*.ZN_GUID";
                    if (openFileDialog2.ShowDialog() == DialogResult.OK)
                    {
                        znPath = openFileDialog2.FileName + ".ZN_GUID";
                        openFileDialog2.FileName = "*.csv";
                    }
                    else
                    {
                        MessageBox.Show("Operation canceld!");
                        return;
                    }
                }
                String slPath = openFileDialog2.FileName + ".SL_GUID";
                if (!System.IO.File.Exists(slPath))
                {
                    MessageBox.Show("Can't find " + slPath + " ! Please select file location!");
                    openFileDialog2.FileName = "*.SL_GUID";
                    if (openFileDialog2.ShowDialog() == DialogResult.OK)
                    {
                        slPath = openFileDialog2.FileName + ".SL_GUID";
                        openFileDialog2.FileName = "*.csv";
                    }
                    else
                    {
                        MessageBox.Show("Operation canceld!");
                        return;
                    }
                }

                String[] csvData = System.IO.File.ReadAllLines(openFileDialog2.FileName, Encoding.UTF8);
                cp.AllChannels.FromCSV(csvData, cp.AllContacts, cp.AllRXGroups, cp.AllScanLists, cp.AllZones, false);
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

        

        private void contactsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cp.AllContacts != null)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllLines(saveFileDialog1.FileName, cp.AllContacts.ToCSV(), Encoding.UTF8);
                }
            }
            else
            {
                MessageBox.Show(this, "Kein Codeplug geöffnet!");
            }
        }

        private void contactsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //import contacts
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllLines(openFileDialog2.FileName+"~tmp", cp.AllChannels.ToCSV(cp.AllContacts, cp.AllRXGroups, cp.AllScanLists, cp.AllZones), Encoding.UTF8);
                String[] csvData = System.IO.File.ReadAllLines(openFileDialog2.FileName, Encoding.UTF8);
                cp.AllContacts.FromCSV(csvData, Debug.GetInstance().DebugOn);
                //
                csvData = System.IO.File.ReadAllLines(openFileDialog2.FileName + "~tmp", Encoding.UTF8);
                cp.AllChannels.FromCSV(csvData, cp.AllContacts, cp.AllRXGroups, cp.AllScanLists, cp.AllZones, Debug.GetInstance().DebugOn);
                System.IO.File.Delete(openFileDialog2.FileName + "~tmp");
            }
        }

        private void zonesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Import Zones
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                //export channels
                System.IO.File.WriteAllLines(openFileDialog2.FileName + "~tmp", cp.AllChannels.ToCSV(cp.AllContacts, cp.AllRXGroups, cp.AllScanLists, cp.AllZones, true), Encoding.UTF8);
                //import zones
                String[] csvData = System.IO.File.ReadAllLines(openFileDialog2.FileName, Encoding.UTF8);
                cp.AllZones.FromCSV(csvData, cp.AllChannels, false);
                //
                //re-import channels -> may be refernces will be updated
                csvData = System.IO.File.ReadAllLines(openFileDialog2.FileName + "~tmp", Encoding.UTF8);
                cp.AllChannels.FromCSV(csvData, cp.AllContacts, cp.AllRXGroups, cp.AllScanLists, cp.AllZones, true);
                System.IO.File.Delete(openFileDialog2.FileName + "~tmp");
            }
        }

        private void scanListsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Import ScanLists
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                //export channels
                System.IO.File.WriteAllLines(openFileDialog2.FileName + "~tmp", cp.AllChannels.ToCSV(cp.AllContacts, cp.AllRXGroups, cp.AllScanLists, cp.AllZones, true), Encoding.UTF8);
                //import scanLists
                String[] csvData = System.IO.File.ReadAllLines(openFileDialog2.FileName, Encoding.UTF8);
                cp.AllScanLists.FromCSV(csvData, cp.AllChannels, false);
                //
                //re-import channels -> may be refernces will be updated
                csvData = System.IO.File.ReadAllLines(openFileDialog2.FileName + "~tmp", Encoding.UTF8);
                cp.AllChannels.FromCSV(csvData, cp.AllContacts, cp.AllRXGroups, cp.AllScanLists, cp.AllZones, true);
                System.IO.File.Delete(openFileDialog2.FileName + "~tmp");
            }
        }

        private void versionLabelToolStripMenuItem_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version: "+typeof(CPSManager).Assembly.GetName().Version.ToString()+"\n"
                            +"\n     Copyright by Lars Schindler"
                            +"\n                   - DH6OBN -");
        }

        
    }
}
