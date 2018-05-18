using System;

namespace CoreTester
{
    public readonly struct PointReadonlyStruct
    {
        public PointReadonlyStruct(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }
    }
}
