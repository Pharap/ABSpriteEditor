using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ABSpriteEditor.Forms;
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

namespace ABSpriteEditor.Controls
{
    public partial class SpriteEditorPanel : UserControl
    {
        private const string emptyIconKey = "EmptyIcon";
        private const string spriteFileIconKey = "SpriteFileIcon";
        private const string spriteIconKey = "SpriteIcon";
        private const string spriteGroupIconKey = "SpriteGroupIcon";
        private const string spriteFrameIconKey = "SpriteFrameIcon";

        #region Image List Creation

        private ImageList CreateImageList16()
        {
            // Cache the image list size for brevity
            var size = new Size(16, 16);

            // Create the image list
            var imageList16 = new ImageList()
            {
                // Set the size
                ImageSize = size,
            };

            // Create an empty image of the correct size
            var emptyImage = new Bitmap(size.Width, size.Height);

            // Add the tree list icons
            imageList16.Images.Add(emptyIconKey, emptyImage);
            imageList16.Images.Add(spriteFileIconKey, Properties.Resources.FileIcon16);
            imageList16.Images.Add(spriteIconKey, Properties.Resources.SpriteIcon16);
            imageList16.Images.Add(spriteGroupIconKey, Properties.Resources.NamespaceIcon16);
            imageList16.Images.Add(spriteFrameIconKey, Properties.Resources.FrameIcon16);

            // Return the image list
            return imageList16;
        }

        private ImageList CreateImageList32()
        {
            // Cache the image list size for brevity
            var size = new Size(32, 32);

            // Create the image list
            var imageList32 = new ImageList()
            {
                // Set the size
                ImageSize = size,
            };

            // Create an empty image of the correct size
            var emptyImage = new Bitmap(size.Width, size.Height);

            // Add the tree list icons
            imageList32.Images.Add(emptyIconKey, emptyImage);
            imageList32.Images.Add(spriteFileIconKey, Properties.Resources.FileIcon32);
            imageList32.Images.Add(spriteIconKey, Properties.Resources.SpriteIcon32);
            imageList32.Images.Add(spriteGroupIconKey, Properties.Resources.NamespaceIcon32);
            imageList32.Images.Add(spriteFrameIconKey, Properties.Resources.FrameIcon32);

            // Return the image list
            return imageList32;
        }

        #endregion

        #region Initialisation

        private void InitialiseSpriteFile()
        {
            // Create a node for the sprite file
            this.spriteFileNode = this.treeView.Nodes.Add(spriteFile.FileName ?? "Untitled");

            // Associate the sprite file with the sprite file node
            this.spriteFileNode.Tag = spriteFile;

            // Give the node the appropriate context menu
            this.spriteFileNode.ContextMenuStrip = this.spriteFileContextMenuStrip;

            // Associate the sprite file node with the file icon
            this.spriteFileNode.ImageKey = spriteFileIconKey;
            this.spriteFileNode.SelectedImageKey = spriteFileIconKey;

            // Register the name change event handler
            this.spriteFile.FileNameChanged += spriteFile_FileNameChanged;

            // Recurse into the sprites
            foreach (var sprite in this.spriteFile.Sprites)
                this.AddExistingSprite(this.spriteFileNode, sprite);

            // Recurse into the subgroups
            foreach (var spriteGroup in this.spriteFile.Subgroups)
                this.AddExistingSpriteGroup(this.spriteFileNode, spriteGroup);

            // Expand all from the start
            this.spriteFileNode.ExpandAll();
        }

        #endregion

        #region Helper Functions
        
        private void SelectForEditing(Bitmap bitmap)
        {
            // Set the active image to the one selected
            bitmapEditor.Image = bitmap;

            // Upscale it to the maximum size
            bitmapEditor.MaximiseScale();

            // Centre the view around the image
            bitmapEditor.CentreOffset();
        }

        private int defaultIndent = 0;

        private void ZoomInTreeView()
        {
            // Save the default indent value
            this.defaultIndent = this.treeView.Indent;

            // Replace the tree view's image list with the 32x32 icon list
            this.treeView.ImageList = this.imageList32;

            // Disable the zoom-in controls
            this.zoomInToolStripButton.Enabled = false;
            this.zoomInToolStripMenuItem.Enabled = false;

            // Enable the zoom-out controls
            this.zoomOutToolStripButton.Enabled = true;
            this.zoomOutToolStripMenuItem.Enabled = true;
        }

