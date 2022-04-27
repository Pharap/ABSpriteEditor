using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ABSpriteEditor.Controls;
using ABSpriteEditor.Properties;
using ABSpriteEditor.Sprites;
using ABSpriteEditor.Sprites.IO.Xml;
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

namespace ABSpriteEditor.Forms
{
    public partial class MainForm : Form
    {
        // The names of the keys used for retrieving
        // images from the tab control's image list.
        private const string savedKey = "Saved";
        private const string unsavedKey = "Unsaved";

        #region Methods

        private void InitialiseTabControlImageList()
        {
            // Create a new image list
            var imageList = new ImageList();

            // Register the saved and unsaved icons
            imageList.Images.Add(savedKey, Resources.SavedIcon32);
            imageList.Images.Add(unsavedKey, Resources.UnsavedIcon32);

            // Give the image list to the tab control
            this.tabControl.ImageList = imageList;
        }

        #region Tab Manipulation

        private void WatchTab(TabPage tabPage)
        {
            // Retrieve the sprite editor panel of the tab
            var spriteEditorPanel = (SpriteEditorPanel)tabPage.Tag;

            // Register the edit event
            spriteEditorPanel.Edited += this.SelectedTab_Edited;

            // Register the image changed event
            spriteEditorPanel.BitmapEditor.ImageChanged += this.BitmapEditor_ImageChanged;

            // Retrieve the selected tab's file path
            this.filePathStatusLabel.Text = string.Format("{0}: {1}", Strings.File, spriteEditorPanel.FilePath);
        }

        private void UnwatchTab(TabPage tabPage)
        {
            // Retrieve the sprite editor panel of the tab
            var spriteEditorPanel = (SpriteEditorPanel)tabPage.Tag;

            // Deregister the edit event
            spriteEditorPanel.Edited -= this.SelectedTab_Edited;

            // Deregister the image changed event
            spriteEditorPanel.BitmapEditor.ImageChanged -= this.BitmapEditor_ImageChanged;

            // Retrieve the selected tab's file path
            this.filePathStatusLabel.Text = string.Format("{0}: ", Strings.File);
        }

        // Retrieves the tab page whose tab contains the provided local coordinate
        private TabPage GetTabAt(Point position)
        {
            // Iterate through the available tabs
            for (var index = 0; index < this.tabControl.TabCount; ++index)
                // If the localised point is on any of the tabs
                if (this.tabControl.GetTabRect(index).Contains(position))
                    // Return the tab
                    return this.tabControl.TabPages[index];

            // If no tab was found, return null
            return null;
        }

        // Retrieves the index of the tab page whose tab contains the provided local coordinate
        private int GetIndexOfTabAt(Point position)
        {
            // Iterate through the available tabs
            for (var index = 0; index < this.tabControl.TabCount; ++index)
                // If the localised point is on any of the tabs
                if (this.tabControl.GetTabRect(index).Contains(position))
                    // Return the tab's index
                    return index;

            // If no tab was found, return -1
            return -1;
        }

        private TabPage AddNewTab()
        {
            // Add an empty sprite file with the title of 'Untitled'
            return this.AddNewTab(new SpriteFile(), "Untitled", null);
        }

        private TabPage AddNewTab(SpriteFile spriteFile, string tabTitle, string filePath)
        {
            // Creat the sprite editor panel
            var spriteEditorPanel = new SpriteEditorPanel(spriteFile)
            {
                Dock = DockStyle.Fill,
                FilePath = filePath,
                Saved = (filePath != null),
            };

            // Create the new tab page
            var tabPage = new TabPage(tabTitle)
            {
                Tag = spriteEditorPanel,
            };

            // Add the sprite editor panel to the tab page
            tabPage.Controls.Add(spriteEditorPanel);

            // Add the new tab page to the tab control
            this.tabControl.TabPages.Add(tabPage);

            // Set the image key after the tab has been added to the control
            tabPage.ImageKey = (spriteEditorPanel.Saved ? savedKey : unsavedKey);

            // Return the tab page
            return tabPage;
        }

