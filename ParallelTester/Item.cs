using System;

namespace TypeTester
{
    public readonly struct Item : IEquatable<Item>
    {
        public Item(int id, int[] links)
        {
            Id = id;
            Links = links;
        }

        public int Id { get; }
        public int[] Links { get; }

        public bool Equals(Item other)
        {
            return Id == other.Id && Equals(Links, other.Links);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Item other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Id * 397) ^ (Links != null ? Links.GetHashCode() : 0);
            }
        }
    }
}
