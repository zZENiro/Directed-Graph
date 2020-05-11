using System;
using System.Collections.Generic;
using System.Text;

namespace Directed_Graph
{
    public enum State
    {
        Visited,
        Unvisited
    }

    public class DirectedGraphWalker<T>
    {
        Dictionary<State, Node<T>> _visitedNodes = new Dictionary<State, Node<T>>();

        public event LoggerEventHandler LogEvent;

        public void WalkGraph(DirectedGraph<T> graph)
        {
            foreach (var edge in graph.Edges)
            {
                if (!_visitedNodes.ContainsValue(edge.To))
                {
                    _visitedNodes.Add(State.Visited, edge.From);
                    LogEvent?.Invoke(this, new LoggerEventArgs($"{edge.From}"));
                    WalkThroughEdge(edge);
                }
            }
        }

        private void WalkThroughEdge(ValuedEdge<T> edge)
        {
            _visitedNodes.TryAdd(State.Visited, edge.To);
            if (edge.To.Edges.Count != 0)
                foreach (var e in edge.From.Edges)
                    if (!_visitedNodes.ContainsValue(e.To))
                        WalkThroughEdge(e);
                    else return;
            else LogEvent?.Invoke(this, new LoggerEventArgs($"{edge.To}"));
                

        }
    }
}
