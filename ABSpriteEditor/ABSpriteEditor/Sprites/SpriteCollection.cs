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
    public class SpriteCollection :
        ObservableCollection<Sprite>, IDisposable
    {
        private readonly ISpriteGroup owner;

        internal SpriteCollection(ISpriteGroup owner) :
            base()
        {
            this.owner = owner;
        }

        public new Sprite this[int index]
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

        protected override void SetItem(int index, Sprite item)
        {
            var newItem = (item.Owner == null) ? item : item.Clone();

            newItem.Owner = this.owner;

            base.SetItem(index, newItem);
        }

        public new Sprite Add(Sprite item)
        {
            base.Add(item);

            return base[base.Count - 1];
        }

        public new Sprite Insert(int index, Sprite item)
        {
            var newItem = (item.Owner == null) ? item : item.Clone();

            newItem.Owner = this.owner;

            return this.InsertInternal(index, newItem);
        }

        private Sprite InsertInternal(int index, Sprite item)
        {
            var newItem = (item.Owner == null) ? item : item.Clone();

            newItem.Owner = this.owner;

            base.InsertItem(index, newItem);

            return newItem;
        }

        protected override void InsertItem(int index, Sprite item)
        {
            var newItem = (item.Owner == null) ? item : item.Clone();

            newItem.Owner = this.owner;

            base.InsertItem(index, newItem);
        }
    }
}
