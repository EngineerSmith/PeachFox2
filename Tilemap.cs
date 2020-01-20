using System.Collections.Generic;
using System.Dynamic;

namespace PeachFox
{
    public class Tag
    {
        public string Name;
        public string StringValue { get; } = null;
        public decimal NumberValue { get; } = -1;
        public enum TagType { NULL, STRING, NUMBER };
        public TagType Type = TagType.NULL;

        public Tag(string name, object value)
        {
            Name = name;
            if (value.GetType() == typeof(decimal) || value.GetType() == typeof(int) || value.GetType() == typeof(float) || value.GetType() == typeof(double))
            {
                NumberValue = (decimal)value;
                Type = TagType.NUMBER;
            }
            else if (value.GetType() == typeof(string))
            {
                StringValue = (string)value;
                Type = TagType.STRING;
            }
            else
                throw new System.InvalidCastException();
        }
    }

    public class Tile
    {
        //
        public List<Tag> Tags;

        //
        public System.Drawing.Image Thumbnail;
    }

    public class ClassicTile : Tile
    {
        public string Image;
        public List<int> Quads;
        public float Time;
    }

    public class LayerTile
    {
        public int Index;
        public int X;
        public int Y;
        public List<Tag> Tags;
    }

    public class Layer
    {
        //Layer details
        public string Name;
        public List<LayerTile> Tiles;
        public List<Tag> Tags;

        //
        public System.Drawing.Image Image;
        public bool DrawToViewport = true;

        public override string ToString()
        {
            return Name;
        }
    }

    public class Tilemap
    {
        public List<Tile> Tiles;
        public List<Layer> Layers;
    }
}
