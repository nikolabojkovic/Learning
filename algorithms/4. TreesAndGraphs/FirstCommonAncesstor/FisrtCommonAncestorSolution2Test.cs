using System;
using Xunit;

namespace FirstCommonAncesstor.Solution2
{
    public class FirstCommonAncestorSolution2Test
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
            Node ancesstor = FindFirstCommonAncestor(node1, node5, node6);

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
            Node ancesstor = FindFirstCommonAncestor(node1, node4, node5);

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
            Node ancesstor = FindFirstCommonAncestor(node1, node3, node6);

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
            Node ancesstor = FindFirstCommonAncestor(node1, node3, node4);

            // Asert
            Assert.Equal(node1, ancesstor);
        }

        private Node FindFirstCommonAncestor(Node root, Node p, Node q)
        {
            if (!Covers(root, p) || !Covers(root, q))
                return null;
            else if (Covers(p, q))
                return p;
            else if (Covers(q, p))
                return q;

            Node sibling = GetSibling(p);
            Node parent = p.Parent;

            while(!Covers(sibling, q))
            {
                sibling = GetSibling(parent);
                parent = parent.Parent;
            }

            return parent;
        }

        private Node GetSibling(Node n)
        {
            if (n == null || n.Parent == null)
                return null;

            Node parent = n.Parent;
            
            return parent.Left == n ? parent.Right : parent.Left; 
        }

        private bool Covers(Node root, Node match)
        {
            if (root == null)
                return false;

            if (root == match)
                return true;

            return Covers(root.Left, match) || Covers(root.Right, match);
        }
    }
}