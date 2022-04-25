using System;
using System.Collections.ObjectModel;
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
    public class SpriteFrameCollection :
        ObservableCollection<SpriteFrame>, IDisposable
    {
        private readonly Sprite owner;

        internal SpriteFrameCollection(Sprite owner) :
            base()
        {
            this.owner = owner;
        }

        public new SpriteFrame this[int index]
        {
            get { return base[index]; }
            set
            {
                // If the image dimensions don't match the dimensions of the owning sprite
                if ((value.Image.Width != this.owner.Width) || (value.Image.Height != this.owner.Height))
                    // Throw an argument exception
                    throw new ArgumentException("Image size did not match the containing Sprite's size");

                if (base[index] != value)
                    this.SetItem(index, value);
            }
        }

        public void Dispose()
        {
            foreach (var frame in base.Items)
                frame.Dispose();
        }

        protected override void RemoveItem(int index)
        {
            var item = base[index];
            base.RemoveItem(index);
            item.Owner = null;
        }

        protected override void ClearItems()
        {
            foreach (var item in base.Items)
                item.Owner = null;

            base.ClearItems();
        }

        protected override void SetItem(int index, SpriteFrame item)
        {
            var newItem = (item.Owner == null) ? item : item.Clone();

            newItem.Owner = this.owner;

            base.SetItem(index, newItem);
        }

        public SpriteFrame Add(string name)
        {
            var image = new Bitmap(this.owner.Width, this.owner.Height);
            var frame = new SpriteFrame(image, name, this.owner);
            return this.AddInternal(frame);
        }

        public SpriteFrame Add(Bitmap image, string name)
        {
            if ((image.Width != this.owner.Width) || (image.Height != this.owner.Height))
                throw new ArgumentException("Image size did not match the containing Sprite's size");

            return AddInternal(new SpriteFrame(image, name));
        }

        public new SpriteFrame Add(SpriteFrame item)
        {
            if ((item.Image.Width != this.owner.Width) || (item.Image.Height != this.owner.Height))
                throw new ArgumentException("Image size did not match the containing Sprite's size");

            return this.AddInternal(item);
        }

        private SpriteFrame AddInternal(SpriteFrame item)
        {
            base.Add(item);

            return base[base.Count - 1];
        }

        public SpriteFrame Insert(int index, string name)
        {
            var image = new Bitmap(this.owner.Width, this.owner.Height);
            var frame = new SpriteFrame(image, name, this.owner);
            return this.InsertInternal(index, frame);
        }

        public SpriteFrame Insert(int index, Bitmap image, string name)
        {
            return this.InsertInternal(index, new SpriteFrame(image, name));
        }

        public new SpriteFrame Insert(int index, SpriteFrame item)
        {
            return this.InsertInternal(index, item);
        }

        private SpriteFrame InsertInternal(int index, SpriteFrame item)
        {
            var newItem = (item.Owner == null) ? item : item.Clone();

            newItem.Owner = this.owner;

            base.InsertItem(index, newItem);

            return newItem;
        }

        protected override void InsertItem(int index, SpriteFrame item)
        {
            if ((item.Image.Width != this.owner.Width) || (item.Image.Height != this.owner.Height))
                throw new ArgumentException("Image size did not match the containing Sprite's size");

            var newItem = (item.Owner == null) ? item : item.Clone();

            newItem.Owner = this.owner;

            base.InsertItem(index, newItem);
        }
    }
}