        private void ZoomOutTreeView()
        {
            // Replace the tree view's image list with the 16x16 icon list
            this.treeView.ImageList = this.imageList16;

            // Enable the zoom-in controls
            this.zoomInToolStripButton.Enabled = true;
            this.zoomInToolStripMenuItem.Enabled = true;

            // Disable the zoom-out controls
            this.zoomOutToolStripButton.Enabled = false;
            this.zoomOutToolStripMenuItem.Enabled = false;

            // Restore the default indent
            this.treeView.Indent = this.defaultIndent;
        }

        private void EditLicence()
        {
            // Create a new licence form
            var licenceForm = new LicenceEditForm();

            // Populate its text field with the sprite's licence text
            licenceForm.LicenceText = this.spriteFile.LicenceText;

            // Show the form to the user
            var result = licenceForm.ShowDialog();

            // If the user cancelled
            if (result == DialogResult.Cancel)
                // Exit early
                return;

            // Set the sprite file's text from the licence form
            this.spriteFile.LicenceText = licenceForm.LicenceText;
        }

        #endregion

        #region Populate Nodes

        #endregion

        #region Add Nodes

        #region Sprite Group

        private void AddSpriteGroup(TreeNode node)
        {
            // Create a new namespace form
            var newNamespaceForm = new NewNamespaceForm();

            // Show the form to the user
            var result = newNamespaceForm.ShowDialog();

            // If the user has cancelled the results
            if (result == DialogResult.Cancel)
                // Exit early
                return;

            // Retrieve the namespace
            var name = newNamespaceForm.Namespace;

            // Create a sprite group from the provided namespace
            var spriteGroup = new SpriteGroup(name);

            // Add the sprite group to this form
            var treeNode = this.AddSpriteGroup(node, spriteGroup);

            // Open up the sprite file node to show off the newly added sprite
            node.Expand();
        }

        private TreeNode AddSpriteGroup(TreeNode node, SpriteGroup spriteGroup)
        {
            // If the node is not associated with a sprite file or sprite group
            if (!(node.Tag is ISpriteGroup))
                // Throw argument exception
                throw new ArgumentException("node.Tag was not a SpriteFile or SpriteGroup");

            // Get the sprite group associated with the node
            var group = (node.Tag as ISpriteGroup);

            // Add the sprite group to the sprite group
            group.Subgroups.Add(spriteGroup);

            // Defer to the more specialised implementation
            return this.AddExistingSpriteGroup(node, spriteGroup);
        }

        private TreeNode AddExistingSpriteGroup(TreeNode node, SpriteGroup spriteGroup)
        {
            // If the node is not associated with a sprite file or sprite group
            if (!(node.Tag is ISpriteGroup))
                // Throw argument exception
                throw new ArgumentException("node.Tag was not a SpriteFile or SpriteGroup");

            // Add a new tree node for the sprite group
            var spriteGroupNode = node.Nodes.Add(spriteGroup.Namespace.ToString());

            // Populate the spriteGroup node
            this.PopulateSpriteGroupNode(spriteGroupNode, spriteGroup);

            // Make all subnodes visible
            spriteGroupNode.ExpandAll();

            // Make a note of the fact the sprite file has been edited
            this.NotifyEdit();

            // Return the recently created node
            return spriteGroupNode;
        }

        private TreeNode InsertExistingSpriteGroup(TreeNode node, int index, SpriteGroup spriteGroup, string nodeText = null)
        {
            // Add a new node to the spriteGroup node using the spriteGroup's generated name
            var spriteGroupNode = node.Nodes.Insert(index, spriteGroup.Namespace.ToString());

            // Populate the spriteGroup node
            this.PopulateSpriteGroupNode(spriteGroupNode, spriteGroup);

            // Make all subnodes visible
            spriteGroupNode.ExpandAll();

            // Make a note of the fact the spriteGroup file has been edited
            this.NotifyEdit();

            // Return the recently created node
            return spriteGroupNode;
        }

