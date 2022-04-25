using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public enum PaletteControlLayout
    {
        Dynamic,
        Vertical,
        Horizontal,

        DynamicGrid,
        VerticalGrid,
        HorizontalGrid,
    }

    public partial class PaletteControl : Control
    {
        private readonly ObservableCollection<Color> palette = new ObservableCollection<Color>();
        private PaletteControlLayout layout = PaletteControlLayout.DynamicGrid;
        private int selectedIndex = -1;

        public event EventHandler SelectedIndexChanged;
        public event EventHandler SelectedColourChanged;

        private readonly Color innerActive = Color.FromArgb(203, 228, 253);
        private readonly Color outerActive = Color.FromArgb(100, 165, 231);

        private readonly Color innerInactive = Color.FromArgb(255, 255, 255);
        private readonly Color outerInactive = Color.FromArgb(160, 160, 160);

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ObservableCollection<Color> Palette
        {
            get { return this.palette; }
        }

        public PaletteControlLayout PaletteLayout
        {
            get { return this.layout; }
            set
            {
                if (this.layout != value)
                {
                    this.layout = value;
                    this.Invalidate();
                }
            }
        }

        public int SelectedIndex
        {
            get { return this.selectedIndex; }
            set
            {
                // If the new index is not the same as the old index
                if (this.selectedIndex != value)
                {
                    // Change the index
                    this.selectedIndex = value;

                    // Raise the related events
                    this.OnSelectedIndexChanged(EventArgs.Empty);
                    this.OnSelectedColourChanged(EventArgs.Empty);

                    // Queue a repaint for the control
                    this.Invalidate();
                }
            }
        }

        public Color? SelectedColour
        {
            // If the selected index is -1, return null, else return the selected colour
            get { return (this.SelectedIndex == -1) ? null : (Color?)this.Palette[this.SelectedIndex]; }
        }

        protected virtual void OnSelectedIndexChanged(EventArgs e)
        {
            var handler = this.SelectedIndexChanged;

            if (handler != null)
                handler(this, e);
        }

        protected virtual void OnSelectedColourChanged(EventArgs e)
        {
            var handler = this.SelectedColourChanged;

            if (handler != null)
                handler(this, e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            this.PaintPalette(e.Graphics);
            //this.PaintBorder(e.Graphics);
        }

        private void PaintBorder(Graphics graphics)
        {
            var pen = (this.Focused ? SystemPens.ActiveBorder : SystemPens.InactiveBorder);
            var width = this.ClientRectangle.Width - 1;
            var height = this.ClientRectangle.Height - 1;

            graphics.DrawRectangle(pen, 0, 0, width, height);
        }

        private void PaintPalette(Graphics graphics)
        {
            if (this.Palette.Count == 0)
                return;

            switch (this.PaletteLayout)
            {
                case PaletteControlLayout.Dynamic:
                    this.PaintDynamic(graphics);
                    break;

                case PaletteControlLayout.Vertical:
                    this.PaintVertical(graphics);
                    break;

                case PaletteControlLayout.Horizontal:
                    this.PaintHorizontal(graphics);
                    break;

                case PaletteControlLayout.VerticalGrid:
                    this.PaintVerticalGrid(graphics);
                    break;

                case PaletteControlLayout.HorizontalGrid:
                    this.PaintHorizontalGrid(graphics);
                    break;

                case PaletteControlLayout.DynamicGrid:
                    this.PaintDynamicGrid(graphics);
                    break;
            }
        }

        private void PaintDynamic(Graphics graphics)
        {
            if (this.Width > this.Height)
                this.PaintHorizontal(graphics);
            else if (this.Height > this.Width)
                this.PaintVertical(graphics);
            else
                this.PaintDynamicGrid(graphics);
        }

        private void PaintVertical(Graphics graphics)
        {
            this.PaintVerticalLayoutGrid(graphics, new Size(1, this.Palette.Count));
        }

        private void PaintHorizontal(Graphics graphics)
        {
            this.PaintHorizontalLayoutGrid(graphics, new Size(this.Palette.Count, 1));
        }

        private void PaintDynamicGrid(Graphics graphics)
        {
            if (this.Height > this.Width)
                this.PaintVerticalGrid(graphics);
            else
                this.PaintHorizontalGrid(graphics);
        }

        private void PaintHorizontalGrid(Graphics graphics)
        {
            this.PaintHorizontalLayoutGrid(graphics, this.CalculateRowsAndColumnsForGrid());
        }

        private void PaintVerticalGrid(Graphics graphics)
        {
            this.PaintVerticalLayoutGrid(graphics, this.CalculateRowsAndColumnsForGrid());
        }

        private void PaintVerticalLayoutGrid(Graphics graphics, Size dimensions)
        {
            var tileWidth = (this.Width / dimensions.Width);
            var tileHeight = (this.Height / dimensions.Height);

            int index = 0;

            for (int x = 0; x < dimensions.Width; ++x)
            {
                // Calculate the x coordinate to draw at
                var drawX = (x * tileWidth);

                for (int y = 0; y < dimensions.Height; ++y)
                {
                    // Calculate the x coordinate to draw at
                    var drawY = (y * tileHeight);

                    // If the index would be beyond the number of palette entries, skip rendering
                    if (index >= this.Palette.Count)
                        break;

                    // Draw a tile for the palette entry
                    this.PaintTile(graphics, index, drawX, drawY, tileWidth - 1, tileHeight - 1);

                    ++index;
                }

                // If the index would be beyond the number of palette entries, skip rendering
                if (index >= this.Palette.Count)
                    break;
            }
        }

        private void PaintHorizontalLayoutGrid(Graphics graphics, Size dimensions)
        {
            var tileWidth = (this.Width / dimensions.Width);
            var tileHeight = (this.Height / dimensions.Height);

            int index = 0;

            for (int y = 0; y < dimensions.Height; ++y)
            {
                // Calculate the x coordinate to draw at
                var drawY = (y * tileHeight);

                for (int x = 0; x < dimensions.Width; ++x)
                {
                    // Calculate the x coordinate to draw at
                    var drawX = (x * tileWidth);

                    // If the index would be beyond the number of palette entries, skip rendering
                    if (index >= this.Palette.Count)
                        break;

                    // Draw a tile for the palette entry
                    this.PaintTile(graphics, index, drawX, drawY, tileWidth - 1, tileHeight - 1);

                    ++index;
                }

                // If the index would be beyond the number of palette entries, skip rendering
                if (index >= this.Palette.Count)
                    break;
            }
        }

        private void PaintTile(Graphics graphics, int index, int x, int y, int width, int height)
        {
            // Select the colour
            var colour = this.Palette[index];

            // Draw palette entry
            using (var brush = new SolidBrush(colour))
                graphics.FillRectangle(brush, x, y, width, height);

            // Draw selection highlight
            var outerColour = (index == this.SelectedIndex) ? outerActive : outerInactive;
            var innerColour = (index == this.SelectedIndex) ? innerActive : innerInactive;

            using (var pen = new Pen(outerColour))
                graphics.DrawRectangle(pen, x, y, width, height);

            using (var pen = new Pen(innerColour))
                graphics.DrawRectangle(pen, x + 1, y + 1, width - 2, height - 2);
        }

        private Size CalculateRowsAndColumnsForGrid()
        {
            return (this.Height > this.Width) ?
                this.CalculateRowsAndColumnsForTallGrid() :
                this.CalculateRowsAndColumnsForWideGrid();
        }

        private Size CalculateRowsAndColumnsForTallGrid()
        {
            var ratio = (this.Height / this.Width);

            var columns = (int)Math.Ceiling((double)this.Palette.Count / ratio);
            var rows = (int)Math.Ceiling((double)this.Palette.Count / columns);

            return new Size(columns, rows);
        }

        private Size CalculateRowsAndColumnsForWideGrid()
        {
            var ratio = (this.Width / this.Height);

            var rows = (int)Math.Ceiling((double)this.Palette.Count / ratio);
            var columns = (int)Math.Ceiling((double)this.Palette.Count / rows);

            return new Size(columns, rows);
        }

        private Size CalculateRowsAndColumns()
        {
            if (this.Palette.Count == 0)
                return new Size(1, 1);

            switch (this.PaletteLayout)
            {
                case PaletteControlLayout.Dynamic:
                    if (this.Width > this.Height)
                        return new Size(this.Palette.Count, 1);
                    else if (this.Height > this.Width)
                        return new Size(1, this.Palette.Count);
                    else
                        return this.CalculateRowsAndColumnsForGrid();

                case PaletteControlLayout.Vertical:
                    return new Size(1, this.Palette.Count);

                case PaletteControlLayout.Horizontal:
                    return new Size(this.Palette.Count, 1);

                case PaletteControlLayout.VerticalGrid:
                case PaletteControlLayout.HorizontalGrid:
                case PaletteControlLayout.DynamicGrid:
                    return this.CalculateRowsAndColumnsForGrid();

                default:
                    return new Size(1, 1);
            }
        }

        private Point ToLocal(Point position)
        {
            var dimensions = this.CalculateRowsAndColumns();

            return new Point(position.X / dimensions.Width, position.Y / dimensions.Height);
        }

        private Point ToGlobal(Point position)
        {
            var dimensions = this.CalculateRowsAndColumns();

            return new Point(position.X * dimensions.Width, position.Y * dimensions.Height);
        }

        public Color? GetColourAt(Point position)
        {
            var index = this.GetIndexAt(position);
            return (index < 0) ? null : (Color?)this.Palette[index];
        }

        public int GetIndexAt(Point position)
        {
            if (this.Palette.Count == 0)
                return -1;

            switch (this.PaletteLayout)
            {
                case PaletteControlLayout.Dynamic:
                    if (this.Width > this.Height)
                        return (position.X / (this.Width / this.Palette.Count));
                    else if (this.Height > this.Width)
                        return (position.Y / (this.Height / this.Palette.Count));
                    else
                        return this.GetIndexAtDynamicGrid(position);

                case PaletteControlLayout.Vertical:
                    return (position.Y / (this.Height / this.Palette.Count));

                case PaletteControlLayout.Horizontal:
                    return (position.X / (this.Width / this.Palette.Count));

                case PaletteControlLayout.VerticalGrid:
                    return this.GetIndexAtVerticalGrid(position);

                case PaletteControlLayout.HorizontalGrid:
                    return this.GetIndexAtHorizontalGrid(position);

                case PaletteControlLayout.DynamicGrid:
                    return this.GetIndexAtDynamicGrid(position);

                default:
                    return -1;
            }
        }

        private int GetIndexAtVerticalGrid(Point position)
        {
            var dimensions = this.CalculateRowsAndColumnsForGrid();

            var local = new Point(position.X / dimensions.Width, position.Y / dimensions.Height);

            return ((local.X * dimensions.Height) + local.Y);
        }

        private int GetIndexAtHorizontalGrid(Point position)
        {
            var dimensions = this.CalculateRowsAndColumnsForGrid();

            var local = new Point(position.X / dimensions.Width, position.Y / dimensions.Height);

            return ((local.Y * dimensions.Width) + local.X);
        }

        private int GetIndexAtDynamicGrid(Point position)
        {
            var dimensions = this.CalculateRowsAndColumnsForGrid();

            var local = new Point(position.X / dimensions.Width, position.Y / dimensions.Height);

            if (this.Height > this.Width)
                return ((local.X * dimensions.Height) + local.Y);
            else
                return ((local.Y * dimensions.Width) + local.X);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left)
            {
                this.SelectedIndex = this.GetIndexAt(e.Location);
            }
        }
    }
}
