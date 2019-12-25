using System.Collections.Generic;
using LsonLib;

/// <summary>
/// This C# file converts 'String' luaTables and makes them editable 
/// A single Tile looks like:
/// {quad={x, y, w, h}, time=time, image=image, x=x, y=y, colliable=colliable}
/// Examples:
/// {quad={0, 0, 8, 8}, image="path/to/img.png", x=0, y=0, colliable=true}
/// {quad={0, 0, 8, 8, 1, 1, 8, 8}, time=0.2, image="Asset.Images.SpriteSheet54", x=0, y=0, colliable=false}
/// 
/// Quad is an int array, this is so muiltple quads can be put into a tile
/// E.g. 0,0,8,8, 1,1,8,8 this allows for animation
/// 
/// Time is a variable that dictates how long each quad will last if there are muiltple
/// 
/// Image is a string, designed to take any string information.
/// So if you don't want a path to be inserted, but say an ID of a lua table of 
/// assets you can do that.
/// 
/// X and Y will be where the tile is drawn
/// 
/// Colliable is a boolean to check if the tile is passable
/// 
/// </summary>

namespace PeachFox
{
    public class Quad
    {
        public List<int> Values
        {
            get
            {
                List<int> r = new List<int>();
                for (int i = 1; _root[i].GetIntSafe() != null; i++)
                {
                    r.Add(_root[i].GetInt());
                }
                return r;
            }
            set
            {
                for (int i = 0; i < value.Count; i++)
                {
                    _root[i] = value[i];
                }
            }
        }

        private LsonDict _root;

        public Quad()
        {
            _root = new LsonDict();
        }
        public Quad(List<int> quad)
        {
            _root = new LsonDict();
            Values = quad;
        }
        public Quad(LsonDict root)
        {
            _root = root;
        }

        public static explicit operator LsonDict(Quad value)
        {
            return value._root;
        }
        public static explicit operator Quad(LsonDict value)
        {
            return new Quad(value);
        }
    }

    public class Tile
    {
        public Quad Quad
        {
            get => (Quad)_root["quad"];
            set => _root["quad"] = (LsonDict)value;
        }
        public double? Time
        {
            get => _root["time"].GetDoubleSafe();
            set => _root["time"] = value;
        }
        public string Image
        {
            get => _root["image"].GetStringSafe();
            set => _root["image"] = value;
        }
        public int? X
        {
            get => _root["x"].GetIntSafe();
            set => _root["x"] = value;
        }
        public int? Y
        {
            get => _root["y"].GetIntSafe();
            set => _root["y"] = value;
        }
        public bool? Colliable
        {
            get => _root["colliable"].GetBoolSafe();
            set => _root["colliable"] = value;
        }

        private LsonDict _root;

        public Tile()
        {
            _root = new LsonDict();
        }
        public Tile(Quad quad, string image, int x, int y, bool colliable, double time = 0d)
        {
            _root = new LsonDict();
            Quad = quad;
            Image = image;
            X = x;
            Y = y;
            Colliable = colliable;
            if (time != 0d) Time = time;
        }

        public Tile(LsonDict root)
        {
            _root = new LsonDict();
        } 

        public static explicit operator LsonDict(Tile value)
        {
            return value._root;
        }
        public static explicit operator Tile(LsonDict value)
        {
            return new Tile(value);
        }
    }
    
    public class Tilemap
    {
        private readonly Dictionary<string, LsonValue> _maps;
        private readonly string _key;
        public LsonDict MapRaw
        {
            get => _maps[_key].GetDict();
        }
        public List<Tile> Map
        {
            get
            {
                List<Tile> r = new List<Tile>();
                for (int i = 1; _maps[_key][i].GetDictSafe() != null; i++)
                    r.Add((Tile)_maps[_key][i].GetDict());
                return r;
            }
            set
            {
                LsonDict map = new LsonDict();
                for (int i = 0; i < value.Count; i++)
                    map.Add(i, (LsonDict)value[i]);
                _maps[_key] = map;
            }
        }

        public Tilemap(string name, string luaTable)
        {
            _key = name;
            _maps = LsonVars.Parse(luaTable);

            if (_maps.ContainsKey(name) == false)
                throw new System.Exception($"luaTable does not contain: {name}");
        }

        public string String()
        {
            return LsonVars.ToString(_maps);
        }
    }
}