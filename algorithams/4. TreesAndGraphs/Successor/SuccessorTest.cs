using System;
using Xunit;

namespace Successor
{
    public class SuccessorTest
    {
        [Fact]
        public void FindSuccessor_ShouldReturnLeftMostNodeOfRightBranch()
        {
            // Arrange
            // Root
            Node node12 = new Node(12);

            // Left branch
            Node node8  = new Node(8);
            Node node10 = new Node(10);
            Node node5  = new Node(5);
            Node node7  = new Node(7);
            Node node3  = new Node(3);

            // Right branch
            Node node15 = new Node(15);
            Node node13 = new Node(13);
            Node node20 = new Node(20);

            // nodes connections
            node12.Left  = node8;
            node12.Right = node15;

            node8.Left   = node5;
            node8.Right  = node10;
            
            node5.Left   = node3;
            node5.Right  = node7;

            node15.Left  = node13;
            node15.Right = node20;
            
            node8.Parent  = node12;
            node10.Parent = node8;
            node5.Parent  = node8;
            node3.Parent  = node5;
            node7.Parent  = node5;

            node15.Parent = node12;
            node13.Parent = node15;
            node20.Parent = node15;

            // Act
            Node actual  = Successor(node12);

            // Assert
            Assert.Equal(13, actual.Value);
        }

        [Fact]
        public void FindSuccessor_ShouldReturnSecondParentNode()
        {
            // Arrange
            // Root
            Node node12 = new Node(12);

            // Left branch
            Node node8  = new Node(8);
            Node node10 = new Node(10);
            Node node5  = new Node(5);
            Node node7  = new Node(7);
            Node node3  = new Node(3);

            // Right branch
            Node node15 = new Node(15);
            Node node13 = new Node(13);
            Node node20 = new Node(20);

            // nodes connections
            node12.Left  = node8;
            node12.Right = node15;

            node8.Left   = node5;
            node8.Right  = node10;
            
            node5.Left   = node3;
            node5.Right  = node7;

            node15.Left  = node13;
            node15.Right = node20;
            
            node8.Parent  = node12;
            node10.Parent = node8;
            node5.Parent  = node8;
            node3.Parent  = node5;
            node7.Parent  = node5;

            node15.Parent = node12;
            node13.Parent = node15;
            node20.Parent = node15;

            // Act
            Node actual  = Successor(node10);

            // Assert
            Assert.Equal(12, actual.Value);
        }

        [Fact]
        public void FindSuccessor_ShouldReturnNextRightNode()
        {
            // Arrange
            // Root
            Node node12 = new Node(12);

            // Left branch
            Node node8  = new Node(8);
            Node node10 = new Node(10);
            Node node5  = new Node(5);
            Node node7  = new Node(7);
            Node node3  = new Node(3);

            // Right branch
            Node node15 = new Node(15);
            Node node13 = new Node(13);
            Node node20 = new Node(20);

            // nodes connections
            node12.Left  = node8;
            node12.Right = node15;

            node8.Left   = node5;
            node8.Right  = node10;
            
            node5.Left   = node3;
            node5.Right  = node7;

            node15.Left  = node13;
            node15.Right = node20;
            
            node8.Parent  = node12;
            node10.Parent = node8;
            node5.Parent  = node8;
            node3.Parent  = node5;
            node7.Parent  = node5;

            node15.Parent = node12;
            node13.Parent = node15;
            node20.Parent = node15;

            // Act
            Node actual  = Successor(node15);

            // Assert
            Assert.Equal(20, actual.Value);
        }

         [Fact]
        public void FindSuccessor_ShouldReturnNull()
        {
            // Arrange
            Node root = null;

            // Act
            Node actual  = Successor(root);

            // Assert
            Assert.Null(actual);
        }

        private Node Successor(Node node)
        {
            if (node == null)
                return null;

            if (node.Right != null)
            {
                node = node.Right;
                while(node.Left != null)
                {
                    node = node.Left;
                }

                return node;
            }
            else
            {
                while(node.Parent != null && node.Parent.Right == node)
                {
                    node = node.Parent;
                }

                return node.Parent;
            }
        }

    }

    public class Node 
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node Parent { get; set; }
        public int Value { get; }

        public Node(int value)
        {
            Value = value;
        }
    }
}
