﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PeachFox.TileEditor
{
    public class TileViewPort : ViewPort
    {
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
                CellCountX = value.Width / CellSize;
                CellCountY = value.Height / CellSize;
                // Redraw
                CenterViewPort();
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

        public List<int> Notes = new List<int>();
        public bool ShowNotes = false;

        private int _cellSize = 16;
        public int CellSize
        {
            get => _cellSize;
            set
            {
                _cellSize = value;
                if (Image != null)
                {
                    CellCountX = Image.Width / value;
                    CellCountY = Image.Height / value;
                }
                Redraw();
            }
        }


        public Color CellColor = Color.FromArgb(150, Color.DarkGray);
        public Color QuadColor = Color.FromArgb(175, Color.Blue);
        public Color SelectedColor = Color.FromArgb(175, Color.Red);

        private float ImageRatio;
        private int CellCountX = 0, CellCountY = 0;

        public TileViewPort(PictureBox pictureBox)
        {
            PictureBox = pictureBox;
        }

        public void Dispose()
        {
            if (Image != null)
                Image.Dispose();
        }

        public override void CenterViewPort()
        {
            ZoomFactor = 1f;
            TranslateX = ((PictureBox.Width / 2) * (TranslateRatio / ZoomFactor)) - (Image.Width / 2);
            TranslateY = ((PictureBox.Height / 2) * (TranslateRatio / ZoomFactor)) - (Image.Height / 2);

            Redraw();
        }

        public Image GetThumbnail(int width = 100, int height = 100)
        {
            if (Quads.Count < 4 || Image == null)
                return null;
            return CropImage(Image, Quads[0], Quads[1], Quads[2], Quads[3], width, height);
        }

        public Image GetTileImage()
        {
            if (Quads.Count < 4 || Image == null)
                return null;
            return CropImage(Image, Quads[0], Quads[1], Quads[2], Quads[3], Quads[2], Quads[3]);
        }

        protected override void Resize(object sender, System.EventArgs e)
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

            CenterViewPort();
        }
        protected override void Draw(object sender, PaintEventArgs e)
        {
            if (Image == null)
                return;

            Graphics g = e.Graphics;

            g.ScaleTransform(ImageRatio * ZoomFactor, ImageRatio * ZoomFactor);
            g.TranslateTransform(TranslateX, TranslateY);

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.DrawImage(Image, 0, 0);

            Pen p = new Pen(CellColor, 1 / ZoomFactor);
            float penDistanceOffset = 0.5f; // Width * ZoomFactor / 2. // (Width * ZoomFactor) will always be 1
            for (int y = 0; y < CellCountY + 1; y++)
                g.DrawLine(p, -penDistanceOffset, y * CellSize - penDistanceOffset, CellCountX * CellSize - penDistanceOffset, y * CellSize - penDistanceOffset);
            for (int x = 0; x < CellCountX + 1; x++)
                g.DrawLine(p, x * CellSize - penDistanceOffset, -penDistanceOffset, x * CellSize - penDistanceOffset, CellCountY * CellSize - penDistanceOffset);
            p.Dispose();

            if (Quads != null)
            {
                if (ShowNotes == false)
                {
                    Pen SelectedPen = new Pen(SelectedColor, (1 / ZoomFactor) * 1.5f);
                    Pen QuadPen = new Pen(QuadColor, (1 / ZoomFactor) * 1.5f);
                    for (int i = 0; i < Quads.Count; i += 5)
                        g.DrawRectangle(Quads[i + 4] != 0 ? SelectedPen : QuadPen,
                            Quads[i] - penDistanceOffset, Quads[i + 1] - penDistanceOffset, Quads[i + 2], Quads[i + 3]);
                    SelectedPen.Dispose();
                    QuadPen.Dispose();
                }
                else
                {
                    for (int i = 0; i < Quads.Count; i += 5)
                    {
                        Color c = GetColorFromBit(Notes[i/5]);
                        g.DrawRectangle(new Pen(c, (1 / ZoomFactor) * 1.5f),
                                        Quads[i] - penDistanceOffset, Quads[i + 1] - penDistanceOffset, Quads[i + 2], Quads[i + 3]);
                        
                        string text = Notes[i/5].ToString();
                        SizeF size = g.MeasureString(text, Control.DefaultFont);
                        g.DrawString(text, Control.DefaultFont, new SolidBrush(c), 
                            Quads[i] + Quads[i+2]/2 - size.Width/2, Quads[i+1] + Quads[i+3]/2 - size.Height/2);

                    }
                }
            }
        }

        private Color GetColorFromBit(int bit)
        {
            Random rnd = new Random(bit);
            return Color.FromArgb(rnd.Next(50, 200), rnd.Next(50, 200), rnd.Next(50, 200));
        }
    }
}