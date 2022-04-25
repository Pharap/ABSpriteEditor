using System;

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

namespace ABSpriteEditor.Sprites
{
    public class SpriteFile : IDisposable, ISpriteGroup
    {
        private readonly SpriteCollection sprites;
        private readonly SpriteGroupCollection subgroups;
        private string fileName = null;
        private string licenceText = null;

        public event EventHandler Disposing;
        public event EventHandler Disposed;
        public event EventHandler FileNameChanged;

        public SpriteFile()
        {
            this.sprites = new SpriteCollection(this);
            this.subgroups = new SpriteGroupCollection(this);
        }

        public SpriteFile(string fileName, string licenceText = null) :
            this()
        {
            // If the value is null
            // Throw a null argument exception
            if (fileName == null)
                throw new ArgumentNullException("fileName");

            this.fileName = fileName;
            this.licenceText = licenceText;
        }

        Identifier ISpriteGroup.Namespace
        {
            get { return null; }
        }

        public SpriteCollection Sprites
        {
            get { return this.sprites; }
        }

        public SpriteGroupCollection Subgroups
        {
            get { return this.subgroups; }
        }

        public string FileName
        {
            get { return this.fileName; }
            set
            {
                // If the value is null
                if (value == null)
                    // Throw a null argument exception
                    throw new ArgumentNullException("value");

                // If the assigned file name is not the same as the current file name
                if (this.fileName != value)
                {
                    // Change the file name
                    this.fileName = value;

                    // Raise the FileNameChanged event
                    this.OnFileNameChanged(EventArgs.Empty);
                }
            }
        }

        public string LicenceText
        {
            get { return this.licenceText; }
            set { this.licenceText = value; }
        }

        public void Dispose()
        {
            // Raise the Disposing event
            this.OnDisposing(EventArgs.Empty);

            // Clear events
            this.Disposing = null;
            this.FileNameChanged = null;

            // Dispose all sprites
            foreach (var sprite in this.Sprites)
                sprite.Dispose();

            // Dispose all sprite groups
            foreach (var spriteGroup in this.Subgroups)
                spriteGroup.Dispose();

            // Raise the Disposed event
            this.OnDisposed(EventArgs.Empty);

            // Clear the disposed event
            this.Disposed = null;
        }

        public SpriteFile Clone()
        {
            // Create a new sprite file
            var result = new SpriteFile(this.FileName, this.LicenceText);

            // Copy the sprites over
            foreach (var sprite in this.Sprites)
                result.Sprites.Add(sprite.Clone());

            // Copy the sprite groups over
            foreach (var spriteGroup in this.Subgroups)
                result.Subgroups.Add(spriteGroup.Clone());

            // Return the result
            return result;
        }

        private void OnFileNameChanged(EventArgs e)
        {
            // Cache the handler
            var handler = this.FileNameChanged;

            // If the handler isn't null
            if (handler != null)
                // Call the handler
                handler(this, e);
        }

        private void OnDisposing(EventArgs e)
        {
            // Cache the handler
            var handler = this.Disposing;

            // If the handler isn't null
            if (handler != null)
                // Call the handler
                handler(this, e);
        }

        private void OnDisposed(EventArgs e)
        {
            // Cache the handler
            var handler = this.Disposed;

            // If the handler isn't null
            if (handler != null)
                // Call the handler
                handler(this, e);
        }
    }
}
