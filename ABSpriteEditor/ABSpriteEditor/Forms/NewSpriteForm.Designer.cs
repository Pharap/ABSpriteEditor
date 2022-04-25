namespace ABSpriteEditor.Forms
{
    partial class NewSpriteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewSpriteForm));
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.widthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.widthLabel = new System.Windows.Forms.Label();
            this.heightLabel = new System.Windows.Forms.Label();
            this.heightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.framesLabel = new System.Windows.Forms.Label();
            this.framesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.createButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.warningLabel = new System.Windows.Forms.Label();
            this.syncCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.widthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.framesNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.Location = new System.Drawing.Point(12, 27);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(238, 20);
            this.nameTextBox.TabIndex = 2;
            this.nameTextBox.Text = "Sprite";
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // nameLabel
            // 
            this.nameLabel.Location = new System.Drawing.Point(12, 9);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(238, 15);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Name";
            // 
            // widthNumericUpDown
            // 
            this.widthNumericUpDown.Location = new System.Drawing.Point(12, 68);
            this.widthNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.widthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.widthNumericUpDown.Name = "widthNumericUpDown";
            this.widthNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.widthNumericUpDown.TabIndex = 4;
            this.widthNumericUpDown.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.widthNumericUpDown.ValueChanged += new System.EventHandler(this.widthNumericUpDown_ValueChanged);
            // 
            // widthLabel
            // 
            this.widthLabel.Location = new System.Drawing.Point(12, 50);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(75, 15);
            this.widthLabel.TabIndex = 3;
            this.widthLabel.Text = "Width";
            // 
            // heightLabel
            // 
            this.heightLabel.Location = new System.Drawing.Point(93, 50);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(75, 15);
            this.heightLabel.TabIndex = 5;
            this.heightLabel.Text = "Height";
            // 
            // heightNumericUpDown
            // 
            this.heightNumericUpDown.Location = new System.Drawing.Point(93, 68);
            this.heightNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.heightNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.heightNumericUpDown.Name = "heightNumericUpDown";
            this.heightNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.heightNumericUpDown.TabIndex = 6;
            this.heightNumericUpDown.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.heightNumericUpDown.ValueChanged += new System.EventHandler(this.heightNumericUpDown_ValueChanged);
            // 
            // framesLabel
            // 
            this.framesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.framesLabel.Location = new System.Drawing.Point(174, 50);
            this.framesLabel.Name = "framesLabel";
            this.framesLabel.Size = new System.Drawing.Size(75, 15);
            this.framesLabel.TabIndex = 7;
            this.framesLabel.Text = "Frames";
            // 
            // framesNumericUpDown
            // 
            this.framesNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.framesNumericUpDown.Location = new System.Drawing.Point(174, 68);
            this.framesNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.framesNumericUpDown.Name = "framesNumericUpDown";
            this.framesNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.framesNumericUpDown.TabIndex = 12;
            this.framesNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.framesNumericUpDown.ValueChanged += new System.EventHandler(this.framesNumericUpDown_ValueChanged);
            // 
            // createButton
            // 
            this.createButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.createButton.Location = new System.Drawing.Point(12, 120);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 9;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(175, 120);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // warningLabel
            // 
            this.warningLabel.ForeColor = System.Drawing.Color.Red;
            this.warningLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.warningLabel.Location = new System.Drawing.Point(47, 9);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(202, 15);
            this.warningLabel.TabIndex = 11;
            this.warningLabel.Text = "Warning frameText goes here";
            this.warningLabel.Visible = false;
            // 
            // syncCheckBox
            // 
            this.syncCheckBox.Checked = true;
            this.syncCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.syncCheckBox.Location = new System.Drawing.Point(12, 94);
            this.syncCheckBox.Name = "syncCheckBox";
            this.syncCheckBox.Size = new System.Drawing.Size(237, 20);
            this.syncCheckBox.TabIndex = 13;
            this.syncCheckBox.Text = "Synchronise Dimensions";
            this.syncCheckBox.UseVisualStyleBackColor = true;
            // 
            // NewSpriteForm
            // 
            this.AcceptButton = this.createButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(259, 151);
            this.Controls.Add(this.syncCheckBox);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.widthLabel);
            this.Controls.Add(this.framesNumericUpDown);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.framesLabel);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.heightNumericUpDown);
            this.Controls.Add(this.heightLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.widthNumericUpDown);
            this.Controls.Add(this.nameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewSpriteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Sprite";
            ((System.ComponentModel.ISupportInitialize)(this.widthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.framesNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.NumericUpDown widthNumericUpDown;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.NumericUpDown heightNumericUpDown;
        private System.Windows.Forms.Label framesLabel;
        private System.Windows.Forms.NumericUpDown framesNumericUpDown;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label warningLabel;
        private System.Windows.Forms.CheckBox syncCheckBox;
    }
}