        private void PopulateSpriteGroupNode(TreeNode spriteGroupNode, SpriteGroup spriteGroup)
        {
            // Associate the created tree node with the sprite group
            spriteGroupNode.Tag = spriteGroup;

            // Give the node the appropriate context menu
            spriteGroupNode.ContextMenuStrip = this.namespaceContextMenuStrip;

            // If the tree view has an image list
            if (this.treeView.ImageList != null)
            {
                // Use the namespace icon
                spriteGroupNode.ImageKey = spriteGroupIconKey;
                spriteGroupNode.SelectedImageKey = spriteGroupNode.ImageKey;
            }

            // For each sprite in the sprite group
            foreach (var sprite in spriteGroup.Sprites)
            {
                // Defer to a more specialist implementation
                this.AddExistingSprite(spriteGroupNode, sprite);
            }

            // For each sprite group in the sprite group
            foreach (var subgroup in spriteGroup.Subgroups)
            {
                // Recurse
                this.AddExistingSpriteGroup(spriteGroupNode, subgroup);
            }

            // Register the collection changed event handlers
            spriteGroup.Sprites.CollectionChanged += sprites_CollectionChanged;
            spriteGroup.Subgroups.CollectionChanged += subgroups_CollectionChanged;
        }

        #endregion

        #region Sprite

        private void AddSprite(TreeNode node)
        {
            // Create a new sprite form
            var newSpriteForm = new NewSpriteForm();

            // Show the form to the user
            var result = newSpriteForm.ShowDialog();

            // If the user has cancelled the results
            if (result == DialogResult.Cancel)
                // Exit early
                return;

            // Retrieve the sprite creation info
            var info = newSpriteForm.SpriteCreationInfo;

            // Create a sprite from the provided info
            var sprite = this.CreateSpriteFromInfo(info);

            // Add the sprite to this node
            var treeNode = this.AddSprite(node, sprite);

            // Open up the node to show off the newly added sprite
            node.Expand();
        }

        private TreeNode AddSprite(TreeNode node, Sprite sprite)
        {
            // If the node is not associated with a sprite file or sprite group
            if (!(node.Tag is ISpriteGroup))
                // Throw argument exception
                throw new ArgumentException("node.Tag was not a SpriteFile or SpriteGroup");

            // Get the sprite group associated with the node
            var spriteGroup = (ISpriteGroup)node.Tag;

            // Add the sprite to the sprite group
            spriteGroup.Sprites.Add(sprite);

            // Defer to the more specialised implementation
            return this.AddExistingSprite(node, sprite);
        }

        private TreeNode AddExistingSprite(TreeNode node, Sprite sprite)
        {
            // If the node is not associated with a sprite file or sprite group
            if (!(node.Tag is ISpriteGroup))
                // Throw argument exception
                throw new ArgumentException("node.Tag was not a SpriteFile or SpriteGroup");

            // Add a new tree node for the sprite
            var spriteNode = node.Nodes.Add(sprite.Name.ToString());

            // Populate the sprite node
            this.PopulateSpriteNode(spriteNode, sprite);

            // Make all subnodes visible
            spriteNode.ExpandAll();

            // Make a note of the fact the sprite file has been edited
            this.NotifyEdit();

            // Return the recently created node
            return spriteNode;
        }

        private TreeNode InsertExistingSprite(TreeNode node, int index, Sprite sprite, string nodeText = null)
        {
            // Add a new node to the sprite node using the sprite's generated name
            var spriteNode = node.Nodes.Insert(index, sprite.Name.ToString());

            // Populate the sprite node
            this.PopulateSpriteNode(spriteNode, sprite);

            // Make all subnodes visible
            spriteNode.ExpandAll();

            // Make a note of the fact the sprite file has been edited
            this.NotifyEdit();

            // Return the recently created node
            return spriteNode;
        }

        private void PopulateSpriteNode(TreeNode spriteNode, Sprite sprite)
        {
            // Associate the created tree node with the sprite
            spriteNode.Tag = sprite;

            // Give the node the appropriate context menu
            spriteNode.ContextMenuStrip = this.spriteContextMenuStrip;

            // If the tree view has an image list
            if (this.treeView.ImageList != null)
            {
                // Use the sprite icon
                spriteNode.ImageKey = spriteIconKey;
                spriteNode.SelectedImageKey = spriteNode.ImageKey;
                spriteNode.StateImageKey = spriteNode.ImageKey;
            }

            // For each frame in the sprite
            for (int index = 0; index < sprite.Frames.Count; ++index)
            {
                // Cache the frame
                var frame = sprite.Frames[index];

                // Add the node
                this.AddExistingSpriteFrame(spriteNode, frame);
            }

            // Register a collection changed event handler
            sprite.Frames.CollectionChanged += frames_CollectionChanged;
        }

        #endregion

        #region Sprite Frame

