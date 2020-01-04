using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace PeachFox.TileMapEditor
{
    public class TileMapViewPort : ViewPort
    {
        public Tilemap Tilemap;

        public List<Image> Images;

        private float ScaleRatio = 1f;

        public int CellSize = 16;
        public Color CellColor = Color.FromArgb(150, Color.DarkGray);


        public TileMapViewPort(PictureBox pictureBox)
        {
            PictureBox = pictureBox;
            CenterViewPort();
        }

        protected override void Draw(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.ScaleTransform(ScaleRatio * ZoomFactor, ScaleRatio * ZoomFactor);
            g.TranslateTransform(TranslateX, TranslateY);

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;

            //CellSize
            float x = -TranslateX;
            float y = -TranslateY;
            float ix = x - (x % CellSize) - CellSize;
            float iy = y - (y % CellSize) - CellSize;

            Pen p = new Pen(CellColor, 1 / ZoomFactor);
            float penDistanceOffset = 0.5f; // Width * ZoomFactor / 2. // (Width * ZoomFactor) will always be 1
            for (y = iy; y < PictureBox.Height - TranslateY + CellSize*2; y+=CellSize)
                g.DrawLine(p, ix-penDistanceOffset, y - penDistanceOffset, ix+PictureBox.Width + CellSize*2, y - penDistanceOffset);
            for (x = ix; x < PictureBox.Width - TranslateX + CellSize*2; x+=CellSize)
                g.DrawLine(p, x - penDistanceOffset, iy-penDistanceOffset, x - penDistanceOffset, iy+PictureBox.Height + CellSize*2);

            g.DrawRectangle(Pens.Red, -penDistanceOffset, -penDistanceOffset, CellSize, CellSize);

            if (Tilemap != null)
            {
                foreach (Layer layer in Tilemap.Layers)
                    foreach (LayerTile tile in layer.Tiles)
                        g.DrawImage(Images[(int)tile.TileIndex], (int)tile.X, (int)tile.Y);
            }

            p.Color = Color.Red;
            g.DrawLine(p, -penDistanceOffset, iy - penDistanceOffset, -penDistanceOffset, iy + PictureBox.Height + CellSize * 2);
            g.DrawLine(p, ix - penDistanceOffset, -penDistanceOffset, ix + PictureBox.Width + CellSize * 2, -penDistanceOffset);
            p.Dispose();
        }

        protected override void Resize(object sender, System.EventArgs e)
        {
            CenterViewPort();
        }
    }
}
