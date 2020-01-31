using System.Collections.Generic;
using System.Dynamic;

namespace PeachFox
{
    public class Tile
    {
        public List<Tag> Tags = new List<Tag>();

        public System.Drawing.Image Thumbnail;
        public System.Drawing.Image TileImage;
    }

    public class ClassicTile : Tile
    {
        public string Image;
        public List<int> Quads;
        public float Time;
    }

    public class BitmaskTile : ClassicTile
    {
        public int Bit = -1;
    }

    public class LayerTile
    {
        public int Index;
        public int X;
        public int Y;
        public List<Tag> Tags = new List<Tag>();
    }

    public class Layer
    {
        public string Name;
        public List<LayerTile> Tiles = new List<LayerTile>();
        public List<Tag> Tags = new List<Tag>();

        public System.Drawing.Image Image;
        public bool DrawToViewport = true;

        public override string ToString()
        {
            return Name;
        }
    }

    public class Tilemap
    {
        public List<Tile> Tiles = new List<Tile>();
        public List<Layer> Layers = new List<Layer>();
    }
}
