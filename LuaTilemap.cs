using System.Collections.Generic;
using LsonLib;

/// Produces a file, of the following format
/// 
/// ----
///local tiles =
///{
///     {quad={ 0, 0,16,16}, image="tileset.base"}, -- Basic tile
///     {quad={ 0,16,16,16, 16,16,16,16}, time=0.1, image="tileset.base"} --Animated Tile
///}
///
///local layers =
///{
///    {
///        name="Foreground", -- SetValue("name", "Foreground")
///        {tile=1, x= 0, y= 0, colliable=true}, -- SetValue("colliable", true)
///        {tile=2, x=16, y=16, colliable=false}, -- SetValue("colliable", true)
///    },
///    {
///        name="Background" -- SetValue("name", "Background")
///    }
///}
///
///return {tiles=tiles, layers=layers}

namespace PeachFox
{
    public class Quad
    {
        public List<int> Values
        {
            get
            {
                List<int> r = new List<int>();
                for (int i = 1; _root.ContainsKey(i); i++)
                    r.Add(_root[i].GetInt());
                return r;
            }
            set
            {
                for (int i = 0; i < value.Count; i++)
                    _root[i+1] = value[i];
            }
        }

        private readonly LsonDict _root;

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

        public static bool operator ==(Quad right, Quad left)
        {
            List<int> a = right?.Values;
            List<int> b = left?.Values;
            if (a == null) return b == null;
            if (b == null || a.Count != b.Count) return false;
            for (int i = 0; i < a.Count; i++)
                if (!(a[i] == b[i]))
                    return false;
            return true;
        }

        public static bool operator !=(Quad right, Quad left)
        {
            return !(right == left);
        }
        /// MSVS Auto-Generated
        public override bool Equals(object obj)
        {
            return obj is Quad quad;
        }
        public override int GetHashCode()
        {
            var hashCode = -1006183635;
            hashCode = hashCode * -1521134295 + EqualityComparer<List<int>>.Default.GetHashCode(Values);
            hashCode = hashCode * -1521134295 + EqualityComparer<LsonDict>.Default.GetHashCode(_root);
            return hashCode;
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
            get => _root.ContainsKey("time") ? _root["time"].GetDoubleSafe() : null;
            set => _root["time"] = value;
        }
        public string Image
        {
            get => _root["image"].GetStringSafe();
            set => _root["image"] = value;
        }

        private readonly LsonDict _root;

        public Tile()
        {
            _root = new LsonDict();
        }
        public Tile(Quad quad, string image, double? time = null)
        {
            _root = new LsonDict();
            Quad = quad;
            Image = image;
            if (time != null) Time = time;
        }
        public Tile(LsonDict root)
        {
            _root = root;
        }

        public void SetValue(string key, LsonValue value)
        {
            _root[key] = value;
        }

        public static explicit operator LsonDict(Tile value)
        {
            return value._root;
        }
        public static explicit operator Tile(LsonDict value)
        {
            return new Tile(value);
        }
        public static bool operator ==(Tile right, Tile left)
        {
            return (right.Image == left.Image) && (right.Time == left.Time) && (right.Quad == left.Quad);
        }

        public static bool operator !=(Tile right, Tile left)
        {
            return !(right == left);
        }

