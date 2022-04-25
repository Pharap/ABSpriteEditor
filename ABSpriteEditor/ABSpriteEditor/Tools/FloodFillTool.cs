using System;
using System.Windows.Forms;
using ABSpriteEditor.Controls;
using ABSpriteEditor.Utilities;

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

namespace ABSpriteEditor.Tools
{
    public class FloodFillTool : ITool<BitmapEditorPanel>
    {
        private BitmapEditorPanel control;

        public void Attach(BitmapEditorPanel control)
        {
            if (control == null)
                throw new ArgumentNullException("spriteEditorPanel");

            if (this.control != null)
                throw new ArgumentException("This tool is already attached to a spriteEditorPanel");

            // Set the local control
            this.control = control;

            // Register mouse event handlers
            this.control.MouseDown += control_MouseDown;
            this.control.MouseUp += control_MouseUp;
        }

        public void Detach(BitmapEditorPanel control)
        {
            if (control == null)
                throw new ArgumentNullException("spriteEditorPanel");

            if (this.control != control)
                throw new ArgumentException("spriteEditorPanel is not the attached spriteEditorPanel");

            // Deregister mouse event handlers
            this.control.MouseDown -= control_MouseDown;
            this.control.MouseUp -= control_MouseUp;

            // Clear the local control
            this.control = null;
        }

        private void control_MouseDown(object sender, MouseEventArgs e)
        {
            // If the left mouse button is used
            if (e.Button.HasFlag(MouseButtons.Left))
            {
                if (this.control.Image == null)
                    return;

                // Begin editing
                this.control.BeginEdit();

                //// Change the mouse point to a local coordinate
                //var clientPoint = this.control.PointToClient(e.Location);

                // Convert the mouse position to a local coordinate
                var localPoint = this.control.ToLocal(e.Location);

                // If the x coordinate is out of bounds, exit early
                if ((localPoint.X < 0) || (localPoint.X >= this.control.Image.Width))
                    return;

                // If the y coordinate is out of bounds, exit early
                if ((localPoint.Y < 0) || (localPoint.Y >= this.control.Image.Width))
                    return;

                // Flood fill with the selected edit colour
                BitmapHelper.FloodFill(this.control.Image, localPoint, this.control.ForeColor);

                // Continue editing
                this.control.Edit();

                // Queue repaint
                this.control.Invalidate();
            }
        }

        private void control_MouseUp(object sender, MouseEventArgs e)
        {
            // If the left mouse button is used
            if (e.Button.HasFlag(MouseButtons.Left))
            {
                // If the control has no image to edit
                if (this.control.Image == null)
                    // Exit early
                    return;

                // End editing
                this.control.EndEdit();

                // Queue repaint
                this.control.Invalidate();
            }
        }
    }
}
