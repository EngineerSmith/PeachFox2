using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PeachFox.TileEditor
{
    public class TileViewPort
    {
        private PictureBox _pictureBox;
        public PictureBox PictureBox
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
        private Image _image;
        public Image Image
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
                // Redraw
                CenterImage();
            }
        }
        private List<int> _quads;
        public List<int> Quads //X, Y, W, H, BOOL
        {
            get => _quads;
            set
            {
                if (value.Count % 5 != 0)
                    throw new System.Exception("Invalid list size");
                _quads = value;
                Redraw();
            }
        }

        private float _zoomFactor = 1f;
        public float ZoomFactor
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
        public int CellSize = 0;
        public float ScrollStep = 0.01f;

        public Color CellColor = Color.FromArgb(150, Color.DarkGray);
        public Color QuadColor = Color.FromArgb(175, Color.Blue);
        public Color SelectedColor = Color.FromArgb(175, Color.Red);

        private float ImageRatio;
        private float TranslateRatio;
        private int CellCountX = 0, CellCountY = 0;
        private float TranslateX = 0f, TranslateY = 0f;
        private float TranslateStartX = 0f, TranslateStartY = 0f;

        public TileViewPort(PictureBox pictureBox)
        {
            PictureBox = pictureBox;
        }

        public void Dispose()
        {
            if (Image != null) 
                Image.Dispose();
        }
        public void Reset()
        {
            ZoomFactor = 1f;
            TranslateX = 0f;
            TranslateY = 0f;

            Redraw();
        }
        
        public void Redraw()
        {
            PictureBox.Refresh();
        }

        public void CenterImage()
        {
            if (Image == null || PictureBox == null)
                return;
            ZoomFactor = 1f;

            TranslateX = ((PictureBox.Width / 2) * (TranslateRatio / ZoomFactor)) - (Image.Width / 2);
            TranslateY = ((PictureBox.Height / 2) * (TranslateRatio / ZoomFactor)) - (Image.Height / 2);

            Redraw();
        }

        public Image GetThumbnail(int width = 100, int height = 100)
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
        

        private void MouseDown(object sender, MouseEventArgs e)
        {
            TranslateStartX = e.X;
            TranslateStartY = e.Y;
        }
        private void MouseUp(object sender, MouseEventArgs e)
        {
            TranslateX += (e.X - TranslateStartX) * (TranslateRatio / ZoomFactor);
            TranslateY += (e.Y - TranslateStartY) * (TranslateRatio / ZoomFactor);

            Redraw();
        }
        private void MouseWheel(object sender, MouseEventArgs e)
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
        private void MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                CenterImage();
            }
        }
        private void Resize(object sender, System.EventArgs e)
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
        private void Draw(object sender, PaintEventArgs e)
        {
            if (Image == null) return;

            Graphics g = e.Graphics;

            g.ScaleTransform(ImageRatio * ZoomFactor, ImageRatio * ZoomFactor);
            g.TranslateTransform(TranslateX, TranslateY);

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.DrawImage(Image, 0, 0);

            Pen p = new Pen(CellColor, 1/ZoomFactor);
            float penDistanceOffset = 0.5f; // Width * ZoomFactor / 2. // (Width * ZoomFactor) will always be 1
            for (int y = 0; y < CellCountY + 1; y++)
                g.DrawLine(p, -penDistanceOffset, y * CellSize - penDistanceOffset, CellCountX * CellSize - penDistanceOffset, y * CellSize - penDistanceOffset);
            for (int x = 0; x < CellCountX + 1; x++)
                g.DrawLine(p, x * CellSize - penDistanceOffset, -penDistanceOffset, x * CellSize - penDistanceOffset, CellCountY * CellSize - penDistanceOffset);
            p.Dispose();

            if (Quads != null)
            {
                Pen SelectedPen = new Pen(SelectedColor, (1 / ZoomFactor) * 1.5f);
                Pen QuadPen = new Pen(QuadColor, (1 / ZoomFactor) * 1.5f);
                for (int i = 0; i < Quads.Count; i += 5)
                    g.DrawRectangle(Quads[i + 4] != 0 ? SelectedPen : QuadPen,
                        Quads[i] - penDistanceOffset, Quads[i + 1] - penDistanceOffset, Quads[i + 2], Quads[i + 3]);
                
                SelectedPen.Dispose();
                QuadPen.Dispose();
            }
        }
    }
}