        private TreeNode AddSpriteFrame(TreeNode node)
        {
            // Get the sprite associated with the node
            var sprite = (Sprite)node.Tag;

            // Generate a new name for the sprite
            var frameText = string.Format("Frame {0}", sprite.Frames.Count);

            // Create a enew image for the sprite
            var image = new Bitmap(sprite.Width, sprite.Height);

            // Add a new sprite to the sprite's sprite collection
            var frame = sprite.Frames.Add(image, frameText);

            // Defer to another function to reduce code duplication
            return this.AddExistingSpriteFrame(node, frame);
        }

        private TreeNode AddSpriteFrame(TreeNode node, Bitmap image, string frameText)
        {
            // Get the sprite associated with the node
            var sprite = (Sprite)node.Tag;

            // If the image is not of a suitable dimension
            if ((image.Width != sprite.Width) || (image.Height != sprite.Height))
                // Throw an exception
                throw new ArgumentException("The image's dimensions do not match the dimensions of the sprite");

            // Add a new sprite to the sprite's sprite collection
            var frame = sprite.Frames.Add(image, frameText);

            // Defer to another function to reduce code duplication
            return this.AddExistingSpriteFrame(node, frame);
        }

        private TreeNode AddExistingSpriteFrame(TreeNode node, SpriteFrame spriteFrame)
        {
            // If the node is not associated with a sprite
            if (!(node.Tag is Sprite))
                // Throw exception
                throw new ArgumentException("node.Tag was not a Sprite");

            // Add a new node to the sprite node using the sprite's generated name
            var frameNode = node.Nodes.Add(spriteFrame.Text ?? "Frame");

            // Register disposing event
            spriteFrame.Disposing += spriteFrame_Disposing;

            // Populate the frame node
            this.PopulateSpriteFrameNode(frameNode, spriteFrame);

            // Return the recently created node
            return frameNode;
        }

        private TreeNode InsertExistingSpriteFrame(TreeNode node, int index, SpriteFrame spriteFrame)
        {
            // Add a new node to the sprite node using the sprite's generated name
            var frameNode = node.Nodes.Insert(index, spriteFrame.Text ?? "Frame");

            // Register disposing event
            spriteFrame.Disposing += spriteFrame_Disposing;

            // Populate the frame node
            this.PopulateSpriteFrameNode(frameNode, spriteFrame);

            // Return the recently created node
            return frameNode;
        }

        private void PopulateSpriteFrameNode(TreeNode spriteFrameNode, SpriteFrame frame)
        {
            // Associate the newly created node with the newly created sprite frame
            spriteFrameNode.Tag = frame;

            // Give the node the appropriate context menu
            spriteFrameNode.ContextMenuStrip = this.frameContextMenuStrip;
            
            // Set the sprite frame node to use the empty image
            spriteFrameNode.ImageKey = emptyIconKey;
            spriteFrameNode.SelectedImageKey = emptyIconKey;

            // Make a note of the fact the sprite file has been edited
            this.NotifyEdit();
        }

        private void ReplaceSpriteFrame(TreeNode spriteFrameNode, SpriteFrame spriteFrame, Bitmap image, string frameText)
        {
            // If the image is not of a suitable dimension
            if ((image.Width != spriteFrame.Image.Width) || (image.Height != spriteFrame.Image.Height))
                // Throw an exception
                throw new ArgumentException("The image's dimensions do not match the dimensions of the sprite");

            // Dispose of the old frame image
            spriteFrame.Image.Dispose();

            // Replace the old frame image with the new frame image
            spriteFrame.Image = image;

            // Replace the old frame text with the new frame text
            spriteFrame.Text = frameText;
            spriteFrameNode.Text = frameText;

            // Set the sprite frame node to use the empty image
            spriteFrameNode.ImageKey = emptyIconKey;
            spriteFrameNode.SelectedImageKey = emptyIconKey;

            // Make a note of the fact the sprite file has been edited
            this.NotifyEdit();
        }

        #endregion

        #endregion

        #region Remove Nodes

        private void RemoveNodeItem(TreeNode node)
        {
            // Defer to the appropriate function
            if (node.Tag is SpriteGroup)
            {
                this.RemoveSpriteGroup(node);
                return;
            }

            if (node.Tag is Sprite)
            {
                this.RemoveSprite(node);
                return;
            }

            if (node.Tag is SpriteFrame)
            {
                this.RemoveSpriteFrame(node);
                return;
            }
        }

