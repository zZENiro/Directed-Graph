using System;
using System.Collections.Generic;
using System.Text;

namespace Directed_Graph
{
    public class DirectedGraph<T>
    {
        private List<ValuedEdge<T>> _edges;

        public List<ValuedEdge<T>> Edges { get => _edges; }

        public DirectedGraph() => _edges = new List<ValuedEdge<T>>();

        public DirectedGraph(List<ValuedEdge<T>> edges) => _edges = edges;

        public void SetValuesToEdges(int[] values)
        {
            for (int i = 0; i < values.Length; ++i)
                _edges[i].Value = values[i];
        }

        public static DirectedGraph<T> CreateGraph(int[,] incedentMatrix)
        {
            /* 
             *  Example: 
             *  (c - is value of node)
             *  
             *      v1 v2 v3 v4| c              e1         
             *  e1  0  1 -1  0 | 12         v3 ---→ v2         
             *  e2  0 -1  0  1 | 33         | \      |         
             *  e3  1  0 -1  0 | 0       e3 |  \ e4  | e2         
             *  e4  0  0 -1  1 | 2          |   \    |            
             *                              |    \   |	         
             *                              ↓     ⇘  ↓	          
             *                              v1       v4         
             */

            if (WrongFormat(incedentMatrix))
                throw new Exception("Wrong format of Incedent Matrix.");

            var nodes = new List<Node<T>>();
            var edges = new List<ValuedEdge<T>>();
            var cLen = incedentMatrix.GetLength(0);
            var rLen = incedentMatrix.GetLength(1);

            for (int i = 0; i < cLen; ++i)
                edges.Add(new ValuedEdge<T>());

            for (int i = 0; i < rLen; ++i)
                nodes.Add(new Node<T>());

            for (int i = 0; i < cLen; ++i)
            {
                for (int j = 0; j < rLen; ++j)
                {
                    if (incedentMatrix[i, j] == -1)
                        edges[i].AddFrom(nodes[j]);

                    if (incedentMatrix[i, j] == 1)
                        edges[i].AddTo(nodes[j]);
                }
            }

            return new DirectedGraph<T>(edges);
        }

        private static bool WrongFormat(int[,] incedentMatrix)
        {
            for (int i = 0; i < incedentMatrix.GetLength(0); ++i)
            {
                var _sum = 0;
                for (int j = 0; j < incedentMatrix.GetLength(1); ++j)
                    _sum += incedentMatrix[i, j];

                if (_sum != 0) return true;
            }
            return false;
        }
    }
}
