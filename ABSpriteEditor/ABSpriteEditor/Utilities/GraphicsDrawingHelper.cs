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

namespace ABSpriteEditor.Utilities
{
    public static class GraphicsDrawingHelper
    {
        public static void DrawScaledImage(Graphics graphics, Bitmap image, int x, int y, int scale)
        {
            DrawScaledImage(graphics, image, x, y, scale, scale);
        }

        public static void DrawScaledImage(Graphics graphics, Bitmap image, int x, int y, int xScale, int yScale)
        {
            // Iterate through the rows of the active image
            for (int row = 0; row < image.Height; ++row)
            {
                // Calculate the y draw coordinate for the current pixel
                var drawY = (y + (row * yScale));

                // Iterate through the columns of the active image
                for (int column = 0; column < image.Width; ++column)
                {
                    // Calculate the x draw coordinate for the current pixel
                    var drawX = (x + (column * xScale));

                    // Get the colour of the current pixel
                    var colour = image.GetPixel(column, row);

                    // If the colour has some degree of transparency
                    if (colour.A < byte.MaxValue)
                        // Don't draw anything
                        continue;

                    // Create a pen of the current pixel's colour
                    using (var brush = new SolidBrush(colour))
                        // Draw the pixel at the appropriate point and scale
                        graphics.FillRectangle(brush, drawX, drawY, xScale, yScale);
                }
            }
        }
    }
}
