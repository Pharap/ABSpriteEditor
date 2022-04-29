namespace ABSpriteEditor.Controls
{
    partial class SpriteEditorPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param fileName="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.treeView = new System.Windows.Forms.TreeView();
            this.treeContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.namespaceContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addSpriteToNamespaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNamespaceToNamespaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFromNamespaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateNamespaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameNamespaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveNamespaceUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveNamespaceDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spriteContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFromSpriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateSpriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameSpriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveSpriteUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveSpriteDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frameContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editFrameTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveFrameUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveFrameDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.treeViewToolStrip = new System.Windows.Forms.ToolStrip();
            this.addNamespaceToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.addSpriteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.addFrameToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.removeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.duplicateToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.renameToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.moveUpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.moveDownToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.zoomOutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.zoomInToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.licenceEditToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.actionPanel = new ABSpriteEditor.Controls.ActionPanel();
            this.colourSelectPanel = new ABSpriteEditor.Controls.ColourSelectPanel();
            this.toolSelectPanel = new ABSpriteEditor.Controls.ToolSelectPanel();
            this.bitmapEditor = new ABSpriteEditor.Controls.BitmapEditorPanel();
            this.exportFileDialogue = new System.Windows.Forms.SaveFileDialog();
            this.spriteFileContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addSpriteToSpriteFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNamespaceToSpriteFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editLicenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeContextMenuStrip.SuspendLayout();
            this.namespaceContextMenuStrip.SuspendLayout();
            this.spriteContextMenuStrip.SuspendLayout();
            this.frameContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.treeViewToolStrip.SuspendLayout();
            this.spriteFileContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.AllowDrop = true;
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView.BackColor = System.Drawing.SystemColors.Control;
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView.ContextMenuStrip = this.treeContextMenuStrip;
            this.treeView.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.treeView.LabelEdit = true;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Margin = new System.Windows.Forms.Padding(0);
            this.treeView.Name = "treeView";
            this.treeView.PathSeparator = "::";
            this.treeView.Size = new System.Drawing.Size(130, 378);
            this.treeView.TabIndex = 0;
            this.treeView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView_AfterLabelEdit);
            this.treeView.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.treeView_DrawNode);
            this.treeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView_ItemDrag);
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            this.treeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView_DragDrop);
            this.treeView.DragOver += new System.Windows.Forms.DragEventHandler(this.treeView_DragOver);
            this.treeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView_KeyDown);
            // 
            // treeContextMenuStrip
            // 
            this.treeContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInToolStripMenuItem,
            this.zoomOutToolStripMenuItem});
            this.treeContextMenuStrip.Name = "treeContextMenuStrip";
            this.treeContextMenuStrip.Size = new System.Drawing.Size(130, 48);
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.ZoomIn16;
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.zoomInToolStripMenuItem.Text = "Zoom &In";
            this.zoomInToolStripMenuItem.Click += new System.EventHandler(this.zoomInToolStripMenuItem_Click);
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Enabled = false;
            this.zoomOutToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.ZoomOut16;
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.zoomOutToolStripMenuItem.Text = "Zoom &Out";
            this.zoomOutToolStripMenuItem.Click += new System.EventHandler(this.zoomOutToolStripMenuItem_Click);
            // 
            // namespaceContextMenuStrip
            // 
            this.namespaceContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSpriteToNamespaceToolStripMenuItem,
            this.addNamespaceToNamespaceToolStripMenuItem,
            this.removeFromNamespaceToolStripMenuItem,
            this.duplicateNamespaceToolStripMenuItem,
            this.renameNamespaceToolStripMenuItem,
            this.moveNamespaceUpToolStripMenuItem,
            this.moveNamespaceDownToolStripMenuItem});
            this.namespaceContextMenuStrip.Name = "treeViewContextMenuStrip";
            this.namespaceContextMenuStrip.Size = new System.Drawing.Size(162, 158);
            // 
            // addSpriteToNamespaceToolStripMenuItem
            // 
            this.addSpriteToNamespaceToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.AddSpriteIcon16;
            this.addSpriteToNamespaceToolStripMenuItem.Name = "addSpriteToNamespaceToolStripMenuItem";
            this.addSpriteToNamespaceToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.addSpriteToNamespaceToolStripMenuItem.Text = "Add &Sprite";
            this.addSpriteToNamespaceToolStripMenuItem.Click += new System.EventHandler(this.addSpriteToolStripMenuItem_Click);
            // 
            // addNamespaceToNamespaceToolStripMenuItem
            // 
            this.addNamespaceToNamespaceToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.AddNamespaceIcon16;
            this.addNamespaceToNamespaceToolStripMenuItem.Name = "addNamespaceToNamespaceToolStripMenuItem";
            this.addNamespaceToNamespaceToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.addNamespaceToNamespaceToolStripMenuItem.Text = "Add &Namespace";
            this.addNamespaceToNamespaceToolStripMenuItem.Click += new System.EventHandler(this.addNamespaceToolStripMenuItem_Click);
            // 
            // removeFromNamespaceToolStripMenuItem
            // 
            this.removeFromNamespaceToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.DeleteIcon16;
            this.removeFromNamespaceToolStripMenuItem.Name = "removeFromNamespaceToolStripMenuItem";
            this.removeFromNamespaceToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.removeFromNamespaceToolStripMenuItem.Text = "&Remove";
            this.removeFromNamespaceToolStripMenuItem.Click += new System.EventHandler(this.removeFromNamespaceToolStripMenuItem_Click);
            // 
            // duplicateNamespaceToolStripMenuItem
            // 
            this.duplicateNamespaceToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.DuplicateIcon16;
            this.duplicateNamespaceToolStripMenuItem.Name = "duplicateNamespaceToolStripMenuItem";
            this.duplicateNamespaceToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.duplicateNamespaceToolStripMenuItem.Text = "Du&plicate";
            this.duplicateNamespaceToolStripMenuItem.Click += new System.EventHandler(this.duplicateNamespaceToolStripMenuItem_Click);
            // 
            // renameNamespaceToolStripMenuItem
            // 
            this.renameNamespaceToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.RenameIcon16;
            this.renameNamespaceToolStripMenuItem.Name = "renameNamespaceToolStripMenuItem";
            this.renameNamespaceToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.renameNamespaceToolStripMenuItem.Text = "Rena&me";
            this.renameNamespaceToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // moveNamespaceUpToolStripMenuItem
            // 
            this.moveNamespaceUpToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.UpIcon16;
            this.moveNamespaceUpToolStripMenuItem.Name = "moveNamespaceUpToolStripMenuItem";
            this.moveNamespaceUpToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.moveNamespaceUpToolStripMenuItem.Text = "Move &Up";
            this.moveNamespaceUpToolStripMenuItem.Click += new System.EventHandler(this.moveUpToolStripMenuItem_Click);
            // 
            // moveNamespaceDownToolStripMenuItem
            // 
            this.moveNamespaceDownToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.DownIcon16;
            this.moveNamespaceDownToolStripMenuItem.Name = "moveNamespaceDownToolStripMenuItem";
            this.moveNamespaceDownToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.moveNamespaceDownToolStripMenuItem.Text = "Move &Down";
            this.moveNamespaceDownToolStripMenuItem.Click += new System.EventHandler(this.moveDownToolStripMenuItem_Click);
            // 
            // spriteContextMenuStrip
            // 
            this.spriteContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFrameToolStripMenuItem,
            this.removeFromSpriteToolStripMenuItem,
            this.duplicateSpriteToolStripMenuItem,
            this.renameSpriteToolStripMenuItem,
            this.moveSpriteUpToolStripMenuItem,
            this.moveSpriteDownToolStripMenuItem});
            this.spriteContextMenuStrip.Name = "spriteContextMenuStrip";
            this.spriteContextMenuStrip.Size = new System.Drawing.Size(153, 158);
            // 
            // addFrameToolStripMenuItem
            // 
            this.addFrameToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.AddFrameIcon16;
            this.addFrameToolStripMenuItem.Name = "addFrameToolStripMenuItem";
            this.addFrameToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addFrameToolStripMenuItem.Text = "Add &Frame";
            this.addFrameToolStripMenuItem.Click += new System.EventHandler(this.addFrameToolStripMenuItem_Click);
            // 
            // removeFromSpriteToolStripMenuItem
            // 
            this.removeFromSpriteToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.DeleteIcon16;
            this.removeFromSpriteToolStripMenuItem.Name = "removeFromSpriteToolStripMenuItem";
            this.removeFromSpriteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.removeFromSpriteToolStripMenuItem.Text = "&Remove";
            this.removeFromSpriteToolStripMenuItem.Click += new System.EventHandler(this.removeFromSpriteToolStripMenuItem_Click);
            // 
            // duplicateSpriteToolStripMenuItem
            // 
            this.duplicateSpriteToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.DuplicateIcon16;
            this.duplicateSpriteToolStripMenuItem.Name = "duplicateSpriteToolStripMenuItem";
            this.duplicateSpriteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.duplicateSpriteToolStripMenuItem.Text = "Du&plicate";
            this.duplicateSpriteToolStripMenuItem.Click += new System.EventHandler(this.duplicateSpriteToolStripMenuItem_Click);
            // 
            // renameSpriteToolStripMenuItem
            // 
            this.renameSpriteToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.RenameIcon16;
            this.renameSpriteToolStripMenuItem.Name = "renameSpriteToolStripMenuItem";
            this.renameSpriteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.renameSpriteToolStripMenuItem.Text = "Rena&me";
            this.renameSpriteToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // moveSpriteUpToolStripMenuItem
            // 
            this.moveSpriteUpToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.UpIcon16;
            this.moveSpriteUpToolStripMenuItem.Name = "moveSpriteUpToolStripMenuItem";
            this.moveSpriteUpToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.moveSpriteUpToolStripMenuItem.Text = "Move &Up";
            this.moveSpriteUpToolStripMenuItem.Click += new System.EventHandler(this.moveUpToolStripMenuItem_Click);
            // 
            // moveSpriteDownToolStripMenuItem
            // 
            this.moveSpriteDownToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.DownIcon16;
            this.moveSpriteDownToolStripMenuItem.Name = "moveSpriteDownToolStripMenuItem";
            this.moveSpriteDownToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.moveSpriteDownToolStripMenuItem.Text = "Move &Down";
            this.moveSpriteDownToolStripMenuItem.Click += new System.EventHandler(this.moveDownToolStripMenuItem_Click);
            // 
            // frameContextMenuStrip
            // 
            this.frameContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeFrameToolStripMenuItem,
            this.duplicateFrameToolStripMenuItem,
            this.editFrameTextToolStripMenuItem,
            this.moveFrameUpToolStripMenuItem,
            this.moveFrameDownToolStripMenuItem,
            this.exportImageToolStripMenuItem});
            this.frameContextMenuStrip.Name = "frameContextMenuStrip";
            this.frameContextMenuStrip.Size = new System.Drawing.Size(144, 136);
            // 
            // removeFrameToolStripMenuItem
            // 
            this.removeFrameToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.DeleteIcon16;
            this.removeFrameToolStripMenuItem.Name = "removeFrameToolStripMenuItem";
            this.removeFrameToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.removeFrameToolStripMenuItem.Text = "&Remove";
            this.removeFrameToolStripMenuItem.Click += new System.EventHandler(this.removeFrameToolStripMenuItem_Click);
            // 
            // duplicateFrameToolStripMenuItem
            // 
            this.duplicateFrameToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.DuplicateIcon16;
            this.duplicateFrameToolStripMenuItem.Name = "duplicateFrameToolStripMenuItem";
            this.duplicateFrameToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.duplicateFrameToolStripMenuItem.Text = "Du&plicate";
            this.duplicateFrameToolStripMenuItem.Click += new System.EventHandler(this.duplicateFrameToolStripMenuItem_Click);
            // 
            // editFrameTextToolStripMenuItem
            // 
            this.editFrameTextToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.RenameIcon16;
            this.editFrameTextToolStripMenuItem.Name = "editFrameTextToolStripMenuItem";
            this.editFrameTextToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.editFrameTextToolStripMenuItem.Text = "Edit &Text";
            this.editFrameTextToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // moveFrameUpToolStripMenuItem
            // 
            this.moveFrameUpToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.UpIcon16;
            this.moveFrameUpToolStripMenuItem.Name = "moveFrameUpToolStripMenuItem";
            this.moveFrameUpToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.moveFrameUpToolStripMenuItem.Text = "Move &Up";
            this.moveFrameUpToolStripMenuItem.Click += new System.EventHandler(this.moveUpToolStripMenuItem_Click);
            // 
            // moveFrameDownToolStripMenuItem
            // 
            this.moveFrameDownToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.DownIcon16;
            this.moveFrameDownToolStripMenuItem.Name = "moveFrameDownToolStripMenuItem";
            this.moveFrameDownToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.moveFrameDownToolStripMenuItem.Text = "Move &Down";
            this.moveFrameDownToolStripMenuItem.Click += new System.EventHandler(this.moveDownToolStripMenuItem_Click);
            // 
            // exportImageToolStripMenuItem
            // 
            this.exportImageToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.ExportImageIcon16;
            this.exportImageToolStripMenuItem.Name = "exportImageToolStripMenuItem";
            this.exportImageToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.exportImageToolStripMenuItem.Text = "&Export Image";
            this.exportImageToolStripMenuItem.Click += new System.EventHandler(this.exportImageToolStripMenuItem_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.treeViewToolStrip);
            this.splitContainer.Panel1.Controls.Add(this.treeView);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.actionPanel);
            this.splitContainer.Panel2.Controls.Add(this.colourSelectPanel);
            this.splitContainer.Panel2.Controls.Add(this.toolSelectPanel);
            this.splitContainer.Panel2.Controls.Add(this.bitmapEditor);
            this.splitContainer.Size = new System.Drawing.Size(640, 380);
            this.splitContainer.SplitterDistance = 156;
            this.splitContainer.TabIndex = 3;
            // 
            // treeViewToolStrip
            // 
            this.treeViewToolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewToolStrip.AutoSize = false;
            this.treeViewToolStrip.BackColor = System.Drawing.SystemColors.ControlLight;
            this.treeViewToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.treeViewToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.treeViewToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNamespaceToolStripButton,
            this.addSpriteToolStripButton,
            this.addFrameToolStripButton,
            this.removeToolStripButton,
            this.duplicateToolStripButton,
            this.renameToolStripButton,
            this.moveUpToolStripButton,
            this.moveDownToolStripButton,
            this.zoomOutToolStripButton,
            this.zoomInToolStripButton,
            this.licenceEditToolStripButton});
            this.treeViewToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.treeViewToolStrip.Location = new System.Drawing.Point(130, 0);
            this.treeViewToolStrip.Name = "treeViewToolStrip";
            this.treeViewToolStrip.Size = new System.Drawing.Size(24, 378);
            this.treeViewToolStrip.TabIndex = 3;
            // 
            // addNamespaceToolStripButton
            // 
            this.addNamespaceToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addNamespaceToolStripButton.Enabled = false;
            this.addNamespaceToolStripButton.Image = global::ABSpriteEditor.Properties.Resources.AddNamespaceIcon16;
            this.addNamespaceToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addNamespaceToolStripButton.Margin = new System.Windows.Forms.Padding(1);
            this.addNamespaceToolStripButton.Name = "addNamespaceToolStripButton";
            this.addNamespaceToolStripButton.Size = new System.Drawing.Size(20, 20);
            this.addNamespaceToolStripButton.Text = "Add Namespace";
            this.addNamespaceToolStripButton.Click += new System.EventHandler(this.addNamespaceToolStripButton_Click);
            // 
            // addSpriteToolStripButton
            // 
            this.addSpriteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addSpriteToolStripButton.Enabled = false;
            this.addSpriteToolStripButton.Image = global::ABSpriteEditor.Properties.Resources.AddSpriteIcon16;
            this.addSpriteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addSpriteToolStripButton.Margin = new System.Windows.Forms.Padding(1);
            this.addSpriteToolStripButton.Name = "addSpriteToolStripButton";
            this.addSpriteToolStripButton.Size = new System.Drawing.Size(20, 20);
            this.addSpriteToolStripButton.Text = "Add Sprite";
            this.addSpriteToolStripButton.Click += new System.EventHandler(this.addSpriteToolStripButton_Click);
            // 
            // addFrameToolStripButton
            // 
            this.addFrameToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addFrameToolStripButton.Enabled = false;
            this.addFrameToolStripButton.Image = global::ABSpriteEditor.Properties.Resources.AddFrameIcon16;
            this.addFrameToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addFrameToolStripButton.Margin = new System.Windows.Forms.Padding(1);
            this.addFrameToolStripButton.Name = "addFrameToolStripButton";
            this.addFrameToolStripButton.Size = new System.Drawing.Size(20, 20);
            this.addFrameToolStripButton.Text = "Add Frame";
            this.addFrameToolStripButton.Click += new System.EventHandler(this.addFrameToolStripButton_Click);
            // 
            // removeToolStripButton
            // 
            this.removeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeToolStripButton.Image = global::ABSpriteEditor.Properties.Resources.DeleteIcon16;
            this.removeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeToolStripButton.Margin = new System.Windows.Forms.Padding(1);
            this.removeToolStripButton.Name = "removeToolStripButton";
            this.removeToolStripButton.Size = new System.Drawing.Size(20, 20);
            this.removeToolStripButton.Text = "Delete";
            this.removeToolStripButton.Click += new System.EventHandler(this.removeToolStripButton_Click);
            // 
            // duplicateToolStripButton
            // 
            this.duplicateToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.duplicateToolStripButton.Image = global::ABSpriteEditor.Properties.Resources.DuplicateIcon16;
            this.duplicateToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.duplicateToolStripButton.Margin = new System.Windows.Forms.Padding(1);
            this.duplicateToolStripButton.Name = "duplicateToolStripButton";
            this.duplicateToolStripButton.Size = new System.Drawing.Size(20, 20);
            this.duplicateToolStripButton.Text = "Duplicate";
            this.duplicateToolStripButton.Click += new System.EventHandler(this.duplicateToolStripButton_Click);
            // 
            // renameToolStripButton
            // 
            this.renameToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.renameToolStripButton.Image = global::ABSpriteEditor.Properties.Resources.RenameIcon16;
            this.renameToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.renameToolStripButton.Name = "renameToolStripButton";
            this.renameToolStripButton.Size = new System.Drawing.Size(22, 20);
            this.renameToolStripButton.Text = "Rename";
            this.renameToolStripButton.Click += new System.EventHandler(this.renameToolStripButton_Click);
            // 
            // moveUpToolStripButton
            // 
            this.moveUpToolStripButton.BackColor = System.Drawing.Color.Transparent;
            this.moveUpToolStripButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.moveUpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveUpToolStripButton.Image = global::ABSpriteEditor.Properties.Resources.UpIcon16;
            this.moveUpToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.moveUpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveUpToolStripButton.Margin = new System.Windows.Forms.Padding(1);
            this.moveUpToolStripButton.Name = "moveUpToolStripButton";
            this.moveUpToolStripButton.Size = new System.Drawing.Size(20, 20);
            this.moveUpToolStripButton.Text = "Move Up";
            this.moveUpToolStripButton.ToolTipText = "Move Up\r\nMoves the selected tree spriteFrameNode up.";
            this.moveUpToolStripButton.Click += new System.EventHandler(this.moveUpToolStripButton_Click);
            // 
            // moveDownToolStripButton
            // 
            this.moveDownToolStripButton.BackColor = System.Drawing.Color.Transparent;
            this.moveDownToolStripButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.moveDownToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveDownToolStripButton.Image = global::ABSpriteEditor.Properties.Resources.DownIcon16;
            this.moveDownToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.moveDownToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveDownToolStripButton.Margin = new System.Windows.Forms.Padding(1);
            this.moveDownToolStripButton.Name = "moveDownToolStripButton";
            this.moveDownToolStripButton.Size = new System.Drawing.Size(20, 20);
            this.moveDownToolStripButton.Text = "Move Down";
            this.moveDownToolStripButton.ToolTipText = "Move Down\r\nMoves the selected tree spriteFrameNode down.";
            this.moveDownToolStripButton.Click += new System.EventHandler(this.moveDownToolStripButton_Click);
            // 
            // zoomOutToolStripButton
            // 
            this.zoomOutToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.zoomOutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomOutToolStripButton.Enabled = false;
            this.zoomOutToolStripButton.Image = global::ABSpriteEditor.Properties.Resources.ZoomOut16;
            this.zoomOutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomOutToolStripButton.Name = "zoomOutToolStripButton";
            this.zoomOutToolStripButton.Size = new System.Drawing.Size(22, 20);
            this.zoomOutToolStripButton.Text = "Zoom Out";
            this.zoomOutToolStripButton.Click += new System.EventHandler(this.zoomOutToolStripButton_Click);
            // 
            // zoomInToolStripButton
            // 
            this.zoomInToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.zoomInToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomInToolStripButton.Image = global::ABSpriteEditor.Properties.Resources.ZoomIn16;
            this.zoomInToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomInToolStripButton.Name = "zoomInToolStripButton";
            this.zoomInToolStripButton.Size = new System.Drawing.Size(22, 20);
            this.zoomInToolStripButton.Text = "Zoom In";
            this.zoomInToolStripButton.Click += new System.EventHandler(this.zoomInToolStripButton_Click);
            // 
            // licenceEditToolStripButton
            // 
            this.licenceEditToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.licenceEditToolStripButton.Image = global::ABSpriteEditor.Properties.Resources.EditLicenceIcon16;
            this.licenceEditToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.licenceEditToolStripButton.Name = "licenceEditToolStripButton";
            this.licenceEditToolStripButton.Size = new System.Drawing.Size(22, 20);
            this.licenceEditToolStripButton.Text = "Edit Licence";
            this.licenceEditToolStripButton.Click += new System.EventHandler(this.licenceEditToolStripButton_Click);
            // 
            // actionPanel
            // 
            this.actionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.actionPanel.Image = null;
            this.actionPanel.Location = new System.Drawing.Point(50, 330);
            this.actionPanel.Margin = new System.Windows.Forms.Padding(0);
            this.actionPanel.Name = "actionPanel";
            this.actionPanel.Size = new System.Drawing.Size(378, 48);
            this.actionPanel.TabIndex = 8;
            this.actionPanel.AfterAction += new System.EventHandler(this.actionPanel_AfterAction);
            // 
            // colourSelectPanel
            // 
            this.colourSelectPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.colourSelectPanel.Location = new System.Drawing.Point(0, 0);
            this.colourSelectPanel.Name = "colourSelectPanel";
            this.colourSelectPanel.Size = new System.Drawing.Size(48, 378);
            this.colourSelectPanel.TabIndex = 7;
            this.colourSelectPanel.ColourChanged += new System.EventHandler(this.colourSelectPanel_ColourChanged);
            // 
            // toolSelectPanel
            // 
            this.toolSelectPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolSelectPanel.Location = new System.Drawing.Point(430, 0);
            this.toolSelectPanel.Margin = new System.Windows.Forms.Padding(0);
            this.toolSelectPanel.Name = "toolSelectPanel";
            this.toolSelectPanel.Size = new System.Drawing.Size(48, 380);
            this.toolSelectPanel.TabIndex = 6;
            this.toolSelectPanel.ToolChanged += new System.EventHandler(this.toolSelectPanel_ToolChanged);
            // 
            // bitmapEditor
            // 
            this.bitmapEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bitmapEditor.BackColor = System.Drawing.SystemColors.Control;
            this.bitmapEditor.ForeColor = System.Drawing.Color.Black;
            this.bitmapEditor.GridColour = System.Drawing.SystemColors.ActiveBorder;
            this.bitmapEditor.GridVisible = true;
            this.bitmapEditor.Image = null;
            this.bitmapEditor.ImageOffset = new System.Drawing.Point(0, 0);
            this.bitmapEditor.ImageScale = 1;
            this.bitmapEditor.Location = new System.Drawing.Point(50, 0);
            this.bitmapEditor.Margin = new System.Windows.Forms.Padding(0);
            this.bitmapEditor.Name = "bitmapEditor";
            this.bitmapEditor.Size = new System.Drawing.Size(378, 330);
            this.bitmapEditor.TabIndex = 1;
            this.bitmapEditor.Tool = null;
            this.bitmapEditor.ImageChanged += new System.EventHandler(this.bitmapEditor_ImageChanged);
            this.bitmapEditor.ImageEndEdit += new System.EventHandler(this.bitmapEditor_ImageEndEdit);
            this.bitmapEditor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bitmapEditor_KeyDown);
            // 
            // exportFileDialogue
            // 
            this.exportFileDialogue.DefaultExt = "png";
            this.exportFileDialogue.Filter = "PNG Files|*.png|BMP Files|*.bmp;*.dib|ICO Files|*.ico|GIF Files|*.gif|TIFF Files|" +
    "*.tif;*.tiff|JPEG Files|*.jpg;*.jpeg;*.jpe;*.jfif";
            this.exportFileDialogue.Title = "Export";
            // 
            // spriteFileContextMenuStrip
            // 
            this.spriteFileContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSpriteToSpriteFileToolStripMenuItem,
            this.addNamespaceToSpriteFileToolStripMenuItem,
            this.editLicenceToolStripMenuItem});
            this.spriteFileContextMenuStrip.Name = "spriteFileContextMenuStrip";
            this.spriteFileContextMenuStrip.Size = new System.Drawing.Size(162, 70);
            // 
            // addSpriteToSpriteFileToolStripMenuItem
            // 
            this.addSpriteToSpriteFileToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.AddSpriteIcon16;
            this.addSpriteToSpriteFileToolStripMenuItem.Name = "addSpriteToSpriteFileToolStripMenuItem";
            this.addSpriteToSpriteFileToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.addSpriteToSpriteFileToolStripMenuItem.Text = "Add &Sprite";
            this.addSpriteToSpriteFileToolStripMenuItem.Click += new System.EventHandler(this.addSpriteToolStripButton_Click);
            this.addSpriteToSpriteFileToolStripMenuItem.DisplayStyleChanged += new System.EventHandler(this.addNamespaceToolStripButton_Click);
            // 
            // addNamespaceToSpriteFileToolStripMenuItem
            // 
            this.addNamespaceToSpriteFileToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.AddNamespaceIcon16;
            this.addNamespaceToSpriteFileToolStripMenuItem.Name = "addNamespaceToSpriteFileToolStripMenuItem";
            this.addNamespaceToSpriteFileToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.addNamespaceToSpriteFileToolStripMenuItem.Text = "Add &Namespace";
            this.addNamespaceToSpriteFileToolStripMenuItem.Click += new System.EventHandler(this.addNamespaceToolStripButton_Click);
            // 
            // editLicenceToolStripMenuItem
            // 
            this.editLicenceToolStripMenuItem.Image = global::ABSpriteEditor.Properties.Resources.EditLicenceIcon16;
            this.editLicenceToolStripMenuItem.Name = "editLicenceToolStripMenuItem";
            this.editLicenceToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.editLicenceToolStripMenuItem.Text = "Edit &Licence";
            this.editLicenceToolStripMenuItem.Click += new System.EventHandler(this.editLicenceToolStripMenuItem_Click);
            // 
            // SpriteEditorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "SpriteEditorPanel";
            this.Size = new System.Drawing.Size(640, 380);
            this.treeContextMenuStrip.ResumeLayout(false);
            this.namespaceContextMenuStrip.ResumeLayout(false);
            this.spriteContextMenuStrip.ResumeLayout(false);
            this.frameContextMenuStrip.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.treeViewToolStrip.ResumeLayout(false);
            this.treeViewToolStrip.PerformLayout();
            this.spriteFileContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ContextMenuStrip namespaceContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addSpriteToNamespaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNamespaceToNamespaceToolStripMenuItem;
        private ABSpriteEditor.Controls.BitmapEditorPanel bitmapEditor;
        private System.Windows.Forms.ContextMenuStrip spriteContextMenuStrip;
        private System.Windows.Forms.ContextMenuStrip frameContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addFrameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFrameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFromNamespaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFromSpriteToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ToolStripMenuItem exportImageToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog exportFileDialogue;
        private System.Windows.Forms.ToolStripMenuItem moveFrameUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveFrameDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveSpriteUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveSpriteDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveNamespaceUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveNamespaceDownToolStripMenuItem;
        private System.Windows.Forms.ToolStrip treeViewToolStrip;
        private System.Windows.Forms.ToolStripButton moveUpToolStripButton;
        private System.Windows.Forms.ToolStripButton moveDownToolStripButton;
        private System.Windows.Forms.ToolStripButton removeToolStripButton;
        private System.Windows.Forms.ToolStripButton addSpriteToolStripButton;
        private System.Windows.Forms.ToolStripButton addNamespaceToolStripButton;
        private System.Windows.Forms.ToolStripButton addFrameToolStripButton;
        private ToolSelectPanel toolSelectPanel;
        private ColourSelectPanel colourSelectPanel;
        private System.Windows.Forms.ToolStripMenuItem duplicateFrameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duplicateNamespaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duplicateSpriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton duplicateToolStripButton;
        private System.Windows.Forms.ContextMenuStrip treeContextMenuStrip;
        private System.Windows.Forms.ToolStripButton zoomOutToolStripButton;
        private System.Windows.Forms.ToolStripButton zoomInToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem zoomInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomOutToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip spriteFileContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addSpriteToSpriteFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNamespaceToSpriteFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editLicenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton licenceEditToolStripButton;
        private ActionPanel actionPanel;
        private System.Windows.Forms.ToolStripButton renameToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem renameNamespaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameSpriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editFrameTextToolStripMenuItem;
    }
}
