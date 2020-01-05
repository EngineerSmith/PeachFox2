namespace PeachFox.TileMapEditor
{
    public struct Cell
    {
        public int X;
        public int Y;
        public static bool operator ==(Cell left, Cell right)
        {
            return left.X == right.X && left.Y == right.Y;
        }

        public static bool operator !=(Cell left, Cell right) => !(left == right);
        // MSVS Auto-Generated Code
        public override bool Equals(object obj)
        {
            return obj is Cell cell &&
                   X == cell.X &&
                   Y == cell.Y;
        }
        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }
    }
}
