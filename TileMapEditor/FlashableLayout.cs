using System.Windows.Forms;

namespace PeachFox.TileMapEditor
{
    class FlashableLayout : Flashable
    {
        private FlowLayoutPanel _flow;

        public FlashableLayout(FlowLayoutPanel flow)
            : base(flow)
        {
            _flow = flow;
        }
    }
}
