﻿// <copyright file="EnumerableComparer.cs" company="xBehave.net contributors">
//  Copyright (c) xBehave.net contributors. All rights reserved.
// </copyright>

namespace Xbehave.Test.Acceptance.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class EnumerableComparer<T> : IComparer<IEnumerable<T>> where T : IComparable
    {
        public int Compare(IEnumerable<T> x, IEnumerable<T> y)
        {
            if (x == null)
            {
                return y == null ? 0 : -1;
            }

            if (y == null)
            {
                return 1;
            }

            var left = x.ToArray();
            var right = y.ToArray();
            for (int index = 0; index < Math.Max(left.Length, right.Length); ++index)
            {
                if (index >= left.Length)
                {
                    return -1;
                }

                if (index >= right.Length)
                {
                    return 1;
                }

                var comparison = Comparer<T>.Default.Compare(left[index], right[index]);
                if (comparison != 0)
                {
                    return comparison;
                }
            }

            return 0;
        }
    }
}
