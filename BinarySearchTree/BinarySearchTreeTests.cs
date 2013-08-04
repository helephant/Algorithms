using System;
using NUnit.Framework;

namespace Algorithms
{
    [TestFixture]
    public class BinarySearchTreeTests
    {
        [Test]
        public void CreateEmptyTree()
        {
            var tree = new BinarySearchTree<int>();

            Assert.That(tree, Is.EqualTo(new int[] {}));
        }

        [Test]
        public void AddSingleValueIntoTree()
        {
            var tree = new BinarySearchTree<int> {7};

            Assert.That(tree, Is.EqualTo(new[] {7}));
        }

        [Test]
        public void AddSmallerValueAfterRootNode()
        {
            var tree = new BinarySearchTree<int> {7, 3};

            Assert.That(tree, Is.EqualTo(new[] {3, 7}));
        }

        [Test]
        public void AddLargerValueAfterRootNode()
        {
            var tree = new BinarySearchTree<int> {7, 10};

            Assert.That(tree, Is.EqualTo(new[] { 7, 10 }));
        }

        [Test]
        public void AddMoreThanOneLevelOfChildNodes()
        {
            var tree = new BinarySearchTree<int> {15, 6, 18, 3, 17, 20};

            Assert.That(tree, Is.EqualTo(new[] { 3, 6, 15, 17, 18, 20 }));
        }

        [Test]
        public void AddSameValueTwice()
        {
            var tree = new BinarySearchTree<int> {5, 5};
            Assert.That(tree, Is.EqualTo(new[] { 5, 5}));
        }

        [Test]
        public void CreateTreeWithOtherComparableTypes()
        {
            var tree = new BinarySearchTree<string> {"Sam", "Joe", "Victoria", "Rufus", "Gill", "Travis", "Zelda"};

            Assert.That(tree, Is.EqualTo(new[] { "Gill", "Joe", "Rufus", "Sam", "Travis", "Victoria", "Zelda" }));
        }

        [Test]
        public void RemoveRootNode()
        {
            var tree = new BinarySearchTree<int> {10};
            tree.Remove(10);

            Assert.That(tree, Is.EqualTo(new int[0]));
        }

        [Test]
        public void RemoveNodeWithNoChildren()
        {
            var tree = new BinarySearchTree<int> {10, 7, 8, 6};

            Assert.That(tree.Remove(8), Is.True);
            Assert.That(tree.Remove(6), Is.True);
            Assert.That(tree, Is.EqualTo(new[] { 7, 10 }));
        }

        [Test]
        public void RemoveNodeWithChildren()
        {
            var tree = new BinarySearchTree<int> {10, 7, 11, 8, 6};

            Assert.That(tree.Remove(7), Is.True);
            Assert.That(tree, Is.EqualTo(new[] {6, 8, 10, 11 }));
        }

        [Test]
        public void RemoveValueFromEmptyTree()
        {
            var tree = new BinarySearchTree<int>();

            Assert.That(tree.Remove(10), Is.False);
            Assert.That(tree, Is.EqualTo(new int[0]));
        }

        [Test]
        public void RemoveValueThatDoesNotExist()
        {
            var tree = new BinarySearchTree<int> {10, 7, 11, 8};

            Assert.That(tree.Remove(13), Is.False);
            Assert.That(tree, Is.EqualTo(new[] { 7, 8, 10, 11 }));
        }

        [Test]
        public void MaximumValue()
        {
            var tree = new BinarySearchTree<int> {15, 6, 18, 20};

            Assert.That(tree.Maximum(), Is.EqualTo(20));
        }

        [Test]
        public void MaximumCalledOnEmptyTreeCausesException()
        {
            var tree = new BinarySearchTree<int>();

            Assert.Throws<InvalidOperationException>(() => tree.Maximum());
        }

        [Test]
        public void MinimumValue()
        {
            var tree = new BinarySearchTree<int> {15, 6, 18, 3};

            Assert.That(tree.Minimum(), Is.EqualTo(3));
        }

        [Test]
        public void MinimumCalledOnEmptyTreeCausesException()
        {
            var tree = new BinarySearchTree<int>();

            Assert.Throws<InvalidOperationException>(() => tree.Minimum());
        }

        [Test]
        public void SearchForValueThatExistsInLeftOfTree()
        {
            var tree = new BinarySearchTree<int> {15, 6, 3, 7};

            Assert.That(tree.Contains(7), Is.EqualTo(true));
        }

        [Test]
        public void SearchForValueThatExistsInRightOfTree()
        {
            var tree = new BinarySearchTree<int> {15, 18, 17, 20};

            Assert.That(tree.Contains(17), Is.EqualTo(true));
        }

        [Test]
        public void SearchForValueThatDoesNotExist()
        {
            var tree = new BinarySearchTree<int> {15, 6, 18, 3, 17, 20};

            Assert.That(tree.Contains(21), Is.EqualTo(false));
        }

        [Test]
        public void SearchForValueInEmptyTree()
        {
            var tree = new BinarySearchTree<int>();

            Assert.That(tree.Contains(13), Is.EqualTo(false));
        }

        [Test]
        public void ClearAllItemsInList()
        {
            var tree = new BinarySearchTree<int> {5, 3, 7};

            tree.Clear();
            
            Assert.That(tree, Is.EqualTo(new int[0]));
        }

        [Test]
        public void Count()
        {
            var tree = new BinarySearchTree<int> {1, 2, 3};

            Assert.That(tree.Count, Is.EqualTo(3));
        }

        [Test]
        public void CountOnEmptyTree()
        {
            var tree = new BinarySearchTree<int>();

            Assert.That(tree.Count, Is.EqualTo(0));
        }
    }
}