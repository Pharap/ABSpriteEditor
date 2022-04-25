using System.Drawing;

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

namespace ABSpriteEditor.Sprites
{
    internal static class SpriteHelper
    {
        public const int ArduboyMemoryLimit = (32 * 1024);

        public static int GetSpriteMemorySize(int width, int height, int frames)
        {
            return (GetFrameMemorySize(width, height) * frames);
        }

        public static int GetFrameMemorySize(int width, int height)
        {
            if ((height % 8) != 0)
                return GetFrameMemorySize(width, ((height & ~0x7) + 8));

            return ((width * height) / 8);
        }

        public static Bitmap CreateMonochromeTransparentCopy(Bitmap bitmap)
        {
            // Create a new bitmap with the same dimensions as the input
            var result = new Bitmap(bitmap.Width, bitmap.Height);

            // For each row of pixels
            for (int y = 0; y < bitmap.Height; ++y)
            {
                // For each column of pixels
                for (int x = 0; x < bitmap.Width; ++x)
                {
                    // Get the source pixel
                    var pixel = bitmap.GetPixel(x, y);

                    // Simplify the colour
                    var colour = SimplifyColour(pixel);

                    // Set the target pixel
                    result.SetPixel(x, y, colour);
                }
            }

            // Return the result
            return result;
        }

        private static Color SimplifyColour(Color colour)
        {
            if(colour.A < 255)
                return Color.Transparent;

            return (Average(colour) > 127) ? Color.White : Color.Black;
        }

        // A helper function for figuring out the average value of a pixel
        private static int Average(Color colour)
        {
            return ((colour.R + colour.G + colour.B) / 3);
        }
    }
}
