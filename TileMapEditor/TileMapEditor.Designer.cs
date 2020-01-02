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
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxTiles = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelTiles = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxTilesButton = new System.Windows.Forms.GroupBox();
            this.buttonRemoveTile = new System.Windows.Forms.Button();
            this.buttonNewTile = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTilemapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTilemapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveTileSetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadTileSetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewTileSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editExistingTileSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxViewPort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewPort)).BeginInit();
            this.groupBoxRight.SuspendLayout();
            this.flowLayoutPanel.SuspendLayout();
            this.groupBoxTiles.SuspendLayout();
            this.groupBoxTilesButton.SuspendLayout();
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
            this.groupBoxViewPort.Size = new System.Drawing.Size(877, 444);
            this.groupBoxViewPort.TabIndex = 0;
            this.groupBoxViewPort.TabStop = false;
            this.groupBoxViewPort.Text = "View Port";
            // 
            // viewPort
            // 
            this.viewPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPort.Location = new System.Drawing.Point(3, 16);
            this.viewPort.Name = "viewPort";
            this.viewPort.Size = new System.Drawing.Size(631, 425);
            this.viewPort.TabIndex = 0;
            this.viewPort.TabStop = false;
            // 
            // groupBoxRight
            // 
            this.groupBoxRight.Controls.Add(this.flowLayoutPanel);
            this.groupBoxRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBoxRight.Location = new System.Drawing.Point(637, 24);
            this.groupBoxRight.Name = "groupBoxRight";
            this.groupBoxRight.Size = new System.Drawing.Size(240, 444);
            this.groupBoxRight.TabIndex = 1;
            this.groupBoxRight.TabStop = false;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Controls.Add(this.groupBoxTiles);
            this.flowLayoutPanel.Controls.Add(this.groupBoxTilesButton);
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(234, 425);
            this.flowLayoutPanel.TabIndex = 0;
            // 
            // groupBoxTiles
            // 
            this.groupBoxTiles.Controls.Add(this.flowLayoutPanelTiles);
            this.groupBoxTiles.Location = new System.Drawing.Point(3, 0);
            this.groupBoxTiles.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.groupBoxTiles.Name = "groupBoxTiles";
            this.groupBoxTiles.Padding = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.groupBoxTiles.Size = new System.Drawing.Size(228, 170);
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
            this.flowLayoutPanelTiles.Size = new System.Drawing.Size(222, 150);
            this.flowLayoutPanelTiles.TabIndex = 0;
            // 
            // groupBoxTilesButton
            // 
            this.groupBoxTilesButton.Controls.Add(this.buttonRemoveTile);
            this.groupBoxTilesButton.Controls.Add(this.buttonNewTile);
            this.groupBoxTilesButton.Location = new System.Drawing.Point(3, 173);
            this.groupBoxTilesButton.Name = "groupBoxTilesButton";
            this.groupBoxTilesButton.Size = new System.Drawing.Size(228, 40);
            this.groupBoxTilesButton.TabIndex = 1;
            this.groupBoxTilesButton.TabStop = false;
            // 
            // buttonRemoveTile
            // 
            this.buttonRemoveTile.Location = new System.Drawing.Point(87, 11);
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
            this.buttonNewTile.Size = new System.Drawing.Size(75, 23);
            this.buttonNewTile.TabIndex = 0;
            this.buttonNewTile.Text = "New Tile";
            this.buttonNewTile.UseVisualStyleBackColor = true;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.tileSetToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(877, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTilemapToolStripMenuItem,
            this.openTilemapToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveTileSetsToolStripMenuItem,
            this.loadTileSetsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.fileToolStripMenuItem.Text = "New/Open";
            // 
            // newTilemapToolStripMenuItem
            // 
            this.newTilemapToolStripMenuItem.Name = "newTilemapToolStripMenuItem";
            this.newTilemapToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.newTilemapToolStripMenuItem.Text = "New Tilemap";
            // 
            // openTilemapToolStripMenuItem
            // 
            this.openTilemapToolStripMenuItem.Name = "openTilemapToolStripMenuItem";
            this.openTilemapToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.openTilemapToolStripMenuItem.Text = "Open Tilemap";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // saveTileSetsToolStripMenuItem
            // 
            this.saveTileSetsToolStripMenuItem.Name = "saveTileSetsToolStripMenuItem";
            this.saveTileSetsToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.saveTileSetsToolStripMenuItem.Text = "Save Tile Sets";
            // 
            // loadTileSetsToolStripMenuItem
            // 
            this.loadTileSetsToolStripMenuItem.Name = "loadTileSetsToolStripMenuItem";
            this.loadTileSetsToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.loadTileSetsToolStripMenuItem.Text = "Load Tile Sets";
            // 
            // tileSetToolStripMenuItem
            // 
            this.tileSetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewTileSetToolStripMenuItem,
            this.editExistingTileSetToolStripMenuItem});
            this.tileSetToolStripMenuItem.Name = "tileSetToolStripMenuItem";
            this.tileSetToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.tileSetToolStripMenuItem.Text = "Tile Sets";
            // 
            // addNewTileSetToolStripMenuItem
            // 
            this.addNewTileSetToolStripMenuItem.Name = "addNewTileSetToolStripMenuItem";
            this.addNewTileSetToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addNewTileSetToolStripMenuItem.Text = "Add new Tile Set";
            // 
            // editExistingTileSetToolStripMenuItem
            // 
            this.editExistingTileSetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox});
            this.editExistingTileSetToolStripMenuItem.Name = "editExistingTileSetToolStripMenuItem";
            this.editExistingTileSetToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editExistingTileSetToolStripMenuItem.Text = "Edit existing Tile Set";
            // 
            // toolStripComboBox
            // 
            this.toolStripComboBox.Name = "toolStripComboBox";
            this.toolStripComboBox.Size = new System.Drawing.Size(121, 23);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "TileSets.tileset";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "tileset.tileset";
            // 
            // TileMapEditorForm
            // 
            this.ClientSize = new System.Drawing.Size(877, 468);
            this.Controls.Add(this.groupBoxRight);
            this.Controls.Add(this.groupBoxViewPort);
            this.Controls.Add(this.menuStrip);
            this.Name = "TileMapEditorForm";
            this.ShowIcon = false;
            this.Text = "Tile Map Editor";
            this.groupBoxViewPort.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.viewPort)).EndInit();
            this.groupBoxRight.ResumeLayout(false);
            this.flowLayoutPanel.ResumeLayout(false);
            this.groupBoxTiles.ResumeLayout(false);
            this.groupBoxTilesButton.ResumeLayout(false);
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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.GroupBox groupBoxTiles;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTiles;
        private System.Windows.Forms.GroupBox groupBoxTilesButton;
        private System.Windows.Forms.Button buttonRemoveTile;
        private System.Windows.Forms.Button buttonNewTile;
        private System.Windows.Forms.ToolStripMenuItem tileSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewTileSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editExistingTileSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveTileSetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadTileSetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolTip toolTip;
    }}