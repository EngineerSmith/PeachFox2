using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace PeachFox.TileMapEditor
{
    public class TileMapViewPort : ViewPort
    {
        private List<Tile> _tiles;
        public List<Tile> Tiles
        {
            get => _tiles;
            set => _tiles = value;
        }

        public Dictionary<string, Image> Images;

        private float ScaleRatio = 1f;

        public TileMapViewPort(PictureBox pictureBox)
        {
            PictureBox = pictureBox;
        }

        protected override void Draw(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.ScaleTransform(ScaleRatio * ZoomFactor, ScaleRatio * ZoomFactor);
            g.TranslateTransform(TranslateX, TranslateY);

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;

            foreach (Tile tile in Tiles)
            {
                g.DrawImage(Images[tile.Image], (float)tile.X, (float)tile.Y);
            }
        }

        protected override void Resize(object sender, System.EventArgs e)
        {
            Redraw();
        }
    }
}
