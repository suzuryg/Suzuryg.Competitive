using System;
using System.Collections.Generic;
using System.Text;

namespace Suzuryg.Competitive.Library.Search
{
    public class Search
    {
        // https://qiita.com/drken/items/97e37dd6143e33a64c8c
        public static int BinarySearch<T>(IReadOnlyList<T> list, Func<IReadOnlyList<T>, int, bool> isOK)
        {
            int ng = -1; //「index = 0」が条件を満たすこともあるので、初期値は -1
            int ok = list.Count; // 「index = a.size()-1」が条件を満たさないこともあるので、初期値は list.Count
            // ok と ng のどちらが大きいかわからないことを考慮
            while (System.Math.Abs(ok - ng) > 1)
            {
                int mid = (ok + ng) / 2;

                if (isOK(list, mid))
                {
                    ok = mid;
                }
                else
                {
                    ng = mid;
                }
            }
            return ok;
        }
        public static int BinarySearch(int ng, int ok, Func<int, bool> isOK)
        {
            // ok と ng のどちらが大きいかわからないことを考慮
            while (System.Math.Abs(ok - ng) > 1)
            {
                int mid = (ok + ng) / 2;

                if (isOK(mid))
                {
                    ok = mid;
                }
                else
                {
                    ng = mid;
                }
            }
            return ok;
        }
        public static long[] BFS(List<List<int>> graph, List<int> startNodes)
        {
            Queue<int> que = new Queue<int>();
            bool[] seen = new bool[graph.Count];
            long[] distance = new long[graph.Count];
            for (int i = 0; i < seen.Length; i++)
            {
                seen[i] = false;
                distance[i] = -1;
            }
            foreach (var start in startNodes)
            {
                que.Enqueue(start);
                distance[start] = 0;
            }
            while(que.Count > 0)
            {
                var now = que.Dequeue();
                if (!seen[now])
                {
                    seen[now] = true;
                    foreach (var next in graph[now])
                    {
                        que.Enqueue(next);
                        distance[next] = distance[now] + 1;
                    }
                }
            }
            return distance;
        }
    }
}
