using System.Collections.Generic;
using LsonLib;

namespace PeachFox.Lua
{
    public static class LuaProjectSettings
    {
        public static string ToLua(ProjectSettings projectSettings)
        {
            Dictionary<string, LsonValue> map = new Dictionary<string, LsonValue>();
            LuaRoot tileSets = new LuaRoot();
            foreach (var kvp in projectSettings.TileSets)
                tileSets.SetValue(kvp.Key, ConstructTileSet(kvp.Value).Root);
            map["tileSets"] = tileSets.Root;

            return LsonVars.ToString(map);
        }

        public static ProjectSettings FromLua(string filePath)
        {
            Dictionary<string, LsonValue> map = LsonVars.Parse(System.IO.File.ReadAllText(filePath));
            ProjectSettings projectSettings = new ProjectSettings();
            foreach (var kvp in map["tileSets"].GetDict())
                projectSettings.TileSets.Add(kvp.Key.GetString(), GetTileSetData((LuaRoot)kvp.Value));

            return projectSettings;
        }

        private static LuaRoot ConstructTileSet(TileSet.TileSetData tileSetData)
        {
            if (tileSetData == null)
                return null;
            LuaRoot root = new LuaRoot();
            root.SetValue("path", tileSetData.Path);
            root.SetValue("exportString", tileSetData.ExportString);
            root.SetValue("cellsize", tileSetData.CellSize);
            return root;
        }

        private static TileSet.TileSetData GetTileSetData(LuaRoot root)
        {
            if (root == null)
                return null;
            return new TileSet.TileSetData()
            {
                Path = root.GetValue("path").GetString(),
                ExportString = root.GetValue("exportString").GetString(),
                CellSize = root.GetValue("cellsize").GetInt(),
            };
        }
    }
}