        private void RemoveSpriteGroup(TreeNode spriteGroupNode)
        {
            // Get the sprite group associated with the provided tree node
            var spriteGroup = (SpriteGroup)spriteGroupNode.Tag;

            // Remove the sprite group from its parent group
            spriteGroup.Owner.Subgroups.Remove(spriteGroup);

            // Remove the sprite group node from its parent node
            spriteGroupNode.Parent.Nodes.RemoveAt(spriteGroupNode.Index);

            // Deregister event handlers
            spriteGroup.Sprites.CollectionChanged -= sprites_CollectionChanged;
            spriteGroup.Subgroups.CollectionChanged -= subgroups_CollectionChanged;

            // Deregister nested event handlers
            foreach (var subgroup in spriteGroup.Subgroups)
            {
                subgroup.Sprites.CollectionChanged -= sprites_CollectionChanged;
                subgroup.Subgroups.CollectionChanged -= subgroups_CollectionChanged;
            }

            // Dispose of the sprite group
            spriteGroup.Dispose();

            // Make a note of the fact the sprite file has been edited
            this.NotifyEdit();
        }

        private void RemoveSprite(TreeNode spriteNode)
        {
            // Get the sprite associated with the provided tree node
            var sprite = (Sprite)spriteNode.Tag;

            // Remove the sprite from its parent group
            sprite.Owner.Sprites.Remove(sprite);

            // Remove the sprite node from its parent node
            spriteNode.Parent.Nodes.RemoveAt(spriteNode.Index);

            // Deregister event handlers
            sprite.Frames.CollectionChanged -= frames_CollectionChanged;

            // Dispose of the sprite
            sprite.Dispose();

            // Make a note of the fact the sprite file has been edited
            this.NotifyEdit();
        }

        private void RemoveSpriteFrame(TreeNode spriteFrameNode)
        {
            // Get the sprite frame
            var spriteFrame = (SpriteFrame)spriteFrameNode.Tag;

            // Remove the frame from its owning sprite
            spriteFrame.Owner.Frames.Remove(spriteFrame);

            // Remove the sprite node from its parent node
            spriteFrameNode.Parent.Nodes.RemoveAt(spriteFrameNode.Index);

            // Dispose of the frame
            spriteFrame.Dispose();

            // Make a note of the fact the sprite file has been edited
            this.NotifyEdit();
        }

        #endregion

        #region Duplicate Nodes

        private void Duplicate(TreeNode node)
        {
            // Defer to the appropriate function
            if (node.Tag is SpriteGroup)
            {
                this.DuplicateSpriteGroup(node);
                return;
            }
            
            if (node.Tag is Sprite)
            {
                this.DuplicateSprite(node);
                return;
            }
            
            if (node.Tag is SpriteFrame)
            {
                this.DuplicateSpriteFrame(node);
                return;
            }
        }

        private void DuplicateSpriteGroup(TreeNode spriteGroupNode)
        {
            // Get the sprite group
            var spriteGroup = (SpriteGroup)spriteGroupNode.Tag;

            // Insert the sprite group to get a duplicate
            var newSpriteGroup = spriteGroup.Owner.Subgroups.Insert(spriteGroupNode.Index + 1, spriteGroup);

            // Add the new sprite group to the tree view
            this.InsertExistingSpriteGroup(spriteGroupNode.Parent, spriteGroupNode.Index + 1, newSpriteGroup, spriteGroupNode.Text);
        }

        private void DuplicateSprite(TreeNode spriteNode)
        {
            // Get the sprite
            var sprite = (Sprite)spriteNode.Tag;

            // Insert the sprite to get a duplicate
            var newSprite = sprite.Owner.Sprites.Insert(spriteNode.Index + 1, sprite);

            // Add the new sprite to the tree view
            this.InsertExistingSprite(spriteNode.Parent, spriteNode.Index + 1, newSprite, spriteNode.Text);
        }

        private void DuplicateSpriteFrame(TreeNode frameNode)
        {
            // Get the sprite frame
            var frame = (SpriteFrame)frameNode.Tag;

            // Insert the frame to get a duplicate
            var newFrame = frame.Owner.Frames.Insert(frameNode.Index + 1, frame);

            // Add the new frame to the tree view
            this.InsertExistingSpriteFrame(frameNode.Parent, frameNode.Index + 1, newFrame);
        }

        #endregion

        #region Reorder Nodes

