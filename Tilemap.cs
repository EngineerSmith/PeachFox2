using System.Collections.Generic;
using System.Dynamic;

namespace PeachFox
{
    public class Tag
    {
        public string Name;
        public string StringValue { get; private set; } = null;
        public decimal NumberValue { get; private set; } = -1;
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

        public void SetString(string str)
        {
            Type = TagType.STRING;
            StringValue = str;
        }

        public void SetNumber(decimal num)
        {
            Type = TagType.NUMBER;
            NumberValue = num;
        }

        public override string ToString()
        {
            string str = $"\"{Name}\"=";
            if (Type == TagType.STRING)
                return str +$"\"{StringValue}\"";
            else if (Type == TagType.NUMBER)
                return str + $"{NumberValue}";
            return null;
        }
    }

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
