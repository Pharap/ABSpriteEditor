using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using ABSpriteEditor.Controls;
using ABSpriteEditor.Properties;
using ABSpriteEditor.Sprites;
using ABSpriteEditor.Sprites.IO;
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
        public MainForm()
        {
            InitializeComponent();
            this.InitialiseTabControlImageList();
        }

        #region Events

        #region Menu Strip Events

        #region File Menu Events

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Add a new tab
            var newTab = this.AddNewTab();

            // If this is the first tab
            if (this.tabControl.TabCount == 1)
                // Watch the tab
                this.WatchTab(newTab);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the open file dialogue
            var result = this.openFileDialogue.ShowDialog();

            // If the user cancelled
            if (result == DialogResult.Cancel)
                // Exit early
                return;

            // Retrieve the user's chosen file names
            foreach (var filePath in this.openFileDialogue.FileNames)
            {
                #if !DEBUG
                try
                {
                #endif
                    // Load the sprite file
                    var spriteFile = XmlSpriteFileHelper.Load(filePath);

                    // Get the file name without extension
                    var fileName = Path.GetFileNameWithoutExtension(filePath);

                    // Add a new tab to the tab control
                    var newTab = this.AddNewTab(spriteFile, fileName, filePath);

                    // If this is the first tab
                    if (this.tabControl.TabCount == 1)
                        // Watch the tab
                        this.WatchTab(newTab);
                #if !DEBUG
                }
                catch (FormatException formatException)
                {
                    // Log the exception to a file
                    var logFile = ErrorLogHelper.CreateErrorLog(formatException);

                    // Inform the user that the file contained errors and a log has been created
                    var errorResult = ErrorsHelper.ShowFileContainedErrorsError(filePath, logFile);

                    // If the user cancelled
                    if (errorResult == DialogResult.Cancel)
                        // Exit the function
                        return;
                    // Otherwise
                    else
                        // Continue to the next file
                        continue;
                }
                catch (XmlException xmlException)
                {
                    // Log the exception to a file
                    var logFile = ErrorLogHelper.CreateErrorLog(xmlException);

                    // Inform the user that the file contained errors and a log has been created
                    var errorResult = ErrorsHelper.ShowFileContainedErrorsError(filePath, logFile);

                    // If the user cancelled
                    if (errorResult == DialogResult.Cancel)
                        // Exit the function
                        return;
                    // Otherwise
                    else
                        // Continue to the next file
                        continue;
                }
                catch (Exception exception)
                {
                    // Log the exception to a file
                    var logFilePath = ErrorLogHelper.CreateErrorLog(exception);

                    // Inform the user that an exception has been logged
                    ErrorsHelper.ShowUnexpectedExceptionLoggedError(logFilePath);
                }
                #endif
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // If there are no open tabs
            if (this.tabControl.TabCount == 0)
            {
                // Show the user an error message
                ErrorsHelper.ShowNoFilesToSaveError();

                // Exit early
                return;
            }

            // Defer to a more specialised function
            this.SaveActiveSpriteFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // If there are no open tabs
            if (this.tabControl.TabCount == 0)
            {
                // Show the user an error message
                ErrorsHelper.ShowNoFilesToSaveError();

                // Exit early
                return;
            }

            // Defer to a more specialised function
            this.SaveActiveSpriteFile(true);
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // If there are no open tabs
            if (this.tabControl.TabCount == 0)
            {
                // Show the user an error message
                ErrorsHelper.ShowNoFilesToExportError();

                // Exit early
                return;
            }

            // Retrieve the selected tab page
            var tabPage = this.tabControl.SelectedTab;

            // Retrieve the sprite editor panel
            var spriteEditorPanel = (tabPage.Tag as SpriteEditorPanel);

            // If the sprite editor panel is null
            if (spriteEditorPanel == null)
                // Exit early
                return;

            // Get the sprite file
            var spriteFile = spriteEditorPanel.SpriteFile;

            // Determine whether the sprite file being exported violates the ODR
            if (ODRHelper.ViolatesODR(spriteFile))
            {
                // Show the user an ODR violation warning
                if (WarningsHelper.ShowSpriteFileViolatesTheODRWarning() == DialogResult.Cancel)
                    // If the user cancelled, exit early
                    return;
            }

            // If the sprite file's name is not null
            if (spriteFile.FileName != null)
                // Set the export file name to match the sprite file's name
                this.exportFileDialogue.FileName = spriteFile.FileName;

            // Show the user the export file dialogue
            var result = this.exportFileDialogue.ShowDialog();

            // If the user cancels the dialogue
            if (result == DialogResult.Cancel)
                // Exit early
                return;

            // Retrieve the user's chosen file path
            var filePath = this.exportFileDialogue.FileName;

            // Create a new export form to show the user
            var exportForm = new ExportForm();

            // Set the licence text from the sprite's licence text
            exportForm.LicenceText = spriteFile.LicenceText;

            // Show the user the export form
            var exportResult = exportForm.ShowDialog();

            // If the user cancelled the form
            if (exportResult == DialogResult.Cancel)
                // Exit early
                return;

            // Set the sprite's licence text from the form's licence text
            spriteFile.LicenceText = exportForm.LicenceText;

            // Retrieve the chosen format from the export form
            var format = exportForm.Format;

            // If the sprite file's file name is null
            if (spriteFile.FileName == null)
            {
                // Get the file name from the user's chosen path without the extension
                var fileName = Path.GetFileNameWithoutExtension(filePath);

                // Set the sprite file's name
                spriteFile.FileName = fileName;

                // Set the tab's filename
                tabPage.Text = fileName;
            }

            // Export the sprite file as a header file
            SpriteFileHelper.Save(filePath, spriteFile, format);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Try to close the current tab
            this.CloseTab(this.tabControl.SelectedTab);
        }

        #endregion

        #endregion

        #region Tab Control Events

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            // If the selected tab is not null
            if (e.TabPage != null)
                // Watch the tab
                this.WatchTab(e.TabPage);
        }

        private void tabControl_Deselected(object sender, TabControlEventArgs e)
        {
            // If the tab page isn't null
            if (e.TabPage != null)
                // Unwatch the tab
                this.UnwatchTab(e.TabPage);
        }

        private void SelectedTab_Edited(object sender, EventArgs e)
        {
            // If the event sender is the editor associated with the selected tab
            if (sender == this.tabControl.SelectedTab.Tag)
            {
                // Change the selected tab's image key to reflect that a sprite has been edited
                this.tabControl.SelectedTab.ImageKey = unsavedKey;
            }
        }

        void BitmapEditor_ImageChanged(object sender, EventArgs e)
        {
            // Get the bitmap editor panel
            var editor = sender as BitmapEditorPanel;

            // If the sender was not a bitmap editor panel
            if (editor == null)
                // Exit
                return;

            // If the current image is not null
            if (editor.Image != null)
            {
                // Format the image dimensions to a string
                var dimensions = string.Format("{0}: {1}x{2}", Strings.Dimensions, editor.Image.Width, editor.Image.Height);

                // Display that string in the status label
                this.frameDimensionsStatusLabel.Text = dimensions;
            }
            // Otherwise, if the current image is null
            else
            {
                // Format the image dimensions to a string
                var dimensions = string.Format("{0}: ", Strings.Dimensions);

                // Display that string in the status label
                this.frameDimensionsStatusLabel.Text = dimensions;
            }
        }

        #endregion

        #region Tab Context Menu Events

        private void closeTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the context strip's location
            var point = this.tabContextMenuStrip.Location;

            // Localise the location to the tree view
            var localPoint = this.tabControl.PointToClient(point);

            // Close the tab located at the localised point
            this.CloseTab(this.GetTabAt(localPoint));
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Iterate through the available tabs
            for (var index = 0; index < this.tabControl.TabCount; ++index)
                // Try to close each tab in turn
                this.CloseTab(this.tabControl.TabPages[index]);
        }

        private void closeLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the context strip's location
            var point = this.tabContextMenuStrip.Location;

            // Localise the location to the tree view
            var localPoint = this.tabControl.PointToClient(point);

            // Get the selected tab
            var tab = this.GetTabAt(localPoint);

            // If no tab was selected
            if(tab == null)
                // Exit
                return;

            var index = 0;

            while (index < this.tabControl.TabCount)
            {
                // Cache the tab at the current index
                var currentTab = this.tabControl.TabPages[index];

                if (currentTab == tab)
                    break;

                if (!this.CloseTab(currentTab))
                    ++index;
            }
        }

        private void closeRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the context strip's location
            var point = this.tabContextMenuStrip.Location;

            // Localise the location to the tree view
            var localPoint = this.tabControl.PointToClient(point);

            // Get the index of the selected tab
            var tabIndex = this.GetIndexOfTabAt(localPoint);

            // If no tab was selected
            if (tabIndex == -1)
                // Exit
                return;

            var index = (tabIndex + 1);

            while (index < this.tabControl.TabCount)
            {
                // Cache the tab at the current index
                var currentTab = this.tabControl.TabPages[index];

                if (!this.CloseTab(currentTab))
                    ++index;
            }
        }

        private void closeOthersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the context strip's location
            var point = this.tabContextMenuStrip.Location;

            // Localise the location to the tree view
            var localPoint = this.tabControl.PointToClient(point);

            // Get the selected tab
            var tab = this.GetTabAt(localPoint);

            // If no tab was selected
            if (tab == null)
                // Exit
                return;

            var index = 0;

            while (index < this.tabControl.TabCount)
            {
                // Cache the tab at the current index
                var currentTab = this.tabControl.TabPages[index];

                if (currentTab == tab)
                {
                    ++index;

                    continue;
                }

                if (!this.CloseTab(currentTab))
                    ++index;
            }
        }

        private void saveTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the context strip's location
            var point = this.tabContextMenuStrip.Location;

            // Localise the location to the tree view
            var localPoint = this.tabControl.PointToClient(point);

            // Save the tab located at the localised point
            this.SaveTab(this.GetTabAt(localPoint));
        }

        private void saveAsTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the context strip's location
            var point = this.tabContextMenuStrip.Location;

            // Localise the location to the tree view
            var localPoint = this.tabControl.PointToClient(point);

            // Save the tab located at the localised point
            this.SaveTab(this.GetTabAt(localPoint), true);
        }

        #endregion

        #region Main Form Events

        // When the main form is closing
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // While there are tabs still open
            while (this.tabControl.TabPages.Count > 0)
            {
                // Try to close the first tab page
                if (!this.CloseTab(this.tabControl.TabPages[0]))
                {
                    // If the user cancelled closing the tab page
                    // then cancel closing the window
                    e.Cancel = true;

                    // Break out of the loop
                    break;
                }
            }
        }

        #endregion

        #endregion
    }
}
