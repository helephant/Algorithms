using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms
{
    public class BinarySearchTree<T> : ICollection<T> where T : IComparable<T>
    {
        private BinarySearchNode<T> _rootNode;

        public void Add(T value)
        {
            var newNode = new BinarySearchNode<T>(value);

            if (_rootNode == null)
                _rootNode = newNode;
            else
                _rootNode.Add(newNode);
        }

        public bool Remove(T value)
        {
            if (_rootNode != null)
            {
                if (_rootNode.Value.CompareTo(value) == 0)
                {
                    _rootNode = null;
                    return true;
                }
                    
                return _rootNode.Remove(value);
            }

            return false;

        }

        public T Maximum()
        {
            if (_rootNode != null)
                return Maximum(_rootNode);

            throw new InvalidOperationException("Can not return a maxium value because there are no items in the list.");
        }


        private T Maximum(BinarySearchNode<T> node)
        {
            if (node.Right != null)
                return Maximum(node.Right);

            return node.Value;
        }

        public T Minimum()
        {
            if(_rootNode != null)
                return Minimum(_rootNode);

            throw new InvalidOperationException("Can not return a maxium value because there are no items in the list.");
        }

        private T Minimum(BinarySearchNode<T> node)
        {
            if (node.Left != null)
                return Minimum(node.Left);

            return node.Value;
        }

        public bool Contains(T value)
        {
            if(_rootNode != null)
                return _rootNode.Contains(value);

            return false;
        }

        public void Clear()
        {
            _rootNode = null;
        }

        public void CopyTo(T[] array, int startIndex)
        {
            throw new NotImplementedException("As this is a coding challenge, I felt this was a bit off topic.");
        }


        public IEnumerator<T> GetEnumerator()
        {
            if (_rootNode != null)
            {
                foreach (var value in _rootNode)
                    yield return value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count { 
            get
            {
                if (_rootNode != null)
                {
                    return _rootNode.Count;
                }
                return 0;
            }
        }
        public bool IsReadOnly { get { return false; } }
    }
}