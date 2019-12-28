using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PeachFox.TileEditor
{
    static class TileSetBox
    {
        private static PictureBox _pictureBox;
        public static PictureBox PictureBox
        {
            get => _pictureBox;
            set
            {
                _pictureBox = value;
                PictureBox.MouseDown += new MouseEventHandler(MouseDown);
                PictureBox.MouseUp += new MouseEventHandler(MouseUp);
                PictureBox.MouseWheel += new MouseEventHandler(MouseWheel);
                PictureBox.MouseClick += new MouseEventHandler(MouseClick);
                PictureBox.Paint += new PaintEventHandler(Draw);
                PictureBox.Resize += new System.EventHandler(Resize);
            }
        }
        private static Image _image;
        public static Image Image
        {
            get => _image;
            set
            {
                _image = value;
                // Ratio
                Resize(null, null);
                // Cells
                if (CellSize != 0)
                {
                    CellCountX = value.Width / CellSize;
                    CellCountY = value.Height / CellSize;
                }
                else
                {
                    CellCountX = 0;
                    CellCountY = 0;
                }
                //
                CenterImage();
            }
        }
        private static List<int> _quads;
        public static List<int> Quads
        {
            get => _quads;
            set
            {
                if (value.Count % 4 != 0)
                    throw new System.Exception("Invalid list size");
                _quads = value;
            }
        }

        private static float _zoomFactor = 1f;
        public static float ZoomFactor
        {
            get => _zoomFactor;
            set
            {
                _zoomFactor = value;
                if (_zoomFactor < 1f)
                    _zoomFactor = 1f;
                else if (_zoomFactor > 8f)
                    _zoomFactor = 8f;
            }
        }
        public static int CellSize = 0;
        public static float ScrollStep = 0.01f;

        public static Color CellColor = Color.FromArgb(150, Color.DarkGray);
        public static Color SelectedColor = Color.FromArgb(175, Color.Red);

        private static float ImageRatio;
        private static float TranslateRatio;
        private static int CellCountX = 0, CellCountY = 0;
        private static float TranslateX = 0f, TranslateY = 0f;
        private static float TranslateStartX = 0f, TranslateStartY = 0f;

        public static void Dispose()
        {
            if (Image != null) 
                Image.Dispose();
        }
        public static void Reset()
        {
            ZoomFactor = 1f;
            TranslateX = 0f;
            TranslateY = 0f;

            Redraw();
        }
        
        public static void Redraw()
        {
            PictureBox.Refresh();
        }

        public static Image GetThumbnail(int width = 100, int height = 100)
        {
            if (Quads.Count < 4 || Image == null) 
                return null;

            Bitmap export = new Bitmap(width, height, Image.PixelFormat);

            try
            {
                export.SetResolution(Image.HorizontalResolution, Image.VerticalResolution);

                Graphics gExport = Graphics.FromImage(export);
                gExport.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
                gExport.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                gExport.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                 
                gExport.DrawImage(Image, new Rectangle(0, 0, width, height), Quads[0], Quads[1], Quads[2], Quads[3], GraphicsUnit.Pixel);

                gExport.Dispose();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Exception while creating Thumbnail: {ex.Message}");
                export.Dispose();
                return null;
            }
            return export;
        }
        public static void CenterImage()
        {
            if (Image == null || PictureBox == null)
                return;
            ZoomFactor = 1f;

            TranslateX = ((PictureBox.Width / 2) * (TranslateRatio / ZoomFactor)) - (Image.Width / 2);
            TranslateY = ((PictureBox.Height / 2) * (TranslateRatio / ZoomFactor)) - (Image.Height / 2);

            Redraw();
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

            Redraw();
        }
        private static void MouseWheel(object sender, MouseEventArgs e)
        {
            float step = e.Delta * ScrollStep;
            ZoomFactor += step;

            if (ZoomFactor > 1f && ZoomFactor < 8f)
            {
                TranslateX = (TranslateX - e.X) * (TranslateRatio / ZoomFactor);
                TranslateY = (TranslateY - e.Y) * (TranslateRatio / ZoomFactor);
            }

            Redraw();
        }
        private static void MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                CenterImage();
            }
        }
        private static void Resize(object sender, System.EventArgs e)
        {
            if (Image.Width > Image.Height)
            {
                ImageRatio = (float)PictureBox.Width / Image.Width;
                TranslateRatio = Image.Width / (float)PictureBox.Width;
            }
            else
            {
                ImageRatio = (float)PictureBox.Height / Image.Height;
                TranslateRatio = Image.Height / (float)PictureBox.Height;
            }

            CenterImage();
        }
        private static void Draw(object sender, PaintEventArgs e)
        {
            if (Image == null) return;

            Graphics g = e.Graphics;

            g.ScaleTransform(ImageRatio * ZoomFactor, ImageRatio * ZoomFactor);
            g.TranslateTransform(TranslateX, TranslateY);

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.DrawImage(Image, 0, 0);

            Pen p = new Pen(CellColor, 1/ZoomFactor);
            float penOffset = p.Width / 2;
            float penDistanceOffset = 0.5f; // Width * ZoomFactor / 2 // (Width * ZoomFactor) will always be 1
            for (int y = 0; y < CellCountY + 1; y++)
                g.DrawLine(p, -penOffset, y * CellSize - penDistanceOffset, CellCountX * CellSize + penOffset, y * CellSize - penDistanceOffset);
            for (int x = 0; x < CellCountX + 1; x++)
                g.DrawLine(p, x * CellSize - penDistanceOffset, -penOffset, x * CellSize - penDistanceOffset, CellCountY * CellSize + penOffset);
            p.Dispose();

            if (Quads != null)
            {
                p = new Pen(SelectedColor);
                for (int i = 0; i < Quads.Count / 4; i += 4)
                    g.DrawRectangle(p, Quads[i], Quads[i + 1], Quads[i + 2], Quads[i + 3]);

                p.Dispose();
            }
        }
    }
}