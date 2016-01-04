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
using BetterCPS.Helper;

namespace BetterCPS
{
    public partial class CPSManager : Form
    {
        Codeplug cp = null;
        Codeplug importCP = null;

        private const String XMLCHANNEL = "channel.xml";
        private const String XMLCONTACT = "contact.xml";
        private const String XMLSCANLIST = "scanlist.xml";
        private const String XMLZONE = "zone.xml";

        private const String CSVCHANNEL = "channel.csv";
        private const String CSVCONTACT = "contact.csv";
        private const String CSVSCANLIST = "scanlist.csv";
        private const String CSVZONE = "zone.csv";

        private String folderPath;
        private Project project;

        public CPSManager()
        {
            Console.WriteLine("Version: "+typeof(CPSManager).Assembly.GetName().Version.ToString());
            //DBAccess.GetInstance();
            InitializeComponent();
            codeplugStatusLabel.Alignment = ToolStripItemAlignment.Right;
            projectStatusLabel.Text = "No active project";
            codeplugStatusLabel.Text = "No codeplug imported";
            cp = new Codeplug();
        }

        private void exit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openCodeplug(object sender, EventArgs e)
        {
            if (project != null)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    byte[] data = System.IO.File.ReadAllBytes(openFileDialog1.FileName);
                    cp.RawData = data;
                    project.CodeplugName = openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf("\\")+1);
                    codeplugStatusLabel.Text = project.CodeplugName;
                    Console.WriteLine("Read " + data.Length + " bytes. OK.");
                }
            }
            else
            {
                MessageBox.Show(this, "Please open project first!");
            }
            
        }

        

        private void checkStateChanged(object sender, EventArgs e)
        {
            Debug.GetInstance().DebugOn = ((ToolStripMenuItem)sender).Checked;
        }

        

        

        private void saveCodeplugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Export codeplug
            if (MessageBox.Show(this, "You do this at your own risk!\nThe author of this software is not responsible for any damage to your hardware!") == DialogResult.OK)
            {
                if (saveFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    byte[] rawData = System.IO.File.ReadAllBytes(saveFileDialog2.FileName);
                    Array.Copy(cp.RawData, 0x061a5, rawData, 0x061a5, 0x2887f);
                    System.IO.File.WriteAllBytes(saveFileDialog2.FileName, rawData);
                }
            }
        }

        private void channelsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Import channels
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                //Export scanlists
                System.IO.File.WriteAllLines(openFileDialog2.FileName + "~tmp1", cp.AllScanLists.ToCSV(cp.AllChannels), Encoding.UTF8);
                //Export zones
                System.IO.File.WriteAllLines(openFileDialog2.FileName + "~tmp2", cp.AllZones.ToCSV(cp.AllChannels), Encoding.UTF8);
                //Import channels
                String[] csvData = System.IO.File.ReadAllLines(openFileDialog2.FileName, Encoding.UTF8);
                cp.AllChannels.FromCSV(csvData, cp.AllContacts, cp.AllRXGroups, cp.AllScanLists, cp.AllZones, false);
                //
                //Re-import zones and scanlist -> references may be updated
                //import scanLists
                csvData = System.IO.File.ReadAllLines(openFileDialog2.FileName + "~tmp1", Encoding.UTF8);
                cp.AllScanLists.FromCSV(csvData, cp.AllChannels, false);
                //import zones
                csvData = System.IO.File.ReadAllLines(openFileDialog2.FileName + "~tmp2", Encoding.UTF8);
                cp.AllZones.FromCSV(csvData, cp.AllChannels, false);
                //
                //Delete tmp files
                System.IO.File.Delete(openFileDialog2.FileName + "~tmp1");
                System.IO.File.Delete(openFileDialog2.FileName + "~tmp2");
            }
        }

        private void channelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Export channels
            if (project != null)
            {
                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllLines(openFileDialog2.FileName, cp.AllChannels.ToCSV(cp.AllContacts, cp.AllRXGroups, cp.AllScanLists, cp.AllZones, false), Encoding.UTF8);
                    //
                }
            }
            else
            {
                MessageBox.Show(this, "Please open project first!");
            }
        }

        private void zonesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Export zones
            if (project != null)
            {
                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllLines(openFileDialog2.FileName, cp.AllZones.ToCSV(cp.AllChannels), Encoding.UTF8);
                }
            }
            else
            {
                MessageBox.Show(this, "Please open project first!");
            }
        }

        private void scanListsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Export scanLists
            if (project != null)
            {
                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllLines(openFileDialog2.FileName, cp.AllScanLists.ToCSV(cp.AllChannels), Encoding.UTF8);
                }
            }
            else
            {
                MessageBox.Show(this, "Please open project first!");
            }
        }

        

        private void contactsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Export contacts
            if (project != null)
            {
                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllLines(openFileDialog2.FileName, cp.AllContacts.ToCSV(), Encoding.UTF8);
                }
            }
            else
            {
                MessageBox.Show(this, "Please open project first!");
            }
        }

        private void contactsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //import contacts
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                //export channels
                System.IO.File.WriteAllLines(openFileDialog2.FileName + "~tmp", cp.AllChannels.ToCSV(cp.AllContacts, cp.AllRXGroups, cp.AllScanLists, cp.AllZones, true), Encoding.UTF8);
                //import contacts
                String[] csvData = System.IO.File.ReadAllLines(openFileDialog2.FileName, Encoding.UTF8);
                cp.AllContacts.FromCSV(csvData, Debug.GetInstance().DebugOn);
                //re-import channels -> may be refernces will be updated
                csvData = System.IO.File.ReadAllLines(openFileDialog2.FileName + "~tmp", Encoding.UTF8);
                cp.AllChannels.FromCSV(csvData, cp.AllContacts, cp.AllRXGroups, cp.AllScanLists, cp.AllZones, true);
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

        private void openWorkingDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openProjectFileDialog.ShowDialog() == DialogResult.OK)
            {
                project = Project.ImportFromXML(openProjectFileDialog.FileName);
                projectStatusLabel.Text = project.ProjectPath;
                codeplugStatusLabel.Text = project.CodeplugName;
                importXMLData();
            }
            
        }
        private void exportXMLData()
        {
            cp.AllChannels.SaveToXML(project.ChannelPath);
            cp.AllContacts.SaveToXML(project.ContactPath);
            cp.AllScanLists.SaveToXML(project.ScanListPath);
            cp.AllZones.SaveToXML(project.ZonePath);
        }
        private void importXMLData()
        {
            cp.AllChannels.ReadFromXML(project.ChannelPath);
            cp.AllContacts.ReadFromXML(project.ContactPath);
            cp.AllScanLists.ReadFromXML(project.ScanListPath);
            cp.AllZones.ReadFromXML(project.ZonePath);
        }
        /*private void importFromCodeplugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Tools.IsEmpty(folderPath))
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    folderPath = folderBrowserDialog1.SelectedPath + "\\";
                    projectStatusLabel.Text = folderPath;
                }
            }

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                byte[] data = System.IO.File.ReadAllBytes(openFileDialog1.FileName);
                cp.RawData = data;
                Console.WriteLine("Read " + data.Length + " bytes. OK.");
            }
            exportXMLData();
        }*/

        private void createProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveProjectFileDialog.ShowDialog() == DialogResult.OK)
            {
                cp = new Codeplug();
                project = new Project();
                project.ProjectPath = saveProjectFileDialog.FileName;
                projectStatusLabel.Text = project.ProjectPath;
                String basePath = project.ProjectPath.Substring(0,project.ProjectPath.LastIndexOf("."));
                project.ChannelPath = basePath + XMLCHANNEL;
                project.ScanListPath = basePath + XMLSCANLIST;
                project.ZonePath = basePath + XMLZONE;
                project.ContactPath = basePath + XMLCONTACT;
                project.ExportToXML(project.ProjectPath);
                exportXMLData();

            }
            
        }

        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportXMLData();
            project.ExportToXML(project.ProjectPath);
        }

        

        
    }
}
