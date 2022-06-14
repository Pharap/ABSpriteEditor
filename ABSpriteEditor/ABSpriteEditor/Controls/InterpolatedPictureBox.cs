using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ABSpriteEditor.Controls
{
    public class InterpolatedPictureBox : PictureBox
    {
        public InterpolationMode InterpolationMode { get; set; }

        public PixelOffsetMode PixelOffsetMode { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = this.InterpolationMode;
            e.Graphics.PixelOffsetMode = this.PixelOffsetMode;

            base.OnPaint(e);
        }
    }
}
