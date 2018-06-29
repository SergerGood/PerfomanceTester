using System;

namespace CoreTester
{
    public readonly struct PointReadonlyStruct : IEquatable<PointReadonlyStruct>
    {
        public PointReadonlyStruct(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public bool Equals(PointReadonlyStruct other)
        {
            return X == other.X && Y == other.Y;
        }
    }
}
