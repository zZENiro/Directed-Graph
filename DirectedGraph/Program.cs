using System;

namespace Directed_Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = DirectedGraph<int>.CreateGraph(new int[,]{
                { 0, 1, -1,  0 },
                { 0, -1,  0, 1 },
                { 1, 0, -1,  0 },
                { 0, 0, -1,  1 }
            });


        }
    }
}
