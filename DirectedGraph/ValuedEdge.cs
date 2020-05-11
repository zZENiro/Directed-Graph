using System;
using System.Collections.Generic;
using System.Text;

namespace Directed_Graph
{
    public class ValuedEdge<T>
    {
        private static int _number = 0;
        private Node<T> _to;
        private Node<T> _from;
        private int _value;

        public readonly int Number;

        public Node<T> To { get => _to; }

        public Node<T> From { get => _from; }

        public int Value { get => _value; set => _value = value; }

        public ValuedEdge() => Number = _number++;

        public ValuedEdge(Node<T> to, Node<T> from) =>
            (Number, _to, _from) = (_number++, to, from);

        public void AddFrom(Node<T> node)
        {
            _from = node;
            node.AddEdge(this);
        }

        public void AddTo(Node<T> node)
        {
            _to = node;
            node.AddEdge(this);
        }
    }
}
