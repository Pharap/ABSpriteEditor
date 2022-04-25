using System;
using System.Drawing;
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
    public class BitmapEditorPanel : Control
    {
        private Bitmap image = null;
        private int imageScale = 1;
        private Point imageOffset = Point.Empty;
        private bool gridVisible = false;
        private Color gridColour = Color.Gray;
        private ITool<BitmapEditorPanel> tool;

        public event EventHandler ImageChanged;
        public event EventHandler ImageScaleChanged;

        public event EventHandler ImageBeginEdit;
        public event EventHandler ImageEdit;
        public event EventHandler ImageEndEdit;

        public BitmapEditorPanel()
        {
            // Enable double buffering for better draw performance
            this.DoubleBuffered = true;
        }

        public ITool<BitmapEditorPanel> Tool
        {
            get { return this.tool; }
            set
            {
                // If the assigned tool is not the current tool
                if (this.tool != value)
                {
                    // If the current tool is not null
                    if (this.tool != null)
                        // Detatch it
                        this.tool.Detach(this);

                    // Assign the new tool as the current tool
                    this.tool = value;

                    // If the current tool is not null
                    if (this.tool != null)
                        // Attach it
                        this.tool.Attach(this);
                }
            }
        }

        public Bitmap Image
        {
            get { return this.image; }
            set
            {
                // If the assigned image is not the current image
                if (this.image != value)
                {
                    // Change the image
                    this.image = value;

                    // Raise ImageChanged event
                    this.OnImageChanged(EventArgs.Empty);

                    // Queue repaint
                    this.Invalidate();
                }
            }
        }

        public int ImageScale
        {
            get { return this.imageScale; }
            set
            {
                // If the value is less than 1
                if (value < 1)
                    // Throw an argument out of range exception
                    throw new ArgumentOutOfRangeException("ImageScale cannot be less than 1");

                // If the assigned valeu is not the same as the current value
                if (this.imageScale != value)
                {
                    // Change the current scale
                    this.ChangeScale(value);

                    // Raise the ImageScaleChanged event
                    this.OnImageScaleChanged(EventArgs.Empty);

                    // Queue repaint
                    this.Invalidate();
                }
            }
        }

        public Point ImageOffset
        {
            get { return this.imageOffset; }
            set
            {
                // If the assigned offset is not the current offset
                if (this.imageOffset != value)
                {
                    // Change the current offset
                    this.imageOffset = value;

                    // Queue repaint
                    this.Invalidate();
                }
            }
        }

        public bool GridVisible
        {
            get { return this.gridVisible; }
            set
            {
                // If the assigned value is not the current value
                if (this.gridVisible != value)
                {
                    // Change the grid's visibility
                    this.gridVisible = value;

                    // Queue repaint
                    this.Invalidate();
                }
            }
        }

        public Color GridColour
        {
            get { return this.gridColour; }
            set
            {
                // If the assigned value is not the current value
                if (this.gridColour != value)
                {
                    // Change the grid's colour
                    this.gridColour = value;

                    // Queue repaint
                    this.Invalidate();
                }
            }
        }

        public void CentreOffset()
        {
            // Calculate the scaled size of the image
            var width = (this.Image.Width * this.ImageScale);
            var height = (this.Image.Height * this.ImageScale);

            // Calculate the top left point of the screen
            var x = ((this.Width - width) / 2);
            var y = ((this.Height - height) / 2);

            // Set the draw offset
            this.ImageOffset = new Point(x, y);
        }

        // Set the scale as large as will go
        // whilst still fitting the image within the editor panel
        public void MaximiseScale()
        {
            var xScale = (this.Width / this.Image.Width);
            var yScale = (this.Height / this.Image.Height);

            this.ImageScale = Math.Min(xScale, yScale);
        }

        // Set the scale back to its minimum
        public void MinimiseScale()
        {
            this.ImageScale = 1;
        }

        public void IncreaseScale(int amount = 1)
        {
            this.ImageScale = (this.ImageScale + amount);
        }

        public void DecreaseScale(int amount = 1)
        {
            this.ImageScale = Math.Max((this.ImageScale - amount), 1);
        }

        private void ChangeScale(int newScale)
        {
            if (newScale < 1)
                throw new ArgumentOutOfRangeException("newScale must not be less than 1");

            var oldScale = this.imageScale;
            this.imageScale = newScale;

            if (this.Image == null)
                return;

            var oldWidth = (this.Image.Width * oldScale);
            var newWidth = (this.Image.Width * newScale);
            var widthDifference = (newWidth - oldWidth);

            var oldHeight = (this.Image.Height * oldScale);
            var newHeight = (this.Image.Height * newScale);
            var heightDifference = (newHeight - oldHeight);

            this.imageOffset.X -= (widthDifference / 2);
            this.imageOffset.Y -= (heightDifference / 2);
        }

        public int ToLocalX(int x)
        {
            return ((x - this.ImageOffset.X) / this.ImageScale);
        }

        public int ToLocalY(int y)
        {
            return ((y - this.ImageOffset.Y) / this.ImageScale);
        }

        public Point ToLocal(Point point)
        {
            return new Point(this.ToLocalX(point.X), this.ToLocalY(point.Y));
        }

        public int ToGlobalX(int x)
        {
            return (this.ImageOffset.X + (x * this.ImageScale));
        }

        public int ToGlobalY(int y)
        {
            return (this.ImageOffset.Y + (y * this.ImageScale));
        }

        public Point ToGlobal(Point point)
        {
            return new Point(this.ToGlobalX(point.X), this.ToGlobalY(point.Y));
        }

        public void BeginEdit()
        {
            this.OnImageBeginEdit(EventArgs.Empty);
        }

        public void Edit()
        {
            this.OnImageEdit(EventArgs.Empty);
        }

        public void EndEdit()
        {
            this.OnImageEndEdit(EventArgs.Empty);
        }

        #region Event Handlers

        protected virtual void OnImageBeginEdit(EventArgs e)
        {
            // Cache the handler
            var handler = this.ImageBeginEdit;

            // If the handler isn't null, call it
            if (handler != null)
                handler(this, e);
        }

        protected virtual void OnImageEdit(EventArgs e)
        {
            // Cache the handler
            var handler = this.ImageEdit;

            // If the handler isn't null, call it
            if (handler != null)
                handler(this, e);
        }

        protected virtual void OnImageEndEdit(EventArgs e)
        {
            // Cache the handler
            var handler = this.ImageEndEdit;

            // If the handler isn't null, call it
            if (handler != null)
                handler(this, e);
        }

        protected virtual void OnImageChanged(EventArgs e)
        {
            // Cache the handler
            var handler = this.ImageChanged;

            // If the handler isn't null, call it
            if (handler != null)
                handler(this, e);
        }

        protected virtual void OnImageScaleChanged(EventArgs e)
        {
            // Cache the handler
            var handler = this.ImageScaleChanged;

            // If the handler isn't null, call it
            if (handler != null)
                handler(this, e);
        }

        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            // Draw the image
            this.DrawImage(e.Graphics);

            // Draw the border
            this.DrawBorder(e.Graphics);

            // Raise the paint event
            base.OnPaint(e);
        }

        private void DrawImage(Graphics graphics)
        {
            // If there is no image to draw, exit early
            if (this.Image == null)
                return;

            // Prepare the grid pen for drawing the grid
            using (var gridPen = new Pen(this.GridColour))
            {
                // Iterate through the rows of the active image
                for (int row = 0; row < this.Image.Height; ++row)
                {
                    // Calculate the y draw coordinate for the current pixel
                    var drawY = this.ToGlobalY(row);

                    // Iterate through the columns of the active image
                    for (int column = 0; column < this.Image.Width; ++column)
                    {
                        // Calculate the x draw coordinate for the current pixel
                        var drawX = this.ToGlobalX(column);

                        // Get the colour of the current pixel
                        var colour = this.Image.GetPixel(column, row);

                        // If the colour has some degree of transparency
                        if (colour.A < byte.MaxValue)
                        {
                            var halfScale = (this.ImageScale / 2);

                            using(var lightBrush = new SolidBrush(Color.LightGray))
                            using (var darkBrush = new SolidBrush(Color.DarkGray))
                            {
                                graphics.FillRectangle(lightBrush, drawX, drawY, halfScale, halfScale);
                                graphics.FillRectangle(darkBrush, drawX + halfScale, drawY, halfScale, halfScale);
                                graphics.FillRectangle(darkBrush, drawX, drawY + halfScale, halfScale, halfScale);
                                graphics.FillRectangle(lightBrush, drawX + halfScale, drawY + halfScale, halfScale, halfScale);
                            }
                        }

                        // Create a pen of the current pixel's colour
                        using (var brush = new SolidBrush(colour))
                            // Draw the pixel at the appropriate point and scale
                            graphics.FillRectangle(brush, drawX, drawY, this.ImageScale, this.ImageScale);

                        // If the grid is visible and scale is greater than 1
                        if (this.GridVisible && (this.ImageScale > 1))
                            // Draw a grid tile on top of the regular pixel
                            graphics.DrawRectangle(gridPen, drawX, drawY, this.ImageScale, this.ImageScale);
                    }
                }
            }
        }

        private void DrawBorder(Graphics graphics)
        {
            var pen = (this.Focused ? SystemPens.ActiveBorder : SystemPens.InactiveBorder);
            var width = this.ClientRectangle.Width - 1;
            var height = this.ClientRectangle.Height - 1;

            graphics.DrawRectangle(pen, 0, 0, width, height);
        }

        private void DrawImageCentred(Graphics graphics)
        {
            if (this.Image == null)
                return;

            var halfWidth = (this.Image.Width / 2);
            var halfHeight = (this.Image.Height / 2);

            for (int row = 0; row < this.Image.Height; ++row)
            {
                var drawY = (this.ImageOffset.Y + ((row - halfWidth) * imageScale));

                for (int column = 0; column < this.Image.Width; ++column)
                {
                    var drawX = (this.ImageOffset.X + ((column - halfHeight) * imageScale));

                    var colour = this.image.GetPixel(column, row);

                    using (var brush = new SolidBrush(colour))
                        graphics.FillRectangle(brush, drawX, drawY, this.ImageScale, this.ImageScale);
                }
            }
        }

        private class OffsetDragState
        {
            public Point OffsetStart;
            public Point MouseStart;

            public Point GetNewOffset(Point mouseLocation)
            {
                var x = (this.OffsetStart.X + (mouseLocation.X - this.MouseStart.X));
                var y = (this.OffsetStart.Y + (mouseLocation.Y - this.MouseStart.Y));

                return new Point(x, y);
            }
        }

        private OffsetDragState middleMouseDragState = null;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button.HasFlag(MouseButtons.Middle))
            {
                // Begin a middle mouse drag operation
                this.middleMouseDragState = new OffsetDragState()
                {
                    OffsetStart = this.ImageOffset,
                    MouseStart = e.Location
                };
            }

            this.Focus();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Button.HasFlag(MouseButtons.Middle))
            {
                // If a middle mouse drag is under way
                if (this.middleMouseDragState != null)
                {
                    // Update the image's offset
                    this.ImageOffset = this.middleMouseDragState.GetNewOffset(e.Location);

                    // Queue repaint
                    this.Invalidate();
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            // If a middle mouse drag has occurred
            if (this.middleMouseDragState != null)
            {
                // Update the image's offset
                this.ImageOffset = this.middleMouseDragState.GetNewOffset(e.Location);

                // Queue repaint
                this.Invalidate();

                // End the drag sequence
                this.middleMouseDragState = null;
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (e.Delta != 0)
            {
                if (e.Delta < 0)
                    this.DecreaseScale();
                else
                    this.IncreaseScale();
            }
        }
    }
}
