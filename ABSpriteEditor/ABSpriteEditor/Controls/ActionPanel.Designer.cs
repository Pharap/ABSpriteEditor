namespace ABSpriteEditor.Controls
{
    partial class ActionPanel
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
            this.actionStrip = new System.Windows.Forms.ToolStrip();
            this.horizontalFlipToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.flipVerticallyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.rotateLeftToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.rotateRightToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.actionStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // actionStrip
            // 
            this.actionStrip.AutoSize = false;
            this.actionStrip.BackColor = System.Drawing.SystemColors.ControlLight;
            this.actionStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.actionStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.horizontalFlipToolStripButton,
            this.flipVerticallyToolStripButton,
            this.rotateLeftToolStripButton,
            this.rotateRightToolStripButton});
            this.actionStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.actionStrip.Location = new System.Drawing.Point(0, 0);
            this.actionStrip.Name = "actionStrip";
            this.actionStrip.Size = new System.Drawing.Size(382, 48);
            this.actionStrip.TabIndex = 1;
            // 
            // horizontalFlipToolStripButton
            // 
            this.horizontalFlipToolStripButton.BackColor = System.Drawing.Color.Transparent;
            this.horizontalFlipToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.horizontalFlipToolStripButton.Image = global::ABSpriteEditor.Properties.Resources.HorizontalFlipIcon32;
            this.horizontalFlipToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.horizontalFlipToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.horizontalFlipToolStripButton.Name = "horizontalFlipToolStripButton";
            this.horizontalFlipToolStripButton.Size = new System.Drawing.Size(36, 45);
            this.horizontalFlipToolStripButton.Text = "Flip Horizontally";
            this.horizontalFlipToolStripButton.ToolTipText = "Flip Horizontally\r\nFlips the frame horizontally around the Y axis.";
            this.horizontalFlipToolStripButton.Click += new System.EventHandler(this.flipHorizontallyToolStripButton_Click);
            // 
            // flipVerticallyToolStripButton
            // 
            this.flipVerticallyToolStripButton.BackColor = System.Drawing.Color.Transparent;
            this.flipVerticallyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.flipVerticallyToolStripButton.Image = global::ABSpriteEditor.Properties.Resources.VerticalFlipIcon32;
            this.flipVerticallyToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.flipVerticallyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.flipVerticallyToolStripButton.Name = "flipVerticallyToolStripButton";
            this.flipVerticallyToolStripButton.Size = new System.Drawing.Size(36, 45);
            this.flipVerticallyToolStripButton.Text = "Flip Vertically";
            this.flipVerticallyToolStripButton.ToolTipText = "Flip Vertically\r\nFlips the frame vertically around the X axis.";
            this.flipVerticallyToolStripButton.Click += new System.EventHandler(this.flipVerticallyToolStripButton_Click);
            // 
            // rotateLeftToolStripButton
            // 
            this.rotateLeftToolStripButton.BackColor = System.Drawing.Color.Transparent;
            this.rotateLeftToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rotateLeftToolStripButton.Image = global::ABSpriteEditor.Properties.Resources.RotateLeftIcon32;
            this.rotateLeftToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.rotateLeftToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rotateLeftToolStripButton.Name = "rotateLeftToolStripButton";
            this.rotateLeftToolStripButton.Size = new System.Drawing.Size(36, 45);
            this.rotateLeftToolStripButton.Text = "Rotate Left";
            this.rotateLeftToolStripButton.ToolTipText = "Rotate Left\r\nRotates the image anticlockwise 90 degrees.";
            // 
            // rotateRightToolStripButton
            // 
            this.rotateRightToolStripButton.BackColor = System.Drawing.Color.Transparent;
            this.rotateRightToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rotateRightToolStripButton.Image = global::ABSpriteEditor.Properties.Resources.RotateRightIcon32;
            this.rotateRightToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.rotateRightToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rotateRightToolStripButton.Name = "rotateRightToolStripButton";
            this.rotateRightToolStripButton.Size = new System.Drawing.Size(36, 45);
            this.rotateRightToolStripButton.Text = "Rotate Right";
            this.rotateRightToolStripButton.ToolTipText = "Rotate Right\r\nRotates the image clockwise 90 degrees.";
            // 
            // ActionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.actionStrip);
            this.Name = "ActionPanel";
            this.Size = new System.Drawing.Size(382, 48);
            this.actionStrip.ResumeLayout(false);
            this.actionStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip actionStrip;
        private System.Windows.Forms.ToolStripButton horizontalFlipToolStripButton;
        private System.Windows.Forms.ToolStripButton flipVerticallyToolStripButton;
        private System.Windows.Forms.ToolStripButton rotateLeftToolStripButton;
        private System.Windows.Forms.ToolStripButton rotateRightToolStripButton;
    }
}
