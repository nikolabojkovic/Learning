using System;
using Xunit;

namespace ValidateBinarySearchTree
{
    public class ValidateBinarySearchTreeTest
    {
        [Fact]
        public void DFSIsBinarySearchTree_ShouldReturnTrue()
        {
            // Arrange
            Node node10 = new Node(10);
            Node node5 = new Node(5);
            Node node7 = new Node(7);
            Node node2 = new Node(2);
            Node node12 = new Node(12);
            Node node11 = new Node(11);

            node10.Left = node5;
            node10.Right = node12;

            node5.Left = node2;
            node5.Right = node7;

            node12.Left = node11;
            // Act   //bool expected = IsBinarySearchTree(node10);
            bool expected = IsBinarySearchTree(node10, null, null);

            // Assert
            Assert.True(expected);
        }

         [Fact]
        public void DFSIsBinarySearchTree_WithSomeIdenticalValues_ShouldReturnFalse()
        {
            // Arrange
            Node node10 = new Node(10);
            Node node10Again = new Node(10);
            Node node15 = new Node(15);
            Node node2 = new Node(2);
            Node node12 = new Node(12);
            Node node11 = new Node(11);

            node10.Left = node10Again;
            node10.Right = node12;

            node10Again.Left = node2;
            node10Again.Right = node11;

            node12.Right = node15;
            // Act
            bool expected = IsBinarySearchTree(node10, null, null);

            // Assert
            Assert.False(expected);
        }

        [Fact]
        public void DFSIsBinarySearchTree_ShouldReturnFalse()
        {
            // Arrange
            Node node10 = new Node(10);
            Node node5 = new Node(5);
            Node node7 = new Node(7);
            Node node2 = new Node(2);
            Node node12 = new Node(12);
            Node node11 = new Node(11);

            node12.Left = node5;
            node12.Right = node10;

            node5.Left = node2;
            node5.Right = node7;

            node10.Left = node11;
            // Act
            bool expected = IsBinarySearchTree(node10, null, null);

            // Assert
            Assert.False(expected);
        }

        private bool IsBinarySearchTree(Node node, int? min, int? max)
        {
            if (node == null)
                return true;

            // right branch check
            if (min.HasValue && node.Value <= min)
                return false;

            // left branch check
            if (max.HasValue && node.Value > max)
                return false;

            if (!IsBinarySearchTree(node.Left, min, node.Value) || !IsBinarySearchTree(node.Right, node.Value, max))
                return false;

            return true;
        }
    }

    public class Node
    {
        public Node(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public Node Left { get; set; }
        public Node Right { get; set; }
    }
}