        private bool CloseTab(TabPage tabPage)
        {
            // If the selected tab is null
            if (tabPage == null)
                // Return success
                return true;

            // Get the associated editor panel
            var spriteEditorPanel = (tabPage.Tag as SpriteEditorPanel);

            // If the associated editor panel is null
            if (spriteEditorPanel == null)
                // Return success
                return true;

            // If the data in the panel has been saved recently
            if (spriteEditorPanel.Saved)
            {
                // Close the tab without further saving
                this.tabControl.TabPages.Remove(tabPage);

                // Remove the edit event handler as a precaution
                spriteEditorPanel.Edited -= SelectedTab_Edited;

                // Register the image changed event handler as a precaution
                spriteEditorPanel.BitmapEditor.ImageChanged -= BitmapEditor_ImageChanged;

                // Return success
                return true;
            }

            // Warn the user that they are trying to discard unsaved data
            switch (WarningsHelper.ShowClosingUnsavedSpriteWarning(tabPage.Text))
            {
                // If the user wants to save changes
                case DialogResult.Yes:
                    {
                        // Save the active sprite file
                        if (this.SaveActiveSpriteFile())
                        {
                            // Now the tab has been saved it is safe to close it
                            this.tabControl.TabPages.Remove(tabPage);

                            // Remove the edit event handler as a precaution
                            spriteEditorPanel.Edited -= SelectedTab_Edited;

                            // Return success
                            return true;
                        }

                        // Return failure
                        return false;
                    }

                // If the user does not want to save changes
                case DialogResult.No:
                    {
                        // Ditch the tab without saving
                        this.tabControl.TabPages.Remove(tabPage);

                        // Return success
                        return true;
                    }

                // If the user cancelled
                case DialogResult.Cancel:
                    // Return failure (i.e. cancel)
                    return false;

                // Under any other circumstance
                default:
                    // Return failure (i.e. cancel)
                    return false;
            }
        }

        private bool SaveTab(TabPage tabPage, bool saveAs = false)
        {
            // If the selected tab is null
            if (tabPage == null)
                // Report success
                return true;

            // Try to get the sprite editor panel from the tab page
            var spriteEditorPanel = (tabPage.Tag as SpriteEditorPanel);

            // If the sprite editor panel is null
            if (spriteEditorPanel == null)
                // Report success
                return true;

            // If not in 'save as' mode
            if (!saveAs)
            {
                // If the sprite editor panel has a stored file path
                if (spriteEditorPanel.FilePath != null)
                {
                    // Save the sprite to the file path that's already in use
                    this.SaveSpriteFile(spriteEditorPanel.SpriteFile, spriteEditorPanel.FilePath);

                    // Record that the image has been saved recently
                    spriteEditorPanel.Saved = true;

                    // Set the tab's image
                    tabPage.ImageKey = savedKey;

                    // Report success
                    return true;
                }
            }

            // Show the user the save file dialogue
            var result = this.saveFileDialogue.ShowDialog();

            // If the user cancels the dialogue
            if (result == DialogResult.Cancel)
                // Report failure
                return false;

            // Retrieve the user's chosen file path
            var filePath = this.saveFileDialogue.FileName;

            // Store the file path in the editor panel
            spriteEditorPanel.FilePath = filePath;

            // Get the file name without the extension
            var fileName = Path.GetFileNameWithoutExtension(filePath);

            // Get the sprite file from the editor panel
            var spriteFile = spriteEditorPanel.SpriteFile;

            // Set the sprite file's filename
            spriteFile.FileName = fileName;

            // Set the tab page's caption
            tabPage.Text = fileName;

            // Save the sprite file
            this.SaveSpriteFile(spriteFile, filePath);

            // Record that the image has been saved recently
            spriteEditorPanel.Saved = true;

            // Set the tab's image
            tabPage.ImageKey = savedKey;

            // Report success
            return true;
        }

        #endregion

        private bool SaveActiveSpriteFile(bool saveAs = false)
        {
            // Save the currently selected tab
            return this.SaveTab(this.tabControl.SelectedTab, saveAs);
        }

        #region Specific

        private bool SaveSpriteFile(SpriteFile spriteFile, string filePath)
        {
            #if !DEBUG
            try
            {
            #endif
                // Create a temporary file path
                var tempPath = Path.ChangeExtension(filePath, "temp");

                // Save the sprite file to a new file with the original's name
                XmlSpriteFileHelper.Save(spriteFile, tempPath);

                // Saving succeeded, so delete the original
                File.Delete(filePath);

                // Instate the temporary as the official version
                File.Move(tempPath, filePath);

                // Report success
                return true;
            #if !DEBUG
            }
            catch (Exception exception)
            {
                // Log the exception to a file
                var logFilePath = ErrorLogHelper.CreateErrorLog(exception);

                // Inform the user that an exception has been logged
                ErrorsHelper.ShowUnexpectedExceptionLoggedError(logFilePath);

                // Report failure
                return false;
            }
#endif
        }

        #endregion

        #endregion
    }
}
