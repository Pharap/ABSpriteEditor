namespace ABSpriteEditor.Forms
{
    partial class ExportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportForm));
            this.formatGroupBox = new System.Windows.Forms.GroupBox();
            this.compressedBitmapRadioButton = new System.Windows.Forms.RadioButton();
            this.uncompressedBitmapRadioButton = new System.Windows.Forms.RadioButton();
            this.spritesExternalMaskRadioButton = new System.Windows.Forms.RadioButton();
            this.spritesPlusMaskRadioButton = new System.Windows.Forms.RadioButton();
            this.spritesNoMaskRadioButton = new System.Windows.Forms.RadioButton();
            this.exportButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.licenceGroupBox = new System.Windows.Forms.GroupBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.licenceTextBox = new System.Windows.Forms.TextBox();
            this.openFileDialogue = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogue = new System.Windows.Forms.SaveFileDialog();
            this.formatGroupBox.SuspendLayout();
            this.licenceGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // formatGroupBox
            // 
            this.formatGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.formatGroupBox.Controls.Add(this.compressedBitmapRadioButton);
            this.formatGroupBox.Controls.Add(this.uncompressedBitmapRadioButton);
            this.formatGroupBox.Controls.Add(this.spritesExternalMaskRadioButton);
            this.formatGroupBox.Controls.Add(this.spritesPlusMaskRadioButton);
            this.formatGroupBox.Controls.Add(this.spritesNoMaskRadioButton);
            this.formatGroupBox.Location = new System.Drawing.Point(12, 12);
            this.formatGroupBox.Name = "formatGroupBox";
            this.formatGroupBox.Size = new System.Drawing.Size(152, 143);
            this.formatGroupBox.TabIndex = 0;
            this.formatGroupBox.TabStop = false;
            this.formatGroupBox.Text = "Format";
            // 
            // compressedBitmapRadioButton
            // 
            this.compressedBitmapRadioButton.AutoSize = true;
            this.compressedBitmapRadioButton.Location = new System.Drawing.Point(7, 112);
            this.compressedBitmapRadioButton.Name = "compressedBitmapRadioButton";
            this.compressedBitmapRadioButton.Size = new System.Drawing.Size(118, 17);
            this.compressedBitmapRadioButton.TabIndex = 4;
            this.compressedBitmapRadioButton.Text = "Compressed Bitmap";
            this.compressedBitmapRadioButton.UseVisualStyleBackColor = true;
            this.compressedBitmapRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // uncompressedBitmapRadioButton
            // 
            this.uncompressedBitmapRadioButton.AutoSize = true;
            this.uncompressedBitmapRadioButton.Location = new System.Drawing.Point(7, 89);
            this.uncompressedBitmapRadioButton.Name = "uncompressedBitmapRadioButton";
            this.uncompressedBitmapRadioButton.Size = new System.Drawing.Size(131, 17);
            this.uncompressedBitmapRadioButton.TabIndex = 3;
            this.uncompressedBitmapRadioButton.Text = "Uncompressed Bitmap";
            this.uncompressedBitmapRadioButton.UseVisualStyleBackColor = true;
            this.uncompressedBitmapRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // spritesExternalMaskRadioButton
            // 
            this.spritesExternalMaskRadioButton.AutoSize = true;
            this.spritesExternalMaskRadioButton.Location = new System.Drawing.Point(7, 66);
            this.spritesExternalMaskRadioButton.Name = "spritesExternalMaskRadioButton";
            this.spritesExternalMaskRadioButton.Size = new System.Drawing.Size(127, 17);
            this.spritesExternalMaskRadioButton.TabIndex = 2;
            this.spritesExternalMaskRadioButton.Text = "Sprites External Mask";
            this.spritesExternalMaskRadioButton.UseVisualStyleBackColor = true;
            this.spritesExternalMaskRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // spritesPlusMaskRadioButton
            // 
            this.spritesPlusMaskRadioButton.AutoSize = true;
            this.spritesPlusMaskRadioButton.Location = new System.Drawing.Point(7, 43);
            this.spritesPlusMaskRadioButton.Name = "spritesPlusMaskRadioButton";
            this.spritesPlusMaskRadioButton.Size = new System.Drawing.Size(109, 17);
            this.spritesPlusMaskRadioButton.TabIndex = 1;
            this.spritesPlusMaskRadioButton.Text = "Sprites Plus Mask";
            this.spritesPlusMaskRadioButton.UseVisualStyleBackColor = true;
            this.spritesPlusMaskRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // spritesNoMaskRadioButton
            // 
            this.spritesNoMaskRadioButton.AutoSize = true;
            this.spritesNoMaskRadioButton.Checked = true;
            this.spritesNoMaskRadioButton.Location = new System.Drawing.Point(7, 20);
            this.spritesNoMaskRadioButton.Name = "spritesNoMaskRadioButton";
            this.spritesNoMaskRadioButton.Size = new System.Drawing.Size(103, 17);
            this.spritesNoMaskRadioButton.TabIndex = 0;
            this.spritesNoMaskRadioButton.TabStop = true;
            this.spritesNoMaskRadioButton.Text = "Sprites No Mask";
            this.spritesNoMaskRadioButton.UseVisualStyleBackColor = true;
            this.spritesNoMaskRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // exportButton
            // 
            this.exportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exportButton.Location = new System.Drawing.Point(12, 367);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(75, 23);
            this.exportButton.TabIndex = 1;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(267, 367);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // licenceGroupBox
            // 
            this.licenceGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.licenceGroupBox.Controls.Add(this.saveButton);
            this.licenceGroupBox.Controls.Add(this.openButton);
            this.licenceGroupBox.Controls.Add(this.licenceTextBox);
            this.licenceGroupBox.Location = new System.Drawing.Point(12, 161);
            this.licenceGroupBox.Name = "licenceGroupBox";
            this.licenceGroupBox.Size = new System.Drawing.Size(330, 200);
            this.licenceGroupBox.TabIndex = 3;
            this.licenceGroupBox.TabStop = false;
            this.licenceGroupBox.Text = "Licence";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(249, 171);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(6, 171);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 2;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // licenceTextBox
            // 
            this.licenceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.licenceTextBox.Location = new System.Drawing.Point(6, 19);
            this.licenceTextBox.Multiline = true;
            this.licenceTextBox.Name = "licenceTextBox";
            this.licenceTextBox.Size = new System.Drawing.Size(318, 146);
            this.licenceTextBox.TabIndex = 1;
            // 
            // openFileDialogue
            // 
            this.openFileDialogue.DefaultExt = "*.txt";
            this.openFileDialogue.FileName = "Licence";
            this.openFileDialogue.Filter = "Text Files|*.txt|All Files|*.*";
            // 
            // saveFileDialogue
            // 
            this.saveFileDialogue.DefaultExt = "*.txt";
            this.saveFileDialogue.FileName = "Licence";
            this.saveFileDialogue.Filter = "Text Files|*.txt|All Files|*.*";
            // 
            // ExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(354, 402);
            this.Controls.Add(this.licenceGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.formatGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export";
            this.formatGroupBox.ResumeLayout(false);
            this.formatGroupBox.PerformLayout();
            this.licenceGroupBox.ResumeLayout(false);
            this.licenceGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox formatGroupBox;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.RadioButton compressedBitmapRadioButton;
        private System.Windows.Forms.RadioButton uncompressedBitmapRadioButton;
        private System.Windows.Forms.RadioButton spritesExternalMaskRadioButton;
        private System.Windows.Forms.RadioButton spritesPlusMaskRadioButton;
        private System.Windows.Forms.RadioButton spritesNoMaskRadioButton;
        private System.Windows.Forms.GroupBox licenceGroupBox;
        private System.Windows.Forms.TextBox licenceTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.OpenFileDialog openFileDialogue;
        private System.Windows.Forms.SaveFileDialog saveFileDialogue;
    }
}