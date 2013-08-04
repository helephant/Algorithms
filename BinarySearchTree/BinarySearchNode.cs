using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms
{
    public class BinarySearchNode<T> : IEnumerable<T> where T : IComparable<T> 
    {
        public T Value { get; private set; }
        public BinarySearchNode<T> Left { get; private set; }
        public BinarySearchNode<T> Right { get; private set; }
        private BinarySearchNode<T> _parent; 
        

        public BinarySearchNode(T value)
        {
            Value = value;
        }

        public void Add(BinarySearchNode<T> newNode)
        {
            if (IsLessThan(newNode.Value, Value))
            {
                if (Left != null)
                    Left.Add(newNode);
                else
                {
                    Left = newNode;
                    newNode._parent = this;
                }
            }
            else
            {
                if (Right != null)
                    Right.Add(newNode);
                else
                {
                    Right = newNode;
                    newNode._parent = this;
                }
            }
        }

        public bool Remove(T value)
        {
            if (Value.Equals(value))
            {
                if (IsLessThan(Value, _parent.Value))
                    _parent.Left = null;
                else
                    _parent.Right = null;

                if(Left != null)
                    _parent.Add(Left);

                if(Right != null)
                    _parent.Add(Right);

                return true;
            }
            
            if(Left != null && IsLessThan(value, Value))
                return Left.Remove(value);
            if (Right != null && IsGreaterThan(value, Value))
                return Right.Remove(value);

            return false;
        }


        public bool Contains(T value)
        {
            if(value.Equals(Value))
                return true;

            if(IsLessThan(value, Value) && Left != null)
                return Left.Contains(value);
            if(IsGreaterThan(value, Value) && Right != null)
                return Right.Contains(value);

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if(Left != null)
            {
                foreach (var value in Left)
                    yield return value;
            }

            yield return Value;

            if (Right != null)
            {
                foreach (var value in Right)
                    yield return value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count
        {
            get 
            { 
                var count = 1;

                if (Left != null)
                    count += Left.Count;
                if (Right != null)
                    count += Right.Count;

                return count;
            }
        }

        public override string ToString()
        {
            return Value.ToString();
        }


        private bool IsGreaterThan(T value1, T value2)
        {
            return value1.CompareTo(value2) >= 0;
        }

        private bool IsLessThan(T value1, T value2)
        {
            return value1.CompareTo(value2) < 0;
        }
    }
}