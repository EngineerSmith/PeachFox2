using System.Collections.Generic;
using LsonLib;
using System.Linq;

/// Produces a file, of the following format
/// 
/// ----
///local tiles =
///{
///     {quad={ 0, 0,16,16}, image="tileset.base"}, -- Basic tile
///     {quad={ 0,16,16,16, 16,16,16,16}, time=0.1, image="tileset.base"}, --Animated Tile
///}
///
///local layers =
///{
///    {
///        name="Foreground", -- name is a custom tag
///        {tile=1, x= 0, y= 0, colliable=true}, --colliable is a custom tag
///        {tile=2, x=16, y=16, colliable=false},
///    },
///    {
///        name="Background",
///    }
///}
///
///return { tiles=tiles, layers=layers}

namespace PeachFox.LuaTilemap
{
    class LuaRoot
    {
        public readonly LsonDict Root;

        public LuaRoot()
        {
            Root = new LsonDict();
        }
        public LuaRoot(LsonDict root)
        {
            Root = root;
        }

        public void SetValue(LsonValue key, LsonValue value)
        {
            Root[key] = value;
        }

        public LsonValue GetValue(LsonValue key)
        {
            return Root[key];
        }

        public static explicit operator LsonDict(LuaRoot value)
        {
            return value.Root;
        }
        public static explicit operator LuaRoot(LsonDict value)
        {
            return new LuaRoot(value);
        }
    }

    public static class LuaTilemap
    {
        public static string ToLua(Tilemap tilemap)
        {
            Dictionary<string, LsonValue> map = new Dictionary<string, LsonValue>();
            LuaRoot tiles = new LuaRoot();
            for (int i = 0; i < tilemap.Tiles.Count(); i++)
                tiles.SetValue(i + 1, ConstructTile(tilemap.Tiles[i]).Root);
            map["tiles"] = tiles.Root;
            LuaRoot layers = new LuaRoot();
            for (int i = 0; i < tilemap.Layers.Count(); i++)
                layers.SetValue(i + 1, ConstuctLayer(tilemap.Layers[i]).Root);
            map["layers"] = layers.Root;
            return LsonVars.ToString(map);
        }

        public static Tilemap FromLua(string filePath)
        {
            Dictionary<string, LsonValue> map = LsonVars.Parse(System.IO.File.ReadAllText(filePath));
            Tilemap tilemap = new Tilemap();
            LsonDict tiles = map["tiles"].GetDict();
            tilemap.Tiles = new List<Tile>(tiles.Count());
            for (int i = 0; i < tiles.Count(); i++)
                tilemap.Tiles[i] = GetTile(new LuaRoot(tiles[i + 1].GetDict()));
            LsonDict layers = map["layers"].GetDict();
            tilemap.Layers = new List<Layer>(layers.Count());
            for (int i = 0; i < layers.Count(); i++)
                tilemap.Layers[i] = GetLayer(new LuaRoot(tiles[i + 1].GetDict()));
            return tilemap;
        }

        private static void AddTags(ref LuaRoot root, List<Tag> tags)
        {
            foreach(Tag tag in tags)
                if (tag.Type == Tag.TagType.STRING)
                    root.SetValue(tag.Name, tag.StringValue);
                else if (tag.Type == Tag.TagType.NUMBER)
                    root.SetValue(tag.Name, tag.NumberValue);
        }

        private static List<Tag> GetTags(LuaRoot root)
        {
            List<Tag> tags = new List<Tag>();
            foreach (var kvp in root.Root)
            {
                if (kvp.Key.GetStringSafe() == null)
                    continue;
                if (kvp.Value.GetDecimalSafe() != null)
                    tags.Add(new Tag(kvp.Key.GetString(), kvp.Value.GetDecimal()));
                else if (kvp.Value.GetStringSafe() != null)
                    tags.Add(new Tag(kvp.Key.GetString(), kvp.Value.GetString()));
            }
            return tags;
        }

