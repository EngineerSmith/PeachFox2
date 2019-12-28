namespace PeachFox{    partial class TileEditorForm    {		        /// <summary>        /// Required designer variable.        /// </summary>        private System.ComponentModel.IContainer components = null;        /// <summary>        /// Clean up any resources being used.        /// </summary>        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>        protected override void Dispose(bool disposing)        {            if (disposing && (components != null))            {                components.Dispose();            }            base.Dispose(disposing);        }        #region Windows Form Designer generated code        /// <summary>        /// Required method for Designer support - do not modify        /// the contents of this method with the code editor.        /// </summary>        private void InitializeComponent()        {            this.viewPort = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.viewPort)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewPort
            // 
            this.viewPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPort.Location = new System.Drawing.Point(3, 16);
            this.viewPort.Name = "viewPort";
            this.viewPort.Size = new System.Drawing.Size(729, 331);
            this.viewPort.TabIndex = 0;
            this.viewPort.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.viewPort);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(735, 350);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "View Port";
            // 
            // TileEditorForm
            // 
            this.ClientSize = new System.Drawing.Size(735, 350);
            this.Controls.Add(this.groupBox1);
            this.Name = "TileEditorForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowIcon = false;
            this.Text = "Tile Editor";
            ((System.ComponentModel.ISupportInitialize)(this.viewPort)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}



        #endregion

        private System.Windows.Forms.PictureBox viewPort;
        private System.Windows.Forms.GroupBox groupBox1;
    }}