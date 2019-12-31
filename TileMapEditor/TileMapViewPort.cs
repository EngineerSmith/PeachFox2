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

            g.DrawRectangle(new Pen(Color.Red), new Rectangle(-10, -10, 10, 10));

            if (Tilemap == null)
                return;

            foreach (Layer layer in Tilemap.Layers)
                foreach (LayerTile tile in layer.Tiles)
                    g.DrawImage(Images[(int)tile.TileIndex], (int)tile.X, (int)tile.Y);
        }

        protected override void Resize(object sender, System.EventArgs e)
        {
            CenterViewPort();
        }
    }
}