        private static bool SearchForTag(List<Tag> tags, string key)
        {
            return tags.SingleOrDefault(tag => tag.Name == key) != null;
        }

        private static void RemoveTag(ref List<Tag> tags, string key)
        {
            int index = tags.FindIndex(tag => tag.Name == key);
            if (index != -1)
                tags.RemoveAt(index);
        }

        private static LuaRoot ConstructTile(Tile tile)
        {
            if (tile == null)
                return null;
            if (tile is ClassicTile classicTile)
                return ConstructClassicTile(classicTile);
            else
            {
                LuaRoot t = new LuaRoot();
                AddTags(ref t, tile.Tags);
                return t;
            }
        }

        private static Tile GetTile(LuaRoot root)
        {
            if (root == null)
                return null;
            Tile tile = new Tile {
                Tags = GetTags(root)
            };

            if (SearchForTag(tile.Tags, "image") && SearchForTag(tile.Tags, "quad"))
            {
                tile = GetClassicTile(root);
                RemoveTag(ref tile.Tags, "image");
                RemoveTag(ref tile.Tags, "quad");
                RemoveTag(ref tile.Tags, "time");
            }

            return tile;
        }

        private static LuaRoot ConstructClassicTile(ClassicTile tile)
        {
            if (tile == null)
                return null;
            LuaRoot t = new LuaRoot();
            t.SetValue("image", tile.Image);
            LuaRoot quad = new LuaRoot();
            for (int i = 0; i < tile.Quads.Count; i++)
                quad.SetValue(i + 1, tile.Quads[i]);
            t.SetValue("quad", quad.Root);
            if (tile.Quads.Count > 4)
                t.SetValue("time", tile.Time);
            AddTags(ref t, tile.Tags);
            return t;
        }

        private static ClassicTile GetClassicTile(LuaRoot root)
        {
            if (root == null)
                return null;
            ClassicTile tile = new ClassicTile();
            tile.Image = root.GetValue("image").GetString();
            LsonDict quads = root.GetValue("quad").GetDict();
            tile.Quads = new List<int>(quads.Count());
            for (int i = 0; i < quads.Count(); i++)
                tile.Quads[i] = quads[i + 1].GetInt();
            if (tile.Quads.Count() > 4)
                tile.Time = (float)root.GetValue("time").GetDouble();
            return tile;
        }

        private static LuaRoot ConstuctLayerTile(LayerTile tile)
        {
            if (tile == null)
                return null;
            LuaRoot t = new LuaRoot();
            t.SetValue("tile", tile.Index + 1);
            t.SetValue("x", tile.X);
            t.SetValue("y", tile.Y);
            AddTags(ref t, tile.Tags);
            return t;
        }

        private static LayerTile GetLayerTile(LuaRoot root)
        {
            if (root == null)
                return null;
            return new LayerTile
            {
                Index = root.GetValue("tile").GetInt() - 1,
                X = root.GetValue("x").GetInt(),
                Y = root.GetValue("y").GetInt(),
            };
        }

        private static LuaRoot ConstuctLayer(Layer layer)
        {
            if (layer == null)
                return null;
            LuaRoot l = new LuaRoot();
            AddTags(ref l, layer.Tags);
            for (int i = 0; i < layer.Tiles.Count(); i++)
                l.SetValue(i + 1, ConstuctLayerTile(layer.Tiles[i]).Root);
            return l;
        }

        private static Layer GetLayer(LuaRoot root)
        {
            if (root == null)
                return null;
            Layer layer = new Layer()
            {
                Tags = GetTags(root),
            };
            layer.Tiles = new List<LayerTile>(root.Root.Count() - layer.Tags.Count());
            for (int i = 0; i < layer.Tiles.Count(); i++)
                layer.Tiles[i] = GetLayerTile(new LuaRoot(root.Root[i + 1].GetDict()));
            return layer;
        }
    }
}