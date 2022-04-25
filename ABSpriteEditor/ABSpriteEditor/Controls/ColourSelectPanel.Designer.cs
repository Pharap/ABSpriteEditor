namespace ABSpriteEditor.Controls
{
    partial class ColourSelectPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColourSelectPanel));
            this.selectedColourBox = new System.Windows.Forms.PictureBox();
            this.colourToolStrip = new System.Windows.Forms.ToolStrip();
            this.blackToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.whiteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.transparentToolStripButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.selectedColourBox)).BeginInit();
            this.colourToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectedColourBox
            // 
            this.selectedColourBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedColourBox.BackColor = System.Drawing.SystemColors.Control;
            this.selectedColourBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.selectedColourBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectedColourBox.Location = new System.Drawing.Point(4, 334);
            this.selectedColourBox.Margin = new System.Windows.Forms.Padding(4);
            this.selectedColourBox.Name = "selectedColourBox";
            this.selectedColourBox.Size = new System.Drawing.Size(40, 40);
            this.selectedColourBox.TabIndex = 6;
            this.selectedColourBox.TabStop = false;
            // 
            // colourToolStrip
            // 
            this.colourToolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colourToolStrip.AutoSize = false;
            this.colourToolStrip.BackColor = System.Drawing.SystemColors.ControlLight;
            this.colourToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.colourToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.colourToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blackToolStripButton,
            this.whiteToolStripButton,
            this.transparentToolStripButton});
            this.colourToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.colourToolStrip.Location = new System.Drawing.Point(0, 0);
            this.colourToolStrip.Name = "colourToolStrip";
            this.colourToolStrip.Size = new System.Drawing.Size(48, 378);
            this.colourToolStrip.TabIndex = 0;
            // 
            // blackToolStripButton
            // 
            this.blackToolStripButton.BackColor = System.Drawing.Color.Transparent;
            this.blackToolStripButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.blackToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.blackToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("blackToolStripButton.Image")));
            this.blackToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.blackToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.blackToolStripButton.Name = "blackToolStripButton";
            this.blackToolStripButton.Size = new System.Drawing.Size(46, 36);
            this.blackToolStripButton.Text = "Black";
            this.blackToolStripButton.Click += new System.EventHandler(this.blackToolStripButton_Click);
            // 
            // whiteToolStripButton
            // 
            this.whiteToolStripButton.BackColor = System.Drawing.Color.Transparent;
            this.whiteToolStripButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.whiteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.whiteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("whiteToolStripButton.Image")));
            this.whiteToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.whiteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.whiteToolStripButton.Name = "whiteToolStripButton";
            this.whiteToolStripButton.Size = new System.Drawing.Size(46, 36);
            this.whiteToolStripButton.Text = "White";
            this.whiteToolStripButton.Click += new System.EventHandler(this.whiteToolStripButton_Click);
            // 
            // transparentToolStripButton
            // 
            this.transparentToolStripButton.BackColor = System.Drawing.Color.Transparent;
            this.transparentToolStripButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.transparentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.transparentToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("transparentToolStripButton.Image")));
            this.transparentToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.transparentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.transparentToolStripButton.Name = "transparentToolStripButton";
            this.transparentToolStripButton.Size = new System.Drawing.Size(46, 36);
            this.transparentToolStripButton.Text = "Transparent";
            this.transparentToolStripButton.Click += new System.EventHandler(this.transparentToolStripButton_Click);
            // 
            // ColourSelectPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.selectedColourBox);
            this.Controls.Add(this.colourToolStrip);
            this.Name = "ColourSelectPanel";
            this.Size = new System.Drawing.Size(48, 378);
            ((System.ComponentModel.ISupportInitialize)(this.selectedColourBox)).EndInit();
            this.colourToolStrip.ResumeLayout(false);
            this.colourToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox selectedColourBox;
        private System.Windows.Forms.ToolStrip colourToolStrip;
        private System.Windows.Forms.ToolStripButton blackToolStripButton;
        private System.Windows.Forms.ToolStripButton whiteToolStripButton;
        private System.Windows.Forms.ToolStripButton transparentToolStripButton;
    }
}
