using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Suzuryg.Competitive.Library.Collections;

namespace Suzuryg.Competitive.Library.Graph
{
    public class Graph
    {
        /// <summary>
        /// ダイクストラ法
        /// ノード番号は0から始まる連続な数とする
        /// エッジは有向であるとする
        /// エッジは edges[始点ノード番号] = {(エッジのコスト, 終点ノード番号), ( , ), ...} となるように格納する
        /// </summary>
        /// <param name="edges">エッジ</param>
        /// <param name="startNode">経路の始点となるノードの番号</param>
        /// <param name="numNodes">ノードの数</param>
        /// <returns>(各ノードの最短経路のコスト、各ノードが最短経路における直前のノード)</returns>
        public static (long[] pathCost, int[] prevNode) Dijkstra(
            List<List<(long cost, int idxNode)>> edges, int startNode, int numNodes)
        {
            bool[] confirmed = new bool[numNodes];
            long[] pathCost = Enumerable.Repeat(long.MaxValue, numNodes).ToArray<long>();
            int[] prevNode = Enumerable.Repeat(-1, numNodes).ToArray<int>();
            var queue = new AtCoder.PriorityQueue<long, int>();

            queue.Enqueue(0, startNode);

            while(queue.TryDequeue(out long cost, out int idxNode))
            {
                if (confirmed[idxNode])
                {
                    continue;
                }
                confirmed[idxNode] = true;
                foreach (var edge in edges[idxNode])
                {
                    long newCost = edge.cost + cost;
                    int nextNode = edge.idxNode;
                    if (newCost < pathCost[nextNode])
                    {
                        pathCost[nextNode] = newCost;
                        prevNode[nextNode] = idxNode;
                        queue.Enqueue(newCost, nextNode);
                    }
                }
            }

            return (pathCost, prevNode);
        }
    }
}
