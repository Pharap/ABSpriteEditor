namespace ABSpriteEditor.Controls
{
    partial class ToolSelectPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolSelectPanel));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.pixelSetToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.floodFillToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.rectangleOutlineToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.rectangleFillToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.selectedToolBox = new System.Windows.Forms.PictureBox();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedToolBox)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pixelSetToolStripButton,
            this.floodFillToolStripButton,
            this.rectangleOutlineToolStripButton,
            this.rectangleFillToolStripButton});
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(48, 378);
            this.toolStrip.TabIndex = 0;
            // 
            // pixelSetToolStripButton
            // 
            this.pixelSetToolStripButton.BackColor = System.Drawing.Color.Transparent;
            this.pixelSetToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pixelSetToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pixelSetToolStripButton.Image")));
            this.pixelSetToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.pixelSetToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pixelSetToolStripButton.Name = "pixelSetToolStripButton";
            this.pixelSetToolStripButton.Size = new System.Drawing.Size(46, 36);
            this.pixelSetToolStripButton.Text = "Set Pixel";
            this.pixelSetToolStripButton.ToolTipText = "Set Pixel\r\nSets an individual pixel in the current image.";
            this.pixelSetToolStripButton.Click += new System.EventHandler(this.pixelSetToolStripButton_Click);
            // 
            // floodFillToolStripButton
            // 
            this.floodFillToolStripButton.BackColor = System.Drawing.Color.Transparent;
            this.floodFillToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.floodFillToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("floodFillToolStripButton.Image")));
            this.floodFillToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.floodFillToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.floodFillToolStripButton.Name = "floodFillToolStripButton";
            this.floodFillToolStripButton.Size = new System.Drawing.Size(46, 36);
            this.floodFillToolStripButton.Text = "Flood Fill";
            this.floodFillToolStripButton.ToolTipText = "Flood Fill\r\nFills an entire connected region in the current image.";
            this.floodFillToolStripButton.Click += new System.EventHandler(this.floodFillToolStripButton_Click);
            // 
            // rectangleOutlineToolStripButton
            // 
            this.rectangleOutlineToolStripButton.BackColor = System.Drawing.Color.Transparent;
            this.rectangleOutlineToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rectangleOutlineToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("rectangleOutlineToolStripButton.Image")));
            this.rectangleOutlineToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.rectangleOutlineToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rectangleOutlineToolStripButton.Name = "rectangleOutlineToolStripButton";
            this.rectangleOutlineToolStripButton.Size = new System.Drawing.Size(46, 36);
            this.rectangleOutlineToolStripButton.Text = "Rectangle Outline";
            this.rectangleOutlineToolStripButton.ToolTipText = "Rectangle Outline\r\nDraws the outline of a rectangle on the current image.";
            this.rectangleOutlineToolStripButton.Click += new System.EventHandler(this.rectangleOutlineToolStripButton_Click);
            // 
            // rectangleFillToolStripButton
            // 
            this.rectangleFillToolStripButton.BackColor = System.Drawing.Color.Transparent;
            this.rectangleFillToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rectangleFillToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("rectangleFillToolStripButton.Image")));
            this.rectangleFillToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.rectangleFillToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rectangleFillToolStripButton.Name = "rectangleFillToolStripButton";
            this.rectangleFillToolStripButton.Size = new System.Drawing.Size(46, 36);
            this.rectangleFillToolStripButton.Text = "Rectangle Fill";
            this.rectangleFillToolStripButton.ToolTipText = "Rectangle Fill\r\nFills a rectangle on the current image.";
            this.rectangleFillToolStripButton.Click += new System.EventHandler(this.rectangleFillToolStripButton_Click);
            // 
            // selectedToolBox
            // 
            this.selectedToolBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedToolBox.BackColor = System.Drawing.SystemColors.Control;
            this.selectedToolBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.selectedToolBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectedToolBox.Location = new System.Drawing.Point(4, 334);
            this.selectedToolBox.Margin = new System.Windows.Forms.Padding(4);
            this.selectedToolBox.Name = "selectedToolBox";
            this.selectedToolBox.Size = new System.Drawing.Size(40, 40);
            this.selectedToolBox.TabIndex = 6;
            this.selectedToolBox.TabStop = false;
            // 
            // ToolSelectPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.selectedToolBox);
            this.Controls.Add(this.toolStrip);
            this.Name = "ToolSelectPanel";
            this.Size = new System.Drawing.Size(48, 378);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedToolBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton pixelSetToolStripButton;
        private System.Windows.Forms.ToolStripButton floodFillToolStripButton;
        private System.Windows.Forms.ToolStripButton rectangleOutlineToolStripButton;
        private System.Windows.Forms.ToolStripButton rectangleFillToolStripButton;
        private System.Windows.Forms.PictureBox selectedToolBox;
    }
}
