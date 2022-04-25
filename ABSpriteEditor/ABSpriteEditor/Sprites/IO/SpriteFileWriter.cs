using System;
using System.Collections.Generic;
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
    public class SpriteFileWriter : IDisposable
    {
        private readonly IndentWriter writer;
        private readonly SpriteFileWriterSettings settings = new SpriteFileWriterSettings();

        public SpriteFileWriter(TextWriter writer)
        {
            // If the provided writer is null
            if (writer == null)
                // Throw a null argument exception
                throw new ArgumentNullException("writer");

            // If the writer is already an indent writer
            if (writer is IndentWriter)
                // Cast it and assign it
                this.writer = (IndentWriter)writer;
            // Otherwise, if the writer is not already an indent writer
            else
                // Wrap it within an indent writer
                this.writer = new IndentWriter(writer);
        }

        public SpriteFileWriter(TextWriter writer, SpriteFileWriterSettings settings)
            : this(writer)
        {
            // If the provided setting are null
            if (settings == null)
                // Throw a null argument exception
                throw new ArgumentNullException("settings");

            // Assign the settings
            this.settings = settings;
        }

        public void Dispose()
        {
            // Dispose of the public writer
            this.writer.Dispose();
        }

        public void Close()
        {
            // Close the public writer
            this.writer.Close();
        }

        public void Write(SpriteFile spriteFile, SpriteFormat spriteFormat)
        {
            // Begin writing the file
            this.BeginFile(spriteFile);

            // Write the sprites and subgroups of the file
            this.WriteSpritesAndSubgroups(spriteFile, spriteFormat);

            // End writing the file
            this.EndFile();
        }

        private void WriteSpritesAndSubgroups(ISpriteGroup spriteGroup, SpriteFormat spriteFormat)
        {
            // Iterate through all the sprites
            for (int index = 0; index < spriteGroup.Sprites.Count; ++index)
            {
                // Cache the current sprite
                var sprite = spriteGroup.Sprites[index];

                // If a sprite has already been written
                if (index > 0)
                    // Insert a blank line
                    this.writer.WriteLine();

                // Write the current sprite
                this.Write(sprite, spriteFormat);
            }

            // If the file has at least one sprite and at least one subgroup
            if ((spriteGroup.Sprites.Count > 0) && (spriteGroup.Subgroups.Count > 0))
                // Separate the two sections with a blank line
                this.writer.WriteLine();

            // Iterate through all the subgroups
            for (int index = 0; index < spriteGroup.Subgroups.Count; ++index)
            {
                // Cache the current subgroup
                var subgroup = spriteGroup.Subgroups[index];

                // If a subgroup has already been written
                if (index > 0)
                    // Insert a blank line
                    this.writer.WriteLine();

                // Write the current subgroup
                this.Write(subgroup, spriteFormat);
            }
        }

        private void Write(SpriteGroup spriteGroup, SpriteFormat spriteFormat)
        {
            // Begin the namespace that the group represends
            this.BeginNamespace(spriteGroup.Namespace);

            // Write the sprites and subgroups of the file
            this.WriteSpritesAndSubgroups(spriteGroup, spriteFormat);

            // End the namespace that the group represends
            this.EndNamespace();
        }

        private void Write(Sprite sprite, SpriteFormat spriteFormat)
        {
            // Choose the appropriate specialised function based on the sprite format
            switch (spriteFormat)
            {
                case SpriteFormat.SpritesNoMask:
                    this.WriteSpritesNoMask(sprite);
                    return;

                case SpriteFormat.SpritesPlusMask:
                    this.WriteSpritesPlusMask(sprite);
                    return;

                case SpriteFormat.SpritesExternalMask:
                    this.WriteSpritesExternalMask(sprite);
                    return;

                case SpriteFormat.UncompressedBitmap:
                    this.WriteUncompressedBitmap(sprite);
                    return;

                case SpriteFormat.CompressedBitmap:
                    this.WriteCompressedBitmap(sprite);
                    return;

                case SpriteFormat.CompressedBitmapExternalMask:
                    this.WriteCompressedBitmapExternalMask(sprite);
                    return;
            }

            // If the value wasn't handled by the switch, it's not supported yet
            throw new NotSupportedException("The provided value of spriteFormat is unrecognised or unsupported");
        }

        private void WriteSpritesNoMask(Sprite sprite)
        {
            // Write the constants for the width and height
            this.WriteDimensionConstants(sprite.Name, sprite.Width, sprite.Height);

            // Begin the sprite
            this.BeginSprite(sprite.Name);
            {
                // Use the dimension constants for the frame's dimensions
                this.WriteDimensionData(sprite.Name);

                // Iterate through all frames
                for (int index = 0; index < sprite.Frames.Count; ++index)
                {
                    // Cache the frame at the current index
                    var frame = sprite.Frames[index];

                    // Write a blank line
                    this.writer.WriteLine();

                    // If the frame has text, use it as a comment
                    this.WriteFrameComment(frame, index);

                    // Write all the image bytes of the frame
                    this.WriteBytes(SpriteEncoding.EnumerateImageBytes(frame.Image), frame.Image.Width);
                }
            }
            // End the sprite
            this.EndSprite();
        }

        private void WriteSpritesPlusMask(Sprite sprite)
        {
            // Write the constants for the width and height
            this.WriteDimensionConstants(sprite.Name, sprite.Width, sprite.Height);

            // Begin the sprite
            this.BeginSprite(sprite.Name);
            {
                // Use the dimension constants for the frame's dimensions
                this.WriteDimensionData(sprite.Name);

                // Iterate through all frames
                for (int index = 0; index < sprite.Frames.Count; ++index)
                {
                    // Cache the frame at the current index
                    var frame = sprite.Frames[index];

                    // Write a blank line
                    this.writer.WriteLine();

                    // If the frame has text, use it as a comment
                    this.WriteFrameComment(frame, index);

                    // Write all the image and mask bytes of the frame
                    this.WriteBytes(SpriteEncoding.EnumerateImageAndMaskBytes(frame.Image), frame.Image.Width);
                }
            }
            // End the sprite
            this.EndSprite();
        }

        private void WriteSpritesExternalMask(Sprite sprite)
        {
            // Write the constants for the width and height
            this.WriteDimensionConstants(sprite.Name, sprite.Width, sprite.Height);

            // Begin the sprite
            this.BeginSprite(sprite.Name);
            {
                // Use the dimension constants for the frame's dimensions
                this.WriteDimensionData(sprite.Name);

                // Iterate through all frames
                for (int index = 0; index < sprite.Frames.Count; ++index)
                {
                    // Cache the frame at the current index
                    var frame = sprite.Frames[index];

                    // Write a blank line
                    this.writer.WriteLine();

                    // If the frame has text, use it as a comment
                    this.WriteFrameComment(frame, index);

                    // Write all the image bytes of the frame
                    this.WriteBytes(SpriteEncoding.EnumerateImageBytes(frame.Image), frame.Image.Width);
                }
            }
            // End the sprite
            this.EndSprite();

            // Insert a blank line
            this.writer.WriteLine();

            // Begin the sprite mask
            this.BeginSpriteMask(sprite.Name);
            {
                // Iterate through all frames
                for (int index = 0; index < sprite.Frames.Count; ++index)
                {
                    // Cache the frame at the current index
                    var frame = sprite.Frames[index];

                    // If this isn't the first frame
                    if (index > 0)
                        // Insert a blank line
                        this.writer.WriteLine();

                    // If the frame has text, use it as a comment
                    this.WriteFrameComment(frame, index);

                    // Write all the mask bytes of the frame
                    this.WriteBytes(SpriteEncoding.EnumerateMaskBytes(frame.Image), frame.Image.Width);
                }
            }
            // End the sprite mask
            this.EndSpriteMask();
        }

        private void WriteUncompressedBitmap(Sprite sprite)
        {
            // If there are no frames
            if (sprite.Frames.Count == 0)
            {
                // Write the constants for the width and height
                this.WriteDimensionConstants(sprite.Name, sprite.Width, sprite.Height);

                // Begin the sprite
                this.BeginSprite(sprite.Name, 1);

                // End the sprite
                this.EndSprite();

                // Exit early
                return;
            }

            // If there's only one frame
            if (sprite.Frames.Count == 1)
            {
                // Treat the single frame as a single image
                this.WriteUncompressedBitmapFrame(sprite.Name, sprite.Frames[0]);

                // Exit early
                return;
            }

            // Iterate through all frames
            for (int index = 0; index < sprite.Frames.Count; ++index)
            {
                // If this isn't the first frame
                if (index > 0)
                    // Insert a blank line
                    this.writer.WriteLine();

                // Since uncompressed images don't handle frames, generate a name for the new image
                var spriteName = Identifier.Create(string.Format("{0}Frame{1}", sprite.Name, index));

                // Write the frame as a sprite
                this.WriteUncompressedBitmapFrame(spriteName, sprite.Frames[index]);
            }
        }

        private void WriteUncompressedBitmapFrame(Identifier spriteName, SpriteFrame spriteFrame)
        {
            // Write the constants for the width and height
            this.WriteDimensionConstants(spriteName, spriteFrame.Image.Width, spriteFrame.Image.Height);

            // Begin the sprite
            this.BeginSprite(spriteName);
            {
                // If the frame has text, use it as a comment
                this.WriteSingleFrameComment(spriteFrame);

                // Write all the image bytes of the frame
                this.WriteBytes(SpriteEncoding.EnumerateImageBytes(spriteFrame.Image), spriteFrame.Image.Width);
            }
            // End the sprite
            this.EndSprite();
        }

        private void WriteCompressedBitmap(Sprite sprite)
        {
            // If there are no frames
            if (sprite.Frames.Count == 0)
            {
                // Write the constants for the width and height
                this.WriteDimensionConstants(sprite.Name, sprite.Width, sprite.Height);

                // Begin the sprite
                this.BeginSprite(sprite.Name);
                {
                    // Use the dimension constants for the frame's dimensions
                    this.WriteCompressedDimensionData(sprite.Name);
                }
                // End the sprite
                this.EndSprite();

                // Exit early
                return;
            }

            // If there's only one frame
            if (sprite.Frames.Count == 1)
            {
                // Treat the single frame as a single image
                this.WriteCompressedBitmapFrame(sprite.Name, sprite.Frames[0]);

                // Exit early
                return;
            }

            // Iterate through all frames
            for (int index = 0; index < sprite.Frames.Count; ++index)
            {
                // If this isn't the first frame
                if (index > 0)
                    // Insert a blank line
                    this.writer.WriteLine();

                // Since uncompressed images don't handle frames, generate a name for the new image
                var spriteName = Identifier.Create(string.Format("{0}Frame{1}", sprite.Name, index));

                // Write the frame as a sprite
                this.WriteCompressedBitmapFrame(spriteName, sprite.Frames[index]);
            }
        }

        private void WriteCompressedBitmapFrame(Identifier spriteName, SpriteFrame spriteFrame)
        {
            // Write the constants for the width and height
            this.WriteDimensionConstants(spriteName, spriteFrame.Image.Width, spriteFrame.Image.Height);

            // Begin the sprite
            this.BeginSprite(spriteName);
            {
                // Use the dimension constants for the frame's dimensions
                this.WriteCompressedDimensionData(spriteName);

                // Add a blank line
                this.writer.WriteLine();

                // If the frame has text, use it as a comment
                this.WriteSingleFrameComment(spriteFrame);

                // Write the compressed image bytes of the frame
                this.WriteBytes(SpriteCompression.EnumerateCompressedImageBytes(spriteFrame.Image), spriteFrame.Image.Width);
            }
            // End the sprite
            this.EndSprite();
        }

        private void WriteCompressedBitmapExternalMask(Sprite sprite)
        {
            // If there are no frames
            if (sprite.Frames.Count == 0)
            {
                // Write the constants for the width and height
                this.WriteDimensionConstants(sprite.Name, sprite.Width, sprite.Height);

                // Begin the sprite
                this.BeginSprite(sprite.Name);
                {
                    // Use the dimension constants for the frame's dimensions
                    this.WriteCompressedDimensionData(sprite.Name);
                }
                // End the sprite
                this.EndSprite();

                // Insert a blank line
                this.writer.WriteLine();

                // Begin the sprite mask
                this.BeginSpriteMask(sprite.Name);

                // End the sprite mask
                this.EndSpriteMask();

                // Exit early
                return;
            }

            // If there's only one frame
            if (sprite.Frames.Count == 1)
            {
                // Treat the single frame as a single image
                this.WriteCompressedBitmapExternalMaskFrame(sprite.Name, sprite.Frames[0]);
                return;
            }

            // Iterate through all frames
            for (int index = 0; index < sprite.Frames.Count; ++index)
            {
                // If this isn't the first frame
                if (index > 0)
                    // Insert a blank line
                    this.writer.WriteLine();

                // Since uncompressed images don't handle frames, generate a name for the new image
                var spriteName = Identifier.Create(string.Format("{0}Frame{1}", sprite.Name, index));

                // Write the frame as a sprite
                this.WriteCompressedBitmapExternalMaskFrame(spriteName, sprite.Frames[index]);
            }
        }

        private void WriteCompressedBitmapExternalMaskFrame(Identifier spriteName, SpriteFrame spriteFrame)
        {
            // Write the constants for the width and height
            this.WriteDimensionConstants(spriteName, spriteFrame.Image.Width, spriteFrame.Image.Height);

            // Begin the sprite
            this.BeginSprite(spriteName);
            {
                // Use the dimension constants for the frame's dimensions
                this.WriteCompressedDimensionData(spriteName);

                // If the frame has text, use it as a comment
                this.WriteSingleFrameComment(spriteFrame);

                // Write the compressed image bytes of the frame
                this.WriteBytes(SpriteCompression.EnumerateCompressedImageBytes(spriteFrame.Image), spriteFrame.Image.Width);
            }
            // End the sprite
            this.EndSprite();

            // Insert a blank line
            this.writer.WriteLine();

            // Begin the sprite mask
            this.BeginSpriteMask(spriteName);
            {
                // If the frame has text, use it as a comment
                this.WriteSingleFrameComment(spriteFrame);

                // Write the compressed image bytes of the frame
                this.WriteBytes(SpriteCompression.EnumerateCompressedMaskBytes(spriteFrame.Image), spriteFrame.Image.Width);
            }
            // End the sprite
            this.EndSpriteMask();
        }

        #region Private Utilities

        private void BeginFile(SpriteFile spriteFile)
        {
            // Write the pragma once
            this.WritePragma();

            // Write the licence text (if any)
            this.WriteLicenceText(spriteFile);

            // Write the include list
            this.WriteIncludes();
        }

        private void WritePragma()
        {
            // Write the pragma once
            this.writer.WriteLine("#pragma once");
            this.writer.WriteLine();
        }

        private void WriteLicenceText(SpriteFile spriteFile)
        {
            // If the settings include some licence text
            if (spriteFile.LicenceText != null)
            {
                // Open a string reader on the licence text
                using (var textReader = new StringReader(spriteFile.LicenceText))
                {
                    // While there is text yet to be read
                    while (textReader.Peek() != -1)
                    {
                        // Read a line of text
                        var line = textReader.ReadLine();

                        // Write prepended comment marker and indent
                        this.writer.Write("// ");

                        // Write the line to the output
                        this.writer.WriteLine(line);
                    }
                }

                // Finally, insert a blank line to account for the licence text
                this.writer.WriteLine();
            }
        }

        private void WriteIncludes()
        {
            // Include stdint.h for uint8_t
            this.writer.WriteLine("// For uint8_t");
            this.writer.WriteLine("#include <stdint.h>");
            this.writer.WriteLine();

            // Include avr/pgmspace.h for PROGMEM
            this.writer.WriteLine("// For PROGMEM");
            this.writer.WriteLine("#include <avr/pgmspace.h>");
            this.writer.WriteLine();
        }

        private void EndFile()
        {
            // Currently empty
        }

        private void BeginNamespace(Identifier identifier)
        {
            // Begin the namespace
            this.writer.WriteLine("namespace {0}", identifier);
            this.writer.WriteLine('{');

            // Increase the indent
            this.writer.IncreaseIndent();
        }

        private void EndNamespace()
        {
            // Decrease the indent
            this.writer.DecreaseIndent();

            // End the namespace
            this.writer.WriteLine('}');
        }

        private void BeginSprite(Identifier identifier)
        {
            // Begin the sprite array
            this.writer.WriteLine("constexpr uint8_t {0}[] PROGMEM", identifier);
            this.writer.WriteLine('{');

            // Increase the indent
            this.writer.IncreaseIndent();
        }

        private void BeginSprite(Identifier identifier, int size)
        {
            // Begin the sprite array
            this.writer.WriteLine("constexpr uint8_t {0}[{1}] PROGMEM", identifier, size);
            this.writer.WriteLine('{');

            // Increase the indent
            this.writer.IncreaseIndent();
        }

        private void EndSprite()
        {
            // Decrease the indent
            this.writer.DecreaseIndent();

            // End the sprite array
            this.writer.WriteLine("};");
        }

        private void BeginSpriteMask(Identifier identifier)
        {
            // Begin a sprite array with a 'Mask' suffix
            this.writer.WriteLine("constexpr uint8_t {0}Mask[] PROGMEM", identifier);
            this.writer.WriteLine('{');

            // Increase the indent
            this.writer.IncreaseIndent();
        }

        private void EndSpriteMask()
        {
            // Decrease the indent
            this.writer.DecreaseIndent();

            // End the sprite array
            this.writer.WriteLine("};");
        }

        private void WriteDimensionConstants(Identifier identifier, int width, int height)
        {
            // Write two constexpr constants for the dimension constants
            this.writer.WriteLine("constexpr uint8_t {0}Width {{ {1} }};", identifier, width);
            this.writer.WriteLine("constexpr uint8_t {0}Height {{ {1} }};", identifier, height);
            this.writer.WriteLine();
        }

        private void WriteDimensionData(Identifier identifier)
        {
            // Reference the earlier constexpr constants within a data array
            this.writer.WriteLine("// Width, Height");
            this.writer.WriteLine("{0}Width, {0}Height,", identifier);
        }

        private void WriteCompressedDimensionData(Identifier identifier)
        {
            // Reference the earlier constexpr constants within a compressed image data array
            this.writer.WriteLine("// Width, Height");
            this.writer.WriteLine("({0}Width - 1), ({0}Height - 1),", identifier);
        }

        private void WriteFrameComment(SpriteFrame spriteFrame, int index)
        {
            // If the frame's text isn't null
            if (spriteFrame.Text != null)
                // Write the frame's text as a comment
                this.writer.WriteLine("// {0}", spriteFrame.Text);
            // Otherwise, if the frame's text was null
            else
                // Write the frame's index as a comment
                this.writer.WriteLine("// Frame {0}", index);
        }

        private void WriteSingleFrameComment(SpriteFrame spriteFrame)
        {
            // If the frame's text isn't null
            if (spriteFrame.Text != null)
                // Write the frame's text as a comment
                this.writer.WriteLine("// {0}", spriteFrame.Text);
        }
        
        // Write a sequence of bytes as a sequence of hexadecimal constants
        private void WriteBytes(IEnumerable<byte> byteSequence, int bytesPerLine)
        {
            // How many bytes have been written on the current line
            int bytesWrittenThisLine = 0;

            // For each byte in the sequence
            foreach (var value in byteSequence)
            {
                // If the number of bytes written this line has reached the limit
                if (bytesWrittenThisLine == bytesPerLine)
                {
                    // Begin a new line
                    this.writer.WriteLine();

                    // Reset the number of bytes written back to zero
                    bytesWrittenThisLine = 0;
                }

                // If a byte has already been written this line
                if (bytesWrittenThisLine > 0)
                    // Write a space before writing the current one
                    this.writer.Write(' ');

                // Write the current byte
                this.writer.Write("0x{0:X2},", value);

                // Count the byte that was just written
                ++bytesWrittenThisLine;
            }

            // End with a new line
            this.writer.WriteLine();
        }

        #endregion
    }
}
