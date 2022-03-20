using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

namespace Suzuryg.Competitive.Library.MyMath
{
    public class Iteration
    {
        public static IEnumerable<T[]> Permutation<T>(IEnumerable<T> items) {
            if (items.Count() == 1) {
                yield return new T[] { items.First() };
                yield break;
            }
            foreach (var item in items) {
                var leftside = new T[] { item };
                var unused = items.Except(leftside);
                foreach (var rightside in Permutation(unused)) {
                    yield return leftside.Concat(rightside).ToArray();
                }
            }
        }
    }
}
