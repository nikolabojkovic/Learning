using System;
using System.Collections.Generic;
using Xunit;

namespace MinimalTree
{
    public class MinimalTreeTest
    {
        [Fact]
        public void CreateTree_FromArrayWithEvenNumberOfElements_ShouldReturn3LevelsTree()
        {
            // Arrange
            int [] arr = new int[6] { 2, 4, 5, 7, 8, 10 };
            
            // Act
            Node root = CreateNode(arr, 0, arr.Length - 1);

            // Assert
            Assert.Equal(7, root.Value);

            Assert.Equal(4, root.Left.Value);
            Assert.Equal(10, root.Right.Value);

            Assert.Equal(2, root.Left.Left.Value);
            Assert.Equal(5, root.Left.Right.Value);
            
            Assert.Equal(8, root.Right.Left.Value);
        }

         [Fact]
        public void CreateTree_FromArrayWithOddNumberOfElements_ShouldReturn3LevelsTree()
        {
            // Arrange
            int [] arr = new int[7] { 2, 4, 5, 7, 8, 10, 12 };
            
            // Act
            Node root = CreateNode(arr, 0, arr.Length - 1);

            // Assert
            Assert.Equal(7, root.Value);

            Assert.Equal(4, root.Left.Value);
            Assert.Equal(10, root.Right.Value);

            Assert.Equal(2, root.Left.Left.Value);
            Assert.Equal(5, root.Left.Right.Value);
            
            Assert.Equal(8, root.Right.Left.Value);
            Assert.Equal(12, root.Right.Right.Value);
        }

        private Node CreateNode(int [] arr, int s, int e)
        {
            if (s > e)
               return null;

            int middle = (int)Math.Ceiling((s + e) / 2f);

            Node node = new Node(arr[middle]);
            node.Left = CreateNode(arr, s, middle - 1);
            node.Right = CreateNode(arr, middle + 1, e);
           
            return node;
        }
    }

    public class Node
    {
        public int Value { get; private set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int value)
        {
            Value = value;
        }

        public void Insert(Node n)
        {
            if (n.Value < Value)
                Left = n;
            else
                Right = n;
        }
    }
}