        private void MoveNodeUpAt(Point position)
        {
            // Localise the location to the tree view
            var localPoint = this.treeView.PointToClient(position);

            // Try to get the node at the specified point
            var node = this.treeView.GetNodeAt(localPoint);

            // If no node was found
            if (node == null)
                // Exit early
                return;

            // Defer to a more specialised function
            this.MoveNodeUp(node);
        }

        private void MoveNodeUp(TreeNode treeNode)
        {
            // If there is no node before this node
            if (treeNode.PrevNode == null)
                // It cannot be moved up, so exit
                return;

            // Defer to an index-based move
            this.MoveNodeToIndex(treeNode, treeNode.Index - 1);
        }

        private void MoveNodeDownAt(Point position)
        {
            // Localise the location to the tree view
            var localPoint = this.treeView.PointToClient(position);

            // Try to get the node at the specified point
            var node = this.treeView.GetNodeAt(localPoint);

            // If no node was found
            if (node == null)
                // Exit early
                return;

            // Defer to a more specialised function
            this.MoveNodeDown(node);
        }

        private void MoveNodeDown(TreeNode treeNode)
        {
            // If there is no node after this node
            if (treeNode.NextNode == null)
                // It cannot be moved down, so exit
                return;

            // Defer to an index-based move
            this.MoveNodeToIndex(treeNode, treeNode.Index + 1);
        }

        private void MoveNodeToIndex(TreeNode treeNode, int targetIndex)
        {
            // Cache the node's parent
            var parent = treeNode.Parent;

            // Remove the tree node
            parent.Nodes.Remove(treeNode);

            // Reinsert it in its new location
            parent.Nodes.Insert(targetIndex, treeNode);

            // Select the moved node
            this.treeView.SelectedNode = parent.Nodes[targetIndex];

            // If the parent holds a sprite
            if (parent.Tag is Sprite)
            {
                // Get the sprite
                var sprite = (Sprite)parent.Tag;

                // Get this node's sprite frame
                var spriteFrame = (SpriteFrame)treeNode.Tag;

                // Remove the sprite frame
                sprite.Frames.Remove(spriteFrame);

                // Reinsert it in its new location
                sprite.Frames.Insert(targetIndex, spriteFrame);

                // Consider this an edit
                this.NotifyEdit();
            }
        }

        #endregion

        #region Drag Nodes

        private bool HandleDrag(TreeNode source, TreeNode destination)
        {
            // Defer to the appropriate function
            if (source.Tag is SpriteGroup)
                return this.HandleDragSpriteGroup(source, destination);
            
            if (source.Tag is Sprite)
                return this.HandleDragSprite(source, destination);
            
            if (source.Tag is SpriteFrame)
                return this.HandleDragSpriteFrame(source, destination);

            return false;
        }

        private bool HandleDragSpriteGroup(TreeNode source, TreeNode destination)
        {
            // Convert the source tag to a sprite group
            var subgroup = (SpriteGroup)source.Tag;

            // If the destination isn't a sprite group
            if (!(destination.Tag is ISpriteGroup))
                // Report failure
                return false;

            // Convert the destination node's tag to a sprite group
            var spriteGroup = (ISpriteGroup)destination.Tag;

            // Remove the sprite group from its owning sprite group
            subgroup.Owner.Subgroups.Remove(subgroup);

            // Remove the sprite group's node from its parent
            source.Parent.Nodes.Remove(source);

            // Add the sprite group to the destination sprite group
            spriteGroup.Subgroups.Add(subgroup);

            // Add the sprite group's node to the destination node's children
            destination.Nodes.Add(source);

            // Report success
            return true;
        }

        private bool HandleDragSprite(TreeNode source, TreeNode destination)
        {
            // Convert the source tag to a sprite
            var sprite = (Sprite)source.Tag;

            // If the destination isn't a sprite group
            if (!(destination.Tag is ISpriteGroup))
                // Report failure
                return false;

            // Convert the destination node's tag to a sprite group
            var spriteGroup = (ISpriteGroup)destination.Tag;

            // Remove the sprite from its owning sprite group
            sprite.Owner.Sprites.Remove(sprite);

            // Remove the sprite's node from its parent
            source.Parent.Nodes.Remove(source);

            // Add the sprite to the destination sprite group
            spriteGroup.Sprites.Add(sprite);

            // Add the sprite's node to the destination node's children
            destination.Nodes.Add(source);

            // Report success
            return true;
        }

