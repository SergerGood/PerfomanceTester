using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Samples
{
    public class Sample
    {
        public double Circumference(double radius)
        {
            double pi = Math.PI;

            return Convert.ToDouble(radius) * 2 * pi;
        }

        public string Format(string value)
        {
            if (value == string.Empty)
            {
                return value;
            }

            var builder = new StringBuilder();

            builder
                .Append("<")
                .Append(value)
                .Append(value.Substring(1))
                .Append(">");

            return builder.ToString();
        }

        public int GetCountItems()
        {
            var items = new List<int>();
            var searchItems = new List<int>();

            items.AddRange(Enumerable.Repeat(0, 10).ToList());

            List<int> enumerable = items.Where(x => searchItems.Contains(x)).ToList();

            return enumerable.Count(x => x == 2);
        }

        public char GetValue(IDictionary<int, char> dictionary, int key)
        {
            if (dictionary.ContainsKey(key))
            {
                return dictionary[key];
            }

            return char.MinValue;
        }
    }
}
