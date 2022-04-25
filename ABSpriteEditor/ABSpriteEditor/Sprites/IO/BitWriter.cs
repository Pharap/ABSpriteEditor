using System.Collections.Generic;

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
    public class BitWriter
    {
        private readonly List<byte> bytes = new List<byte>();
        private byte byteBuffer = 0;
        private int shift = 0;

        public void WriteBit(bool value)
        {
            if (value)
                this.byteBuffer |= (byte)(1 << this.shift);

            ++this.shift;

            if (this.shift >= 8)
            {
                this.bytes.Add(this.byteBuffer);
                this.byteBuffer = 0;
                this.shift = 0;
            }
        }

        public void PadByte(bool value)
        {
            while (this.shift > 0)
                this.WriteBit(value);
        }

        public IEnumerable<byte> EnumerateBytes()
        {
            foreach (var value in this.bytes)
                yield return value;

            if (this.shift > 0)
            {
                var shift = (8 - this.shift);

                yield return (byte)(this.byteBuffer << shift);
            }
        }
    }
}
