namespace BetterCPS
{
    partial class CPSManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.createProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openWorkingDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.openCodeplugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCodeplugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.channelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zonesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanListsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.channelsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contactsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.zonesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.scanListsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.projectStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.openProjectFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveProjectFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.codeplugStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(795, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createProjectToolStripMenuItem,
            this.saveProjectToolStripMenuItem,
            this.openWorkingDirectoryToolStripMenuItem,
            this.toolStripMenuItem4,
            this.openCodeplugToolStripMenuItem,
            this.saveCodeplugToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exportToolStripMenuItem,
            this.importToolStripMenuItem,
            this.toolStripMenuItem3,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // createProjectToolStripMenuItem
            // 
            this.createProjectToolStripMenuItem.Name = "createProjectToolStripMenuItem";
            this.createProjectToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.createProjectToolStripMenuItem.Text = "Create Project";
            this.createProjectToolStripMenuItem.Click += new System.EventHandler(this.createProjectToolStripMenuItem_Click);
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.saveProjectToolStripMenuItem.Text = "SaveProject";
            this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.saveProjectToolStripMenuItem_Click);
            // 
            // openWorkingDirectoryToolStripMenuItem
            // 
            this.openWorkingDirectoryToolStripMenuItem.Name = "openWorkingDirectoryToolStripMenuItem";
            this.openWorkingDirectoryToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.openWorkingDirectoryToolStripMenuItem.Text = "Open Project";
            this.openWorkingDirectoryToolStripMenuItem.Click += new System.EventHandler(this.openWorkingDirectoryToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(191, 6);
            // 
            // openCodeplugToolStripMenuItem
            // 
            this.openCodeplugToolStripMenuItem.Name = "openCodeplugToolStripMenuItem";
            this.openCodeplugToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.openCodeplugToolStripMenuItem.Text = "Import from Codeplug";
            this.openCodeplugToolStripMenuItem.Click += new System.EventHandler(this.openCodeplug);
            // 
            // saveCodeplugToolStripMenuItem
            // 
            this.saveCodeplugToolStripMenuItem.Name = "saveCodeplugToolStripMenuItem";
            this.saveCodeplugToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.saveCodeplugToolStripMenuItem.Text = "Export to Codeplug";
            this.saveCodeplugToolStripMenuItem.Click += new System.EventHandler(this.saveCodeplugToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(191, 6);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.channelsToolStripMenuItem,
            this.contactsToolStripMenuItem,
            this.zonesToolStripMenuItem,
            this.scanListsToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // channelsToolStripMenuItem
            // 
            this.channelsToolStripMenuItem.Name = "channelsToolStripMenuItem";
            this.channelsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.channelsToolStripMenuItem.Text = "Channels";
            this.channelsToolStripMenuItem.Click += new System.EventHandler(this.channelsToolStripMenuItem_Click);
            // 
            // contactsToolStripMenuItem
            // 
            this.contactsToolStripMenuItem.Name = "contactsToolStripMenuItem";
            this.contactsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.contactsToolStripMenuItem.Text = "Contacts";
            this.contactsToolStripMenuItem.Click += new System.EventHandler(this.contactsToolStripMenuItem_Click);
            // 
            // zonesToolStripMenuItem
            // 
            this.zonesToolStripMenuItem.Name = "zonesToolStripMenuItem";
            this.zonesToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.zonesToolStripMenuItem.Text = "Zones";
            this.zonesToolStripMenuItem.Click += new System.EventHandler(this.zonesToolStripMenuItem_Click);
            // 
            // scanListsToolStripMenuItem
            // 
            this.scanListsToolStripMenuItem.Name = "scanListsToolStripMenuItem";
            this.scanListsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.scanListsToolStripMenuItem.Text = "ScanLists";
            this.scanListsToolStripMenuItem.Click += new System.EventHandler(this.scanListsToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.channelsToolStripMenuItem1,
            this.contactsToolStripMenuItem1,
            this.zonesToolStripMenuItem1,
            this.scanListsToolStripMenuItem1});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // channelsToolStripMenuItem1
            // 
            this.channelsToolStripMenuItem1.Name = "channelsToolStripMenuItem1";
            this.channelsToolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
            this.channelsToolStripMenuItem1.Text = "Channels";
            this.channelsToolStripMenuItem1.Click += new System.EventHandler(this.channelsToolStripMenuItem1_Click);
            // 
            // contactsToolStripMenuItem1
            // 
            this.contactsToolStripMenuItem1.Name = "contactsToolStripMenuItem1";
            this.contactsToolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
            this.contactsToolStripMenuItem1.Text = "Contacts";
            this.contactsToolStripMenuItem1.Click += new System.EventHandler(this.contactsToolStripMenuItem1_Click);
            // 
            // zonesToolStripMenuItem1
            // 
            this.zonesToolStripMenuItem1.Name = "zonesToolStripMenuItem1";
            this.zonesToolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
            this.zonesToolStripMenuItem1.Text = "Zones";
            this.zonesToolStripMenuItem1.Click += new System.EventHandler(this.zonesToolStripMenuItem1_Click);
            // 
            // scanListsToolStripMenuItem1
            // 
            this.scanListsToolStripMenuItem1.Name = "scanListsToolStripMenuItem1";
            this.scanListsToolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
            this.scanListsToolStripMenuItem1.Text = "ScanLists";
            this.scanListsToolStripMenuItem1.Click += new System.EventHandler(this.scanListsToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(191, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exit);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.debugToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.CheckOnClick = true;
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.debugToolStripMenuItem.Text = "Debug";
            this.debugToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.checkStateChanged);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "*.rdt";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "csv";
            this.saveFileDialog1.FileName = "*.csv";
            this.saveFileDialog1.Filter = "CSV-File|*.csv";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "*.csv";
            this.openFileDialog2.Filter = "CSV Files|*.cvs";
            this.openFileDialog2.Title = "Import CSV Data";
            // 
            // saveFileDialog2
            // 
            this.saveFileDialog2.FileName = "*.rdt";
            this.saveFileDialog2.Filter = "Codeplug|*.rdt";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectStatusLabel,
            this.codeplugStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 472);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(795, 24);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // projectStatusLabel
            // 
            this.projectStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.projectStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.projectStatusLabel.Name = "projectStatusLabel";
            this.projectStatusLabel.Size = new System.Drawing.Size(627, 19);
            this.projectStatusLabel.Spring = true;
            this.projectStatusLabel.Text = "toolStripStatusLabel1";
            this.projectStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // openProjectFileDialog
            // 
            this.openProjectFileDialog.FileName = "*.cps";
            this.openProjectFileDialog.Filter = "CPS Project|*.cps";
            // 
            // saveProjectFileDialog
            // 
            this.saveProjectFileDialog.DefaultExt = "cps";
            this.saveProjectFileDialog.FileName = "*.cps";
            this.saveProjectFileDialog.Filter = "CPS Project|*.cps";
            // 
            // codeplugStatusLabel
            // 
            this.codeplugStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.codeplugStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.codeplugStatusLabel.Name = "codeplugStatusLabel";
            this.codeplugStatusLabel.Size = new System.Drawing.Size(122, 19);
            this.codeplugStatusLabel.Text = "toolStripStatusLabel1";
            this.codeplugStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CPSManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 496);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CPSManager";
            this.Text = "CPS-Manager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openCodeplugToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem channelsToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem saveCodeplugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem channelsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.ToolStripMenuItem zonesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanListsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem zonesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem scanListsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel projectStatusLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem openWorkingDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openProjectFileDialog;
        private System.Windows.Forms.SaveFileDialog saveProjectFileDialog;
        private System.Windows.Forms.ToolStripStatusLabel codeplugStatusLabel;
    }
}

