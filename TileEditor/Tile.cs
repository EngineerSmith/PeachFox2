using System.Collections.Generic;

namespace PeachFox.TileEditor
{
    public struct Tile
    {
        public System.Drawing.Image Thumbnail;
        public string Image;
        public List<int> Quads;
        public float Time;
    }
}
