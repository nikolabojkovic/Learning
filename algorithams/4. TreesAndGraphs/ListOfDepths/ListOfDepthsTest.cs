using System;
using System.Collections.Generic;
using Xunit;

namespace ListOfDepths
{
    public class ListOfDepthsTest
    {
        [Fact]
        public void CreateListForEachTreeLevel_ShouldReturnListWithNodesForEveryLevel()
        {
            // Arrange
            TreeNode A = new TreeNode("A");
            TreeNode B = new TreeNode("B");
            TreeNode C = new TreeNode("C");
            TreeNode D = new TreeNode("D");
            TreeNode E = new TreeNode("E");
            TreeNode F = new TreeNode("F");
            TreeNode G = new TreeNode("G");
            TreeNode H = new TreeNode("H");
            TreeNode J = new TreeNode("J");

            A.Left = B;
            A.Right = C;

            B.Left = D;
            B.Right = E;

            C.Left = F;
            C.Right = G;

            D.Left = H;
            D.Right = J;

            List<ListNode> lists = new List<ListNode>();

            // Act
            ListOfDepth(A, 1, lists);

            // Assert
            Assert.Equal(4, lists.Count);
            Assert.Equal("A", lists[0].Name);
            Assert.Equal("B", lists[1].Previous.Name);
            Assert.Equal("C", lists[1].Name);
            Assert.Equal("D", lists[2].Previous.Previous.Previous.Name);
            Assert.Equal("E", lists[2].Previous.Previous.Name);
            Assert.Equal("F", lists[2].Previous.Name);
            Assert.Equal("G", lists[2].Name);            
            Assert.Equal("H", lists[3].Previous.Name);            
            Assert.Equal("J", lists[3].Name);
        }

        [Fact]
        public void CreateListForEachTreeLevel_ShouldReturnListOfListForEveryLevel()
        {
            // Arrange
            TreeNode A = new TreeNode("A");
            TreeNode B = new TreeNode("B");
            TreeNode C = new TreeNode("C");
            TreeNode D = new TreeNode("D");
            TreeNode E = new TreeNode("E");
            TreeNode F = new TreeNode("F");
            TreeNode G = new TreeNode("G");
            TreeNode H = new TreeNode("H");
            TreeNode J = new TreeNode("J");

            A.Left = B;
            A.Right = C;

            B.Left = D;
            B.Right = E;

            C.Left = F;
            C.Right = G;

            D.Left = H;
            D.Right = J;

            List<List<TreeNode>> lists = new List<List<TreeNode>>();

            // Act
            ListsOfDepth(A, 0, lists);

            // Assert
            Assert.Equal(4, lists.Count);
            Assert.Equal("A", lists[0][0].Name);
            Assert.Equal("B", lists[1][0].Name);
            Assert.Equal("C", lists[1][1].Name);
            Assert.Equal("D", lists[2][0].Name);
            Assert.Equal("E", lists[2][1].Name);
            Assert.Equal("F", lists[2][2].Name);
            Assert.Equal("G", lists[2][3].Name);            
            Assert.Equal("H", lists[3][0].Name);            
            Assert.Equal("J", lists[3][1].Name);
        }

        [Fact]
        public void CreateListForEachTreeLevel_ShouldReturnListOfListForEveryLevel_AdditionalSolutionTest()
        {
            // Arrange
            TreeNode A = new TreeNode("A");
            TreeNode B = new TreeNode("B");
            TreeNode C = new TreeNode("C");
            TreeNode D = new TreeNode("D");
            TreeNode E = new TreeNode("E");
            TreeNode F = new TreeNode("F");
            TreeNode G = new TreeNode("G");
            TreeNode H = new TreeNode("H");
            TreeNode J = new TreeNode("J");

            A.Left = B;
            A.Right = C;

            B.Left = D;
            B.Right = E;

            C.Left = F;
            C.Right = G;

            D.Left = H;
            D.Right = J;

            // Act
            List<List<TreeNode>> lists = ListsListOfDepthsAlternative(A);

            // Assert
            Assert.Equal(4, lists.Count);
            Assert.Equal("A", lists[0][0].Name);
            Assert.Equal("B", lists[1][0].Name);
            Assert.Equal("C", lists[1][1].Name);
            Assert.Equal("D", lists[2][0].Name);
            Assert.Equal("E", lists[2][1].Name);
            Assert.Equal("F", lists[2][2].Name);
            Assert.Equal("G", lists[2][3].Name);            
            Assert.Equal("H", lists[3][0].Name);            
            Assert.Equal("J", lists[3][1].Name);
        }

        private void ListOfDepth(TreeNode root, int level, List<ListNode> lists)
        {
            if (root == null) return;

            var node = new ListNode(root.Name);

            if (lists.Count < level)
            {
                lists.Add(node);
            }
            else
            {
                lists[level - 1].Next = node;
                node.Previous = lists[level - 1];
                lists[level - 1] = lists[level - 1].Next;
            }

            if (root.Left != null)
                ListOfDepth(root.Left, level + 1, lists);

            if (root.Right != null)
                ListOfDepth(root.Right, level + 1, lists);
        }
  
        private void ListsOfDepth(TreeNode root, int level, List<List<TreeNode>> lists)
        {
            if (root == null) return;

            List<TreeNode> list = null;
            if (lists.Count == level)
            {
                list = new List<TreeNode>();
                lists.Add(list);
            }
            else
            {
                list = lists[level];
            }

            list.Add(root);
            ListsOfDepth(root.Left, level + 1, lists);
            ListsOfDepth(root.Right, level + 1, lists);
        }

        private List<List<TreeNode>> ListsListOfDepthsAlternative(TreeNode root)
        {
            if (root == null) return null;

            List<List<TreeNode>> result = new List<List<TreeNode>>();
            List<TreeNode> currentLevel = new List<TreeNode>();
            currentLevel.Add(root);

            while(currentLevel.Count > 0)
            {
                result.Add(currentLevel);
                List<TreeNode> parents = currentLevel;
                currentLevel = new List<TreeNode>();

                foreach(var parent in parents)
                {
                    if (parent.Left != null)
                        currentLevel.Add(parent.Left);

                    if (parent.Right != null)
                        currentLevel.Add(parent.Right);
                }
            }

            return result;
        }
    }

    public class ListNode
    {
        public string Name { get; private set; }
        public ListNode Next { get; set; }
        public ListNode Previous { get; set; }

        public ListNode(string name)
        {
            Name = name;
        }
    }

    public class TreeNode
    {
        public string Name { get; private set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(string name)
        {
            Name = name;
        }
    }
}
