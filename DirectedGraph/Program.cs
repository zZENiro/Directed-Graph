using System;

namespace Directed_Graph
{
    public class LoggerEventArgs : EventArgs
    {
        public string Message { get; set; }

        public LoggerEventArgs(string message) => Message = message;
    }

    public delegate void LoggerEventHandler(object sender, LoggerEventArgs args);

    class Program
    {
        static void Main(string[] args)
        {
            var graph = DirectedGraph<int>.CreateGraph(new int[,]{
                { -1,1,0,0,0,0,0,0 },
                { -1,0,1,0,0,0,0,0 },
                { -1,0,0,1,0,0,0,0 },
                { 0,-1,0,0,1,0,0,0 },
                { 0,0,0,0,-1,1,0,0 },
                { 0,1,0,0,0,-1,0,0 },
                { 0,0,0,0,0,0,-1,1 }
            });

            var walk = new DirectedGraphWalker<int>();
            walk.WalkGraph(graph);
        }

    }
}
