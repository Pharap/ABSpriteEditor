using System;
using System.Drawing;
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

namespace ABSpriteEditor.Controls
{
    public partial class ColourSelectPanel : UserControl
    {
        private Color colour = Color.Black;

        public event EventHandler ColourChanged;

        public ColourSelectPanel()
        {
            InitializeComponent();
        }

        public Color Colour
        {
            get { return this.colour; }
        }

        #region Methods

        #region Colour Select Functions

        public void SelectBlack()
        {
            // Set the colour
            this.ChangeColour(Color.Black);

            // Uncheck all colours
            this.UncheckAll(this.colourToolStrip);

            // Check the selected colours
            this.blackToolStripButton.Checked = true;

            // Update the display box
            this.selectedColourBox.BackgroundImage = this.blackToolStripButton.Image;
        }

        public void SelectWhite()
        {
            // Set the colour
            this.ChangeColour(Color.White);

            // Uncheck all colours
            this.UncheckAll(this.colourToolStrip);

            // Check the selected colours
            this.whiteToolStripButton.Checked = true;

            // Update the display box
            this.selectedColourBox.BackgroundImage = this.whiteToolStripButton.Image;
        }

        public void SelectTransparent()
        {
            // Set the colour
            this.ChangeColour(Color.Transparent);

            // Uncheck all colours
            this.UncheckAll(this.colourToolStrip);

            // Check the selected colours
            this.transparentToolStripButton.Checked = true;

            // Update the display box
            this.selectedColourBox.BackgroundImage = this.transparentToolStripButton.Image;
        }

        #endregion

        private void ChangeColour(Color newColour)
        {
            // If the new colour is not the same as the old colour
            if (this.colour != newColour)
            {
                // Change the colour
                this.colour = newColour;

                // Raise the ColourChanged event
                this.OnColourChanged(EventArgs.Empty);
            }
        }

        private void OnColourChanged(EventArgs e)
        {
            // Cache the handler
            var handler = this.ColourChanged;

            // If the handler isn't null
            if (handler != null)
                // Call the handler
                handler(this, e);
        }

        private void UncheckAll(ToolStrip toolStrip)
        {
            // Iterate through all the items in the tool strip
            for (int index = 0; index < toolStrip.Items.Count; ++index)
            {
                // Get the item at the current index as a ToolStripButton
                var button = (toolStrip.Items[index] as ToolStripButton);

                // If the item was a ToolStripButton
                if (button != null)
                {
                    // Uncheck the button
                    button.Checked = false;
                }
            }
        }

        #endregion

        #region Event Handlers

        private void blackToolStripButton_Click(object sender, EventArgs e)
        {
            this.SelectBlack();
        }

        private void whiteToolStripButton_Click(object sender, EventArgs e)
        {
            this.SelectWhite();
        }

        private void transparentToolStripButton_Click(object sender, EventArgs e)
        {
            this.SelectTransparent();
        }

        #endregion
    }
}
