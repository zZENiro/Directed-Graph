using System;
using System.Collections.Generic;
using System.Text;

namespace Directed_Graph
{
    public class Node<T>
    {
        private static int _number = 0;
        private List<ValuedEdge<T>> _edges;
        private int _value;

        public readonly int Number;

        public List<ValuedEdge<T>> Edges { get => _edges; }

        public int Value { get => _value; set => _value = value; }

        public Node()
        {
            Number = _number++;
            _edges = new List<ValuedEdge<T>>();
        }

        public void AddEdge(ValuedEdge<T> edge)
        {
            if (_edges.Contains(edge) || edge == null)
                throw new Exception($"Unable add edge to {this}");

            _edges.Add(edge);
        }
    }
}
