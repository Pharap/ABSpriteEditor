using System;
using System.Collections.Generic;
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
    public static class BitmapHelper
    {
        #region Nudge

        public static void NudgeUp(Bitmap bitmap)
        {
            // Precalculate the first y coordinate
            var firstY = 0;

            // Precalculate the last y coordinate
            var lastY = (bitmap.Height - 1);

            // For each row from the first to the last,
            // but not including the last itself
            for (int y = firstY; y < lastY; ++y)
                // For each pixel in the row
                for (int x = 0; x < bitmap.Width; ++x)
                {
                    // Read the pixel from the row below
                    var pixel = bitmap.GetPixel(x, y + 1);

                    // Write the pixel into the row above
                    bitmap.SetPixel(x, y, pixel);
                }
        }

        public static void NudgeDown(Bitmap bitmap)
        {
            // Precalculate the first y coordinate
            var firstY = 0;

            // Precalculate the last y coordinate
            var lastY = (bitmap.Height - 1);

            // For each row from the last to first,
            // but not including the first itself
            for (int y = lastY; y > firstY; --y)
                // For each pixel in the row
                for (int x = 0; x < bitmap.Width; ++x)
                {
                    // Read the pixel from the row above
                    var pixel = bitmap.GetPixel(x, y - 1);

                    // Write the pixel into the row below
                    bitmap.SetPixel(x, y, pixel);
                }
        }

        public static void NudgeLeft(Bitmap bitmap)
        {
            // Precalculate the first x coordinate
            var firstX = 0;

            // Precalculate the last x coordinate
            var lastX = (bitmap.Width - 1);

            // For each column from the first to the last,
            // but not including the last itself
            for (int x = firstX; x < lastX; ++x)
                // For each pixel in the column
                for (int y = 0; y < bitmap.Height; ++y)
                {
                    // Read the pixel from the right hand column
                    var pixel = bitmap.GetPixel(x + 1, y);

                    // Write the pixel into the left hand column
                    bitmap.SetPixel(x, y, pixel);
                }
        }

        public static void NudgeRight(Bitmap bitmap)
        {
            // Precalculate the first x coordinate
            var firstX = 0;

            // Precalculate the last x coordinate
            var lastX = (bitmap.Width - 1);

            // For each column from the last to first,
            // but not including the first itself
            for (int x = lastX; x > firstX; --x)
                // For each pixel in the column
                for (int y = 0; y < bitmap.Height; ++y)
                {
                    // Read the pixel from the left hand column
                    var pixel = bitmap.GetPixel(x - 1, y);

                    // Write the pixel into the right hand column
                    bitmap.SetPixel(x, y, pixel);
                }
        }

        #endregion

        #region Roll (Arbitrary)

        public static void RollUp(Bitmap bitmap, int amount)
        {
            // If the amount is greater than or equal to the bitmap's height
            if (amount > bitmap.Height)
                // Reduce the amount to the remainder after division by height
                // thus making amount the minimum number of rolls required
                amount %= bitmap.Height;

            // If the amount is zero
            if (amount == 0)
                // Exit without doing anything
                return;

            // If the amount is 1
            if (amount == 1)
            {
                // Defer to the more optimal version
                RollUp(bitmap);

                // Exit
                return;
            }

            // Precalculate the first y coordinate
            var firstY = 0;

            // Precalculate the last y coordinate
            var lastY = (bitmap.Height - 1);

            // A buffer for a whole block of colour
            var blockBuffer = new Color[amount, bitmap.Width];

            // Copy the data into the buffer
            for (int y = 0; y < amount; ++y)
                for (int x = 0; x < bitmap.Width; ++x)
                    blockBuffer[y, x] = bitmap.GetPixel(x, firstY + y);

            // For each row from the first to the last,
            // but not including the last itself
            for (int y = firstY; y < lastY; ++y)
                // For each pixel in the row
                for (int x = 0; x < bitmap.Width; ++x)
                {
                    // Read the pixel from the row below
                    var pixel = bitmap.GetPixel(x, (y + amount) % bitmap.Height);

                    // Write the pixel into the row above
                    bitmap.SetPixel(x, y, pixel);
                }

            // Calculate the start position for copying buffer data back into the image
            var bufferDesinationStartY = (bitmap.Height - amount);

            // Copy the contents of the buffer into the destination area
            for (int y = 0; y < amount; ++y)
                for (int x = 0; x < bitmap.Width; ++x)
                    bitmap.SetPixel(x, bufferDesinationStartY + y, blockBuffer[y, x]);
        }

        public static void RollDown(Bitmap bitmap, int amount)
        {
            // If the amount is greater than or equal to the bitmap's height
            if (amount > bitmap.Height)
                // Reduce the amount to the remainder after division by height
                // thus making amount the minimum number of rolls required
                amount %= bitmap.Height;

            // If the amount is zero
            if (amount == 0)
                // Exit without doing anything
                return;

            // If the amount is 1
            if (amount == 1)
            {
                // Defer to the more optimal version
                RollDown(bitmap);

                // Exit
                return;
            }

            // Abuse the fact that rolling down n steps
            // is equivalent to rolling up (height - n) steps
            // which avoids some potentially nasty calculations
            RollUp(bitmap, bitmap.Height - amount);
        }

        public static void RollLeft(Bitmap bitmap, int amount)
        {
            // If the amount is greater than or equal to the bitmap's height
            if (amount > bitmap.Width)
                // Reduce the amount to the remainder after division by height
                // thus making amount the minimum number of rolls required
                amount %= bitmap.Width;

            // If the amount is zero
            if (amount == 0)
                // Exit without doing anything
                return;

            // If the amount is 1
            if (amount == 1)
            {
                // Defer to the more optimal version
                RollLeft(bitmap);

                // Exit
                return;
            }

            // Precalculate the first x coordinate
            var firstX = 0;

            // Precalculate the last x coordinate
            var lastX = (bitmap.Width - 1);

            // A buffer for a whole block of colour
            var blockBuffer = new Color[amount, bitmap.Height];

            // Copy the data into the buffer
            for (int x = 0; x < amount; ++x)
                for (int y = 0; y < bitmap.Height; ++y)
                    blockBuffer[x, y] = bitmap.GetPixel(firstX + x, y);

            // For each column from the first to the last,
            // but not including the last itself
            for (int x = firstX; x < lastX; ++x)
                // For each pixel in the column
                for (int y = 0; y < bitmap.Height; ++y)
                {
                    // Read the pixel from the column below
                    var pixel = bitmap.GetPixel((x + amount) % bitmap.Width, y);

                    // Write the pixel into the column above
                    bitmap.SetPixel(x, y, pixel);
                }

            // Calculate the start position for copying buffer data back into the image
            var bufferDesinationStartX = (bitmap.Width - amount);

            // Copy the contents of the buffer into the destination area
            for (int x = 0; x < amount; ++x)
                for (int y = 0; y < bitmap.Height; ++y)
                    bitmap.SetPixel(bufferDesinationStartX + x, y, blockBuffer[x, y]);
        }

        public static void RollRight(Bitmap bitmap, int amount)
        {
            // If the amount is greater than or equal to the bitmap's height
            if (amount > bitmap.Width)
                // Reduce the amount to the remainder after division by height
                // thus making amount the minimum number of rolls required
                amount %= bitmap.Width;

            // If the amount is zero
            if (amount == 0)
                // Exit without doing anything
                return;

            // If the amount is 1
            if (amount == 1)
            {
                // Defer to the more optimal version
                RollRight(bitmap);

                // Exit
                return;
            }

            // Abuse the fact that rolling right n steps
            // is equivalent to rolling left (height - n) steps
            // which avoids some potentially nasty calculations
            RollLeft(bitmap, bitmap.Height - amount);
        }

        #endregion

        #region Roll (Single)

        public static void RollUp(Bitmap bitmap)
        {
            // Precalculate the first y coordinate
            var firstY = 0;

            // Precalculate the last y coordinate
            var lastY = (bitmap.Height - 1);

            // A buffer for a whole row of colour
            var rowBuffer = new Color[bitmap.Width];

            // Copy the first row into the row buffer
            for (int x = 0; x < bitmap.Width; ++x)
                rowBuffer[x] = bitmap.GetPixel(x, firstY);

            // For each row from the first to the last,
            // but not including the last itself
            for (int y = firstY; y < lastY; ++y)
                // For each pixel in the row
                for (int x = 0; x < bitmap.Width; ++x)
                {
                    // Read the pixel from the row below
                    var pixel = bitmap.GetPixel(x, y + 1);

                    // Write the pixel into the row above
                    bitmap.SetPixel(x, y, pixel);
                }

            // Copy the contents of the buffer into the last row
            for (int x = 0; x < bitmap.Width; ++x)
                bitmap.SetPixel(x, lastY, rowBuffer[x]);
        }

        public static void RollDown(Bitmap bitmap)
        {
            // Precalculate the first y coordinate
            var firstY = 0;

            // Precalculate the last y coordinate
            var lastY = (bitmap.Height - 1);

            // A buffer for a whole row of colour
            var rowBuffer = new Color[bitmap.Width];
            
            // Copy the last row into the row buffer
            for (int x = 0; x < bitmap.Width; ++x)
                rowBuffer[x] = bitmap.GetPixel(x, lastY);

            // For each row from the last to first,
            // but not including the first itself
            for (int y = lastY; y > firstY; --y)
                // For each pixel in the row
                for (int x = 0; x < bitmap.Width; ++x)
                {
                    // Read the pixel from the row above
                    var pixel = bitmap.GetPixel(x, y - 1);

                    // Write the pixel into the row below
                    bitmap.SetPixel(x, y, pixel);
                }

            // Copy the contents of the buffer into the first row
            for (int x = 0; x < bitmap.Width; ++x)
                bitmap.SetPixel(x, firstY, rowBuffer[x]);
        }

        public static void RollLeft(Bitmap bitmap)
        {
            // Precalculate the first x coordinate
            var firstX = 0;

            // Precalculate the last x coordinate
            var lastX = (bitmap.Width - 1);

            // A buffer for a whole column of colour
            var columnBuffer = new Color[bitmap.Height];

            // Copy the first column into the column buffer
            for (int y = 0; y < bitmap.Height; ++y)
                columnBuffer[y] = bitmap.GetPixel(firstX, y);

            // For each column from the first to the last,
            // but not including the last itself
            for (int x = firstX; x < lastX; ++x)
                // For each pixel in the column
                for (int y = 0; y < bitmap.Height; ++y)
                {
                    // Read the pixel from the right hand column
                    var pixel = bitmap.GetPixel(x + 1, y);

                    // Write the pixel into the left hand column
                    bitmap.SetPixel(x, y, pixel);
                }

            // Copy the contents of the buffer into the last column
            for (int y = 0; y < bitmap.Height; ++y)
                bitmap.SetPixel(lastX, y, columnBuffer[y]);
        }

        public static void RollRight(Bitmap bitmap)
        {
            // Precalculate the first x coordinate
            var firstX = 0;

            // Precalculate the last x coordinate
            var lastX = (bitmap.Width - 1);

            // A buffer for a whole column of colour
            var columnBuffer = new Color[bitmap.Height];
            
            // Copy the last column into the column buffer
            for (int y = 0; y < bitmap.Height; ++y)
                columnBuffer[y] = bitmap.GetPixel(lastX, y);

            // For each column from the last to first,
            // but not including the first itself
            for (int x = lastX; x > firstX; --x)
                // For each pixel in the column
                for (int y = 0; y < bitmap.Height; ++y)
                {
                    // Read the pixel from the left hand column
                    var pixel = bitmap.GetPixel(x - 1, y);

                    // Write the pixel into the right hand column
                    bitmap.SetPixel(x, y, pixel);
                }

            // Copy the contents of the buffer into the first column
            for (int y = 0; y < bitmap.Height; ++y)
                bitmap.SetPixel(firstX, y, columnBuffer[y]);
        }

        #endregion

        #region Rotation

        public static void RotateRight(Bitmap bitmap)
        {
            throw new NotImplementedException("RotateRight is not currently implemented");
        }

        public static void RotateLeft(Bitmap bitmap)
        {
            throw new NotImplementedException("RotateLeft is not currently implemented");
        }

        #endregion

        #region Flipping

        public static void FlipHorizontally(Bitmap bitmap)
        {
            // Precalculate half the width
            var halfWidth = (bitmap.Width / 2);

            // Precalculate the last x coordinate
            var lastX = (bitmap.Width - 1);

            // For each row
            for (int y = 0; y < bitmap.Height; ++y)
            {
                // Iterate x up to half way
                for (int x = 0; x < halfWidth; ++x)
                {
                    // Calculate the coordinates at each end
                    var leftX = x;
                    var rightX = (lastX - x);

                    // Read the pixels at each end
                    var leftPixel = bitmap.GetPixel(leftX, y);
                    var rightPixel = bitmap.GetPixel(rightX, y);

                    // Swap the pixels over
                    bitmap.SetPixel(rightX, y, leftPixel);
                    bitmap.SetPixel(leftX, y, rightPixel);
                }
            }
        }

        public static void FlipVertically(Bitmap bitmap)
        {
            // Precalculate half the height
            var halfHeight = (bitmap.Height / 2);

            // Precalculate the last y coordinate
            var lastY = (bitmap.Height - 1);

            // For each column
            for (int x = 0; x < bitmap.Width; ++x)
            {
                // Iterate y up to half way
                for (int y = 0; y < halfHeight; ++y)
                {
                    // Calculate the coordinates at each end
                    var topY = y;
                    var BottomY = (lastY - y);

                    // Read the pixels at each end
                    var topPixel = bitmap.GetPixel(x, topY);
                    var BottomPixel = bitmap.GetPixel(x, BottomY);

                    // Swap the pixels over
                    bitmap.SetPixel(x, BottomY, topPixel);
                    bitmap.SetPixel(x, topY, BottomPixel);
                }
            }
        }

        #endregion

        #region Line Drawing

        public static void DrawVerticalLine(Bitmap bitmap, Point point, int height, Color fillColour)
        {
            // Draw a vertical line of tiles
            for (int y = 0; y < height; ++y)
            {
                // Caclulate the y draw coordinate
                var drawY = (point.Y + y);

                // Set the target pixel
                bitmap.SetPixel(point.X, drawY, fillColour);
            }
        }

        public static void DrawHorizontalLine(Bitmap bitmap, Point point, int width, Color fillColour)
        {
            // Draw a horizontal line of tiles
            for (int x = 0; x < width; ++x)
            {
                // Caclulate the x draw coordinate
                var drawX = (point.X + x);

                // Set the target pixel
                bitmap.SetPixel(drawX, point.Y, fillColour);
            }
        }

        #endregion

        #region Rectangle Drawing

        public static void FillRectangle(Bitmap bitmap, Rectangle area, Color fillColour)
        {
            // Set the tiles in a rectangular pattern
            for (int y = 0; y < area.Height; ++y)
            {
                // Caclulate the y draw coordinate
                var drawY = (area.Y + y);

                for (int x = 0; x < area.Width; ++x)
                {
                    // Caclulate the x draw coordinate
                    var drawX = (area.X + x);

                    // Set the target pixel
                    bitmap.SetPixel(drawX, drawY, fillColour);
                }
            }
        }

        public static void OutlineRectangle(Bitmap bitmap, Rectangle area, Color fillColour)
        {
            // Calculate x coordinates
            var startX = area.X;
            var endX = (area.X + (area.Width - 1));

            // Draw a vertical line of tiles
            for (int y = 0; y < area.Height; ++y)
            {
                // Caclulate the y draw coordinate
                var drawY = (area.Y + y);

                // Set the target pixel
                bitmap.SetPixel(startX, drawY, fillColour);

                // Set the target pixel
                bitmap.SetPixel(endX, drawY, fillColour);
            }

            // Calculate y coordinates
            var startY = area.Y;
            var endY = (area.Y + (area.Height - 1));

            // Draw a horizontal line of tiles
            for (int x = 0; x < area.Width; ++x)
            {
                // Caclulate the x draw coordinate
                var drawX = (area.X + x);

                // Set the target pixel
                bitmap.SetPixel(drawX, startY, fillColour);

                // Set the target pixel
                bitmap.SetPixel(drawX, endY, fillColour);
            }
        }

        #endregion

        #region Flood Fill

        public static void FloodFill(Bitmap bitmap, Point point, Color fillColour)
        {
            var targetColour = bitmap.GetPixel(point.X, point.Y);
            FloodFill(bitmap, point, fillColour, targetColour);
        }

        private static void FloodFill(Bitmap bitmap, Point point, Color fillColour, Color targetColour)
        {
            // Attempting to fill an area with the same colour overflows the stack,
            // and attempting to compare a named colour with an unnamed colour does not
            // result in equality, so the underlying values must be compared directly
            if (targetColour.ToArgb() == fillColour.ToArgb())
                return;

            var stack = new Stack<Point>();

            stack.Push(point);

            while (stack.Count > 0)
            {
                var target = stack.Pop();

                var sourceColour = bitmap.GetPixel(target.X, target.Y);

                if (sourceColour == targetColour)
                {
                    bitmap.SetPixel(target.X, target.Y, fillColour);

                    if (target.X > 0)
                        stack.Push(new Point(target.X - 1, target.Y));

                    if (target.Y > 0)
                        stack.Push(new Point(target.X, target.Y - 1));

                    if (target.X < (bitmap.Width - 1))
                        stack.Push(new Point(target.X + 1, target.Y));

                    if (target.Y < (bitmap.Height - 1))
                        stack.Push(new Point(target.X, target.Y + 1));
                }
            }
        }

        #endregion

        #region Inversion

        public static Color Invert(Color colour)
        {
            var alpha = colour.A;
            var red = (byte.MaxValue - colour.R);
            var green = (byte.MaxValue - colour.G);
            var blue = (byte.MaxValue - colour.B);

            return Color.FromArgb(alpha, red, green, blue);
        }

        public static void Invert(Bitmap bitmap)
        {
            // Iterate through all pixels of the bitmap
            for (int y = 0; y < bitmap.Height; ++y)
                for (int x = 0; x < bitmap.Width; ++x)
                {
                    // Retrieve the value of the current pixe
                    var colour = bitmap.GetPixel(x, y);

                    // Set the current pixel to the inverse of the retrieved value
                    bitmap.SetPixel(x, y, Invert(colour));
                }
        }

        #endregion
    }
}