using System;
using Xunit;

namespace CheckBalanced
{
    public class CheckBalancedTest
    {
        [Fact]
        public void ChechBalanced_Tree_ShouldReturnTrue()
        {
            // Arrange
            Node A = new Node("A");
            Node B = new Node("B");
            Node C = new Node("C");
            Node D = new Node("D");
            Node E = new Node("E");

            A.Left = B;
            A.Right = C;

            B.Left = D;
            B.Right = E;

            // Act
            Result actualResult = IsBalanced(A);

            // Assert
            Assert.True(actualResult.IsBalanced);
        }

        [Fact]
        public void ChechBalanced_Tree_ShouldReturnFalse()
        {
            // Arrange
            Node A = new Node("A");
            Node B = new Node("B");
            Node C = new Node("C");
            Node D = new Node("D");
            Node E = new Node("E");
            Node F = new Node("F");
            Node G = new Node("G");

            A.Left = B;
            A.Right = C;

            B.Left = D;
            B.Right = E;

            D.Left = F;
            D.Right = G;

            // Act
            Result actualResult = IsBalanced(A);

            // Assert
            Assert.False(actualResult.IsBalanced);
        }

        [Fact]
        public void ChechComplexBalanced_Tree_ShouldReturnFalse()
        {
            // Arrange
            Node A = new Node("A");
            Node B = new Node("B");
            Node C = new Node("C");
            Node D = new Node("D");
            Node E = new Node("E");
            Node F = new Node("F");
            Node G = new Node("G");
            Node H = new Node("H");
            Node I = new Node("I");
            Node J = new Node("J");
            Node K = new Node("K");
            Node O = new Node("O");
            Node P = new Node("P");
            Node Q = new Node("Q");
            Node S = new Node("S");
            Node T = new Node("T");

                    A.Left = B;
                    A.Right = C;

            B.Left = D;   C.Left = F;
            B.Right = E;  C.Right = G; 

            D.Left = F;   F.Left = J; 
            D.Right = G;  F.Left = K;  

            E.Left = H;   K.Left = Q;  
            E.Right = I;  K.Left = P;   
 
            H.Left = O;   G.Left = S;   
            H.Right = P;  G.Left = T;   

            // Act
            Result actualResult = IsBalanced(A);

            // Assert
            Assert.False(actualResult.IsBalanced);
        }

        private Result IsBalanced(Node node) // O(n) time and O(H) space where H is the hight of tree
        {
            if (node == null)
                return new Result(false, 0);
                
            if (node.Left == null && node.Right == null)
                return new Result(true, 1);

            Result leftResult = new Result(true, 0);
            if (node.Left != null) 
                leftResult = IsBalanced(node.Left);

            if (!leftResult.IsBalanced)
                return new Result(false, 0);

            Result rightResult = new Result(true, 0);
            if (node.Right != null)
                rightResult = IsBalanced(node.Right);  

            if (!rightResult.IsBalanced)
                return new Result(false, 0);

            int ld = leftResult.DeepestBranchDepth;
            int rd = rightResult.DeepestBranchDepth;

            return new Result(Math.Abs(ld - rd) < 2, Math.Max(ld, rd) + 1);
        }
    }

    public class Node 
    {
        public string Name { get; private set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(string name)
        {
            Name = name;
        }
    }

    public class Result
    {
        public bool IsBalanced { get; private set; }
        public int DeepestBranchDepth { get; set; }

        public Result(bool isBalanced, int depth)
        {
            IsBalanced = isBalanced;
            DeepestBranchDepth = depth;
        }
    }
}
