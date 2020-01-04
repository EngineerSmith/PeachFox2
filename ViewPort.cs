using System.Drawing;
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
                //Debug
                if (DebugZoom) 
                {
                    PictureBox.MouseMove += DebugZoomMouseMove;
                    PictureBox.Paint += DebugZoomDraw;
                }
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

        protected float ScrollStep = 0.005f;
        protected float TranslateRatio = 1f;
        protected float TranslateX = 0f, TranslateY = 0f;
        private float TranslateStartX = 0f, TranslateStartY = 0f;

        public bool EnableMouseMovement = true;

        private bool DebugZoom = false;
        private float _debugTranslateX = 0f, _debugTranslateY = 0f, _debugZoomFactor = 1f;

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
            if (!EnableMouseMovement)
                return;
            TranslateStartX = e.X;
            TranslateStartY = e.Y;
        }
        private void MouseUp(object sender, MouseEventArgs e)
        {
            if (!EnableMouseMovement)
                return;
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
            if (!EnableMouseMovement)
                return;
            float step = e.Delta * ScrollStep;
            float pre = ZoomFactor;
            ZoomFactor += step;

            float width = (PictureBox.Width / ZoomFactor) /2, height = (PictureBox.Height / ZoomFactor) /2;
            TranslateX = TranslateX - (e.X / pre) + width;
            TranslateY = TranslateY - (e.Y / pre) +height;

            Redraw();
        }

        private void DebugZoomMouseMove(object sender, MouseEventArgs e)
        {
            //120 used as that is the value of e.Delta when mouse wheel moves to zoom in
            _debugZoomFactor = ZoomFactor + (120 * ScrollStep); 

            float width = (PictureBox.Width / _debugZoomFactor) /2, height = (PictureBox.Height / _debugZoomFactor) /2;
            _debugTranslateX = TranslateX - (e.X / ZoomFactor) +width;
            _debugTranslateY = TranslateY - (e.Y / ZoomFactor) +height;
            
            Redraw();
        }

        private void DebugZoomDraw(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawRectangle(Pens.Red, -_debugTranslateX, -_debugTranslateY, PictureBox.Width / _debugZoomFactor, PictureBox.Height / _debugZoomFactor);
        }

        protected abstract void Resize(object sender, System.EventArgs e);
       
        protected abstract void Draw(object sender, PaintEventArgs e);
    }
}
