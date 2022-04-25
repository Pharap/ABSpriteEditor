using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
    public class SpriteFileWriter : IDisposable
    {
        private readonly XmlWriter writer;

        public SpriteFileWriter(TextWriter writer)
        {
            if (writer == null)
                throw new ArgumentNullException("writer");

            this.writer = XmlWriter.Create(writer);
        }

        public SpriteFileWriter(XmlWriter writer)
        {
            if (writer == null)
                throw new ArgumentNullException("writer");

            this.writer = writer;
        }

        public void Dispose()
        {
            ((IDisposable)this.writer).Dispose();
        }

        public void Close()
        {
            this.writer.Close();
        }

        public void Write(SpriteFile spriteFile)
        {
            // Begin the document
            this.writer.WriteStartDocument();
            {
                // Begin the root element - SpriteFile
                this.writer.WriteStartElement("SpriteFile");
                {
                    // Write the file name information (if any)
                    this.WriteFileName(spriteFile.FileName);

                    // Write the licence information (if any)
                    this.WriteLicence(spriteFile.LicenceText);

                    // Iterate through all sprites
                    foreach (var sprite in spriteFile.Sprites)
                        // Write each sprite in turn
                        this.Write(sprite);

                    // Iterate through all sprite groups
                    foreach (var subgroup in spriteFile.Subgroups)
                        // Write each sprite group in turn
                        this.Write(subgroup);
                }
                // End the root element
                this.writer.WriteEndElement();
            }
            // End the document
            this.writer.WriteEndDocument();
        }

        private void WriteFileName(string fileName)
        {
            // If the file name is not null
            if (fileName != null)
                // Write the file name as an attribute
                this.writer.WriteAttributeString("FileName", fileName);
        }

        private void WriteLicence(string licence)
        {
            // If the licence is not null
            if (licence != null)
                // Write the licence as an attribute
                this.writer.WriteElementString("LicenceText", licence);
        }

        private void Write(SpriteGroup spriteGroup)
        {
            // Begin a sprite group element
            this.writer.WriteStartElement("SpriteGroup");
            {
                // If the sprite group's namespace is null
                if (spriteGroup.Namespace == null)
                    // Throw an argument exception
                    throw new ArgumentException("A SpriteGroup within the SpriteFile had no Namespace");

                // Write the namespace as an attribute
                this.writer.WriteAttributeString("Namespace", spriteGroup.Namespace.ToString());

                // Iterate through all sprites
                foreach (var sprite in spriteGroup.Sprites)
                    // Write each sprite in turn
                    this.Write(sprite);

                // Iterate through all sprite groups
                foreach (var subgroup in spriteGroup.Subgroups)
                    // Write each sprite group in turn
                    this.Write(subgroup);
            }
            // End a sprite group element
            this.writer.WriteEndElement();
        }

        private void Write(Sprite sprite)
        {
            // Begin a sprite element
            this.writer.WriteStartElement("Sprite");
            {
                // If the sprite's name is null
                if (sprite.Name != null)
                    // Throw an argument exception
                    throw new ArgumentException("A Sprite within the SpriteFile had no Name");

                // Write the name as an attribute
                this.writer.WriteAttributeString("Name", sprite.Name.ToString());

                // Write the width and height as attributes
                this.writer.WriteAttributeString("Width", sprite.Width.ToString());
                this.writer.WriteAttributeString("Height", sprite.Height.ToString());

                // Iterate through all sprite frames
                foreach (var spriteFrame in sprite.Frames)
                    // Write each sprite frame in turn
                    this.Write(spriteFrame);
            }
            // End a sprite element
            this.writer.WriteEndElement();
        }

        private void Write(SpriteFrame spriteFrame)
        {
            // Begin a sprite frame element
            this.writer.WriteStartElement("SpriteFrame");
            {
                // If the sprite frame's text is not null
                if (spriteFrame.Text != null)
                    // Write the text as an attribute
                    this.writer.WriteAttributeString("Text", spriteFrame.Text);

                // Write the frame's image
                this.Write(spriteFrame.Image);
            }
            // End a sprite frame element
            this.writer.WriteEndElement();
        }

        private void Write(Bitmap image)
        {
            // Create a memory stream to write to
            using (var memoryStream = new MemoryStream())
            {
                // Save the image to a PNG stream in memory
                image.Save(memoryStream, ImageFormat.Png);

                // Check the stream's size will fit in an int
                if (memoryStream.Length > int.MaxValue)
                    // If it won't fit then throw an exception
                    throw new ArgumentException("An within the SpriteFile was too large to write");

                // Then write the stream into the XML output in BinHex format
                this.writer.WriteBinHex(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
            }
        }
    }
}
