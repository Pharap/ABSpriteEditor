using System.IO;

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
    public static class SpriteFileHelper
    {
        public static void Save(string filePath, SpriteFile spriteFile, SpriteFormat spriteFormat)
        {
            using (var textWriter = File.CreateText(filePath))
                Save(textWriter, spriteFile, spriteFormat);
        }

        public static void Save(TextWriter textWriter, SpriteFile spriteFile, SpriteFormat spriteFormat)
        {
            using (var writer = new SpriteFileWriter(textWriter))
                writer.Write(spriteFile, spriteFormat);
        }

        public static void Save(string filePath, SpriteFile spriteFile, SpriteFormat spriteFormat, SpriteFileWriterSettings settings)
        {
            using (var textWriter = File.CreateText(filePath))
                Save(textWriter, spriteFile, spriteFormat, settings);
        }

        public static void Save(TextWriter textWriter, SpriteFile spriteFile, SpriteFormat spriteFormat, SpriteFileWriterSettings settings)
        {
            using (var writer = new SpriteFileWriter(textWriter, settings))
                writer.Write(spriteFile, spriteFormat);
        }
    }
}
