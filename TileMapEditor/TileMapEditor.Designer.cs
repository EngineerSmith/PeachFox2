namespace PeachFox
{    partial class TileMapEditorForm
    {
        /// <summary>        /// Required designer variable.        /// </summary>        private System.ComponentModel.IContainer components = null;

        /// <summary>        /// Clean up any resources being used.        /// </summary>        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>        protected override void Dispose(bool disposing)        {            if (disposing && (components != null))            {                components.Dispose();            }            base.Dispose(disposing);        }

        #region Windows Form Designer generated code
        /// <summary>        /// Required method for Designer support - do not modify        /// the contents of this method with the code editor.        /// </summary>        private void InitializeComponent()        {
            this.labelHelloWorld = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelHelloWorld
            // 
            this.labelHelloWorld.AutoSize = true;
            this.labelHelloWorld.Location = new System.Drawing.Point(12, 9);
            this.labelHelloWorld.Name = "labelHelloWorld";
            this.labelHelloWorld.Size = new System.Drawing.Size(62, 13);
            this.labelHelloWorld.TabIndex = 0;
            this.labelHelloWorld.Text = "Hello World";
            // 
            // TileMapEditorForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.labelHelloWorld);
            this.Name = "TileMapEditorForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }




        #endregion
        private System.Windows.Forms.Label labelHelloWorld;
    }}