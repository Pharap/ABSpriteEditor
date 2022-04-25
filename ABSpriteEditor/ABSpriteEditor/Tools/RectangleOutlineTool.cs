using System;
using System.Drawing;
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
    public class RectangleOutlineTool : ITool<BitmapEditorPanel>
    {
        // Half-transparent green
        private static readonly Color defaultColor = Color.FromArgb(127, 0, 255, 0);

        private BitmapEditorPanel control;
        private Color highlightColour = defaultColor;
        private Point? startPoint = null;
        private Point? endPoint = null;

        public Color HighlightColour
        {
            get { return this.highlightColour; }
            set { this.highlightColour = value; }
        }

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
            this.control.Paint += control_Paint;
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
            this.control.Paint -= control_Paint;

            // Clear the local control
            this.control = null;
        }

        private Rectangle CalculateOverlayAreaRectangle()
        {
            // Localise the start and end points
            var localStart = this.control.ToLocal(this.startPoint.Value);
            var localEnd = this.control.ToLocal(this.endPoint.Value);

            // Find the minimum and maximum points
            var minPoint = PointHelper.Min(localStart, localEnd);
            var maxPoint = PointHelper.Max(localStart, localEnd);

            // Calculate the upper limits
            var width = (this.control.Image.Width - 1);
            var height = (this.control.Image.Height - 1);

            // Clamp the relevant values
            var startX = PointHelper.Clamp(minPoint.X, 0, width);
            var startY = PointHelper.Clamp(minPoint.Y, 0, height);
            var endX = PointHelper.Clamp(maxPoint.X, 0, width);
            var endY = PointHelper.Clamp(maxPoint.Y, 0, height);

            // Globalise the points again
            var globalStartX = this.control.ToGlobalX(startX);
            var globalStartY = this.control.ToGlobalY(startY);
            var globalEndX = this.control.ToGlobalX(endX);
            var globalEndY = this.control.ToGlobalY(endY);

            // Create a rectangle identifying the area to fill
            return Rectangle.FromLTRB(globalStartX, globalStartY, globalEndX, globalEndY);
        }

        private void control_Paint(object sender, PaintEventArgs e)
        {
            // If both the start and end point have a value
            if (this.startPoint.HasValue && this.endPoint.HasValue)
            {
                // Calculate the overlayArea to highlight
                var overlayArea = this.CalculateOverlayAreaRectangle();

                // The amount needed to adjust the rectangle by
                var halfStep = (this.control.ImageScale / 2);

                // Adjust the rectangle to align it with the centre of the pixels
                overlayArea.Offset(halfStep, halfStep);

                // Create a pen from the highlight colour
                using (var pen = new Pen(this.HighlightColour, this.control.ImageScale))
                {
                    // Draw a rectangle over the selected overlay outlineArea
                    e.Graphics.DrawRectangle(pen, overlayArea);
                }
            }
        }

        private void control_MouseDown(object sender, MouseEventArgs e)
        {
            // If the left mouse button is used
            if (e.Button.HasFlag(MouseButtons.Left))
            {
                // If the control has no image to edit
                if (this.control.Image == null)
                    // Exit early
                    return;

                if (!this.startPoint.HasValue)
                {
                    // Begin editing
                    this.control.BeginEdit();

                    // Store the start point
                    this.startPoint = e.Location;

                    // Store the end point
                    this.endPoint = e.Location;

                    // Request a redraw
                    this.control.Invalidate();
                }
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

                // If the start point has been set
                if (this.startPoint.HasValue)
                {
                    // Set the end point
                    this.endPoint = e.Location;

                    // Request a redraw
                    this.control.Invalidate();
                }
            }
        }

        private Rectangle CalculateOutlineAreaRectangle()
        {
            // Localise the start and end points
            var localStart = this.control.ToLocal(this.startPoint.Value);
            var localEnd = this.control.ToLocal(this.endPoint.Value);

            // Find the minimum and maximum points
            var start = PointHelper.Min(localStart, localEnd);
            var end = PointHelper.Max(localStart, localEnd);

            // Calculate the upper limits
            var width = this.control.Image.Width;
            var height = this.control.Image.Height;

            // Clamp the relevant values
            var startX = PointHelper.Clamp(start.X, 0, width);
            var startY = PointHelper.Clamp(start.Y, 0, height);
            var endX = PointHelper.Clamp(end.X + 1, 0, width);
            var endY = PointHelper.Clamp(end.Y + 1, 0, height);

            // Create a rectangle identifying the area to fill
            return Rectangle.FromLTRB(startX, startY, endX, endY);
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

                // If the start and end points have been set
                if (this.startPoint.HasValue && this.endPoint.HasValue)
                {
                    // Create a rectangle identifying the area to outline
                    var outlineArea = this.CalculateOutlineAreaRectangle();

                    // Fill the rectangle
                    BitmapHelper.OutlineRectangle(this.control.Image, outlineArea, this.control.ForeColor);

                    // Nullify the start and end points
                    this.startPoint = null;
                    this.endPoint = null;

                    // End editing
                    this.control.EndEdit();

                    // Request a redraw
                    this.control.Invalidate();
                }
            }
        }
    }
}
