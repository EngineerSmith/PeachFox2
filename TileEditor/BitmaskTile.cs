using System.Collections.Generic;
using System.Linq;

namespace PeachFox.TileEditor
{
    public class BitmaskTiles
    {
        public System.Drawing.Image Thumbnail;
        public List<BitmaskTile> Tiles;
        public int Mode;
        public string Id { get; }

        public BitmaskTiles()
        {
            Id = RandomString.Generate(16);
            Tiles = new List<BitmaskTile>();
        }

        public BitmaskTiles(List<BitmaskTile> tiles)
        {
            Tiles = tiles ?? new List<BitmaskTile>();
            Id = RandomString.Generate(16);
            if (Tiles.Count > 0)
            {
                Tag id = Tiles[0].Tags.SingleOrDefault(tag => tag.Name == "bitmaskId");
                if (id != null)
                    Id = id.StringValue;
            }
        }

        public List<Tile> GetTiles()
        {
            foreach (var tile in Tiles)
            {
                List<Tag> tags = tile.Tags.FindAll(tag => tag.Name == "bitmaskId" || tag.Name == "bitmaskMode" || tag.Name == "bitmaskBit");
                if (tags.Count == 3)
                    foreach(Tag tag in tags)
                        if (tag.Name == "bitmaskId")
                            tag.SetString(Id);
                        else if (tag.Name == "bitmaskMode")
                            tag.SetNumber(Mode);
                        else if (tag.Name == "bitmaskBit")
                            tag.SetNumber(tile.Bit);
                else
                    tile.Tags.AddRange(new List<Tag>() { new Tag("bitmaskId", Id), new Tag("bitmaskMode", Mode), new Tag("bitmaskBit", tile.Bit) });
            }

            return Tiles.Cast<Tile>().ToList();
        }
    }
}
