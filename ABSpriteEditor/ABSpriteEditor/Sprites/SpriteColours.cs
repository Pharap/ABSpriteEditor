using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ABSpriteEditor.Sprites
{
    public static class SpriteColours
    {
        private static readonly Color black = Color.FromArgb(0xFF, 0x00, 0x00, 0x00);
        private static readonly Color white = Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF);
        private static readonly Color transparent = Color.FromArgb(0x00, 0x00, 0x00, 0x00);

        public static Color Black
        {
            get { return black; }
        }

        public static Color White
        {
            get { return white; }
        }

        public static Color Transparent
        {
            get { return transparent; }
        }
    }
}
