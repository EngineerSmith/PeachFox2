using System.Windows.Forms;

namespace PeachFox
{
    class Flashable
    {
        private Timer _timer;
        private Control _control;

        public Flashable(Control control)
        {
            _control = control;
        }

        public void Flash()
        {
            if (_timer != null)
                return;
            int tickCount = 0;
            _timer = new Timer()
            {
                Interval = 310,
                Enabled = false,
            };
            _timer.Tick += (sender, e) =>
            {
                if (_control.BackColor == System.Drawing.Color.LightBlue)
                    _control.BackColor = System.Drawing.Color.White;
                else
                    _control.BackColor = System.Drawing.Color.LightBlue;
                if (++tickCount >= 4)
                {
                    _timer.Stop();
                    _timer = null;
                }
            };
            _timer.Start();
        }
    }
}
