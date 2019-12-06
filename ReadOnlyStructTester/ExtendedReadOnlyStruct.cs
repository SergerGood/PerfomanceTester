using System;
using System.Collections.Generic;

namespace ReadOnlyStructTester
{
    public readonly struct ExtendedReadonlyStruct : IEquatable<ExtendedReadonlyStruct>, IComparer<ExtendedReadonlyStruct>, IComparable<ExtendedReadonlyStruct>
    {
        public ExtendedReadonlyStruct(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public bool Equals(ExtendedReadonlyStruct other)
        {
            return X == other.X && Y == other.Y;
        }

        public int Compare(ExtendedReadonlyStruct x, ExtendedReadonlyStruct y)
        {
            return x.CompareTo(y);
        }

        public int CompareTo(ExtendedReadonlyStruct other)
        {
            int xComparison = X.CompareTo(other.X);
            if (xComparison != 0)
            {
                return xComparison;
            }

            return Y.CompareTo(other.Y);
        }

        public override bool Equals(object obj)
        {
            return obj is ExtendedReadonlyStruct other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public static bool operator ==(in ExtendedReadonlyStruct x, in ExtendedReadonlyStruct y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(in ExtendedReadonlyStruct x, in ExtendedReadonlyStruct y)
        {
            return !(x == y);
        }

        public static bool operator <(in ExtendedReadonlyStruct x, in ExtendedReadonlyStruct y)
        {
            return x.CompareTo(y) < 0;
        }

        public static bool operator >(in ExtendedReadonlyStruct x, in ExtendedReadonlyStruct y)
        {
            return x.CompareTo(y) > 0;
        }

        public static bool operator <=(in ExtendedReadonlyStruct x, in ExtendedReadonlyStruct y)
        {
            return x.CompareTo(y) <= 0;
        }

        public static bool operator >=(in ExtendedReadonlyStruct x, in ExtendedReadonlyStruct y)
        {
            return x.CompareTo(y) >= 0;
        }
    }
}
