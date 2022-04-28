using System;
using System.Drawing;
using System.Windows.Forms;
using ABSpriteEditor.Controls;

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
    public class PixelSetTool : ITool<BitmapEditorPanel>
    {
        #if PIXEL_SET_HIGHLIGHT_SQUARE
        // Half-transparent green
        private static readonly Color defaultColor = Color.FromArgb(127, 0, 255, 0);
        #endif

        private BitmapEditorPanel control;

        #if PIXEL_SET_HIGHLIGHT_SQUARE
        private Color highlightColour = defaultColor;
        private Timer highlightTimer = new Timer();
        #endif

        #if PIXEL_SET_HIGHLIGHT_SQUARE
        public PixelSetTool()
        {
            // Run once every 10ms (i.e. every 0.01s)
            this.highlightTimer.Interval = 10;
        }
        #endif

        #if PIXEL_SET_HIGHLIGHT_SQUARE
        public Color HighlightColour
        {
            get { return this.highlightColour; }
            set { this.highlightColour = value; }
        }
        #endif

        public void Attach(BitmapEditorPanel control)
        {
            if (control == null)
                throw new ArgumentNullException("spriteEditorPanel");

            if (this.control != null)
                throw new ArgumentException("This tool is already attached to a spriteEditorPanel");

            // Set the local control
            this.control = control;

            // Register event handlers
            this.control.MouseDown += control_MouseDown;
            this.control.MouseMove += control_MouseMove;
            this.control.MouseUp += control_MouseUp;

            #if PIXEL_SET_HIGHLIGHT_SQUARE
            this.control.Paint += control_Paint;
            this.control.MouseEnter += control_MouseEnter;
            this.control.MouseLeave += control_MouseLeave;

            // Register the tick event
            this.highlightTimer.Tick += highlightTimer_Tick;
            #endif
        }

        public void Detach(BitmapEditorPanel control)
        {
            if (control == null)
                throw new ArgumentNullException("spriteEditorPanel");

            if (this.control != control)
                throw new ArgumentException("spriteEditorPanel is not the attached spriteEditorPanel");

            // Deregister event handlers
            this.control.MouseDown -= control_MouseDown;
            this.control.MouseMove -= control_MouseMove;
            this.control.MouseUp -= control_MouseUp;
            
            #if PIXEL_SET_HIGHLIGHT_SQUARE
            this.control.Paint -= control_Paint;
            this.control.MouseEnter -= control_MouseEnter;
            this.control.MouseLeave -= control_MouseLeave;

            // Stop the timer as a precaution
            this.highlightTimer.Stop();

            // Deegister the tick event
            this.highlightTimer.Tick -= highlightTimer_Tick;
            #endif

            // Clear the local control
            this.control = null;
        }
        
        #if PIXEL_SET_HIGHLIGHT_SQUARE
        void highlightTimer_Tick(object sender, EventArgs e)
        {
            // Invalidate the control each tick to ensure the highlight square is redrawn
            this.control.Invalidate();
        }

        void control_MouseLeave(object sender, EventArgs e)
        {
            // Stop the highlight timer
            this.highlightTimer.Stop();

            // Queue one last redraw to get rid of the highlight square
            this.control.Invalidate();
        }

        void control_MouseEnter(object sender, EventArgs e)
        {
            // Resume the highlight timer
            this.highlightTimer.Start();
        }

        private Rectangle CalculateOverlayAreaRectangle(Point position)
        {
            // Localise the start and end points
            var local = this.control.ToLocal(position);

            // Calculate the upper limits
            var width = (this.control.Image.Width - 1);
            var height = (this.control.Image.Height - 1);

            // Clamp the relevant values
            var startX = PointHelper.Clamp(local.X, 0, width);
            var startY = PointHelper.Clamp(local.Y, 0, height);

            // Globalise the points again
            var global = this.control.ToGlobal(new Point(startX, startY));

            // Create a rectangle identifying the area to fill
            return new Rectangle(global.X, global.Y, this.control.ImageScale, this.control.ImageScale);
        }

        private void control_Paint(object sender, PaintEventArgs e)
        {
            if (this.control.Image == null)
                return;

            var position = this.control.PointToClient(Control.MousePosition);

            if (!this.control.ClientRectangle.Contains(position))
                return;

            // Calculate the overlayArea to highlight
            var overlayArea = this.CalculateOverlayAreaRectangle(position);

            // Create a pen from the highlight colour
            using (var brush = new SolidBrush(this.HighlightColour))
            {
                // Draw a rectangle over the selected overlay outlineArea
                e.Graphics.FillRectangle(brush, overlayArea);
            }
        }
        #endif

        private void control_MouseDown(object sender, MouseEventArgs e)
        {
            // If the left mouse button is used
            if (e.Button.HasFlag(MouseButtons.Left))
            {
                // If the control has no image to edit
                if(this.control.Image == null)
                    // Exit early
                    return;

                // Begin editing
                this.control.BeginEdit();

                // Convert the mouse position to a local coordinate
                var localPoint = this.control.ToLocal(e.Location);

                // If the x coordinate is out of bounds, exit early
                if ((localPoint.X < 0) || (localPoint.X >= this.control.Image.Width))
                    return;

                // If the y coordinate is out of bounds, exit early
                if ((localPoint.Y < 0) || (localPoint.Y >= this.control.Image.Height))
                    return;

                // Set the target pixel to the selected edit colour
                this.control.Image.SetPixel(localPoint.X, localPoint.Y, this.control.ForeColor);

                // Continue editing
                this.control.Edit();

                // Queue repaint
                this.control.Invalidate();

                //// Temporarily stop the highlight timer
                //this.highlightTimer.Stop();
            }
        }

        private void control_MouseMove(object sender, MouseEventArgs e)
        {
            // If the left mouse button is used
            if (e.Button.HasFlag(MouseButtons.Left))
            {
                // If the control has no image to edit
                if (this.control.Image == null)
                    // Exit early
                    return;

                // Convert the mouse position to a local coordinate
                var localPoint = this.control.ToLocal(e.Location);

                // If the x coordinate is out of bounds, exit early
                if ((localPoint.X < 0) || (localPoint.X >= this.control.Image.Width))
                    return;

                // If the y coordinate is out of bounds, exit early
                if ((localPoint.Y < 0) || (localPoint.Y >= this.control.Image.Width))
                    return;

                // Set the target pixel to the selected edit colour
                this.control.Image.SetPixel(localPoint.X, localPoint.Y, this.control.ForeColor);

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

                #if PIXEL_SET_HIGHLIGHT_SQUARE
                // Resume the highlight timer
                this.highlightTimer.Start();
                #endif
            }
        }
    }
}
