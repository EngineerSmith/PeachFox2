﻿using System.Drawing;
using System.Windows.Forms;

namespace PeachFox
{
    public abstract class ViewPort
    {
        private PictureBox _pictureBox;
        protected PictureBox PictureBox
        {
            get => _pictureBox;
            set
            {
                _pictureBox = value;
                PictureBox.MouseDown += MouseDown;
                PictureBox.MouseUp += MouseUp;
                PictureBox.MouseClick += MouseClick;
                PictureBox.MouseWheel += MouseWheel;
                PictureBox.Resize += Resize;
                PictureBox.Paint += Draw;
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

        protected float ScrollStep = 0.01f;
        protected float TranslateRatio = 1f;
        protected float TranslateX = 0f, TranslateY = 0f;
        private float TranslateStartX = 0f, TranslateStartY = 0f;

        public void Reset()
        {
            ZoomFactor = 1f;
            TranslateX = 0f;
            TranslateY = 0f;

            Redraw();
        }

        public virtual void CenterViewPort()
        {
            ZoomFactor = 1f;
            TranslateX = PictureBox.Width / 2f;
            TranslateY = PictureBox.Height / 2f;

            Redraw();
        }

        public void Redraw()
        {
            PictureBox.Refresh();
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
        private void MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
                CenterViewPort();
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

        protected abstract void Resize(object sender, System.EventArgs e);
       
        protected abstract void Draw(object sender, PaintEventArgs e);
    }
}
