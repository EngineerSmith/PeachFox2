using System.Collections.Generic;
using LsonLib;

namespace PeachFox.TileSet
{
    public class LuaTileSet
    {
        public string Path
        {
            get => _root["path"].GetStringSafe();
            set => _root["path"] = value;
        }
        public string ExportString
        {
            get => _root["exportString"].GetStringSafe();
            set => _root["exportString"] = value;
        }
        public int? CellSize
        {
            get => _root["cellSize"].GetIntSafe();
            set => _root["cellSize"] = value;
        }

        private readonly LsonDict _root;

        public LuaTileSet()
        {
            _root = new LsonDict();
        }
        public LuaTileSet(TileSetData data)
        {
            _root = new LsonDict();
            Path = data.Path;
            ExportString = data.ExportString;
            CellSize = data.CellSize;
        }
        public LuaTileSet(LsonDict root)
        {
            _root = root;
        }

        public static explicit operator LsonDict(LuaTileSet value)
        {
            return value._root;
        }
        public static explicit operator LuaTileSet(LsonDict value)
        {
            return new LuaTileSet(value);
        }

        public static explicit operator TileSetData(LuaTileSet value)
        {
            return new TileSetData() { Path=value.Path,ExportString=value.ExportString,CellSize=value.CellSize.GetValueOrDefault(1)};
        }

        public static explicit operator LuaTileSet(TileSetData value)
        {
            return new LuaTileSet(value);
        }
    }

    public class LuaTileSets
    {
        private Dictionary<string, LsonValue> _tables;

        public List<TileSetData> TileSetData
        {
            get
            {
                List<TileSetData> result = new List<TileSetData>();
                LsonDict sets = _tables["sets"].GetDictSafe();
                foreach (var set in sets)
                    result.Add((TileSetData)(LuaTileSet)set.Value.GetDict());
                return result;
            }
            set
            {
                LsonDict dict = new LsonDict();
                for (int i = 0; i < value.Count; i++)
                    dict.Add(i, (LsonDict)(LuaTileSet)value[i]);
                _tables["sets"] = dict;
            }
        }

        public List<LuaTileSet> LuaTileSetData
        {
            get
            {
                List<LuaTileSet> result = new List<LuaTileSet>();
                LsonDict sets = _tables["sets"].GetDictSafe();
                foreach (var set in sets)
                    result.Add((LuaTileSet)set.Value.GetDict());
                return result;
            }
            set
            {
                LsonDict dict = new LsonDict();
                for (int i = 0; i < value.Count; i++)
                    dict.Add(i, (LsonDict)value[i]);
                _tables["sets"] = dict;
            }
        }

        public void Open(string luaTable)
        {
            _tables = LsonVars.Parse(luaTable);
            if (_tables.ContainsKey("sets") == false)
                _tables.Add("sets", new LsonDict());
        }

        public override string ToString()
        {
            return LsonVars.ToString(_tables);
        }
    }
}
