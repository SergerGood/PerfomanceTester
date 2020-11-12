﻿using System;

namespace TypeTester
{
    public class PointClass
    {
        public PointClass(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; init; }
        public int Y { get; init; }
    }
}
