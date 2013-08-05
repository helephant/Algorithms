using System.Collections.Generic;
using NUnit.Framework;

namespace SortAlgorithms
{
    /// <summary>
    /// Very naive and simple o(n^2) sort algoritm.
    /// Not much difference between average case and worst case.
    /// </summary>
    [TestFixture]
    public class BubbleSortTests
    {
        [Test]
        public void SortEmptyArray()
        {
            var unsorted = new int[0];
            var sorted = new int[0];

            Assert.That(BubbleSort(unsorted), Is.EqualTo(sorted));
        }

        [Test]
        public void SortArrayOfInts()
        {
            var unsorted = new[] { 5, 2, 3, -1, 8 };
            var sorted = new[] { -1, 2, 3, 5, 8 };

            Assert.That(BubbleSort(unsorted), Is.EqualTo(sorted));
        }

        private IEnumerable<int> BubbleSort(IEnumerable<int> unsorted)
        {
            var sorted = new List<int>(unsorted);

            var lastUnsortedIndex = sorted.Count - 1;
            while (lastUnsortedIndex > 0)
            {
                for (int x = 0; x < lastUnsortedIndex; x++)
                {
                    if (sorted[x] > sorted[x + 1])
                    {
                        var item = sorted[x];
                        sorted[x] = sorted[x + 1];
                        sorted[x + 1] = item;
                    }
                }
                lastUnsortedIndex--;
            }

            return sorted;
        } 
    }
}
