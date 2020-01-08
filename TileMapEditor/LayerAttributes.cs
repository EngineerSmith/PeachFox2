namespace PeachFox.TileMapEditor
{
    public class LayerAttributes
    {
        public string name;
        public Layer layer;
        public System.Drawing.Image image;
        public bool drawToViewPort = true;

        public LayerAttributes(string name, Layer layer)
        {
            this.name = name;
            this.layer = layer;
        }

        public LayerAttributes(Layer layer)
        {
            this.layer = layer;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
