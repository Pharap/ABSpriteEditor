using System;
using System.Drawing;
using System.Windows.Forms;
using ABSpriteEditor.Utilities;

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

namespace ABSpriteEditor.Controls
{
    public partial class ActionPanel : UserControl
    {
        private Bitmap image;

        public event EventHandler ImageChanged;
        public event EventHandler BeforeAction;
        public event EventHandler AfterAction;

        public ActionPanel()
        {
            InitializeComponent();
        }

        public Bitmap Image
        {
            get { return this.image; }
            set
            {
                // If the assigned image is not the current image
                if (this.image != value)
                {
                    // Change the image
                    this.image = value;

                    // Raise ImageChanged event
                    this.OnImageChanged(EventArgs.Empty);
                }
            }
        }

        #region Methods

        private void OnImageChanged(EventArgs e)
		{
			// Cache the handler
			var handler = this.ImageChanged;

			// If the handler isn't null
			if (handler != null)
				// Call the handler
				handler(this, e);
		}				

        private void OnAfterAction(EventArgs e)
        {
	        // Cache the handler
	        var handler = this.AfterAction;

	        // If the handler isn't null
	        if (handler != null)
		        // Call the handler
		        handler(this, e);
        }

        private void OnBeforeAction(EventArgs e)
        {
            // Cache the handler
            var handler = this.BeforeAction;

            // If the handler isn't null
            if (handler != null)
                // Call the handler
                handler(this, e);
        }

        #endregion

        private void flipHorizontallyToolStripButton_Click(object sender, EventArgs e)
        {
            // If there is no image
            if (this.Image == null)
                // Exit early
                return;

            // Raise before action event
            this.OnBeforeAction(EventArgs.Empty);

            // Defer to a helper class to horizontally flip the image
            BitmapHelper.FlipHorizontally(this.Image);

            // Raise after action event
            this.OnAfterAction(EventArgs.Empty);
        }

        private void flipVerticallyToolStripButton_Click(object sender, EventArgs e)
        {
            // If there is no image
            if (this.Image == null)
                // Exit early
                return;

            // Raise before action event
            this.OnBeforeAction(EventArgs.Empty);

            // Defer to a helper class to vertically flip the image
            BitmapHelper.FlipVertically(this.Image);

            // Raise after action event
            this.OnAfterAction(EventArgs.Empty);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // If there is no image
            if (this.Image == null)
                // Exit early
                return;

            // Raise before action event
            this.OnBeforeAction(EventArgs.Empty);

            // Defer to a helper class to vertically flip the image
            BitmapHelper.RollLeft(this.Image, 2);

            // Raise after action event
            this.OnAfterAction(EventArgs.Empty);
        }
    }
}
