using System;
using System.IO;
using System.Windows.Forms;

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
    public partial class LicenceEditForm : Form
    {
        public LicenceEditForm()
        {
            InitializeComponent();
        }

        public string LicenceText
        {
            get
            {
                // If the text box is empty
                if (string.IsNullOrWhiteSpace(this.licenceTextBox.Text))
                    // Return null
                    return null;

                // Otherwise, return the text box text
                return this.licenceTextBox.Text;
            }
            set
            {
                // Set the licence box's text
                this.licenceTextBox.Text = value;
            }
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            // Set the result to OK
            this.DialogResult = DialogResult.OK;
            
            // Close the form
            this.Close();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            // Show the user the open file dialogue
            var result = this.openFileDialogue.ShowDialog();

            // If the user cancelled
            if (result == DialogResult.Cancel)
                // Exit early
                return;

            // Read the licence from the file
            this.licenceTextBox.Text = File.ReadAllText(this.openFileDialogue.FileName);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Show the user the save file dialogue
            var result = this.saveFileDialogue.ShowDialog();

            // If the user cancelled
            if (result == DialogResult.Cancel)
                // Exit early
                return;

            // Save the licence text to the file
            File.WriteAllText(this.saveFileDialogue.FileName, this.licenceTextBox.Text);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            // Set the result to Cancel
            this.DialogResult = DialogResult.Cancel;

            // Close the form
            this.Close();
        }
    }
}
