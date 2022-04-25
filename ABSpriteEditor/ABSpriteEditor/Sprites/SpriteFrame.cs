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
    public class SpriteFrame : IDisposable
    {
        private Bitmap image = null;
        private string text = null;
        private Sprite owner = null;

        public event EventHandler Disposing;
        public event EventHandler Disposed;
        public event EventHandler TextChanged;

        public SpriteFrame(Bitmap image)
        {
            // If the image is null
            if (image == null)
                // Throw a null argument exception
                throw new ArgumentNullException("image");

            this.image = image;
        }

        public SpriteFrame(Bitmap image, string text) :
            this(image)
        {
            this.text = text;
        }

        internal SpriteFrame(Bitmap image, string text, Sprite owner) :
            this(image, text)
        {
            this.owner = owner;
        }

        public Sprite Owner
        {
            get { return this.owner; }
            internal set { this.owner = value; }
        }

        public Bitmap Image
        {
            get { return this.image; }
            internal set { this.image = value; }
        }

        public string Text
        {
            get { return this.text; }
            set
            {
                // If the assigned text is not the same as the current text
                if (this.text != value)
                {
                    // Change the text
                    this.text = value;

                    // Raise the TextChanged event
                    this.OnTextChanged(EventArgs.Empty);
                }
            }
        }

        public void Dispose()
        {
            // Raise the Disposing event
            this.OnDisposing(EventArgs.Empty);

            // Clear events
            this.Disposing = null;
            this.TextChanged = null;

            // Dispose the image
            this.image.Dispose();

            // Clear the disposed event
            this.Disposed = null;
        }

        public SpriteFrame Clone()
        {
            // Create a new sprite frame, relying on Bitmap's constructor to do the copying
            return new SpriteFrame(new Bitmap(this.image), this.Text);
        }

        private void OnTextChanged(EventArgs e)
        {
            // Cache the handler
            var handler = this.TextChanged;

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
