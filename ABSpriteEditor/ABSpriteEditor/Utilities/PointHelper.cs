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
    public static class PointHelper
    {
        public static int Min(int left, int right)
        {
            return ((left < right) ? left : right);
        }

        public static Point Min(Point left, Point right)
        {
            return new Point(Min(left.X, right.X), Min(left.Y, right.Y));
        }

        public static int Max(int left, int right)
        {
            return ((left > right) ? left : right);
        }

        public static Point Max(Point left, Point right)
        {
            return new Point(Max(left.X, right.X), Max(left.Y, right.Y));
        }

        public static int Clamp(int value, int min, int max)
        {
            return ((value < min) ? min : (value > max) ? max : value);
        }

        public static Point Clamp(Point value, Point min, Point max)
        {
            return new Point(Clamp(value.X, min.X, max.X), Clamp(value.Y, min.Y, max.Y));
        }

        public static Point Clamp(Point point, Point start, Size size)
        {
            return new Point(Clamp(point.X, start.X, start.X + size.Width - 1), Clamp(point.Y, start.Y, start.Y + size.Height - 1));
        }

        public static Point Clamp(Point point, Rectangle rectangle)
        {
            return Clamp(point, rectangle.Location, rectangle.Size);
        }
    }
}
