using System;
using System.Collections.Generic;
using System.Drawing;
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
    // TODO: Comment this class
    public class SpriteFileReader : IDisposable
    {
        private readonly XmlReader reader;

        public SpriteFileReader(XmlReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException("reader");

            this.reader = reader;
        }

        public void Dispose()
        {
            ((IDisposable)this.reader).Dispose();
        }

        public void Close()
        {
            this.reader.Close();
        }

        // Skips an XML declaration if one is present
        private void SkipXmlDeclaration()
        {
            if (this.reader.NodeType == XmlNodeType.XmlDeclaration)
                this.reader.Skip();
        }

        // Determines if the reader is currently positioned at a SpriteFile element
        private bool IsAtSpriteFile()
        {
            return ((this.reader.NodeType == XmlNodeType.Element) && (this.reader.Name == "SpriteFile"));
        }

        // Determines if the reader is currently positioned at a SpriteGroup element
        private bool IsAtSpriteGroup()
        {
            return ((this.reader.NodeType == XmlNodeType.Element) && (this.reader.Name == "SpriteGroup"));
        }

        // Determines if the reader is currently positioned at a Sprite element
        private bool IsAtSprite()
        {
            return ((this.reader.NodeType == XmlNodeType.Element) && (this.reader.Name == "Sprite"));
        }

        // Determines if the reader is currently positioned at a SpriteFrame element
        private bool IsAtSpriteFrame()
        {
            return ((this.reader.NodeType == XmlNodeType.Element) && (this.reader.Name == "SpriteFrame"));
        }

        // Determines if the reader is currently positioned at a SpriteFile element
        private bool IsAtLicenceText()
        {
            return ((this.reader.NodeType == XmlNodeType.Element) && (this.reader.Name == "LicenceText"));
        }

        // Reads a sprite file
        public SpriteFile Read()
        {
            // Try to begin reading
            if (!this.reader.Read())
                // If reading was not possible, throw a format exception
                throw new FormatException("Could not begin reading the XML file");

            // Skip the XML declaration
            this.SkipXmlDeclaration();

            // If the reader is not positioned at a SpriteFile element
            if (!this.IsAtSpriteFile())
                // Throw a format exception
                throw new FormatException("File did not begin with a SpriteFile element");

            // Create a new sprite file
            var spriteFile = new SpriteFile();

            // Try to read a file name attribute from the file
            var fileName = this.reader.GetAttribute("FileName");

            // If a file name is recorded
            if (fileName != null)
                // Use that file name
                spriteFile.FileName = fileName;

            // If the reader is not positioned at an empty element
            if (this.reader.IsEmptyElement)
                // Throw a format exception, the sprite file should not be empty
                throw new FormatException("Empty SpriteFile element encountered");

            // Read the start element
            this.reader.ReadStartElement("SpriteFile");

            // Read the licence text
            spriteFile.LicenceText = this.ReadLicenceText();

            // Read all the sprites
            foreach (var sprite in this.ReadSprites())
                // Add them to the sprite group
                spriteFile.Sprites.Add(sprite);

            // Read all the subgroups
            foreach (var subgroup in this.ReadSpriteGroups())
                // Add them to the sprite group
                spriteFile.Subgroups.Add(subgroup);

            // Read the end element
            this.reader.ReadEndElement();

            // Return the resulting sprite file
            return spriteFile;
        }

        private string ReadLicenceText()
        {
            // If the reader is not at a licence text node
            if (!this.IsAtLicenceText())
                // Return null
                return null;

            // If the reader is at an empty element
            if (this.reader.IsEmptyElement)
            {
                // Read the element
                this.reader.ReadStartElement("LicenceText");

                // Return null
                return null;
            }

            // Read the start element
            this.reader.ReadStartElement("LicenceText");

            // Read the text
            var result = this.reader.ReadString();

            // Read the end element
            this.reader.ReadEndElement();

            // Return the text, replacing new lines with the environment new line
            return result.Replace("\n", Environment.NewLine);
        }

        private IEnumerable<SpriteGroup> ReadSpriteGroups()
        {
            // While the reader is positioned at a sprite group
            while (this.IsAtSpriteGroup())
                // Read the sprite group
                yield return this.ReadSpriteGroup();
        }

        private SpriteGroup ReadSpriteGroup()
        {
            // Try to read a namespace attribute from the file
            var namespaceAttribute = this.reader.GetAttribute("Namespace");

            // If there's no namespace recorded
            if (namespaceAttribute == null)
                // Throw a format exception
                throw new FormatException("SpriteGroup without Namespace attribute");

            // If the namespace is not a suitable identifier
            if (!Identifier.CanCreateIdentifierFrom(namespaceAttribute))
                // Throw a format exception
                throw new FormatException("Invalid Namespace attribute on SpriteGroup");

            // Construct a new sprite group
            var spriteGroup = new SpriteGroup(Identifier.Create(namespaceAttribute));

            // If the element is empty
            if (this.reader.IsEmptyElement)
            {
                // Read the element
                this.reader.ReadStartElement("SpriteGroup");

                // Return the newly created empty sprite group
                return spriteGroup;
            }

            // Read the opening SpriteGroup element
            this.reader.ReadStartElement("SpriteGroup");

            // Read all the sprites
            foreach (var sprite in this.ReadSprites())
                // Add them to the sprite group
                spriteGroup.Sprites.Add(sprite);

            // Read all the subgroups
            foreach (var subgroup in this.ReadSpriteGroups())
                // Add them to the sprite group
                spriteGroup.Subgroups.Add(subgroup);

            // Read the closing SpriteGroup element
            this.reader.ReadEndElement();

            // Return the resulting sprite group
            return spriteGroup;
        }

        private IEnumerable<Sprite> ReadSprites()
        {
            while (this.IsAtSprite())
                yield return this.ReadSprite();
        }

        private Sprite ReadSprite()
        {
            // Try to read a name attribute from the file
            var nameAttribute = this.reader.GetAttribute("Name");

            // If there's no name recorded
            if (nameAttribute == null)
                // Throw a format exception
                throw new FormatException("Sprite without Name attribute");

            // If the name is not a suitable identifier
            if (!Identifier.CanCreateIdentifierFrom(nameAttribute))
                // Throw a format exception
                throw new FormatException("Invalid Name attribute on Sprite");

            // Try to read a width attribute from the file
            var widthAttribute = this.reader.GetAttribute("Width");

            // Prepare a variable to store the width
            int width = 0;

            // Try to read the width attribute as an integer
            if (!int.TryParse(widthAttribute, out width))
                // If the width attribute wasn't a valid integer, throw a format exception
                throw new FormatException("Invalid Width attribute on Sprite");

            // Try to read a height attribute from the file
            var heightAttribute = this.reader.GetAttribute("Height");

            // Prepare a variable to store the height
            int height = 0;

            // Try to read the height attribute as an integer
            if (!int.TryParse(heightAttribute, out height))
                // If the height attribute wasn't a valid integer, throw a format exception
                throw new FormatException("Invalid Height attribute on Sprite");

            // Create a new sprite with the established details
            var sprite = new Sprite(width, height, Identifier.Create(nameAttribute));

            // If the element is empty
            if (this.reader.IsEmptyElement)
            {
                // Read the element
                this.reader.ReadStartElement("Sprite");

                // Return the newly created empty sprite
                return sprite;
            }

            // Read the opening Sprite element
            this.reader.ReadStartElement("Sprite");

            // Read all the sprite frames
            foreach (var frame in this.ReadSpriteFrames(width, height))
                // Add them to the sprite
                sprite.Frames.Add(frame);

            // Read the closing Sprite element
            this.reader.ReadEndElement();

            // Return the resulting sprite
            return sprite;
        }

        private IEnumerable<SpriteFrame> ReadSpriteFrames(int width, int height)
        {
            // While the reader is positioned at a sprite frame
            while (this.IsAtSpriteFrame())
                // Read the sprite frame
                yield return this.ReadSpriteFrame(width, height);
        }

        private SpriteFrame ReadSpriteFrame(int width, int height)
        {
            // Try to read a text attribute from the file
            var textAttribute = this.reader.GetAttribute("Text");

            // If the element is empty
            if (this.reader.IsEmptyElement)
                // This element actually shouldn't be empty, so throw a format exception
                throw new FormatException("A SpriteFrame node was empty");

            // Read the opening SpriteFrame element
            this.reader.ReadStartElement("SpriteFrame");

            // Read the bitmap encoded in the content
            var bitmap = this.ReadBitmap();

            if ((bitmap.Width != width) || (bitmap.Height != height))
                // Throw a format exception
                throw new FormatException("Invalid image dimensions in SpriteFrame");

            // Read the closing SpriteFrame element
            this.reader.ReadEndElement();

            // Return a new sprite frame
            return new SpriteFrame(bitmap, textAttribute);
        }

        private Bitmap ReadBitmap()
        {
            // Create a new buffer in memory to read the data into
            using (var memoryStream = new MemoryStream())
            {
                // Create a temporary 1KB buffer for reading the data in chunks
                var buffer = new byte[1024];

                // Loop continually
                while (true)
                {
                    // Read bytes into the buffer
                    var amountRead = reader.ReadContentAsBinHex(buffer, 0, buffer.Length);

                    // If no bytes were read, the end has been reached
                    if (amountRead == 0)
                        // So exit the loop
                        break;

                    // Otherwise data was read, so write the read data into the memory stream
                    memoryStream.Write(buffer, 0, amountRead);
                }

                // Return a new bitmap constructed from the data stored in the memory stream
                return new Bitmap(memoryStream);
            }
        }
    }
}