        ///MSVS Auto-Generated
        public override bool Equals(object obj)
        {
            return obj is Tile tile;
        }
        public override int GetHashCode()
        {
            var hashCode = -2036332282;
            hashCode = hashCode * -1521134295 + EqualityComparer<Quad>.Default.GetHashCode(Quad);
            hashCode = hashCode * -1521134295 + Time.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Image);
            hashCode = hashCode * -1521134295 + EqualityComparer<LsonDict>.Default.GetHashCode(_root);
            return hashCode;
        }
    }

    public class LayerTile
    {
        public int? TileIndex
        {
            get => _root["tile"].GetIntSafe();
            set => _root["tile"] = value;
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

        private readonly LsonDict _root;

        public LayerTile()
        {
            _root = new LsonDict();
        }
        public LayerTile(int tileIndex, int x, int y)
        {
            _root = new LsonDict();
            TileIndex = tileIndex;
            X = x;
            Y = y;
        }
        public LayerTile(LsonDict root)
        {
            _root = root;
        }

        public void SetValue(string key, LsonValue value)
        {
            _root[key] = value;
        }

        public LsonSafeValue GetValue(string key)
        {
            return _root.ContainsKey(key) ? _root[key].Safe : null;
        }

        public Dictionary<LsonValue, LsonValue> GetValues()
        {
            Dictionary<LsonValue, LsonValue> values = new Dictionary<LsonValue, LsonValue>();
            foreach (KeyValuePair<LsonValue, LsonValue> value in _root)
                if (value.Key.GetIntSafe() == null)
                    values[value.Key] = value.Value;
            return values;
        }

        public static explicit operator LsonDict(LayerTile value)
        {
            return value._root;
        }
        public static explicit operator LayerTile(LsonDict value)
        {
            return new LayerTile(value);
        }
    }

    public class Layer
    {
        public List<LayerTile> Tiles
		{
            get
            {
                List<LayerTile> tiles = new List<LayerTile>();
                for (int i = 1; _root.ContainsKey(i); i++)
                    tiles.Add((LayerTile)_root[i]);
                return tiles;
            }
            set 
            {
                for (int i = 0; i < value.Count; i++)
                        _root[i+1] = (LsonDict)value[i];
            }
	    }

        private readonly LsonDict _root;

        public Layer()
        {
            _root = new LsonDict();
        }
        public Layer(bool? temp)
        {
            _root = new LsonDict();
        }
        public Layer(LsonDict root)
        {
            _root = root;
        }

        public void SetValue(string key, LsonValue value)
        {
            if (value != null)
                _root[key] = value;
            else
                _root.Remove(key);
        }

        public LsonSafeValue GetValue(string key)
        {
            return _root.ContainsKey(key) ? _root[key].Safe : null;
        }

        public Dictionary<LsonValue, LsonValue> GetValues()
        {
            Dictionary<LsonValue, LsonValue> values = new Dictionary<LsonValue, LsonValue>();
            foreach (KeyValuePair<LsonValue, LsonValue> value in _root)
                if (value.Key.GetIntSafe() == null)
                    values[value.Key] = value.Value;
            return values;
        }

        public static explicit operator LsonDict(Layer value)
        {
            return value._root;
        }
        public static explicit operator Layer(LsonDict value)
        {
            return new Layer(value);
        }
    }

    public class Tilemap
    {
        private Dictionary<string, LsonValue> _tables;

        public List<Tile> Tiles { get; private set; }
        public List<Layer> Layers { get; private set; }


        public Tilemap(string luatable = null)
        {
            if (luatable == null)
                NewTileMap();
            else
                OpenTileMap(luatable);
        }

        public void OpenTileMap(string luaTable)
        {
            _tables = LsonVars.Parse(luaTable);

            // Tiles
            Tiles = new List<Tile>();
            var tiles = _tables["tiles"].GetDictSafe();
            if (tiles != null)
                foreach (LsonDict tile in tiles.ToEnumerable())
                    Tiles.Add((Tile)tile);
            else
                _tables["tiles"] = new LsonDict();

            // Layers
            Layers = new List<Layer>();
            var layers = _tables["layers"].GetDictSafe();
            if (layers != null)
                foreach (LsonDict layer in layers.ToEnumerable())
                    Layers.Add((Layer)layer);
            else
                _tables["layers"] = new LsonDict();
        }

        public void NewTileMap()
        {
            _tables = new Dictionary<string, LsonValue>();
            Tiles = new List<Tile>();
            Layers = new List<Layer>();
        }

        public override string ToString()
        {
            _tables["tiles"] = ToLsonDict(Tiles);
            _tables["layers"] = ToLsonDict(Layers);
            return LsonVars.ToString(_tables);
        }

        private static LsonDict ToLsonDict(List<Tile> value)
        {
            LsonDict dict = new LsonDict();
                for (int i = 0; i<value.Count; i++)
                    dict.Add(i, (LsonDict) value[i]);
            return dict;
        }

        private static LsonDict ToLsonDict(List<Layer> value)
        {
            LsonDict dict = new LsonDict();
            for (int i = 0; i < value.Count; i++)
                dict.Add(i, (LsonDict)value[i]);
            return dict;
        }
    }
}