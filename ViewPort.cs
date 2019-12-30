using System.Drawing;
using System.Windows.Forms;

namespace PeachFox
{
    public class ViewPort
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

        public float ScrollStep = 0.01f;

        protected float TranslateRatio;
        protected float TranslateX = 0f, TranslateY = 0f;
        private float TranslateStartX = 0f, TranslateStartY = 0f;

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
    }
}
