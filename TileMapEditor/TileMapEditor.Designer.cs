namespace PeachFox
{    partial class TileMapEditorForm
    {
        /// <summary>        /// Required designer variable.        /// </summary>        private System.ComponentModel.IContainer components = null;

        /// <summary>        /// Clean up any resources being used.        /// </summary>        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>        protected override void Dispose(bool disposing)        {            if (disposing && (components != null))            {                components.Dispose();            }            base.Dispose(disposing);        }

        #region Windows Form Designer generated code
        /// <summary>        /// Required method for Designer support - do not modify        /// the contents of this method with the code editor.        /// </summary>        private void InitializeComponent()        {
            this.groupBoxViewPort = new System.Windows.Forms.GroupBox();
            this.groupBoxRight = new System.Windows.Forms.GroupBox();
            this.viewPort = new System.Windows.Forms.PictureBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTilemapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTilemapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxTiles = new System.Windows.Forms.GroupBox();
            this.groupBoxTilesButton = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelTiles = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.buttonNewTile = new System.Windows.Forms.Button();
            this.buttonRemoveTile = new System.Windows.Forms.Button();
            this.tileSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewTileSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editExistingTileSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxViewPort.SuspendLayout();
            this.groupBoxRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewPort)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.flowLayoutPanel.SuspendLayout();
            this.groupBoxTiles.SuspendLayout();
            this.groupBoxTilesButton.SuspendLayout();
            this.flowLayoutPanelTiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxViewPort
            // 
            this.groupBoxViewPort.Controls.Add(this.viewPort);
            this.groupBoxViewPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxViewPort.Location = new System.Drawing.Point(0, 24);
            this.groupBoxViewPort.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.groupBoxViewPort.Name = "groupBoxViewPort";
            this.groupBoxViewPort.Padding = new System.Windows.Forms.Padding(3, 3, 223, 3);
            this.groupBoxViewPort.Size = new System.Drawing.Size(877, 444);
            this.groupBoxViewPort.TabIndex = 0;
            this.groupBoxViewPort.TabStop = false;
            this.groupBoxViewPort.Text = "View Port";
            // 
            // groupBoxRight
            // 
            this.groupBoxRight.Controls.Add(this.flowLayoutPanel);
            this.groupBoxRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBoxRight.Location = new System.Drawing.Point(657, 24);
            this.groupBoxRight.Name = "groupBoxRight";
            this.groupBoxRight.Size = new System.Drawing.Size(220, 444);
            this.groupBoxRight.TabIndex = 1;
            this.groupBoxRight.TabStop = false;
            // 
            // viewPort
            // 
            this.viewPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPort.Location = new System.Drawing.Point(3, 16);
            this.viewPort.Name = "viewPort";
            this.viewPort.Size = new System.Drawing.Size(651, 425);
            this.viewPort.TabIndex = 0;
            this.viewPort.TabStop = false;
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
            this.openTilemapToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.fileToolStripMenuItem.Text = "New/Open";
            // 
            // newTilemapToolStripMenuItem
            // 
            this.newTilemapToolStripMenuItem.Name = "newTilemapToolStripMenuItem";
            this.newTilemapToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newTilemapToolStripMenuItem.Text = "New Tilemap";
            // 
            // openTilemapToolStripMenuItem
            // 
            this.openTilemapToolStripMenuItem.Name = "openTilemapToolStripMenuItem";
            this.openTilemapToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openTilemapToolStripMenuItem.Text = "Open Tilemap";
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Controls.Add(this.groupBoxTiles);
            this.flowLayoutPanel.Controls.Add(this.groupBoxTilesButton);
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(214, 425);
            this.flowLayoutPanel.TabIndex = 0;
            // 
            // groupBoxTiles
            // 
            this.groupBoxTiles.Controls.Add(this.flowLayoutPanelTiles);
            this.groupBoxTiles.Location = new System.Drawing.Point(3, 0);
            this.groupBoxTiles.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.groupBoxTiles.Name = "groupBoxTiles";
            this.groupBoxTiles.Padding = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.groupBoxTiles.Size = new System.Drawing.Size(208, 170);
            this.groupBoxTiles.TabIndex = 0;
            this.groupBoxTiles.TabStop = false;
            this.groupBoxTiles.Text = "Tiles";
            // 
            // groupBoxTilesButton
            // 
            this.groupBoxTilesButton.Controls.Add(this.buttonRemoveTile);
            this.groupBoxTilesButton.Controls.Add(this.buttonNewTile);
            this.groupBoxTilesButton.Location = new System.Drawing.Point(3, 173);
            this.groupBoxTilesButton.Name = "groupBoxTilesButton";
            this.groupBoxTilesButton.Size = new System.Drawing.Size(200, 40);
            this.groupBoxTilesButton.TabIndex = 1;
            this.groupBoxTilesButton.TabStop = false;
            // 
            // flowLayoutPanelTiles
            // 
            this.flowLayoutPanelTiles.AutoScroll = true;
            this.flowLayoutPanelTiles.Controls.Add(this.button1);
            this.flowLayoutPanelTiles.Controls.Add(this.button3);
            this.flowLayoutPanelTiles.Controls.Add(this.button2);
            this.flowLayoutPanelTiles.Controls.Add(this.button4);
            this.flowLayoutPanelTiles.Controls.Add(this.button5);
            this.flowLayoutPanelTiles.Controls.Add(this.button6);
            this.flowLayoutPanelTiles.Controls.Add(this.button7);
            this.flowLayoutPanelTiles.Controls.Add(this.button8);
            this.flowLayoutPanelTiles.Controls.Add(this.button9);
            this.flowLayoutPanelTiles.Controls.Add(this.button10);
            this.flowLayoutPanelTiles.Controls.Add(this.button11);
            this.flowLayoutPanelTiles.Controls.Add(this.button12);
            this.flowLayoutPanelTiles.Controls.Add(this.button13);
            this.flowLayoutPanelTiles.Controls.Add(this.button14);
            this.flowLayoutPanelTiles.Controls.Add(this.button15);
            this.flowLayoutPanelTiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelTiles.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanelTiles.MaximumSize = new System.Drawing.Size(202, 0);
            this.flowLayoutPanelTiles.MinimumSize = new System.Drawing.Size(202, 0);
            this.flowLayoutPanelTiles.Name = "flowLayoutPanelTiles";
            this.flowLayoutPanelTiles.Size = new System.Drawing.Size(202, 153);
            this.flowLayoutPanelTiles.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(84, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(84, 32);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(3, 61);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(84, 61);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 6;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(3, 90);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 7;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(84, 90);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 8;
            this.button8.Text = "button8";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(3, 119);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 9;
            this.button9.Text = "button9";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(84, 119);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 10;
            this.button10.Text = "button10";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(3, 148);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 11;
            this.button11.Text = "button11";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(84, 148);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 23);
            this.button12.TabIndex = 12;
            this.button12.Text = "button12";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(3, 177);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 23);
            this.button13.TabIndex = 13;
            this.button13.Text = "button13";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(84, 177);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(75, 23);
            this.button14.TabIndex = 14;
            this.button14.Text = "button14";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(3, 206);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(75, 23);
            this.button15.TabIndex = 15;
            this.button15.Text = "button15";
            this.button15.UseVisualStyleBackColor = true;
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
            // buttonRemoveTile
            // 
            this.buttonRemoveTile.Location = new System.Drawing.Point(87, 11);
            this.buttonRemoveTile.Name = "buttonRemoveTile";
            this.buttonRemoveTile.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveTile.TabIndex = 1;
            this.buttonRemoveTile.Text = "Remove Tile";
            this.buttonRemoveTile.UseVisualStyleBackColor = true;
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
            this.editExistingTileSetToolStripMenuItem.Name = "editExistingTileSetToolStripMenuItem";
            this.editExistingTileSetToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editExistingTileSetToolStripMenuItem.Text = "Edit existing Tile Set";
            // 
            // TileMapEditorForm
            // 
            this.ClientSize = new System.Drawing.Size(877, 468);
            this.Controls.Add(this.groupBoxRight);
            this.Controls.Add(this.groupBoxViewPort);
            this.Controls.Add(this.menuStrip);
            this.Name = "TileMapEditorForm";
            this.groupBoxViewPort.ResumeLayout(false);
            this.groupBoxRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.viewPort)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.flowLayoutPanel.ResumeLayout(false);
            this.groupBoxTiles.ResumeLayout(false);
            this.groupBoxTilesButton.ResumeLayout(false);
            this.flowLayoutPanelTiles.ResumeLayout(false);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.GroupBox groupBoxTilesButton;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button buttonRemoveTile;
        private System.Windows.Forms.Button buttonNewTile;
        private System.Windows.Forms.ToolStripMenuItem tileSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewTileSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editExistingTileSetToolStripMenuItem;
    }}