using System;
using System.Xml;

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

namespace ABSpriteEditor.Sprites.IO.Xml
{
    public static class XmlSpriteFileHelper
    {
        private static readonly XmlWriterSettings defaultWriterSettings =
            new XmlWriterSettings()
            {
                CloseOutput = true,
                Indent = true,
                IndentChars = "\t",
                NewLineChars = Environment.NewLine,
            };

        private static readonly XmlReaderSettings defaultReaderSettings =
            new XmlReaderSettings()
            {
                CloseInput = true,
                IgnoreWhitespace = true,
                IgnoreComments = true,
            };

        public static void Save(SpriteFile spriteFile, string filePath)
        {
            Save(spriteFile, filePath, defaultWriterSettings);
        }

        public static void Save(SpriteFile spriteFile, string filePath, XmlWriterSettings xmlWriterSettings)
        {
            using (var xmlWriter = XmlWriter.Create(filePath, xmlWriterSettings))
                Save(spriteFile, xmlWriter);
        }

        public static void Save(SpriteFile spriteFile, XmlWriter xmlWriter)
        {
            using (var writer = new SpriteFileWriter(xmlWriter))
                writer.Write(spriteFile);
        }

        public static SpriteFile Load(string filePath)
        {
            return Load(filePath, defaultReaderSettings);
        }

        public static SpriteFile Load(string filePath, XmlReaderSettings xmlReaderSettings)
        {
            using (var xmlReader = XmlReader.Create(filePath, xmlReaderSettings))
                return Load(xmlReader);
        }

        public static SpriteFile Load(XmlReader xmlReader)
        {
            using (var reader = new SpriteFileReader(xmlReader))
                return reader.Read();
        }
    }
}
