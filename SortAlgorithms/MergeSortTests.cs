using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace SortAlgorithms
{
    [TestFixture]
    public class MergeSortTests
    {
        [Test]
        public void SortEmptyArray()
        {
            var unsorted = new int[0];
            var sorted = new int[0];

            Assert.That(MergeSort(unsorted), Is.EqualTo(sorted));
        }

        [Test]
        public void SortArrayOfInts()
        {
            var unsorted = new[] { 5, 2, 3, -1, 8, 0 };
            var sorted = new[] { -1, 0, 2, 3, 5, 8 };

            var mergeSort = MergeSort(unsorted);
            Assert.That(mergeSort, Is.EqualTo(sorted));
        }

        private IEnumerable<int> MergeSort(IEnumerable<int> unsorted)
        {
            var e = unsorted.GetEnumerator();

            var left = new List<int>();
            var right = new List<int>();
            while (e.MoveNext())
            {
                left.Add(e.Current);
                if (e.MoveNext())
                    right.Add(e.Current);
            } 

            IEnumerable<int> leftMerge = left;
            if (left.Count > 1)
                leftMerge = MergeSort(left);

            IEnumerable<int> rightMerge = right;
            if (right.Count > 1)
                rightMerge = MergeSort(right);

            return Merge(leftMerge, rightMerge);
        }

        private IEnumerable<int> Merge(IEnumerable<int> left, IEnumerable<int> right)
        {
            var l = left.GetEnumerator();
            var r = right.GetEnumerator();

            var moreLeft = l.MoveNext();
            var moreRight = r.MoveNext();

            while (moreLeft || moreRight)
            {
                if (moreLeft && (l.Current < r.Current || !moreRight))
                {
                    var current = l.Current;
                    moreLeft = l.MoveNext();
                    yield return current;
                }
                else
                {
                    var current = r.Current;
                    moreRight = r.MoveNext();
                    yield return current;
                }
            }

        }
    }
}
