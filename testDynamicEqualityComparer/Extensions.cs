using System;
using System.Collections.Generic;
using System.Linq;

namespace testDynamicEqualityComparer
{
    public static class Extensions
    {
        public static IEnumerable<T> DistinctWithComparer<T>(this IEnumerable<T> source, Func<T, T, bool> comparer)
            where T : class =>
            source.Distinct(new DynamicEqualityComparer<T>(comparer));

        private sealed class DynamicEqualityComparer<T> : IEqualityComparer<T>
            where T : class
        {
            private readonly Func<T, T, bool> _func;

            public DynamicEqualityComparer(Func<T, T, bool> func)
            {
                _func = func;
            }

            public bool Equals(T x, T y) =>
                _func(x, y);

            public int GetHashCode(T obj) =>
                0;
        }
    }
}