namespace BetterCPS
{
    partial class BetterCPS
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
            this.openCodeplugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCodeplugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.channelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zonesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanListsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.channelsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.idOutLabel = new System.Windows.Forms.Label();
            this.nameOutLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.contactsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.zonesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.scanListsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(795, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            // openCodeplugToolStripMenuItem
            // 
            this.openCodeplugToolStripMenuItem.Name = "openCodeplugToolStripMenuItem";
            this.openCodeplugToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.openCodeplugToolStripMenuItem.Text = "Open Codeplug";
            this.openCodeplugToolStripMenuItem.Click += new System.EventHandler(this.openCodeplug);
            // 
            // saveCodeplugToolStripMenuItem
            // 
            this.saveCodeplugToolStripMenuItem.Name = "saveCodeplugToolStripMenuItem";
            this.saveCodeplugToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.saveCodeplugToolStripMenuItem.Text = "Save Codeplug";
            this.saveCodeplugToolStripMenuItem.Click += new System.EventHandler(this.saveCodeplugToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(155, 6);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.channelsToolStripMenuItem,
            this.contactsToolStripMenuItem,
            this.zonesToolStripMenuItem,
            this.scanListsToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // channelsToolStripMenuItem
            // 
            this.channelsToolStripMenuItem.Name = "channelsToolStripMenuItem";
            this.channelsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.channelsToolStripMenuItem.Text = "Channels";
            this.channelsToolStripMenuItem.Click += new System.EventHandler(this.channelsToolStripMenuItem_Click);
            // 
            // zonesToolStripMenuItem
            // 
            this.zonesToolStripMenuItem.Name = "zonesToolStripMenuItem";
            this.zonesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.zonesToolStripMenuItem.Text = "Zones";
            this.zonesToolStripMenuItem.Click += new System.EventHandler(this.zonesToolStripMenuItem_Click);
            // 
            // scanListsToolStripMenuItem
            // 
            this.scanListsToolStripMenuItem.Name = "scanListsToolStripMenuItem";
            this.scanListsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
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
            this.importToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // channelsToolStripMenuItem1
            // 
            this.channelsToolStripMenuItem1.Name = "channelsToolStripMenuItem1";
            this.channelsToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.channelsToolStripMenuItem1.Text = "Channels";
            this.channelsToolStripMenuItem1.Click += new System.EventHandler(this.channelsToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(155, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
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
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.debugToolStripMenuItem.Text = "Debug";
            this.debugToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.checkStateChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "*.rdt";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "csv";
            this.saveFileDialog1.FileName = "*.csv";
            this.saveFileDialog1.Filter = "CSV-File|*.csv";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(30, 60);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(214, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(264, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = "Get ID for GUID";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID:";
            // 
            // idOutLabel
            // 
            this.idOutLabel.AutoSize = true;
            this.idOutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idOutLabel.Location = new System.Drawing.Point(54, 101);
            this.idOutLabel.Name = "idOutLabel";
            this.idOutLabel.Size = new System.Drawing.Size(0, 13);
            this.idOutLabel.TabIndex = 4;
            // 
            // nameOutLabel
            // 
            this.nameOutLabel.AutoSize = true;
            this.nameOutLabel.Location = new System.Drawing.Point(89, 134);
            this.nameOutLabel.Name = "nameOutLabel";
            this.nameOutLabel.Size = new System.Drawing.Size(0, 13);
            this.nameOutLabel.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Name:";
            // 
            // contactsToolStripMenuItem
            // 
            this.contactsToolStripMenuItem.Name = "contactsToolStripMenuItem";
            this.contactsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.contactsToolStripMenuItem.Text = "Contacts";
            this.contactsToolStripMenuItem.Click += new System.EventHandler(this.contactsToolStripMenuItem_Click);
            // 
            // contactsToolStripMenuItem1
            // 
            this.contactsToolStripMenuItem1.Name = "contactsToolStripMenuItem1";
            this.contactsToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.contactsToolStripMenuItem1.Text = "Contacts";
            this.contactsToolStripMenuItem1.Click += new System.EventHandler(this.contactsToolStripMenuItem1_Click);
            // 
            // zonesToolStripMenuItem1
            // 
            this.zonesToolStripMenuItem1.Name = "zonesToolStripMenuItem1";
            this.zonesToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.zonesToolStripMenuItem1.Text = "Zones";
            this.zonesToolStripMenuItem1.Click += new System.EventHandler(this.zonesToolStripMenuItem1_Click);
            // 
            // scanListsToolStripMenuItem1
            // 
            this.scanListsToolStripMenuItem1.Name = "scanListsToolStripMenuItem1";
            this.scanListsToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.scanListsToolStripMenuItem1.Text = "ScanLists";
            this.scanListsToolStripMenuItem1.Click += new System.EventHandler(this.scanListsToolStripMenuItem1_Click);
            // 
            // BetterCPS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 496);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nameOutLabel);
            this.Controls.Add(this.idOutLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "BetterCPS";
            this.Text = "BetterCPS";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label idOutLabel;
        private System.Windows.Forms.Label nameOutLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem contactsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem zonesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem scanListsToolStripMenuItem1;
    }
}

