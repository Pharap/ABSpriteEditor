namespace ABSpriteEditor.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param fileName="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeMultipleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeOthersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabContextMenuStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialogue = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialogue = new System.Windows.Forms.OpenFileDialog();
            this.exportFileDialogue = new System.Windows.Forms.SaveFileDialog();
            this.frameDimensionsStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.filePathStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.tabContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(784, 24);
            this.menuStrip.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.fileToolStripMenuSeparator1,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.fileToolStripMenuSeparator2,
            this.exportToolStripMenuItem,
            this.fileToolStripMenuSeparator3,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.NewIcon16;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.OpenIcon16;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // fileToolStripMenuSeparator1
            // 
            this.fileToolStripMenuSeparator1.Name = "fileToolStripMenuSeparator1";
            this.fileToolStripMenuSeparator1.Size = new System.Drawing.Size(180, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.SaveIcon16;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.SaveAsIcon16;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.saveAsToolStripMenuItem.Text = "SaveAs";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // fileToolStripMenuSeparator2
            // 
            this.fileToolStripMenuSeparator2.Name = "fileToolStripMenuSeparator2";
            this.fileToolStripMenuSeparator2.Size = new System.Drawing.Size(180, 6);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.ExportFileIcon16;
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // fileToolStripMenuSeparator3
            // 
            this.fileToolStripMenuSeparator3.Name = "fileToolStripMenuSeparator3";
            this.fileToolStripMenuSeparator3.Size = new System.Drawing.Size(180, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.CloseIcon16;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filePathStatusLabel,
            this.frameDimensionsStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 579);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(784, 22);
            this.statusStrip.TabIndex = 2;
            // 
            // tabControl
            // 
            this.tabControl.ContextMenuStrip = this.tabContextMenuStrip;
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(784, 555);
            this.tabControl.TabIndex = 1;
            this.tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl_Selected);
            this.tabControl.Deselected += new System.Windows.Forms.TabControlEventHandler(this.tabControl_Deselected);
            // 
            // tabContextMenuStrip
            // 
            this.tabContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeTabToolStripMenuItem,
            this.closeMultipleToolStripMenuItem,
            this.tabContextMenuStripSeparator,
            this.saveTabToolStripMenuItem,
            this.saveAsTabToolStripMenuItem});
            this.tabContextMenuStrip.Name = "tabContextMenuStrip";
            this.tabContextMenuStrip.Size = new System.Drawing.Size(151, 98);
            // 
            // closeTabToolStripMenuItem
            // 
            this.closeTabToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.CloseIcon16;
            this.closeTabToolStripMenuItem.Name = "closeTabToolStripMenuItem";
            this.closeTabToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.closeTabToolStripMenuItem.Text = "Close";
            this.closeTabToolStripMenuItem.Click += new System.EventHandler(this.closeTabToolStripMenuItem_Click);
            // 
            // closeMultipleToolStripMenuItem
            // 
            this.closeMultipleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeAllToolStripMenuItem,
            this.closeLeftToolStripMenuItem,
            this.closeRightToolStripMenuItem,
            this.closeOthersToolStripMenuItem});
            this.closeMultipleToolStripMenuItem.Name = "closeMultipleToolStripMenuItem";
            this.closeMultipleToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.closeMultipleToolStripMenuItem.Text = "Close &Multiple";
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.closeAllToolStripMenuItem.Text = "Close &All Tabs";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.closeAllToolStripMenuItem_Click);
            // 
            // closeLeftToolStripMenuItem
            // 
            this.closeLeftToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.CloseLeftIcon16;
            this.closeLeftToolStripMenuItem.Name = "closeLeftToolStripMenuItem";
            this.closeLeftToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.closeLeftToolStripMenuItem.Text = "Close Tabs to the &Left";
            this.closeLeftToolStripMenuItem.Click += new System.EventHandler(this.closeLeftToolStripMenuItem_Click);
            // 
            // closeRightToolStripMenuItem
            // 
            this.closeRightToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.CloseRightIcon16;
            this.closeRightToolStripMenuItem.Name = "closeRightToolStripMenuItem";
            this.closeRightToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.closeRightToolStripMenuItem.Text = "Close Tabs to the &Right";
            this.closeRightToolStripMenuItem.Click += new System.EventHandler(this.closeRightToolStripMenuItem_Click);
            // 
            // closeOthersToolStripMenuItem
            // 
            this.closeOthersToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.CloseOtherIcon16;
            this.closeOthersToolStripMenuItem.Name = "closeOthersToolStripMenuItem";
            this.closeOthersToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.closeOthersToolStripMenuItem.Text = "Close &Other Tabs";
            this.closeOthersToolStripMenuItem.Click += new System.EventHandler(this.closeOthersToolStripMenuItem_Click);
            // 
            // tabContextMenuStripSeparator
            // 
            this.tabContextMenuStripSeparator.Name = "tabContextMenuStripSeparator";
            this.tabContextMenuStripSeparator.Size = new System.Drawing.Size(147, 6);
            // 
            // saveTabToolStripMenuItem
            // 
            this.saveTabToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.SavedIcon16;
            this.saveTabToolStripMenuItem.Name = "saveTabToolStripMenuItem";
            this.saveTabToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.saveTabToolStripMenuItem.Text = "&Save";
            this.saveTabToolStripMenuItem.Click += new System.EventHandler(this.saveTabToolStripMenuItem_Click);
            // 
            // saveAsTabToolStripMenuItem
            // 
            this.saveAsTabToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.SaveAsIcon16;
            this.saveAsTabToolStripMenuItem.Name = "saveAsTabToolStripMenuItem";
            this.saveAsTabToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.saveAsTabToolStripMenuItem.Text = "Save &As";
            this.saveAsTabToolStripMenuItem.Click += new System.EventHandler(this.saveAsTabToolStripMenuItem_Click);
            // 
            // saveFileDialogue
            // 
            this.saveFileDialogue.Filter = "Xml Files|*.xml";
            // 
            // openFileDialogue
            // 
            this.openFileDialogue.Filter = "Xml Files|*.xml";
            this.openFileDialogue.Multiselect = true;
            // 
            // exportFileDialogue
            // 
            this.exportFileDialogue.Filter = "Header Files|*.h";
            // 
            // frameDimensionsStatusLabel
            // 
            this.frameDimensionsStatusLabel.Name = "frameDimensionsStatusLabel";
            this.frameDimensionsStatusLabel.Size = new System.Drawing.Size(72, 17);
            this.frameDimensionsStatusLabel.Text = "Dimensions:";
            // 
            // filePathStatusLabel
            // 
            this.filePathStatusLabel.Name = "filePathStatusLabel";
            this.filePathStatusLabel.Size = new System.Drawing.Size(666, 17);
            this.filePathStatusLabel.Spring = true;
            this.filePathStatusLabel.Text = "File:";
            this.filePathStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 601);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AB Sprite Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tabContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialogue;
        private System.Windows.Forms.OpenFileDialog openFileDialogue;
        private System.Windows.Forms.SaveFileDialog exportFileDialogue;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip tabContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem closeTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeMultipleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeLeftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeRightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeOthersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator fileToolStripMenuSeparator1;
        private System.Windows.Forms.ToolStripSeparator fileToolStripMenuSeparator2;
        private System.Windows.Forms.ToolStripSeparator fileToolStripMenuSeparator3;
        private System.Windows.Forms.ToolStripSeparator tabContextMenuStripSeparator;
        private System.Windows.Forms.ToolStripStatusLabel frameDimensionsStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel filePathStatusLabel;


    }
}

