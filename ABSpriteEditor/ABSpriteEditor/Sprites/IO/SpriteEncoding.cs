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

namespace ABSpriteEditor.Sprites.IO
{
    public static class SpriteEncoding
    {
        public struct SpritePacket
        {
            private readonly byte imageByte;
            private readonly byte maskByte;

            public SpritePacket(byte imageByte, byte maskByte)
            {
                this.imageByte = imageByte;
                this.maskByte = maskByte;
            }

            public byte ImageByte
            {
                get { return this.imageByte; }
            }

            public byte MaskByte
            {
                get { return this.maskByte; }
            }
        }

        public static IEnumerable<byte> EnumerateImageBytes(Bitmap bitmap)
        {
            foreach (var packet in EnumerateSpritePackets(bitmap))
                yield return packet.ImageByte;
        }

        public static IEnumerable<byte> EnumerateMaskBytes(Bitmap bitmap)
        {
            foreach (var packet in EnumerateSpritePackets(bitmap))
                yield return packet.MaskByte;
        }

        public static IEnumerable<byte> EnumerateImageAndMaskBytes(Bitmap bitmap)
        {
            foreach (var packet in EnumerateSpritePackets(bitmap))
            {
                yield return packet.ImageByte;
                yield return packet.MaskByte;
            }
        }

        public static IEnumerable<SpritePacket> EnumerateSpritePackets(Bitmap bitmap)
        {
            int remainder = 0;
            int quotient = Math.DivRem(bitmap.Height, 8, out remainder);

            int rows = (remainder > 0) ? (quotient + 1) : quotient;
            int columns = bitmap.Width;

            for (int row = 0; row < rows; ++row)
            {
                int yStart = (row * 8);

                for (int column = 0; column < columns; ++column)
                {
                    byte imageByte = 0;
                    byte maskByte = 0;

                    for (int bitIndex = 0; bitIndex < 8; ++bitIndex)
                    {
                        int y = (yStart + bitIndex);

                        if (y >= bitmap.Height)
                            continue;

                        var pixel = bitmap.GetPixel(column, y);
                        var average = Average(pixel);

                        if ((pixel.A == 0xFF) && (average > 127))
                            imageByte |= (byte)(1 << bitIndex);

                        if (pixel.A == 0xFF)
                            maskByte |= (byte)(1 << bitIndex);
                    }

                    yield return new SpritePacket(imageByte, maskByte);
                }
            }
        }

        // A helper function for figuring out the average value of a pixel
        private static int Average(Color colour)
        {
            return ((colour.R + colour.G + colour.B) / 3);
        }
    }
}
