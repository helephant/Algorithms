using System.Collections.Generic;
using NUnit.Framework;

namespace SortAlgorithms
{
    /// <summary>
    /// A o(n^2) sort algorithm. 
    /// Best case (alreadys sorted input): n. Worst case (input sorted in reverse): n^2. 
    /// More efficient than quick sort on small lists because it doesn't use recursion,
    /// but becomes less efficient the larger the list grows. 
    /// Is good for lists that are already mostly sorted. 
    /// </summary>
    [TestFixture]
    public class InsertionSortTests
    {
        [Test]
        public void SortEmptyArray()
        {
            var unsorted = new int[0];
            var sorted = new int[0];

            Assert.That(InsertionSortArray(unsorted), Is.EqualTo(sorted));
        }

        [Test]
        public void SortArrayOfInts()
        {
            var unsorted = new[] {5, 2, 3, -1, 8};
            var sorted = new[] {-1, 2, 3, 5, 8};

            Assert.That(InsertionSortArray(unsorted), Is.EqualTo(sorted));
        }

        private int[] InsertionSortArray(int[] unsorted)
        {
            var sorted = new int[unsorted.Length];
            if(unsorted.Length > 0)
                sorted[0] = unsorted[0];

            for (int currentIndex = 1; currentIndex < unsorted.Length; currentIndex++)
            {
                var currentItem = unsorted[currentIndex];

                var newIndex = currentIndex - 1;
                while (newIndex >= 0 && sorted[newIndex] > currentItem)
                {
                    sorted[newIndex + 1] = sorted[newIndex];
                    newIndex--;
                }
                sorted[newIndex + 1] = currentItem;
            }

            return sorted;
        }

        [Test]
        public void SortEmptyList()
        {
            var unsorted = new int[0];
            var sorted = new int[0];

            Assert.That(InsertionSortIEnumerable(unsorted), Is.EqualTo(sorted));
        }

        [Test]
        public void SortListOfInts()
        {
            var unsorted = new[] { 5, 2, 3, -1, 8 };
            var sorted = new[] { -1, 2, 3, 5, 8 };

            Assert.That(InsertionSortIEnumerable(unsorted), Is.EqualTo(sorted));
        }

        /// <summary>
        /// A simpler version of the algorithm that works with any IEnumerable. 
        /// </summary>
        private IEnumerable<int> InsertionSortIEnumerable(IEnumerable<int> unsorted)
        {
            var sorted = new List<int>();
            foreach (var item in unsorted)
            {
                var newIndex = sorted.Count;
                while (newIndex > 0 && sorted[newIndex-1] > item)
                    newIndex--;
                sorted.Insert(newIndex, item);
            }

            return sorted;
        }
    }
}
