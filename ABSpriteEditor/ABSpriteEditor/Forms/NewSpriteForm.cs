using System;
using System.Windows.Forms;
using ABSpriteEditor.Sprites;

//
//  Copyright (C) 2022 Pharap (@Pharap)
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

namespace ABSpriteEditor.Forms
{
    public partial class NewSpriteForm : Form
    {
        private SpriteCreationInfo spriteCreationInfo = null;

        public NewSpriteForm()
        {
            InitializeComponent();
        }

        #region Properties

        public SpriteCreationInfo SpriteCreationInfo
        {
            get { return this.spriteCreationInfo; }
        }

        #endregion

        #region Methods

        private bool DoMemoryCheck(int width, int height, int frames)
        {
            // Calculate the amount of memory the sprite will use
            var memory = SpriteHelper.GetSpriteMemorySize(width, height, frames);

            // If the memory usage would be within the Arduboy's flash limit
            if (memory < SpriteHelper.ArduboyMemoryLimit)
                // Report success
                return true;

            // Warn the user about the memory usage
            var result = WarningsHelper.ShowMemoryUsageWarning(memory, SpriteHelper.ArduboyMemoryLimit);

            // If the user opts to cancel the creation of the sprite
            if (result == DialogResult.Cancel)
                // Report failure
                return false;

            // Report success
            return true;
        }

        private bool DoNameCheck(string name, out Identifier identifier)
        {
            // If the name is already a valid identifier
            if (Identifier.IsValidIdentifier(name))
            {
                // Create and assign the identifier
                identifier = Identifier.Create(name);
            }
            // Otherwise, if the identifier is not already valid
            else
            {
                // Either convert the identifier to something suitable or use the name "Sprite" as the default
                identifier = (Identifier.CanCreateIdentifierFrom(name) ? Identifier.Create(name) : Identifier.Create("Sprite"));

                // Warn the user about the name change
                var result = WarningsHelper.ShowInvalidSpriteNameChangedWarning(identifier);

                // If the user cancelled
                if (result == DialogResult.Cancel)
                    // Report failure
                    return false;
            }

            // Report success
            return true;
        }

        #endregion

        #region Event Handlers

        private void createButton_Click(object sender, EventArgs e)
        {
            // Cast all the numeric box values
            var width = (int)this.widthNumericUpDown.Value;
            var height = (int)this.heightNumericUpDown.Value;
            var frames = (int)this.framesNumericUpDown.Value;

            // Do a memory check, and if it fails...
            if (!this.DoMemoryCheck(width, height, frames))
                // Exit the function
                return;

            // Prepare an identifier to hold the name
            Identifier identifier = null;

            // Do a name check on the name in the text box, and if it fails...
            if (!this.DoNameCheck(this.nameTextBox.Text, out identifier))
                // Exit the function
                return;

            // With the last piece of info, the sprite creation info can be created
            this.spriteCreationInfo = new SpriteCreationInfo()
            {
                Width = width,
                Height = height,
                Frames = frames,
                Name = identifier,
            };

            // Set the dialogue result to 'OK'
            this.DialogResult = DialogResult.OK;

            // Close the form
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            // Set the dialogue result to 'Cancel'
            this.DialogResult = DialogResult.Cancel;

            // Close the form
            this.Close();
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            // If the text isn't a valid identifier
            if (!Identifier.IsValidIdentifier(this.nameTextBox.Text))
            {
                // Display a warning
                this.warningLabel.Text = Properties.ErrorStrings.InvalidSpriteName;
                this.warningLabel.Visible = true;

                // Exit the function
                return;
            }

            // Otherwise, no issues were found, so hide the warning label
            this.warningLabel.Visible = false;
        }

        private void widthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // If the sync box is checked
            if (this.syncCheckBox.Checked)
                // Synchronise the height box to the width box's value
                this.heightNumericUpDown.Value = this.widthNumericUpDown.Value;
        }

        private void heightNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // If the sync box is checked
            if (this.syncCheckBox.Checked)
                // Synchronise the width box to the height box's value
                this.widthNumericUpDown.Value = this.heightNumericUpDown.Value;
        }

        private void framesNumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