        private bool HandleDragSpriteFrame(TreeNode source, TreeNode destination)
        {
            // If the destination is a sprite group
            if (destination.Tag is ISpriteGroup)
                // Report failure
                return false;

            // If the destination is a sprite
            if (destination.Tag is Sprite)
                // Defer to a more specialised function
                return this.HandleDragSpriteFrameOntoSprite(source, destination);

            // If the destination is a sprite frame
            if (destination.Tag is SpriteFrame)
                // Defer to a more specialised function
                return HandleDragSpriteFrameOntoSpriteFrame(source, destination);

            // Report failure
            return false;
        }

        private bool HandleDragSpriteFrameOntoSprite(TreeNode source, TreeNode destination)
        {
            // Convert the source tag to a sprite frame
            var spriteFrame = (SpriteFrame)source.Tag;

            // Convert the destination node's tag to a sprite
            var sprite = (Sprite)destination.Tag;

            // If the frame's dimensions are unsuitable
            if ((spriteFrame.Image.Width != sprite.Width) || (spriteFrame.Image.Height != sprite.Height))
                // Report failure
                return false;

            // Remove the frame from its owning sprite
            spriteFrame.Owner.Frames.Remove(spriteFrame);

            // Remove the frame's node from its parent
            source.Parent.Nodes.Remove(source);

            // Add the frame to the destination sprite
            sprite.Frames.Add(spriteFrame);

            // Add the frame's node to the destination node's children
            destination.Nodes.Add(source);

            // Report success
            return true;
        }

        private bool HandleDragSpriteFrameOntoSpriteFrame(TreeNode source, TreeNode destination)
        {
            // Convert the tags to sprite frames
            var sourceFrame = (SpriteFrame)source.Tag;
            var destinationFrame = (SpriteFrame)destination.Tag;

            // If the frames' dimensions aren't the same
            if (sourceFrame.Image.Size != destinationFrame.Image.Size)
                // Report failure
                return false;

            // Cache the frames' indices
            var sourceIndex = source.Index;
            var destinationIndex = destination.Index;

            // Cache the frames' owners
            var sourceSprite = sourceFrame.Owner;
            var destinationSprite = destinationFrame.Owner;

            // Cache the nodes' parents
            var sourceParent = source.Parent;
            var destinationParent = destination.Parent;

            // Remove the frames from their owning sprites
            sourceFrame.Owner.Frames.Remove(sourceFrame);
            destinationFrame.Owner.Frames.Remove(destinationFrame);

            // Remove the frames' nodes from their parents
            source.Parent.Nodes.Remove(source);
            destination.Parent.Nodes.Remove(destination);

            // Make sure that the item with the lowest index is handled first
            // to prevent a rare edge condition where the frames both belong
            // to the same sprite and the higher index is outside the bounds
            // of the frames collection due to the number of frames being reduced.
            if (sourceIndex < destinationIndex)
            {
                // Add the frames to their destination sprites
                sourceSprite.Frames.Insert(sourceIndex, destinationFrame);
                destinationSprite.Frames.Insert(destinationIndex, sourceFrame);

                // Add the nodes to their destination parents
                sourceParent.Nodes.Insert(sourceIndex, destination);
                destinationParent.Nodes.Insert(destinationIndex, source);
            }
            else
            {
                // Add the frames to their destination sprites
                destinationSprite.Frames.Insert(destinationIndex, sourceFrame);
                sourceSprite.Frames.Insert(sourceIndex, destinationFrame);

                // Add the nodes to their destination parents
                destinationParent.Nodes.Insert(destinationIndex, source);
                sourceParent.Nodes.Insert(sourceIndex, destination);
            }

            // Report success
            return true;
        }

        #endregion

        #region File Dropping

        private void HandleFileDrop(string[] files, TreeNode target)
        {
            // If the tree node holds a sprite
            if (target.Tag is Sprite)
            {
                // Defer to the sprite handling function
                this.HandleSpriteFileDrop(files, target);

                // Exit early
                return;
            }

            // If the tree node holds a sprite group or sprite file
            if (target.Tag is ISpriteGroup)
            {
                // Defer to the sprite group handling function
                this.HandleSpriteGroupFileDrop(files, target);

                // Exit early
                return;
            }

            // If the tree node holds a sprite frame
            if (target.Tag is SpriteFrame)
            {
                // Defer to the spriteframe handling function
                this.HandleSpriteFrameFileDrop(files, target);

                // Exit early
                return;
            }
        }

