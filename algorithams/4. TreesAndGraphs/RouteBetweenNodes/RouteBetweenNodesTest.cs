using System;
using System.Collections.Generic;
using Xunit;

namespace RouteBetweenNodes
{
    public class RouteBetweenNodesTest
    {
        [Fact]
        public void FindPath_ShouldReturnPathDoesExist()
        {
            // Arrange
            Node A = new Node("A");
            Node B = new Node("B");
            Node C = new Node("C");
            Node D = new Node("D");
            Node E = new Node("E");
            Node F = new Node("F");

            A.Adjesent.Add(B);
            A.Adjesent.Add(C);
            B.Adjesent.Add(F);
            B.Adjesent.Add(C);
            C.Adjesent.Add(D);
            D.Adjesent.Add(B);
            D.Adjesent.Add(E);
            F.Adjesent.Add(D);

            // Act
            var expectedReslt = HasPathBetween(A, D);

            // Assert
            Assert.True(expectedReslt);
        }

        [Fact]
        public void FindPath_ShouldReturnPathDoesNotExist()
        {
            // Arrange
            Node A = new Node("A");
            Node B = new Node("B");
            Node C = new Node("C");
            Node D = new Node("D");
            Node E = new Node("E");
            Node F = new Node("F");

            A.Adjesent.Add(B);
            A.Adjesent.Add(C);
            B.Adjesent.Add(F);
            B.Adjesent.Add(C);
            C.Adjesent.Add(D);
            D.Adjesent.Add(B);
            E.Adjesent.Add(D);
            F.Adjesent.Add(D);

            // Act
            var expectedReslt = HasPathBetween(A, E);

            // Assert
            Assert.False(expectedReslt);
        }

        public bool HasPathBetween(Node start, Node destination)
        {
            Queue<Node> visitors = new Queue<Node>();
            visitors.Enqueue(start);

            while(visitors.Count > 0)
            {
                Node current = visitors.Dequeue();

                if (current.Name == destination.Name)
                    return true;

                current.Visit();

                foreach(Node node in current.Adjesent)
                {
                    if (!node.Visited)
                        visitors.Enqueue(node);
                }
            }

            return false;
        }
    }

    public class Node 
    {
        public string Name { get; private set; }
        public List<Node> Adjesent { get; private set; }
        public bool Visited { get; private set; }

        public Node(string name)
        {
            Name = name;
            Adjesent = new List<Node>();
        }

        public void Visit() => Visited = true;
    }
}
