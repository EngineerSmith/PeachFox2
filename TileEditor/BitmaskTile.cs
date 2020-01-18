using System.Collections.Generic;

namespace PeachFox.TileEditor
{
    public class BitmaskTile
    {
        public System.Drawing.Image Thumbnail;
        public System.Drawing.Image TileImage;
        public string Image;
        public List<int> Quads = new List<int>();
        public float Time;
        public int Bit=-1;
    }
    public class BitmaskTiles
    {
        public System.Drawing.Image Thumbnail;
        public List<BitmaskTile> Tiles = new List<BitmaskTile>();
        public int Mode;
        public string Id { get; }

        public BitmaskTiles()
            : this(RandomString.Generate(16)) {}

        public BitmaskTiles(string id)
        {
            Id = id;
        }

        public List<PeachFox.Tile> GetTiles()
        {
            List<PeachFox.Tile> tiles = new List<PeachFox.Tile>();
            foreach (var tile in Tiles)
            {
                PeachFox.Tile t = new PeachFox.Tile(new Quad(tile.Quads), tile.Image, tile.Quads.Count > 4 ? (double?)tile.Time : null);
                t.SetValue("BitmaskID", Id);
                t.SetValue("BitmaskMode", Mode);
                tiles.Add(t);
            }
            return tiles;
        }
    }
}
