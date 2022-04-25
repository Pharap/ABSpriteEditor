using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ABSpriteEditor.Forms;
using ABSpriteEditor.Sprites;
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
    public partial class SpriteEditorPanel : UserControl
    {
        private SpriteFile spriteFile;
        private TreeNode spriteFileNode = null;
        private string filePath = null;
        private bool saved = false;
        private Random randomGenerator = new Random();

        private readonly ImageList imageList16;
        private readonly ImageList imageList32;

        public event EventHandler Edited;

        public SpriteEditorPanel()
            : this(new SpriteFile())
        {
        }

        public SpriteEditorPanel(SpriteFile spriteFile)
        {
            this.spriteFile = spriteFile;

            this.imageList16 = this.CreateImageList16();
            this.imageList32 = this.CreateImageList32();

            InitializeComponent();

            this.colourSelectPanel.SelectBlack();
            this.toolSelectPanel.SelectPixelSetTool();

            this.treeView.ImageList = imageList16;

            this.InitialiseSpriteFile();
        }

        #region Properties

        public SpriteFile SpriteFile
        {
            get { return this.spriteFile; }
        }

        public bool Saved
        {
            get { return this.saved; }
            set { this.saved = value; }
        }

        public string FilePath
        {
            get { return this.filePath; }
            set { this.filePath = value; }
        }

        public BitmapEditorPanel BitmapEditor
        {
            get { return this.bitmapEditor; }
        }

        #endregion

        #region Methods

        private void NotifyEdit()
        {
            // Recognise that the changed that have been made are unsaved
            this.saved = false;

            // Raise the edited event
            this.OnEdited(EventArgs.Empty);
        }

        private void OnEdited(EventArgs e)
        {
            // Cache event handler
            var handler = this.Edited;

            // If the event handler isn't null
            if (handler != null)
                // Call the event handler
                handler(this, e);
        }

        private Sprite CreateSpriteFromInfo(SpriteCreationInfo info)
        {
            // Create a new sprite
            var sprite = new Sprite(info.Width, info.Height, info.Name);

            // Fill it with empty sprites named 'Frame #'
            for (int index = 0; index < info.Frames; ++index)
                sprite.Frames.Add(new Bitmap(info.Width, info.Height), string.Format("Frame {0}", index));

            // Return the sprite
            return sprite;
        }

        #endregion

        #region Events

        #region Sprites

        void spriteFrame_Disposing(object sender, EventArgs e)
        {
            // Get the sprite frame
            var spriteFrame = (SpriteFrame)sender;

            // If the image being removed holds the image that was being edited
            if (this.bitmapEditor.Image == spriteFrame.Image)
                // Remove the image so the editor doesn't crash
                this.bitmapEditor.Image = null;
        }

        #endregion

        #region Collections

        private void spriteFile_FileNameChanged(object sender, EventArgs e)
        {
            // Update the sprite file node text
            this.spriteFileNode.Text = this.spriteFile.FileName;
        }

        private void frames_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Make a note of the fact a sprite collection has been edited
            this.NotifyEdit();
        }

        // TODO: Review whether this is actually needed
        private void sprites_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Make a note of the fact a collection has been edited
            this.NotifyEdit();
        }

        // TODO: Review whether this is actually needed
        private void subgroups_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Make a note of the fact a collection has been edited
            this.NotifyEdit();
        }

        #endregion

        #region BitmapEditor

        private void bitmapEditor_ImageChanged(object sender, EventArgs e)
        {
            // Update the action panel's image reference
            this.actionPanel.Image = this.bitmapEditor.Image;
        }

        private void bitmapEditor_ImageEndEdit(object sender, EventArgs e)
        {
            // Queue repaint for tree view
            this.treeView.Invalidate();

            // Make a note of the fact an image has been edited
            this.NotifyEdit();
        }

        private void bitmapEditor_KeyDown(object sender, KeyEventArgs e)
        {
            // Handle shortcut keys
            switch (e.KeyCode)
            {
                case Keys.D1:
                    this.colourSelectPanel.SelectBlack();
                    return;

                case Keys.D2:
                    this.colourSelectPanel.SelectWhite();
                    return;

                case Keys.D3:
                    this.colourSelectPanel.SelectTransparent();
                    return;

                case Keys.P:
                    this.toolSelectPanel.SelectPixelSetTool();
                    return;

                case Keys.F:
                    this.toolSelectPanel.SelectFloodFillTool();
                    return;

                case Keys.R:
                    this.toolSelectPanel.SelectRectangleFillTool();
                    return;

                case Keys.O:
                    this.toolSelectPanel.SelectRectangleOutlineTool();
                    return;
            }
        }

        #endregion

        #region Action Strip

        private void actionPanel_AfterAction(object sender, EventArgs e)
        {
            // Update the editor's display
            this.bitmapEditor.Invalidate();

            // Register that an edit has occurred
            this.NotifyEdit();
        }

        #endregion

        #region Colour Tool Strip

        private void colourSelectPanel_ColourChanged(object sender, EventArgs e)
        {
            // When the colou select panel changes the selected colou
            // assign the colou to the bitmap editor.
            this.bitmapEditor.ForeColor = this.colourSelectPanel.Colour;
        }

        #endregion

        #region Tool Strip

        private void toolSelectPanel_ToolChanged(object sender, EventArgs e)
        {
            // When the tool select panel changes the selected tool
            // assign the tool to the bitmap editor.
            this.bitmapEditor.Tool = this.toolSelectPanel.Tool;
        }

        #endregion

        #region TreeView

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Cache the tag for brevity
            var tag = e.Node.Tag;

            if (tag is SpriteFile)
            {
                // Update the tree view tool strip buttons
                this.addFrameToolStripButton.Enabled = false;
                this.addSpriteToolStripButton.Enabled = true;
                this.addNamespaceToolStripButton.Enabled = true;
                this.removeToolStripButton.Enabled = false;
                this.duplicateToolStripButton.Enabled = false;
                this.moveUpToolStripButton.Enabled = false;
                this.moveDownToolStripButton.Enabled = false;
            }

            if (tag is SpriteGroup)
            {
                // Update the tree view tool strip buttons
                this.addFrameToolStripButton.Enabled = false;
                this.addSpriteToolStripButton.Enabled = true;
                this.addNamespaceToolStripButton.Enabled = true;
                this.removeToolStripButton.Enabled = true;
                this.duplicateToolStripButton.Enabled = true;
                this.moveUpToolStripButton.Enabled = true;
                this.moveDownToolStripButton.Enabled = true;
            }

            // If the associated tag is a sprite
            if (tag is Sprite)
            {
                // Retrieve the sprite
                var sprite = (tag as Sprite);

                // If the sprite has at least one frame
                if (sprite.Frames.Count > 0)
                    // Select the first frame for editing
                    this.SelectForEditing(sprite.Frames[0].Image);
                // Otherwise
                else
                    // Set the edited image to null
                    this.bitmapEditor.Image = null;

                // Update the tree view tool strip buttons
                this.addFrameToolStripButton.Enabled = true;
                this.addSpriteToolStripButton.Enabled = false;
                this.addNamespaceToolStripButton.Enabled = false;
                this.removeToolStripButton.Enabled = true;
                this.duplicateToolStripButton.Enabled = true;
                this.moveUpToolStripButton.Enabled = true;
                this.moveDownToolStripButton.Enabled = true;
            }

            // If the associated tag is a frame
            if (tag is SpriteFrame)
            {
                // Retrieve the frame
                var frame = (tag as SpriteFrame);

                // Select the frame for editing
                this.SelectForEditing(frame.Image);

                // Update the tree view tool strip buttons
                this.addFrameToolStripButton.Enabled = false;
                this.addSpriteToolStripButton.Enabled = false;
                this.addNamespaceToolStripButton.Enabled = false;
                this.removeToolStripButton.Enabled = true;
                this.duplicateToolStripButton.Enabled = true;
                this.moveUpToolStripButton.Enabled = true;
                this.moveDownToolStripButton.Enabled = true;
            }
        }

        private void treeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            // Cache the relevant parts of the event arguments for brevity
            var label = e.Label;
            var node = e.Node;
            var tag = node.Tag;

            // If the associated tag is a sprite file
            if (tag is SpriteFile)
            {
                // Don't allow the sprite file name to be edited
                e.CancelEdit = true;
            }
            // If the associated tag is a sprite group
            else if (tag is SpriteGroup)
            {
                // Defer to a more specialised function
                this.treeView_AfterLabelEditSpriteGroup(sender, e);
            }
            // If the associated tag is a sprite
            else if (tag is Sprite)
            {
                // Defer to a more specialised function
                this.treeView_AfterLabelEditSprite(sender, e);
            }
            // If the associated tag is a sprite frame
            else if (tag is SpriteFrame)
            {
                // Defer to a more specialised function
                this.treeView_AfterLabelEditSpriteFrame(sender, e);
            }
        }

        private void treeView_AfterLabelEditSpriteGroup(object sender, NodeLabelEditEventArgs e)
        {
            // Cache the label for brevity
            var label = e.Label;

            // If the label is null (i.e. editing was cancelled)
            if (label == null)
                // Exit early
                return;

            // Retrieve the sprite group
            var spriteGroup = (e.Node.Tag as SpriteGroup);

            // If a suitable identifier cannot be created from the label
            if (!Identifier.CanCreateIdentifierFrom(label))
            {
                // Show the user an error
                ErrorsHelper.ShowInvalidNamespaceNameError();

                // Then exit
                return;
            }

            // Create an identifier from the label
            var identifier = Identifier.Create(label);

            // If the label was not already a valid identifier
            if (!Identifier.IsValidIdentifier(label))
            {
                // Warn the user that the name is due to be changed
                var result = WarningsHelper.ShowInvalidNamespaceNameChangedWarning(identifier);

                // If the user chose to cancel the rename
                if (result == DialogResult.Cancel)
                    // Exit
                    return;
            }

            // Cancel the edit
            e.CancelEdit = true;

            // Set the sprite group's namespace
            spriteGroup.Namespace = identifier;

            // Set the node's text to the (potentially) corrected identifier
            e.Node.Text = identifier.ToString();

            // Consider a name edit to be an edit
            this.NotifyEdit();
        }

        private void treeView_AfterLabelEditSprite(object sender, NodeLabelEditEventArgs e)
        {
            // Cache the label for brevity
            var label = e.Label;

            // If the label is null (i.e. editing was cancelled)
            if (label == null)
                // Exit early
                return;

            // Retrieve the sprite
            var sprite = (e.Node.Tag as Sprite);

            // If the sprite is null
            if (sprite == null)
                // Exit early
                return;

            // If a suitable identifier cannot be created from the label
            if (!Identifier.CanCreateIdentifierFrom(label))
            {
                // Show the user an error
                ErrorsHelper.ShowInvalidSpriteNameError();

                // Then exit
                return;
            }

            // Create an identifier from the label
            var identifier = Identifier.Create(label);

            // If the label was not already a valid identifier
            if (!Identifier.IsValidIdentifier(label))
            {
                // Warn the user that the name is due to be changed
                var result = WarningsHelper.ShowInvalidSpriteNameChangedWarning(identifier);

                // If the user chose to cancel the rename
                if (result == DialogResult.Cancel)
                    // Exit
                    return;
            }

            // Cancel the edit
            e.CancelEdit = true;

            // Set the sprite's name
            sprite.Name = identifier;

            // Set the node's text to the (potentially) corrected identifier
            e.Node.Text = identifier.ToString();

            // Consider a name edit to be an edit
            this.NotifyEdit();
        }

        private void treeView_AfterLabelEditSpriteFrame(object sender, NodeLabelEditEventArgs e)
        {
            // Cache the label for brevity
            var label = e.Label;

            // If the label is null (i.e. editing was cancelled)
            if (label == null)
                // Exit early
                return;

            // Retrieve the sprite frame
            var spriteFrame = (e.Node.Tag as SpriteFrame);

            // If the sprite frame is null
            if (spriteFrame == null)
                // Exit early
                return;

            // Set the frame's text from the edited label
            spriteFrame.Text = label;

            // Consider a text edit to be an edit
            this.NotifyEdit();
        }
        
        private void treeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // When the user tries to drag a node, begin a drag operation
            this.treeView.DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void treeView_DragOver(object sender, DragEventArgs e)
        {
            // When data is dragged over the tree view, attempt to copy it
            e.Effect = (DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void treeView_DragDrop(object sender, DragEventArgs e)
        {
            // If the user has dropped a file into the list view
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Read the dropped data as a list of files
                var files = e.Data.GetData(DataFormats.FileDrop) as string[];

                // Localise the drop coordinates
                var localPoint = this.treeView.PointToClient(new Point(e.X, e.Y));

                // Find the drop target
                var target = this.treeView.GetNodeAt(localPoint);

                // If a drop target was found
                if (target != null)
                {
                    // If the target contains a sprite frame
                    if (target.Tag is SpriteFrame)
                    {
                        // Warn the user that the frame will be overwritten
                        var result = WarningsHelper.ShowFileDropOverwritesFramesWarning();

                        // If the user has cancelled the operation
                        if (result == DialogResult.Cancel)
                            // Exit
                            return;
                    }

                    // Handle a file drop
                    this.HandleFileDrop(files, target);
                }

                // Exit
                return;
            }

            // If the dragged data is a tree node
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                // Retrieve the dragged tree node
                var source = (TreeNode)e.Data.GetData(typeof(TreeNode));
                
                // Calculate the localised drop position
                var position = this.treeView.PointToClient(new Point(e.X, e.Y));

                // Try to find a destination node
                var destination = this.treeView.GetNodeAt(position);

                // If there is no destination node
                if (destination == null)
                    // Exit
                    return;

                // Attempt to handle the drag operation
                this.HandleDrag(source, destination);

                // Exit
                return;
            }
        }

        private void treeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            // Let the default rendering occur regardless
            e.DrawDefault = true;

            // If the node isn't associated with a sprite frame
            if (!(e.Node.Tag is SpriteFrame))
                // Don't do anything else, just exit
                return;

            // Otherwise, retrieve the sprite frame
            var frame = e.Node.Tag as SpriteFrame;

            // If the tree view doesn't have an associated image list
            if (this.treeView.ImageList == null)
                // Don't do anything else, just exit
                return;

            // Get the size of the images used by the tree view's image list
            var targetSize = this.treeView.ImageList.ImageSize;

            // The gap between the image and the text
            int imageTextGap = 3;

            // Calculate the target x coordinate
            var targetX = (e.Node.Bounds.X - targetSize.Width - imageTextGap);

            // Calculate the top left of the target area
            var targetLocation = new Point(targetX, e.Node.Bounds.Y);

            // If the image size matches the draw area size
            if (frame.Image.Size == targetSize)
            {
                // Draw without scaling
                e.Graphics.DrawImageUnscaled(frame.Image, targetLocation);

                // Exit
                return;
            }

            // Begin calculating the draw size
            var drawSize = targetSize;

            // If the image is wider than it is tall
            if (frame.Image.Width > frame.Image.Height)
            {
                // Calculate the width to height ratio
                var ratio = frame.Image.Width / frame.Image.Height;

                // Adjust the target height accordingly
                drawSize.Height /= ratio;
            }
            // If the image is taller than it is wide
            else if (frame.Image.Width < frame.Image.Height)
            {
                // Calculate the height to width ratio
                var ratio = frame.Image.Height / frame.Image.Width;

                // Adjust the target width accordingly
                drawSize.Width /= ratio;
            }

            // Calculate the draw coordinates in a way that centres the image
            var x = ((targetSize.Width - drawSize.Width) / 2);
            var y = ((targetSize.Height - drawSize.Height) / 2);

            // Calculate the position to draw at
            var drawLocation = new Point(targetLocation.X + x, targetLocation.Y + y);

            // Make a bounding rectangle specifying the draw target
            // (This is where the image list image would normally be drawn.)
            var drawBounds = new Rectangle(drawLocation, drawSize);

            // If the image needs upscaling
            if ((frame.Image.Width <= targetSize.Width) && (frame.Image.Height <= targetSize.Height))
            {
                // Work out the scale
                var scale = (frame.Image.Width > frame.Image.Height) ?
                    (targetSize.Width / frame.Image.Width) :
                    (targetSize.Height / frame.Image.Height);

                // Use custom upscaling
                GraphicsDrawingHelper.DrawScaledImage(e.Graphics, frame.Image, drawLocation.X, drawLocation.Y, scale);
            }
            // If the image needs downscaling
            else
            {
                // Use bicubic interpolation
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

                // Draw the image with native downscaling
                e.Graphics.DrawImage(frame.Image, drawLocation.X, drawLocation.Y, drawSize.Width, drawSize.Height);
            }

            // Exit
            return;
        }

        private void treeView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // If F2 was pressed
                case Keys.F2:
                    {
                        // If there the selected node exists
                        if (this.treeView.SelectedNode != null)
                            // Begin editing it
                            this.treeView.SelectedNode.BeginEdit();

                        // Confirm that the key has been handled
                        e.Handled = true;
                    }
                    break;
            }
        }

        #endregion

        #region Tree View Tool Strip

        private void moveUpToolStripButton_Click(object sender, EventArgs e)
        {
            // Move the selected node up
            this.MoveNodeUp(this.treeView.SelectedNode);
        }

        private void moveDownToolStripButton_Click(object sender, EventArgs e)
        {
            // Move the selected node down
            this.MoveNodeDown(this.treeView.SelectedNode);
        }

        private void removeToolStripButton_Click(object sender, EventArgs e)
        {
            // Remove the selected node
            this.RemoveNodeItem(this.treeView.SelectedNode);
        }

        private void duplicateToolStripButton_Click(object sender, EventArgs e)
        {
            // Cache the selected node for brevity
            var selectedNode = this.treeView.SelectedNode;

            // If the selected node is not null
            if (selectedNode != null)
                // Duplicate it
                this.Duplicate(selectedNode);
        }

        private void addFrameToolStripButton_Click(object sender, EventArgs e)
        {
            // If the selected node is not null
            if (this.treeView.SelectedNode != null)
            {
                // Try to add a new frame to that node
                this.AddSpriteFrame(this.treeView.SelectedNode);
            }
        }

        private void addSpriteToolStripButton_Click(object sender, EventArgs e)
        {
            // If the selected node is not null
            if (this.treeView.SelectedNode != null)
            {
                // Try to add a new sprite to that node
                this.AddSprite(this.treeView.SelectedNode);
            }
        }

        private void addNamespaceToolStripButton_Click(object sender, EventArgs e)
        {
            // If the selected node is not null
            if (this.treeView.SelectedNode != null)
            {
                // Try to add a new frame to that node
                this.AddSpriteGroup(this.treeView.SelectedNode);
            }
        }

        private void licenceEditToolStripButton_Click(object sender, EventArgs e)
        {
            this.EditLicence();
        }

        private void zoomInToolStripButton_Click(object sender, EventArgs e)
        {
            this.ZoomInTreeView();
        }

        private void zoomOutToolStripButton_Click(object sender, EventArgs e)
        {
            this.ZoomOutTreeView();
        }

        #endregion

        #region Tree View Context Menu

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ZoomInTreeView();
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ZoomOutTreeView();
        }

        #endregion

        #region Shared Menu Handlers

        private void addSpriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Try to interpret the sender as a context menu
            var contextMenuItem = sender as ToolStripDropDownItem;

            // Assertion for debugging without the end user getting a crash
            Debug.Assert(contextMenuItem != null, "'sender' was not a ToolStripDropDownItem");

            // If the sender is not a context menu
            if (contextMenuItem == null)
                // Exit early
                return;

            // Localise the context menu's location to the tree view
            var localPoint = this.treeView.PointToClient(contextMenuItem.Owner.Location);

            // Try to get the node at the specified point
            var node = this.treeView.GetNodeAt(localPoint);

            // If no node was found
            if (node == null)
                // Exit early
                return;

            // Defer to a more specialised function
            this.AddSprite(node);
        }

        private void addNamespaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Try to interpret the sender as a context menu
            var contextMenuItem = sender as ToolStripDropDownItem;

            // Assertion for debugging without the end user getting a crash
            Debug.Assert(contextMenuItem != null, "'sender' was not a ToolStripDropDownItem");

            // If the sender is not a context menu
            if (contextMenuItem == null)
                // Exit early
                return;

            // Localise the context menu's location to the tree view
            var localPoint = this.treeView.PointToClient(contextMenuItem.Owner.Location);

            // Try to get the node at the specified point
            var node = this.treeView.GetNodeAt(localPoint);

            // If no node was found
            if (node == null)
                // Exit early
                return;

            // Defer to a more specialised function
            this.AddSpriteGroup(node);
        }

        private void moveUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Try to interpret the sender as a context menu
            var contextMenuItem = sender as ToolStripDropDownItem;

            // Assertion for debugging without the end user getting a crash
            Debug.Assert(contextMenuItem != null, "'sender' was not a ToolStripDropDownItem");

            // If the sender is not a context menu
            if (contextMenuItem == null)
                // Exit early
                return;

            // Move the node at the context menu strip's position up
            this.MoveNodeUpAt(contextMenuItem.Owner.Location);
        }

        private void moveDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Try to interpret the sender as a context menu
            var contextMenuItem = sender as ToolStripDropDownItem;

            // Assertion for debugging without the end user getting a crash
            Debug.Assert(contextMenuItem != null, "'sender' was not a ToolStripDropDownItem");

            // If the sender is not a context menu
            if (contextMenuItem == null)
                // Exit early
                return;

            // Move the node at the context menu strip's position down
            this.MoveNodeDownAt(contextMenuItem.Owner.Location);
        }

        #endregion

        #region Sprite File Context Menu

        private void editLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.EditLicence();
        }

        #endregion

        #region Namespace Context Menu

        private void removeFromNamespaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the context strip's location
            var point = this.namespaceContextMenuStrip.Location;

            // Localise the location to the tree view
            var localPoint = this.treeView.PointToClient(point);

            // Try to get the node at the specified point
            var node = this.treeView.GetNodeAt(localPoint);

            // If no node was found
            if (node == null)
                // Exit early
                return;

            // Remove the sprite group
            this.RemoveSpriteGroup(node);
        }

        private void duplicateNamespaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the context strip's location
            var point = this.namespaceContextMenuStrip.Location;

            // Localise the location to the tree view
            var localPoint = this.treeView.PointToClient(point);

            // Try to get the node at the specified point
            var node = this.treeView.GetNodeAt(localPoint);

            // If no node was found
            if (node == null)
                // Exit early
                return;

            // Defer to more specialised function
            this.DuplicateSpriteGroup(node);
        }

        #endregion

        #region Sprite Context Menu

        private void addFrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the context strip's location
            var point = this.spriteContextMenuStrip.Location;

            // Localise the location to the tree view
            var localPoint = this.treeView.PointToClient(point);

            // Try to get the node at the specified point
            var node = this.treeView.GetNodeAt(localPoint);
            
            // If no node was found
            if (node == null)
                // Exit early
                return;

            // Add a new sprite frame to that node
            this.AddSpriteFrame(node);
        }

        private void removeFromSpriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the context strip's location
            var point = this.spriteContextMenuStrip.Location;

            // Localise the location to the tree view
            var localPoint = this.treeView.PointToClient(point);

            // Try to get the node at the specified point
            var node = this.treeView.GetNodeAt(localPoint);

            // If no node was found
            if (node == null)
                // Exit early
                return;

            // Remove the sprite
            this.RemoveSprite(node);
        }

        private void duplicateSpriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the context strip's location
            var point = this.spriteContextMenuStrip.Location;

            // Localise the location to the tree view
            var localPoint = this.treeView.PointToClient(point);

            // Try to get the node at the specified point
            var node = this.treeView.GetNodeAt(localPoint);

            // If no node was found
            if (node == null)
                // Exit early
                return;

            // Defer to more specialised function
            this.DuplicateSprite(node);
        }

        #endregion

        #region Frame Context Menu

        private void removeFrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the context strip's location
            var point = this.frameContextMenuStrip.Location;

            // Localise the location to the tree view
            var localPoint = this.treeView.PointToClient(point);

            // Try to get the node at the specified point
            var node = this.treeView.GetNodeAt(localPoint);

            // If no node was found
            if (node == null)
                // Exit early
                return;

            // Try to add a new sprite to the node
            this.RemoveSpriteFrame(node);
        }

        private void duplicateFrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the context strip's location
            var point = this.frameContextMenuStrip.Location;

            // Localise the location to the tree view
            var localPoint = this.treeView.PointToClient(point);

            // Try to get the node at the specified point
            var node = this.treeView.GetNodeAt(localPoint);

            // If no node was found
            if (node == null)
                // Exit early
                return;

            // Defer to more specialised function
            this.DuplicateSpriteFrame(node);
        }

        private void exportImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the context strip's location
            var point = this.frameContextMenuStrip.Location;

            // Localise the location to the tree view
            var localPoint = this.treeView.PointToClient(point);

            // Try to get the node at the specified point
            var node = this.treeView.GetNodeAt(localPoint);

            // If no node was found
            if (node == null)
                // Exit early
                return;

            // Get the sprite frame
            var frame = (node.Tag as SpriteFrame);

            // If the frame's text is not null or whitespace
            if (!string.IsNullOrWhiteSpace(frame.Text))
                // Set the export dialogue's default file name using a validated form of the frame's text
                this.exportFileDialogue.FileName = FileHelper.ValidateFileName(frame.Text);

            // Show the user the export dialogue
            var result = this.exportFileDialogue.ShowDialog();

            // If the user cancelled the dialogue
            if (result == DialogResult.Cancel)
                // Exit early
                return;

            // Retrieve the user's selected file
            var filePath = this.exportFileDialogue.FileName;

            // Save the frame's image to the specified file
            frame.Image.Save(filePath);
        }

        #endregion

        #endregion
    }
}