        private void HandleSpriteGroupFileDrop(string[] files, TreeNode target)
        {
            // If there are no files
            if (files.Length == 0)
                // Exit early
                return;

            // For the first file
            var filePath = files[0];

            // Get a bitmap from the file
            using (var fileImage = new Bitmap(filePath))
            {
                // Get a colour reduced copy of that first bitmap to avoid file locking issues
                var image = SpriteHelper.CreateMonochromeTransparentCopy(fileImage);

                // Get the file's name, without extension
                var fileName = Path.GetFileNameWithoutExtension(filePath);

                // Create a name for the sprite from the file name, with "Sprite" as a fallback
                var name = Identifier.CreateOrDefault(fileName, Identifier.Create("Sprite"));

                // Create the new sprite
                var sprite = new Sprite(image.Width, image.Height, name);

                // Add the sprite, receiving the resulting node
                var spriteNode = this.AddSprite(target, sprite);

                // Add the frame
                this.AddSpriteFrame(spriteNode, image, fileName);
            }

            // Defer to the sprite drop function to handle the remaining images
            this.HandleSpriteFileDrop(files.Skip(1), target.LastNode);
        }

        private void HandleSpriteFileDrop(IEnumerable<string> files, TreeNode target)
        {
            // Get the sprite
            var sprite = (Sprite)target.Tag;

            // For each file path included in the data
            foreach (var filePath in files)
            {
                // Get a bitmap from the file
                using (var fileImage = new Bitmap(filePath))
                {
                    // Get a colour reduced copy of that first bitmap to avoid file locking issues
                    var image = SpriteHelper.CreateMonochromeTransparentCopy(fileImage);

                    // Use the file's name, without extension, as the frame's text
                    var text = Path.GetFileNameWithoutExtension(filePath);

                    // Check that the image dimensions are appropriate for the sprite
                    if ((image.Width != sprite.Width) || (image.Height != sprite.Height))
                    {
                        // Show the user an error message
                        var result = ErrorsHelper.ShowSpriteFileDropInvalidDimensionsError(filePath, image.Width, image.Height, sprite.Width, sprite.Height);

                        // If the user cancelled
                        if (result == DialogResult.Cancel)
                            // Exit the function
                            return;

                        // Otherwise, move on to the next file
                        continue;
                    }

                    // Add the frame
                    this.AddSpriteFrame(target, image, text);
                }
            }
        }

        private void HandleSpriteFrameFileDrop(IEnumerable<string> files, TreeNode target)
        {
            // Retrieve the first image that was changed
            var targetSpriteFrame = (SpriteFrame)target.Tag;

            // Get the containing sprite
            var sprite = targetSpriteFrame.Owner;

            // Start the current target off as the first one specified
            var currentTarget = target;

            // For each file path included in the data
            foreach(var filePath in files)
            {
                // Get a bitmap from the file
                using (var fileImage = new Bitmap(filePath))
                {
                    // Get a copy of that first bitmap to avoid file locking issues
                    var image = SpriteHelper.CreateMonochromeTransparentCopy(fileImage);

                    // Use the file's name, without extension, as the frame's text
                    var text = Path.GetFileNameWithoutExtension(filePath);

                    // Check that the image dimensions are appropriate for the sprite
                    if (image.Size != sprite.Size)
                    {
                        // Show the user an error message
                        var result = ErrorsHelper.ShowSpriteFileDropInvalidDimensionsError(filePath, image.Width, image.Height, sprite.Width, sprite.Height);

                        // If the user cancelled
                        if (result == DialogResult.Cancel)
                            // Exit the function
                            return;

                        // Otherwise, move on to the next file
                        continue;
                    }

                    // If there is no current target node
                    if (currentTarget == null)
                    {
                        // Create one by adding a new frame to the current target's parent
                        currentTarget = this.AddSpriteFrame(target.Parent);
                    }

                    // Cache the current sprite frame
                    var currentSpriteFrame = (SpriteFrame)currentTarget.Tag;

                    // Try to replace the frame, and if replacing the frame fails...
                    this.ReplaceSpriteFrame(currentTarget, currentSpriteFrame, image, text);
                }

                // Move to the next sibling for the next iteration
                currentTarget = currentTarget.NextNode;
            }

            // Select the first image for editing
            this.SelectForEditing(targetSpriteFrame.Image);
        }

        #endregion
    }
}