using System;
using System.Collections.ObjectModel;

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
    public class SpriteGroupCollection :
        ObservableCollection<SpriteGroup>, IDisposable
    {
        private readonly ISpriteGroup owner;

        internal SpriteGroupCollection(ISpriteGroup owner) :
            base()
        {
            this.owner = owner;
        }

        public new SpriteGroup this[int index]
        {
            get { return base[index]; }
            set
            {
                if (base[index] != value)
                    this.SetItem(index, value);
            }
        }

        public void Dispose()
        {
            foreach (var spriteGroup in base.Items)
                spriteGroup.Dispose();
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

        protected override void SetItem(int index, SpriteGroup item)
        {
            var newItem = (item.Owner == null) ? item : item.Clone();

            newItem.Owner = this.owner;

            base.SetItem(index, newItem);
        }

        public SpriteGroup Add(Identifier namespaceIdentifier)
        {
            return this.Add(new SpriteGroup(namespaceIdentifier));
        }

        public new SpriteGroup Add(SpriteGroup item)
        {
            base.Add(item);

            return base[base.Count - 1];
        }

        public SpriteGroup Insert(int index, Identifier namespaceIdentifier)
        {
            var spriteGroup = new SpriteGroup(namespaceIdentifier, this.owner);
            return this.InsertInternal(index, spriteGroup);
        }

        public new SpriteGroup Insert(int index, SpriteGroup item)
        {
            var newItem = (item.Owner == null) ? item : item.Clone();

            newItem.Owner = this.owner;

            return this.InsertInternal(index, newItem);
        }

        private SpriteGroup InsertInternal(int index, SpriteGroup item)
        {
            var newItem = (item.Owner == null) ? item : item.Clone();

            newItem.Owner = this.owner;

            base.InsertItem(index, newItem);

            return newItem;
        }

        protected override void InsertItem(int index, SpriteGroup item)
        {
            var newItem = (item.Owner == null) ? item : item.Clone();

            newItem.Owner = this.owner;

            base.InsertItem(index, newItem);
        }
    }
}
