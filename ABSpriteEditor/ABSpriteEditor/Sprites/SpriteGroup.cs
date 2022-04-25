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
    public class SpriteGroup : IDisposable, ISpriteGroup, IIdentifiable
    {
        private readonly SpriteCollection sprites;
        private readonly SpriteGroupCollection subgroups;
        private ISpriteGroup owner;
        private Identifier name;

        public event EventHandler Disposing;
        public event EventHandler Disposed;
        public event EventHandler NamespaceChanged;

        public SpriteGroup(Identifier name)
        {
            // If the name is null
            if (name == null)
                // Throw a null argument exception
                throw new ArgumentNullException("namespace");

            this.name = name;
            this.sprites = new SpriteCollection(this);
            this.subgroups = new SpriteGroupCollection(this);
        }

        internal SpriteGroup(Identifier name, ISpriteGroup owner) :
            this(name)
        {
            this.owner = owner;
        }

        Identifier IIdentifiable.Identifier
        {
            get { return this.Namespace; }
        }

        public ISpriteGroup Owner
        {
            get { return this.owner; }
            internal set { this.owner = value; }
        }

        public Identifier Namespace
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

                    // Raise the NamespaceChanged event
                    this.OnNamespaceChanged(EventArgs.Empty);
                }
            }
        }

        public SpriteCollection Sprites
        {
            get { return this.sprites; }
        }

        public SpriteGroupCollection Subgroups
        {
            get { return this.subgroups; }
        }

        public void Dispose()
        {
            // Raise the Disposing event
            this.OnDisposing(EventArgs.Empty);

            // Clear events
            this.Disposing = null;
            this.NamespaceChanged = null;

            // Dispose all sprites
            foreach (var sprite in this.Sprites)
                sprite.Dispose();

            // Dispose all subgroups
            foreach (var subgroup in this.Subgroups)
                subgroup.Dispose();

            // Raise the Disposed event
            this.OnDisposed(EventArgs.Empty);

            // Clear the disposed event
            this.Disposed = null;
        }

        public SpriteGroup Clone()
        {
            // Create a new sprite group
            var result = new SpriteGroup(this.Namespace);

            // Copy the sprites over
            foreach (var sprite in this.Sprites)
                result.Sprites.Add(sprite.Clone());

            // Copy the sprite groups over
            foreach (var spriteGroup in this.Subgroups)
                result.Subgroups.Add(spriteGroup.Clone());

            // Return the result
            return result;
        }

        private void OnNamespaceChanged(EventArgs e)
        {
            // Cache the handler
            var handler = this.NamespaceChanged;

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
