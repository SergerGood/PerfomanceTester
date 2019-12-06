using System;
using System.Collections.Generic;

namespace ReadOnlyStructTester
{
    public readonly struct ReadOnlyStruct : IEquatable<ReadOnlyStruct>, IComparer<ReadOnlyStruct>, IComparable<ReadOnlyStruct>
    {
        public ReadOnlyStruct(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public bool Equals(ReadOnlyStruct other)
        {
            return X == other.X && Y == other.Y;
        }

        public int Compare(ReadOnlyStruct x, ReadOnlyStruct y)
        {
            return x.CompareTo(y);
        }

        public int CompareTo(ReadOnlyStruct other)
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
            return obj is ReadOnlyStruct other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public static bool operator ==(ReadOnlyStruct x, ReadOnlyStruct y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(ReadOnlyStruct x, ReadOnlyStruct y)
        {
            return !(x == y);
        }

        public static bool operator <(ReadOnlyStruct x, ReadOnlyStruct y)
        {
            return x.CompareTo(y) < 0;
        }

        public static bool operator >(ReadOnlyStruct x, ReadOnlyStruct y)
        {
            return x.CompareTo(y) > 0;
        }

        public static bool operator <=(ReadOnlyStruct x, ReadOnlyStruct y)
        {
            return x.CompareTo(y) <= 0;
        }

        public static bool operator >=(ReadOnlyStruct x, ReadOnlyStruct y)
        {
            return x.CompareTo(y) >= 0;
        }
    }
}
