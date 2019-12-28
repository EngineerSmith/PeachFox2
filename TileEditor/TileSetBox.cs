using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PeachFox.TileEditor
{
    static class TileSetBox
    {
        public static PictureBox PictureBox
        {
            get => PictureBox;
            set
            {
                PictureBox = value;
                PictureBox.Paint += new PaintEventHandler(Draw);
                PictureBox.MouseDown += new MouseEventHandler(MouseDown);
                PictureBox.MouseUp += new MouseEventHandler(MouseUp);
            }
        }
        public static Image Image
        {
            get => Image;
            set
            {
                Image = value;
                // Ratio
                if (value.Width > value.Height)
                {
                    ImageRatio = (float)PictureBox.Width / value.Width;
                    TranslateRatio = value.Width / (float)PictureBox.Width;
                }
                else
                {
                    ImageRatio = (float)PictureBox.Height / value.Height;
                    TranslateRatio = value.Height / (float)PictureBox.Height;
                }
                // Cells
                if (CellSize != 0)
                {
                    CellCountX = (int)(value.Width / CellSize);
                    CellCountY = (int)(value.Height / CellSize);
                }
                else
                {
                    CellCountX = 0;
                    CellCountY = 0;
                }
            }
        }
        public static List<int> Quads
        {
            get => Quads;
            set
            {
                if (Quads.Count % 4 != 0)
                    throw new System.Exception("Invalid list size");
                Quads = value;
            }
        }

        public static float ZoomFactor = 1f;
        public static float TranslateX = 0f, TranslateY = 0f;
        public static float CellSize = 0f;

        public static Color CellColor = Color.FromArgb(150, Color.DarkGray);
        public static Color SelectedColor = Color.FromArgb(175, Color.Red);

        private static float ImageRatio;
        private static float TranslateRatio;
        private static int CellCountX = 0, CellCountY = 0;
        private static float TranslateStartX = 0f, TranslateStartY = 0f;

        public static void Reset()
        {
            ZoomFactor = 1f;
            TranslateX = 0f;
            TranslateY = 0f;
            CellSize = 0f;
        }
        public static void Redraw()
        {
            PictureBox.Refresh();
        }

        private static void MouseDown(object sender, MouseEventArgs e)
        {
            TranslateStartX = e.X;
            TranslateStartY = e.Y;
        }
        private static void MouseUp(object sender, MouseEventArgs e)
        {
            TranslateX += (e.X - TranslateStartX) * (TranslateRatio / ZoomFactor);
            TranslateY += (e.Y - TranslateStartY) * (TranslateRatio / ZoomFactor);

            PictureBox.Refresh();
        }
        private static void Draw(object sender, PaintEventArgs e)
        {
            if (Image == null) return;

            Graphics g = e.Graphics;

            g.ScaleTransform(ImageRatio * ZoomFactor, ImageRatio * ZoomFactor);
            g.TranslateTransform(TranslateX, TranslateY);

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.DrawImage(Image, 0, 0);

            Pen p = new Pen(CellColor);
            for (int y = 0; y < CellCountY + 1; y++)
                g.DrawLine(p, 0, y * CellSize, CellCountX * CellSize, y * CellSize);
            for (int x = 0; x < CellCountX + 1; x++)
                g.DrawLine(p, x * CellSize, 0, x * CellSize, CellCountY * CellSize);
            p.Dispose();

            p = new Pen(SelectedColor);
            for (int i = 0; i < Quads.Count / 4; i += 4)
                g.DrawRectangle(p, Quads[i], Quads[i+1], Quads[i+2], Quads[i+3]);

            p.Dispose();
        }
    }
}