using System;
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

namespace ABSpriteEditor.Sprites
{
    public class Sprite : IDisposable, IIdentifiable
    {
        private readonly SpriteFrameCollection frames;
        private readonly Size size;
        private ISpriteGroup owner;
        private Identifier name;

        public event EventHandler Disposing;
        public event EventHandler Disposed;
        public event EventHandler NameChanged;

        public Sprite(int width, int height, Identifier name)
        {
            // If the width is zero or negative
            if (width <= 0)
                // Throw an out of range exception
                throw new ArgumentOutOfRangeException("width cannot be negative or zero");

            // If the height is zero or negative
            if (height <= 0)
                // Throw an out of range exception
                throw new ArgumentOutOfRangeException("height cannot be negative or zero");

            // If the value is null
            if (name == null)
                // Throw a null argument exception
                throw new ArgumentNullException("name");

            this.frames = new SpriteFrameCollection(this);
            this.size = new Size(width, height);
            this.name = name;
        }

        internal Sprite(int width, int height, Identifier name, ISpriteGroup owner) :
            this(width, height, name)
        {
            this.owner = owner;
        }

        Identifier IIdentifiable.Identifier
        {
            get { return this.Name; }
        }

        public ISpriteGroup Owner
        {
            get { return this.owner; }
            internal set { this.owner = value; }
        }

        public Size Size
        {
            get { return this.size; }
        }

        public int Width
        {
            get { return this.size.Width; }
        }

        public int Height
        {
            get { return this.size.Height; }
        }

        public Identifier Name
        {
            get { return this.name; }
            set
            {
                // If the value is null
                if (value == null)
                    // Throw a null argument exception
                    throw new ArgumentNullException("value");

                // If the assigned name is not the same as the current name
                if (this.name != value)
                {
                    // Change the name
                    this.name = value;

                    // Raise the NameChanged event
                    this.OnNameChanged(EventArgs.Empty);
                }
            }
        }

        public SpriteFrameCollection Frames
        {
            get { return this.frames; }
        }

        public void Dispose()
        {
            // Raise the Disposing event
            this.OnDisposing(EventArgs.Empty);

            // Clear events
            this.Disposing = null;
            this.NameChanged = null;

            // Dispose all frames
            this.frames.Dispose();

            // Raise the Disposed event
            this.OnDisposed(EventArgs.Empty);

            // Clear the disposed event
            this.Disposed = null;
        }

        public Sprite Clone()
        {
            // Create a new sprite
            var result = new Sprite(this.Width, this.Height, this.Name);

            // Copy the sprite frames over
            foreach (var frame in this.Frames)
                result.Frames.Add(frame);

            // Return the result
            return result;
        }

        private void OnNameChanged(EventArgs e)
        {
            // Cache the handler
            var handler = this.NameChanged;

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