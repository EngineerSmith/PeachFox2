namespace PeachFox{    partial class TileEditorForm    {		        /// <summary>        /// Required designer variable.        /// </summary>        private System.ComponentModel.IContainer components = null;        /// <summary>        /// Clean up any resources being used.        /// </summary>        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>        protected override void Dispose(bool disposing)        {            if (disposing && (components != null))            {                components.Dispose();            }            base.Dispose(disposing);        }        #region Windows Form Designer generated code        /// <summary>        /// Required method for Designer support - do not modify        /// the contents of this method with the code editor.        /// </summary>        private void InitializeComponent()        {            this.components = new System.ComponentModel.Container();
            this.viewPort = new System.Windows.Forms.PictureBox();
            this.groupBoxViewPort = new System.Windows.Forms.GroupBox();
            this.groupBoxControls = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageQuads = new System.Windows.Forms.TabPage();
            this.groupBoxQuads = new System.Windows.Forms.GroupBox();
            this.listBox = new System.Windows.Forms.ListBox();
            this.groupBoxButtons = new System.Windows.Forms.GroupBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.tabPageBitmask = new System.Windows.Forms.TabPage();
            this.checkBoxBitmaskMode = new System.Windows.Forms.CheckBox();
            this.buttonMask128 = new System.Windows.Forms.Button();
            this.buttonMask64 = new System.Windows.Forms.Button();
            this.buttonMask32 = new System.Windows.Forms.Button();
            this.buttonMask16 = new System.Windows.Forms.Button();
            this.buttonTILE = new System.Windows.Forms.Button();
            this.buttonMask8 = new System.Windows.Forms.Button();
            this.buttonMask4 = new System.Windows.Forms.Button();
            this.buttonMask2 = new System.Windows.Forms.Button();
            this.buttonMask1 = new System.Windows.Forms.Button();
            this.groupBoxQuadSettings = new System.Windows.Forms.GroupBox();
            this.labelHeight = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.numericHeight = new System.Windows.Forms.NumericUpDown();
            this.numericWidth = new System.Windows.Forms.NumericUpDown();
            this.numericY = new System.Windows.Forms.NumericUpDown();
            this.numericX = new System.Windows.Forms.NumericUpDown();
            this.groupBoxExportSettings = new System.Windows.Forms.GroupBox();
            this.buttonTileTags = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.labelTime = new System.Windows.Forms.Label();
            this.numericTime = new System.Windows.Forms.NumericUpDown();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonShowAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.viewPort)).BeginInit();
            this.groupBoxViewPort.SuspendLayout();
            this.groupBoxControls.SuspendLayout();
            this.flowLayoutPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageQuads.SuspendLayout();
            this.groupBoxQuads.SuspendLayout();
            this.groupBoxButtons.SuspendLayout();
            this.tabPageBitmask.SuspendLayout();
            this.groupBoxQuadSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericX)).BeginInit();
            this.groupBoxExportSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTime)).BeginInit();
            this.SuspendLayout();
            // 
            // viewPort
            // 
            this.viewPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewPort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.viewPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPort.Location = new System.Drawing.Point(3, 16);
            this.viewPort.Name = "viewPort";
            this.viewPort.Size = new System.Drawing.Size(478, 372);
            this.viewPort.TabIndex = 0;
            this.viewPort.TabStop = false;
            // 
            // groupBoxViewPort
            // 
            this.groupBoxViewPort.Controls.Add(this.viewPort);
            this.groupBoxViewPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxViewPort.Location = new System.Drawing.Point(0, 0);
            this.groupBoxViewPort.Name = "groupBoxViewPort";
            this.groupBoxViewPort.Padding = new System.Windows.Forms.Padding(3, 3, 203, 3);
            this.groupBoxViewPort.Size = new System.Drawing.Size(684, 391);
            this.groupBoxViewPort.TabIndex = 1;
            this.groupBoxViewPort.TabStop = false;
            this.groupBoxViewPort.Text = "View Port";
            // 
            // groupBoxControls
            // 
            this.groupBoxControls.Controls.Add(this.flowLayoutPanel);
            this.groupBoxControls.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBoxControls.Location = new System.Drawing.Point(484, 0);
            this.groupBoxControls.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.groupBoxControls.Name = "groupBoxControls";
            this.groupBoxControls.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.groupBoxControls.Size = new System.Drawing.Size(200, 391);
            this.groupBoxControls.TabIndex = 1;
            this.groupBoxControls.TabStop = false;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Controls.Add(this.tabControl);
            this.flowLayoutPanel.Controls.Add(this.groupBoxQuadSettings);
            this.flowLayoutPanel.Controls.Add(this.groupBoxExportSettings);
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(3, 13);
            this.flowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(194, 378);
            this.flowLayoutPanel.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageQuads);
            this.tabControl.Controls.Add(this.tabPageBitmask);
            this.tabControl.HotTrack = true;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(188, 182);
            this.tabControl.TabIndex = 6;
            // 
            // tabPageQuads
            // 
            this.tabPageQuads.Controls.Add(this.groupBoxQuads);
            this.tabPageQuads.Controls.Add(this.groupBoxButtons);
            this.tabPageQuads.Location = new System.Drawing.Point(4, 22);
            this.tabPageQuads.Name = "tabPageQuads";
            this.tabPageQuads.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageQuads.Size = new System.Drawing.Size(180, 156);
            this.tabPageQuads.TabIndex = 0;
            this.tabPageQuads.Text = "Quads";
            this.tabPageQuads.UseVisualStyleBackColor = true;
            // 
            // groupBoxQuads
            // 
            this.groupBoxQuads.Controls.Add(this.listBox);
            this.groupBoxQuads.Location = new System.Drawing.Point(3, 3);
            this.groupBoxQuads.Margin = new System.Windows.Forms.Padding(0);
            this.groupBoxQuads.Name = "groupBoxQuads";
            this.groupBoxQuads.Padding = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.groupBoxQuads.Size = new System.Drawing.Size(171, 99);
            this.groupBoxQuads.TabIndex = 0;
            this.groupBoxQuads.TabStop = false;
            // 
            // listBox
            // 
            this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(3, 16);
            this.listBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 4);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(165, 82);
            this.listBox.TabIndex = 0;
            // 
            // groupBoxButtons
            // 
            this.groupBoxButtons.Controls.Add(this.buttonClear);
            this.groupBoxButtons.Controls.Add(this.buttonAdd);
            this.groupBoxButtons.Controls.Add(this.buttonRemove);
            this.groupBoxButtons.Location = new System.Drawing.Point(3, 102);
            this.groupBoxButtons.Margin = new System.Windows.Forms.Padding(0);
            this.groupBoxButtons.Name = "groupBoxButtons";
            this.groupBoxButtons.Size = new System.Drawing.Size(174, 47);
            this.groupBoxButtons.TabIndex = 4;
            this.groupBoxButtons.TabStop = false;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(116, 14);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(55, 23);
            this.buttonClear.TabIndex = 3;
            this.buttonClear.Text = "Clear All";
            this.buttonClear.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(2, 14);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(44, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(52, 14);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(58, 23);
            this.buttonRemove.TabIndex = 2;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            // 
            // tabPageBitmask
            // 
            this.tabPageBitmask.Controls.Add(this.buttonShowAll);
            this.tabPageBitmask.Controls.Add(this.checkBoxBitmaskMode);
            this.tabPageBitmask.Controls.Add(this.buttonMask128);
            this.tabPageBitmask.Controls.Add(this.buttonMask64);
            this.tabPageBitmask.Controls.Add(this.buttonMask32);
            this.tabPageBitmask.Controls.Add(this.buttonMask16);
            this.tabPageBitmask.Controls.Add(this.buttonTILE);
            this.tabPageBitmask.Controls.Add(this.buttonMask8);
            this.tabPageBitmask.Controls.Add(this.buttonMask4);
            this.tabPageBitmask.Controls.Add(this.buttonMask2);
            this.tabPageBitmask.Controls.Add(this.buttonMask1);
            this.tabPageBitmask.Location = new System.Drawing.Point(4, 22);
            this.tabPageBitmask.Name = "tabPageBitmask";
            this.tabPageBitmask.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBitmask.Size = new System.Drawing.Size(180, 156);
            this.tabPageBitmask.TabIndex = 1;
            this.tabPageBitmask.Text = "Bitmask";
            this.tabPageBitmask.UseVisualStyleBackColor = true;
            // 
            // checkBoxBitmaskMode
            // 
            this.checkBoxBitmaskMode.AutoSize = true;
            this.checkBoxBitmaskMode.Location = new System.Drawing.Point(162, 6);
            this.checkBoxBitmaskMode.Name = "checkBoxBitmaskMode";
            this.checkBoxBitmaskMode.Size = new System.Drawing.Size(15, 14);
            this.checkBoxBitmaskMode.TabIndex = 9;
            this.toolTip.SetToolTip(this.checkBoxBitmaskMode, "Change bitmask mode");
            this.checkBoxBitmaskMode.UseVisualStyleBackColor = true;
            // 
            // buttonMask128
            // 
            this.buttonMask128.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonMask128.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonMask128.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonMask128.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMask128.Location = new System.Drawing.Point(4, 105);
            this.buttonMask128.Name = "buttonMask128";
            this.buttonMask128.Size = new System.Drawing.Size(45, 45);
            this.buttonMask128.TabIndex = 8;
            this.buttonMask128.Tag = 128;
            this.buttonMask128.Text = "128";
            this.buttonMask128.UseVisualStyleBackColor = false;
            this.buttonMask128.Click += new System.EventHandler(this.BitmaskToggle);
            // 
            // buttonMask64
            // 
            this.buttonMask64.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonMask64.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonMask64.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonMask64.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMask64.Location = new System.Drawing.Point(103, 105);
            this.buttonMask64.Name = "buttonMask64";
            this.buttonMask64.Size = new System.Drawing.Size(45, 45);
            this.buttonMask64.TabIndex = 7;
            this.buttonMask64.Tag = 64;
            this.buttonMask64.Text = "64";
            this.buttonMask64.UseVisualStyleBackColor = false;
            this.buttonMask64.Click += new System.EventHandler(this.BitmaskToggle);
            // 
            // buttonMask32
            // 
            this.buttonMask32.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonMask32.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonMask32.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonMask32.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMask32.Location = new System.Drawing.Point(103, 5);
            this.buttonMask32.Name = "buttonMask32";
            this.buttonMask32.Size = new System.Drawing.Size(45, 45);
            this.buttonMask32.TabIndex = 6;
            this.buttonMask32.Tag = 32;
            this.buttonMask32.Text = "32";
            this.buttonMask32.UseVisualStyleBackColor = false;
            this.buttonMask32.Click += new System.EventHandler(this.BitmaskToggle);
            // 
            // buttonMask16
            // 
            this.buttonMask16.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonMask16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonMask16.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonMask16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMask16.Location = new System.Drawing.Point(4, 4);
            this.buttonMask16.Name = "buttonMask16";
            this.buttonMask16.Size = new System.Drawing.Size(45, 45);
            this.buttonMask16.TabIndex = 5;
            this.buttonMask16.Tag = 16;
            this.buttonMask16.Text = "16";
            this.buttonMask16.UseVisualStyleBackColor = false;
            this.buttonMask16.Click += new System.EventHandler(this.BitmaskToggle);
            // 
            // buttonTILE
            // 
            this.buttonTILE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonTILE.FlatAppearance.BorderSize = 0;
            this.buttonTILE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTILE.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTILE.Location = new System.Drawing.Point(55, 55);
            this.buttonTILE.Name = "buttonTILE";
            this.buttonTILE.Size = new System.Drawing.Size(45, 45);
            this.buttonTILE.TabIndex = 4;
            this.buttonTILE.Text = "0";
            this.buttonTILE.UseVisualStyleBackColor = true;
            // 
            // buttonMask8
            // 
            this.buttonMask8.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonMask8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonMask8.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonMask8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMask8.Location = new System.Drawing.Point(4, 55);
            this.buttonMask8.Name = "buttonMask8";
            this.buttonMask8.Size = new System.Drawing.Size(45, 45);
            this.buttonMask8.TabIndex = 3;
            this.buttonMask8.Tag = 8;
            this.buttonMask8.Text = "8";
            this.buttonMask8.UseVisualStyleBackColor = false;
            this.buttonMask8.Click += new System.EventHandler(this.BitmaskToggle);
            // 
            // buttonMask4
            // 
            this.buttonMask4.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonMask4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonMask4.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonMask4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMask4.Location = new System.Drawing.Point(53, 105);
            this.buttonMask4.Name = "buttonMask4";
            this.buttonMask4.Size = new System.Drawing.Size(45, 45);
            this.buttonMask4.TabIndex = 2;
            this.buttonMask4.Tag = 4;
            this.buttonMask4.Text = "4";
            this.buttonMask4.UseVisualStyleBackColor = false;
            this.buttonMask4.Click += new System.EventHandler(this.BitmaskToggle);
            // 
            // buttonMask2
            // 
            this.buttonMask2.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonMask2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonMask2.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonMask2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMask2.Location = new System.Drawing.Point(103, 55);
            this.buttonMask2.Name = "buttonMask2";
            this.buttonMask2.Size = new System.Drawing.Size(45, 45);
            this.buttonMask2.TabIndex = 1;
            this.buttonMask2.Tag = 2;
            this.buttonMask2.Text = "2";
            this.buttonMask2.UseVisualStyleBackColor = false;
            this.buttonMask2.Click += new System.EventHandler(this.BitmaskToggle);
            // 
            // buttonMask1
            // 
            this.buttonMask1.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonMask1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonMask1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonMask1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMask1.Location = new System.Drawing.Point(54, 4);
            this.buttonMask1.Name = "buttonMask1";
            this.buttonMask1.Size = new System.Drawing.Size(45, 45);
            this.buttonMask1.TabIndex = 0;
            this.buttonMask1.Tag = 1;
            this.buttonMask1.Text = "1";
            this.buttonMask1.UseVisualStyleBackColor = false;
            this.buttonMask1.Click += new System.EventHandler(this.BitmaskToggle);
            // 
            // groupBoxQuadSettings
            // 
            this.groupBoxQuadSettings.Controls.Add(this.labelHeight);
            this.groupBoxQuadSettings.Controls.Add(this.labelWidth);
            this.groupBoxQuadSettings.Controls.Add(this.labelY);
            this.groupBoxQuadSettings.Controls.Add(this.labelX);
            this.groupBoxQuadSettings.Controls.Add(this.numericHeight);
            this.groupBoxQuadSettings.Controls.Add(this.numericWidth);
            this.groupBoxQuadSettings.Controls.Add(this.numericY);
            this.groupBoxQuadSettings.Controls.Add(this.numericX);
            this.groupBoxQuadSettings.Location = new System.Drawing.Point(3, 182);
            this.groupBoxQuadSettings.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.groupBoxQuadSettings.Name = "groupBoxQuadSettings";
            this.groupBoxQuadSettings.Size = new System.Drawing.Size(188, 115);
            this.groupBoxQuadSettings.TabIndex = 3;
            this.groupBoxQuadSettings.TabStop = false;
            this.groupBoxQuadSettings.Text = "Quad Settings";
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(4, 90);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(38, 13);
            this.labelHeight.TabIndex = 7;
            this.labelHeight.Text = "Height";
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(7, 67);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(35, 13);
            this.labelWidth.TabIndex = 6;
            this.labelWidth.Text = "Width";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(27, 45);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(14, 13);
            this.labelY.TabIndex = 5;
            this.labelY.Text = "Y";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(28, 21);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(14, 13);
            this.labelX.TabIndex = 4;
            this.labelX.Text = "X";
            // 
            // numericHeight
            // 
            this.numericHeight.Location = new System.Drawing.Point(46, 88);
            this.numericHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericHeight.Name = "numericHeight";
            this.numericHeight.Size = new System.Drawing.Size(134, 20);
            this.numericHeight.TabIndex = 3;
            this.numericHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericWidth
            // 
            this.numericWidth.Location = new System.Drawing.Point(46, 65);
            this.numericWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericWidth.Name = "numericWidth";
            this.numericWidth.Size = new System.Drawing.Size(134, 20);
            this.numericWidth.TabIndex = 2;
            this.numericWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericY
            // 
            this.numericY.Location = new System.Drawing.Point(45, 42);
            this.numericY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericY.Name = "numericY";
            this.numericY.Size = new System.Drawing.Size(134, 20);
            this.numericY.TabIndex = 1;
            // 
            // numericX
            // 
            this.numericX.Location = new System.Drawing.Point(45, 19);
            this.numericX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericX.Name = "numericX";
            this.numericX.Size = new System.Drawing.Size(134, 20);
            this.numericX.TabIndex = 0;
            // 
            // groupBoxExportSettings
            // 
            this.groupBoxExportSettings.Controls.Add(this.buttonTileTags);
            this.groupBoxExportSettings.Controls.Add(this.buttonExport);
            this.groupBoxExportSettings.Controls.Add(this.labelTime);
            this.groupBoxExportSettings.Controls.Add(this.numericTime);
            this.groupBoxExportSettings.Location = new System.Drawing.Point(3, 297);
            this.groupBoxExportSettings.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.groupBoxExportSettings.Name = "groupBoxExportSettings";
            this.groupBoxExportSettings.Size = new System.Drawing.Size(188, 76);
            this.groupBoxExportSettings.TabIndex = 5;
            this.groupBoxExportSettings.TabStop = false;
            this.groupBoxExportSettings.Text = "Export Settings";
            // 
            // buttonTileTags
            // 
            this.buttonTileTags.Enabled = false;
            this.buttonTileTags.Location = new System.Drawing.Point(7, 46);
            this.buttonTileTags.Name = "buttonTileTags";
            this.buttonTileTags.Size = new System.Drawing.Size(75, 23);
            this.buttonTileTags.TabIndex = 3;
            this.buttonTileTags.Text = "Tags";
            this.buttonTileTags.UseVisualStyleBackColor = true;
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(104, 46);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(75, 23);
            this.buttonExport.TabIndex = 2;
            this.buttonExport.Text = "Export";
            this.buttonExport.UseVisualStyleBackColor = true;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(11, 21);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(30, 13);
            this.labelTime.TabIndex = 1;
            this.labelTime.Text = "Time";
            // 
            // numericTime
            // 
            this.numericTime.DecimalPlaces = 6;
            this.numericTime.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericTime.Location = new System.Drawing.Point(46, 19);
            this.numericTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericTime.Name = "numericTime";
            this.numericTime.Size = new System.Drawing.Size(133, 20);
            this.numericTime.TabIndex = 0;
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 200;
            // 
            // buttonShowAll
            // 
            this.buttonShowAll.Location = new System.Drawing.Point(153, 129);
            this.buttonShowAll.Name = "buttonShowAll";
            this.buttonShowAll.Size = new System.Drawing.Size(23, 23);
            this.buttonShowAll.TabIndex = 10;
            this.toolTip.SetToolTip(this.buttonShowAll, "Show All Tiles");
            this.buttonShowAll.UseVisualStyleBackColor = true;
            // 
            // TileEditorForm
            // 
            this.ClientSize = new System.Drawing.Size(684, 391);
            this.Controls.Add(this.groupBoxControls);
            this.Controls.Add(this.groupBoxViewPort);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(700, 430);
            this.Name = "TileEditorForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tile Editor";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.ShowHelp);
            ((System.ComponentModel.ISupportInitialize)(this.viewPort)).EndInit();
            this.groupBoxViewPort.ResumeLayout(false);
            this.groupBoxControls.ResumeLayout(false);
            this.flowLayoutPanel.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageQuads.ResumeLayout(false);
            this.groupBoxQuads.ResumeLayout(false);
            this.groupBoxButtons.ResumeLayout(false);
            this.tabPageBitmask.ResumeLayout(false);
            this.tabPageBitmask.PerformLayout();
            this.groupBoxQuadSettings.ResumeLayout(false);
            this.groupBoxQuadSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericX)).EndInit();
            this.groupBoxExportSettings.ResumeLayout(false);
            this.groupBoxExportSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTime)).EndInit();
            this.ResumeLayout(false);

		}



        #endregion

        private System.Windows.Forms.PictureBox viewPort;
        private System.Windows.Forms.GroupBox groupBoxViewPort;
        private System.Windows.Forms.GroupBox groupBoxControls;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.GroupBox groupBoxQuads;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.GroupBox groupBoxQuadSettings;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.NumericUpDown numericHeight;
        private System.Windows.Forms.NumericUpDown numericWidth;
        private System.Windows.Forms.NumericUpDown numericY;
        private System.Windows.Forms.NumericUpDown numericX;
        private System.Windows.Forms.GroupBox groupBoxButtons;
        private System.Windows.Forms.GroupBox groupBoxExportSettings;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.NumericUpDown numericTime;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageQuads;
        private System.Windows.Forms.TabPage tabPageBitmask;
        private System.Windows.Forms.Button buttonMask128;
        private System.Windows.Forms.Button buttonMask64;
        private System.Windows.Forms.Button buttonMask32;
        private System.Windows.Forms.Button buttonMask16;
        private System.Windows.Forms.Button buttonTILE;
        private System.Windows.Forms.Button buttonMask8;
        private System.Windows.Forms.Button buttonMask4;
        private System.Windows.Forms.Button buttonMask2;
        private System.Windows.Forms.Button buttonMask1;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button buttonTileTags;
        private System.Windows.Forms.CheckBox checkBoxBitmaskMode;
        private System.Windows.Forms.Button buttonShowAll;
    }}