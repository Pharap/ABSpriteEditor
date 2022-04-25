using System;
using System.Windows.Forms;
using ABSpriteEditor.Tools;

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
    public partial class ToolSelectPanel : UserControl
    {
        private ITool<BitmapEditorPanel> tool;

        private readonly PixelSetTool pixelSetTool = new PixelSetTool();
        private readonly FloodFillTool floodFillTool = new FloodFillTool();
        private readonly RectangleFillTool rectangleFillTool = new RectangleFillTool();
        private readonly RectangleOutlineTool rectangleOutlineTool = new RectangleOutlineTool();

        public event EventHandler ToolChanged;

        public ToolSelectPanel()
        {
            InitializeComponent();
        }

        public ITool<BitmapEditorPanel> Tool
        {
            get { return this.tool; }
        }

        #region Methods

        #region Tool Select Functions

        public void SelectPixelSetTool()
        {
            // Set the tool
            this.ChangeTool(this.pixelSetTool);

            // Uncheck all tools
            this.UncheckAll(this.toolStrip);

            // Check the selected tool
            this.pixelSetToolStripButton.Checked = true;

            // Update the display box
            this.selectedToolBox.BackgroundImage = this.pixelSetToolStripButton.Image;
        }

        public void SelectFloodFillTool()
        {
            // Set the tool
            this.ChangeTool(this.floodFillTool);

            // Uncheck all tools
            this.UncheckAll(this.toolStrip);

            // Check the selected tool
            this.floodFillToolStripButton.Checked = true;

            // Update the display box
            this.selectedToolBox.BackgroundImage = this.floodFillToolStripButton.Image;
        }

        public void SelectRectangleOutlineTool()
        {
            // Set the tool
            this.ChangeTool(this.rectangleFillTool);

            // Uncheck all tools
            this.UncheckAll(this.toolStrip);

            // Check the selected tool
            this.rectangleOutlineToolStripButton.Checked = true;

            // Update the display box
            this.selectedToolBox.BackgroundImage = this.rectangleOutlineToolStripButton.Image;
        }

        public void SelectRectangleFillTool()
        {
            // Set the tool
            this.ChangeTool(this.rectangleOutlineTool);

            // Uncheck all tools
            this.UncheckAll(this.toolStrip);

            // Check the selected tool
            this.rectangleFillToolStripButton.Checked = true;

            // Update the display box
            this.selectedToolBox.BackgroundImage = this.rectangleFillToolStripButton.Image;
        }

        #endregion

        private void ChangeTool(ITool<BitmapEditorPanel> newTool)
        {
            // If the new tool is not the same as the old tool
            if (this.tool != newTool)
            {
                // Change the tool
                this.tool = newTool;

                // Raise the ToolChanged event
                this.OnToolChanged(EventArgs.Empty);
            }
        }

        private void OnToolChanged(EventArgs e)
        {
            // Cache the handler
            var handler = this.ToolChanged;

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

        private void pixelSetToolStripButton_Click(object sender, EventArgs e)
        {
            this.SelectPixelSetTool();
        }

        private void floodFillToolStripButton_Click(object sender, EventArgs e)
        {
            this.SelectFloodFillTool();
        }

        private void rectangleOutlineToolStripButton_Click(object sender, EventArgs e)
        {
            this.SelectRectangleOutlineTool();
        }

        private void rectangleFillToolStripButton_Click(object sender, EventArgs e)
        {
            this.SelectRectangleFillTool();
        }

        #endregion
    }
}
