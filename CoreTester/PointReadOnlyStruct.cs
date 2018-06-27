using System;

namespace CoreTester
{
    public readonly struct PointReadonlyStruct : IEquatable<PointStruct>
    {
        public PointReadonlyStruct(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public bool Equals(PointStruct other)
        {
            return X == other.X && Y == other.Y;
        }
    }
}
