using LsonLib;

namespace PeachFox.Lua
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

        public static implicit operator LuaRoot(LsonDict value)
        {
            return new LuaRoot(value);
        }
    }
}