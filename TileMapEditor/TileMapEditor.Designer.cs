namespace PeachFox
{    partial class TileMapEditorForm
    {
        /// <summary>        /// Required designer variable.        /// </summary>        private System.ComponentModel.IContainer components = null;

        /// <summary>        /// Clean up any resources being used.        /// </summary>        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>        protected override void Dispose(bool disposing)        {            if (disposing && (components != null))            {                components.Dispose();            }            base.Dispose(disposing);        }

        #region Windows Form Designer generated code
        /// <summary>        /// Required method for Designer support - do not modify        /// the contents of this method with the code editor.        /// </summary>        private void InitializeComponent()        {
            this.components = new System.ComponentModel.Container();
            this.groupBoxViewPort = new System.Windows.Forms.GroupBox();
            this.viewPort = new System.Windows.Forms.PictureBox();
            this.groupBoxRight = new System.Windows.Forms.GroupBox();
            this.panel = new System.Windows.Forms.Panel();
            this.groupBoxLayers = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelLayers = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxTiles = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelTiles = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxLayerButtons = new System.Windows.Forms.GroupBox();
            this.buttonLayerEdit = new System.Windows.Forms.Button();
            this.buttonLayerNew = new System.Windows.Forms.Button();
            this.groupBoxTilesButton = new System.Windows.Forms.GroupBox();
            this.buttonEditTile = new System.Windows.Forms.Button();
            this.buttonRemoveTile = new System.Windows.Forms.Button();
            this.buttonNewTile = new System.Windows.Forms.Button();
            this.groupBoxTools = new System.Windows.Forms.GroupBox();
            this.buttonToolTag = new System.Windows.Forms.Button();
            this.buttonToolEraser = new System.Windows.Forms.Button();
            this.buttonToolPaint = new System.Windows.Forms.Button();
            this.buttonToolMove = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTilemapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTilemapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTilemapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cellSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxCellSize = new System.Windows.Forms.ToolStripTextBox();
            this.tileSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewTileSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editExistingTileSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createTileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createBitmaskTileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBoxViewPort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewPort)).BeginInit();
            this.groupBoxRight.SuspendLayout();
            this.panel.SuspendLayout();
            this.groupBoxLayers.SuspendLayout();
            this.groupBoxTiles.SuspendLayout();
            this.groupBoxLayerButtons.SuspendLayout();
            this.groupBoxTilesButton.SuspendLayout();
            this.groupBoxTools.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxViewPort
            // 
            this.groupBoxViewPort.Controls.Add(this.viewPort);
            this.groupBoxViewPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxViewPort.Location = new System.Drawing.Point(0, 24);
            this.groupBoxViewPort.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.groupBoxViewPort.Name = "groupBoxViewPort";
            this.groupBoxViewPort.Padding = new System.Windows.Forms.Padding(3, 3, 243, 3);
            this.groupBoxViewPort.Size = new System.Drawing.Size(877, 482);
            this.groupBoxViewPort.TabIndex = 0;
            this.groupBoxViewPort.TabStop = false;
            this.groupBoxViewPort.Text = "View Port";
            // 
            // viewPort
            // 
            this.viewPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPort.Location = new System.Drawing.Point(3, 16);
            this.viewPort.Name = "viewPort";
            this.viewPort.Size = new System.Drawing.Size(631, 463);
            this.viewPort.TabIndex = 0;
            this.viewPort.TabStop = false;
            // 
            // groupBoxRight
            // 
            this.groupBoxRight.Controls.Add(this.panel);
            this.groupBoxRight.Controls.Add(this.groupBoxLayerButtons);
            this.groupBoxRight.Controls.Add(this.groupBoxTilesButton);
            this.groupBoxRight.Controls.Add(this.groupBoxTools);
            this.groupBoxRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBoxRight.Location = new System.Drawing.Point(637, 24);
            this.groupBoxRight.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.groupBoxRight.Name = "groupBoxRight";
            this.groupBoxRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.groupBoxRight.Size = new System.Drawing.Size(240, 482);
            this.groupBoxRight.TabIndex = 1;
            this.groupBoxRight.TabStop = false;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.groupBoxLayers);
            this.panel.Controls.Add(this.groupBoxTiles);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(3, 53);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(234, 326);
            this.panel.TabIndex = 5;
            // 
            // groupBoxLayers
            // 
            this.groupBoxLayers.Controls.Add(this.flowLayoutPanelLayers);
            this.groupBoxLayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLayers.Location = new System.Drawing.Point(0, 0);
            this.groupBoxLayers.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.groupBoxLayers.Name = "groupBoxLayers";
            this.groupBoxLayers.Size = new System.Drawing.Size(234, 136);
            this.groupBoxLayers.TabIndex = 2;
            this.groupBoxLayers.TabStop = false;
            this.groupBoxLayers.Text = "Layers";
            // 
            // flowLayoutPanelLayers
            // 
            this.flowLayoutPanelLayers.AutoScroll = true;
            this.flowLayoutPanelLayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelLayers.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanelLayers.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelLayers.Name = "flowLayoutPanelLayers";
            this.flowLayoutPanelLayers.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.flowLayoutPanelLayers.Size = new System.Drawing.Size(228, 117);
            this.flowLayoutPanelLayers.TabIndex = 2;
            // 
            // groupBoxTiles
            // 
            this.groupBoxTiles.Controls.Add(this.flowLayoutPanelTiles);
            this.groupBoxTiles.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxTiles.Location = new System.Drawing.Point(0, 136);
            this.groupBoxTiles.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.groupBoxTiles.Name = "groupBoxTiles";
            this.groupBoxTiles.Padding = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.groupBoxTiles.Size = new System.Drawing.Size(234, 190);
            this.groupBoxTiles.TabIndex = 0;
            this.groupBoxTiles.TabStop = false;
            this.groupBoxTiles.Text = "Tiles";
            // 
            // flowLayoutPanelTiles
            // 
            this.flowLayoutPanelTiles.AutoScroll = true;
            this.flowLayoutPanelTiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelTiles.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanelTiles.MaximumSize = new System.Drawing.Size(0, 150);
            this.flowLayoutPanelTiles.MinimumSize = new System.Drawing.Size(0, 150);
            this.flowLayoutPanelTiles.Name = "flowLayoutPanelTiles";
            this.flowLayoutPanelTiles.Size = new System.Drawing.Size(228, 150);
            this.flowLayoutPanelTiles.TabIndex = 0;
            // 
            // groupBoxLayerButtons
            // 
            this.groupBoxLayerButtons.Controls.Add(this.buttonLayerEdit);
            this.groupBoxLayerButtons.Controls.Add(this.buttonLayerNew);
            this.groupBoxLayerButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxLayerButtons.Location = new System.Drawing.Point(3, 13);
            this.groupBoxLayerButtons.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.groupBoxLayerButtons.Name = "groupBoxLayerButtons";
            this.groupBoxLayerButtons.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.groupBoxLayerButtons.Size = new System.Drawing.Size(234, 40);
            this.groupBoxLayerButtons.TabIndex = 3;
            this.groupBoxLayerButtons.TabStop = false;
            // 
            // buttonLayerEdit
            // 
            this.buttonLayerEdit.Location = new System.Drawing.Point(80, 11);
            this.buttonLayerEdit.Name = "buttonLayerEdit";
            this.buttonLayerEdit.Size = new System.Drawing.Size(63, 23);
            this.buttonLayerEdit.TabIndex = 1;
            this.buttonLayerEdit.Text = "Edit Layer";
            this.buttonLayerEdit.UseVisualStyleBackColor = true;
            // 
            // buttonLayerNew
            // 
            this.buttonLayerNew.Location = new System.Drawing.Point(6, 11);
            this.buttonLayerNew.Name = "buttonLayerNew";
            this.buttonLayerNew.Size = new System.Drawing.Size(68, 23);
            this.buttonLayerNew.TabIndex = 0;
            this.buttonLayerNew.Text = "New Layer";
            this.buttonLayerNew.UseVisualStyleBackColor = true;
            // 
            // groupBoxTilesButton
            // 
            this.groupBoxTilesButton.Controls.Add(this.buttonEditTile);
            this.groupBoxTilesButton.Controls.Add(this.buttonRemoveTile);
            this.groupBoxTilesButton.Controls.Add(this.buttonNewTile);
            this.groupBoxTilesButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxTilesButton.Location = new System.Drawing.Point(3, 379);
            this.groupBoxTilesButton.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.groupBoxTilesButton.Name = "groupBoxTilesButton";
            this.groupBoxTilesButton.Size = new System.Drawing.Size(234, 40);
            this.groupBoxTilesButton.TabIndex = 1;
            this.groupBoxTilesButton.TabStop = false;
            // 
            // buttonEditTile
            // 
            this.buttonEditTile.Location = new System.Drawing.Point(71, 11);
            this.buttonEditTile.Name = "buttonEditTile";
            this.buttonEditTile.Size = new System.Drawing.Size(53, 23);
            this.buttonEditTile.TabIndex = 2;
            this.buttonEditTile.Text = "Edit Tile";
            this.buttonEditTile.UseVisualStyleBackColor = true;
            // 
            // buttonRemoveTile
            // 
            this.buttonRemoveTile.Enabled = false;
            this.buttonRemoveTile.Location = new System.Drawing.Point(147, 11);
            this.buttonRemoveTile.Name = "buttonRemoveTile";
            this.buttonRemoveTile.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveTile.TabIndex = 1;
            this.buttonRemoveTile.Text = "Remove Tile";
            this.buttonRemoveTile.UseVisualStyleBackColor = true;
            // 
            // buttonNewTile
            // 
            this.buttonNewTile.Location = new System.Drawing.Point(6, 11);
            this.buttonNewTile.Name = "buttonNewTile";
            this.buttonNewTile.Size = new System.Drawing.Size(59, 23);
            this.buttonNewTile.TabIndex = 0;
            this.buttonNewTile.Text = "New Tile";
            this.buttonNewTile.UseVisualStyleBackColor = true;
            // 
            // groupBoxTools
            // 
            this.groupBoxTools.Controls.Add(this.buttonToolTag);
            this.groupBoxTools.Controls.Add(this.buttonToolEraser);
            this.groupBoxTools.Controls.Add(this.buttonToolPaint);
            this.groupBoxTools.Controls.Add(this.buttonToolMove);
            this.groupBoxTools.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxTools.Location = new System.Drawing.Point(3, 419);
            this.groupBoxTools.Name = "groupBoxTools";
            this.groupBoxTools.Size = new System.Drawing.Size(234, 60);
            this.groupBoxTools.TabIndex = 4;
            this.groupBoxTools.TabStop = false;
            this.groupBoxTools.Text = "Tools";
            // 
            // buttonToolTag
            // 
            this.buttonToolTag.Enabled = false;
            this.buttonToolTag.Image = global::PeachFox.Properties.Resources.tag;
            this.buttonToolTag.Location = new System.Drawing.Point(126, 19);
            this.buttonToolTag.Name = "buttonToolTag";
            this.buttonToolTag.Size = new System.Drawing.Size(34, 34);
            this.buttonToolTag.TabIndex = 3;
            this.buttonToolTag.UseVisualStyleBackColor = true;
            // 
            // buttonToolEraser
            // 
            this.buttonToolEraser.Image = global::PeachFox.Properties.Resources.eraser;
            this.buttonToolEraser.Location = new System.Drawing.Point(86, 19);
            this.buttonToolEraser.Name = "buttonToolEraser";
            this.buttonToolEraser.Size = new System.Drawing.Size(34, 34);
            this.buttonToolEraser.TabIndex = 2;
            this.buttonToolEraser.UseVisualStyleBackColor = true;
            // 
            // buttonToolPaint
            // 
            this.buttonToolPaint.Image = global::PeachFox.Properties.Resources.paint;
            this.buttonToolPaint.Location = new System.Drawing.Point(46, 19);
            this.buttonToolPaint.Name = "buttonToolPaint";
            this.buttonToolPaint.Size = new System.Drawing.Size(34, 34);
            this.buttonToolPaint.TabIndex = 1;
            this.buttonToolPaint.UseVisualStyleBackColor = true;
            // 
            // buttonToolMove
            // 
            this.buttonToolMove.Image = global::PeachFox.Properties.Resources.move;
            this.buttonToolMove.Location = new System.Drawing.Point(6, 19);
            this.buttonToolMove.Name = "buttonToolMove";
            this.buttonToolMove.Size = new System.Drawing.Size(34, 34);
            this.buttonToolMove.TabIndex = 0;
            this.buttonToolMove.UseVisualStyleBackColor = true;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.tileToolStripMenuItem,
            this.tileSetToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.tilesToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(877, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTilemapToolStripMenuItem,
            this.toolStripSeparator2,
            this.openTilemapToolStripMenuItem,
            this.saveTilemapToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveProjectToolStripMenuItem,
            this.loadProjectToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newTilemapToolStripMenuItem
            // 
            this.newTilemapToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.newTilemapToolStripMenuItem.Name = "newTilemapToolStripMenuItem";
            this.newTilemapToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.newTilemapToolStripMenuItem.Text = "New Tilemap";
            // 
            // openTilemapToolStripMenuItem
            // 
            this.openTilemapToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.openTilemapToolStripMenuItem.Name = "openTilemapToolStripMenuItem";
            this.openTilemapToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.openTilemapToolStripMenuItem.Text = "Open Tilemap";
            // 
            // saveTilemapToolStripMenuItem
            // 
            this.saveTilemapToolStripMenuItem.Name = "saveTilemapToolStripMenuItem";
            this.saveTilemapToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.saveTilemapToolStripMenuItem.Text = "SaveAs Tilemap";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(182, 6);
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.saveProjectToolStripMenuItem.Text = "Save Project Settings";
            // 
            // loadProjectToolStripMenuItem
            // 
            this.loadProjectToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.loadProjectToolStripMenuItem.Name = "loadProjectToolStripMenuItem";
            this.loadProjectToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.loadProjectToolStripMenuItem.Text = "Load Project Settings";
            // 
            // tileToolStripMenuItem
            // 
            this.tileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cellSizeToolStripMenuItem});
            this.tileToolStripMenuItem.Name = "tileToolStripMenuItem";
            this.tileToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.tileToolStripMenuItem.Text = "Tilemap";
            // 
            // cellSizeToolStripMenuItem
            // 
            this.cellSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxCellSize});
            this.cellSizeToolStripMenuItem.Name = "cellSizeToolStripMenuItem";
            this.cellSizeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.cellSizeToolStripMenuItem.Text = "Cell Size";
            // 
            // toolStripTextBoxCellSize
            // 
            this.toolStripTextBoxCellSize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxCellSize.MaxLength = 12;
            this.toolStripTextBoxCellSize.Name = "toolStripTextBoxCellSize";
            this.toolStripTextBoxCellSize.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxCellSize.ToolTipText = "Tilemap cellsize";
            // 
            // tileSetToolStripMenuItem
            // 
            this.tileSetToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tileSetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewTileSetToolStripMenuItem,
            this.editExistingTileSetToolStripMenuItem});
            this.tileSetToolStripMenuItem.Name = "tileSetToolStripMenuItem";
            this.tileSetToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.tileSetToolStripMenuItem.Text = "Tile Sets";
            // 
            // addNewTileSetToolStripMenuItem
            // 
            this.addNewTileSetToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addNewTileSetToolStripMenuItem.Name = "addNewTileSetToolStripMenuItem";
            this.addNewTileSetToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.addNewTileSetToolStripMenuItem.Text = "Add new Tile Set";
            // 
            // editExistingTileSetToolStripMenuItem
            // 
            this.editExistingTileSetToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.editExistingTileSetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox});
            this.editExistingTileSetToolStripMenuItem.Name = "editExistingTileSetToolStripMenuItem";
            this.editExistingTileSetToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.editExistingTileSetToolStripMenuItem.Text = "Edit existing Tile Set";
            // 
            // toolStripComboBox
            // 
            this.toolStripComboBox.Name = "toolStripComboBox";
            this.toolStripComboBox.Size = new System.Drawing.Size(121, 23);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // tilesToolStripMenuItem
            // 
            this.tilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createTileToolStripMenuItem,
            this.createBitmaskTileToolStripMenuItem});
            this.tilesToolStripMenuItem.Name = "tilesToolStripMenuItem";
            this.tilesToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.tilesToolStripMenuItem.Text = "Tiles";
            // 
            // createTileToolStripMenuItem
            // 
            this.createTileToolStripMenuItem.Name = "createTileToolStripMenuItem";
            this.createTileToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.createTileToolStripMenuItem.Text = "Create Tile";
            // 
            // createBitmaskTileToolStripMenuItem
            // 
            this.createBitmaskTileToolStripMenuItem.Name = "createBitmaskTileToolStripMenuItem";
            this.createBitmaskTileToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.createBitmaskTileToolStripMenuItem.Text = "Create Bitmask Tile";
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(182, 6);
            // 
            // TileMapEditorForm
            // 
            this.ClientSize = new System.Drawing.Size(877, 506);
            this.Controls.Add(this.groupBoxRight);
            this.Controls.Add(this.groupBoxViewPort);
            this.Controls.Add(this.menuStrip);
            this.Name = "TileMapEditorForm";
            this.ShowIcon = false;
            this.Text = "Tile Map Editor";
            this.groupBoxViewPort.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.viewPort)).EndInit();
            this.groupBoxRight.ResumeLayout(false);
            this.panel.ResumeLayout(false);
            this.groupBoxLayers.ResumeLayout(false);
            this.groupBoxTiles.ResumeLayout(false);
            this.groupBoxLayerButtons.ResumeLayout(false);
            this.groupBoxTilesButton.ResumeLayout(false);
            this.groupBoxTools.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }





        #endregion

        private System.Windows.Forms.GroupBox groupBoxViewPort;
        private System.Windows.Forms.PictureBox viewPort;
        private System.Windows.Forms.GroupBox groupBoxRight;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newTilemapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTilemapToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxTiles;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTiles;
        private System.Windows.Forms.GroupBox groupBoxTilesButton;
        private System.Windows.Forms.Button buttonRemoveTile;
        private System.Windows.Forms.Button buttonNewTile;
        private System.Windows.Forms.ToolStripMenuItem tileSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewTileSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editExistingTileSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox groupBoxLayers;
        private System.Windows.Forms.GroupBox groupBoxLayerButtons;
        private System.Windows.Forms.Button buttonLayerNew;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.Button buttonLayerEdit;
        private System.Windows.Forms.GroupBox groupBoxTools;
        private System.Windows.Forms.Button buttonToolMove;
        private System.Windows.Forms.Button buttonToolEraser;
        private System.Windows.Forms.Button buttonToolPaint;
        private System.Windows.Forms.ToolStripMenuItem saveTilemapToolStripMenuItem;
        private System.Windows.Forms.Button buttonEditTile;
        private System.Windows.Forms.Button buttonToolTag;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelLayers;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createTileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createBitmaskTileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cellSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxCellSize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }}