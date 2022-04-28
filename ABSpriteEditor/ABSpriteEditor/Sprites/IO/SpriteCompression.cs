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
    public static class SpriteCompression
    {
        public static IEnumerable<byte> EnumerateCompressedImageBytes(Bitmap bitmap)
        {
            return EnumerateCompressedBytes(bitmap, SpriteEncoding.EnumerateImageBytes(bitmap));
        }

        public static IEnumerable<byte> EnumerateCompressedMaskBytes(Bitmap bitmap)
        {
            return EnumerateCompressedBytes(bitmap, SpriteEncoding.EnumerateMaskBytes(bitmap));
        }

        private static IEnumerable<byte> EnumerateCompressedBytes(Bitmap bitmap, IEnumerable<byte> bytes)
        {
            if ((bitmap.Width < 1) || (bitmap.Height < 1))
                throw new ArgumentException("bitmap must be at least 1x1");

            return EnumerateCompressedBytes(bitmap.GetPixel(0, 0), bytes);
        }

        private static IEnumerable<byte> EnumerateCompressedBytes(Color firstPixel, IEnumerable<byte> bytes)
        {
            var writer = new BitWriter();

            writer.WriteBit(firstPixel.ToArgb() == SpriteColours.White.ToArgb());

            foreach (var span in GenerateBitSpans(bytes))
            {
                WriteCompressedLength(writer, span - 1);
            }

            writer.PadByte(false);

            return writer.EnumerateBytes();
        }

        private static void WriteCompressedLength(BitWriter writer, int length)
        {
            var bitsNeeded = 1;

            while ((1 << bitsNeeded) <= length)
            {
                bitsNeeded += 2;
                writer.WriteBit(false);
            }

            writer.WriteBit(true);

            for(int index = 0; index < bitsNeeded; ++index)
                writer.WriteBit((length & (1 << index)) != 0);
        }

        private static int GetBitsNeeded(int length)
        {
            int result = 1;

            while ((length - 1) > result)
                result += 2;

            return result;
        }

        private static IEnumerable<int> GenerateBitSpans(IEnumerable<byte> bytes)
        {
            bool? bit = null;
            int length = 0;

            int index = 0;

            foreach (var value in bytes)
            {
                for (int shift = 0; shift < 8; ++shift, ++index)
                {
                    var current = ((value & (1 << shift)) != 0);

                    if (bit == null)
                        bit = current;

                    if (current == bit.Value)
                    {
                        ++length;
                        continue;
                    }

                    yield return length;

                    bit = current;
                    length = 1;
                }
            }

            if (bit != null)
                yield return length;
        }
    }
}
