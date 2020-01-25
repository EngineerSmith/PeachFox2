using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace PeachFox.TileMapEditor
{
    public class TileMapViewPort : ViewPort
    {
        public List<LayerListItem> Layers;

        public Dictionary<int, Image> Images = new Dictionary<int, Image>();

        private float ScaleRatio = 1f;

        public int CellSize = 16;
        public Color CellColor = Color.FromArgb(150, Color.DarkGray);

        private Cell _hovered;
        private Cell _pre;
        public Cell GetCell { get => _hovered; }

        public TileMapViewPort(PictureBox pictureBox)
        {
            PictureBox = pictureBox;
            PictureBox.MouseMove += MouseMove;
            PictureBox.MouseClick += MouseClick;
            CenterViewPort();
        }

        public override void Redraw()
        {
            if (Layers != null)
                foreach (LayerListItem layer in Layers)
                    layer.Draw(Images, PictureBox.Width, PictureBox.Height, TranslateX, TranslateY, ScaleRatio * ZoomFactor);
            base.Redraw();
        }

        private void MouseClick(object sender, MouseEventArgs e)
        {
             Program.TileMapEditor.MouseInput(e);
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            if (_hovered != _pre)
            {
                if(Program.TileMapEditor.MouseInput(e))
                    _pre = _hovered;
            }

            if (EnableMouseTranslation)
                return;
            int mx = (int)(TranslateX - (e.X / ZoomFactor));
            int my = (int)(TranslateY - (e.Y / ZoomFactor));
            int Y = my - (my % CellSize) + (my > 0 ? CellSize : 0);
            int X = mx - (mx % CellSize) + (mx > 0 ? CellSize : 0);
            Cell current = new Cell{X=-X, Y=-Y};
            if (_hovered != current)
            {
                _hovered = current;
                Redraw();
            }
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
                g.DrawLine(p, ix - penDistanceOffset, y - penDistanceOffset, ix+PictureBox.Width + CellSize*2, y - penDistanceOffset);
            for (x = ix; x < PictureBox.Width - TranslateX + CellSize*2; x+=CellSize)
                g.DrawLine(p, x - penDistanceOffset, iy - penDistanceOffset, x - penDistanceOffset, iy+PictureBox.Height + CellSize*2);

            if (Layers != null)
            {
                g.ResetTransform();
                for (int i = Layers.Count - 1; i >= 0; i--)
                {
                    Layer layer = Layers[i].Layer;
                    if (layer.DrawToViewport && layer.Image != null)
                        g.DrawImage(layer.Image, 0,0);
                }
                g.ScaleTransform(ScaleRatio * ZoomFactor, ScaleRatio * ZoomFactor);
                g.TranslateTransform(TranslateX, TranslateY);
            }

            int tImage;
            if(!EnableMouseTranslation)
                if((tImage = Program.TileMapEditor.GetSelectedTileIndex()) != -1 && Images.ContainsKey(tImage))
                    g.DrawRectangle(Pens.Red, _hovered.X - penDistanceOffset, _hovered.Y - penDistanceOffset, Images[tImage].Width, Images[tImage].Height);
                else
                    g.DrawRectangle(Pens.Red, _hovered.X- penDistanceOffset, _hovered.Y- penDistanceOffset, CellSize, CellSize);

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
