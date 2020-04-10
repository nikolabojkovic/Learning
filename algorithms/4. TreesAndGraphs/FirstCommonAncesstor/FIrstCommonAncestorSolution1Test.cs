using System;
using Xunit;

namespace FirstCommonAncesstor
{
    public class FirstCommonAncesstorSolution1Test
    {
        [Fact]
        public void FindFirstCommonAncesstor_SouldReturn1()
        {
            // Arrange
            Node node1 = new Node();
            Node node2 = new Node();
            Node node3 = new Node();
            Node node4 = new Node();
            Node node5 = new Node();
            Node node6 = new Node();

            node1.Left = node2;
            node1.Right = node3;

            node2.Left = node4;
            node2.Right = node5;

            node3.Right = node6;

            node2.Parent = node1;
            node4.Parent = node2;
            node5.Parent = node2;
            node3.Parent = node1;
            node6.Parent = node3;

            // Act
            Node ancesstor = FindFirstCommonAncesstor(node5, node6);

            // Asert
            Assert.Equal(node1, ancesstor);
        }

        [Fact]
        public void FindFirstCommonAncesstor_SouldReturn2()
        {
            // Arrange
            Node node1 = new Node();
            Node node2 = new Node();
            Node node3 = new Node();
            Node node4 = new Node();
            Node node5 = new Node();
            Node node6 = new Node();

            node1.Left = node2;
            node1.Right = node3;

            node2.Left = node4;
            node2.Right = node5;

            node3.Right = node6;

            node2.Parent = node1;
            node4.Parent = node2;
            node5.Parent = node2;
            node3.Parent = node1;
            node6.Parent = node3;

            // Act
            Node ancesstor = FindFirstCommonAncesstor(node4, node5);

            // Asert
            Assert.Equal(node2, ancesstor);
        }

        [Fact]
        public void FindFirstCommonAncesstor_SouldReturn3()
        {
            // Arrange
            Node node1 = new Node();
            Node node2 = new Node();
            Node node3 = new Node();
            Node node4 = new Node();
            Node node5 = new Node();
            Node node6 = new Node();

            node1.Left = node2;
            node1.Right = node3;

            node2.Left = node4;
            node2.Right = node5;

            node3.Right = node6;

            node2.Parent = node1;
            node4.Parent = node2;
            node5.Parent = node2;
            node3.Parent = node1;
            node6.Parent = node3;

            // Act
            Node ancesstor = FindFirstCommonAncesstor(node3, node6);

            // Asert
            Assert.Equal(node3, ancesstor);
        }

         [Fact]
        public void FindFirstCommonAncesstor_NodesOnDifferentLevel_SouldReturn1()
        {
            // Arrange
            Node node1 = new Node();
            Node node2 = new Node();
            Node node3 = new Node();
            Node node4 = new Node();
            Node node5 = new Node();
            Node node6 = new Node();

            node1.Left = node2;
            node1.Right = node3;

            node2.Left = node4;
            node2.Right = node5;

            node3.Right = node6;

            node2.Parent = node1;
            node4.Parent = node2;
            node5.Parent = node2;
            node3.Parent = node1;
            node6.Parent = node3;

            // Act
            Node ancesstor = FindFirstCommonAncesstor(node3, node4);

            // Asert
            Assert.Equal(node1, ancesstor);
        }

        private Node FindFirstCommonAncesstor(Node p, Node q)
        {
            int delta = Depth(p) - Depth(q);
            Node first = delta > 0 ? q : p;
            Node second = delta > 0 ? p : q;
            second = GoUpBy(second, Math.Abs(delta));

            while(first != second && first != null && second != null)
            {
                first = first.Parent;
                second = second.Parent;
            }

            return first == null || second == null ? null : first;
        }

        Node GoUpBy(Node node, int delta)
        {
            while(delta > 0 && node != null)
            {
                node = node.Parent;
                delta--;
            }

            return node;
        }

        int Depth(Node n)
        {
            int depth = 0;

            while(n != null)
            {
                n = n.Parent;
                depth++;
            }

            return depth;
        }
    }

    class Node
    {
        public Node Parent { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }
}