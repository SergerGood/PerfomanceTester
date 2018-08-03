using System;

namespace TypeTester
{
    public struct PointStruct : IEquatable<PointStruct>
    {
        public PointStruct(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public bool Equals(PointStruct other)
        {
            return X == other.X && Y == other.Y;
        }
    }
}
