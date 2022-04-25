using System;
using System.Windows.Forms;
using ABSpriteEditor.Sprites;

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

namespace ABSpriteEditor.Forms
{
    public partial class NewNamespaceForm : Form
    {
        private Identifier namespaceIdentifier;

        public NewNamespaceForm()
        {
            InitializeComponent();
        }

        #region Properties

        public Identifier Namespace
        {
            get { return this.namespaceIdentifier; }
        }

        #endregion

        #region Methods

        private bool TryEstablishIdentifier(string name, out Identifier resultIdentifier)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                var identifier = Identifier.Create("Images");

                var result = WarningsHelper.ShowInvalidSpriteNameChangedWarning(identifier);

                if (result == DialogResult.Cancel)
                {
                    resultIdentifier = null;
                    return false;
                }

                resultIdentifier = identifier;
                return true;
            }

            if (Identifier.IsValidIdentifier(name))
            {
                resultIdentifier = Identifier.Create(name);
                return true;
            }
            else if (Identifier.CanCreateIdentifierFrom(name))
            {
                var identifier = Identifier.Create(name);

                var result = WarningsHelper.ShowInvalidSpriteNameChangedWarning(identifier);

                if (result == DialogResult.Cancel)
                {
                    resultIdentifier = null;
                    return false;
                }

                resultIdentifier = identifier;
                return true;
            }
            else
            {
                var identifier = Identifier.Create("Images");

                var result = WarningsHelper.ShowInvalidSpriteNameChangedWarning(identifier);

                if (result == DialogResult.Cancel)
                {
                    resultIdentifier = null;
                    return false;
                }

                resultIdentifier = identifier;
                return true;
            }
        }

        #endregion

        #region Events

        private void createButton_Click(object sender, EventArgs e)
        {
            if (this.TryEstablishIdentifier(this.nameTextBox.Text, out this.namespaceIdentifier))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Identifier.IsValidIdentifier(nameTextBox.Text))
            {
                this.warningLabel.Visible = false;
            }
            else
            {
                this.warningLabel.Text = Properties.ErrorStrings.InvalidNamespaceName;
                this.warningLabel.Visible = true;
            }
        }

        #endregion
    }
}
