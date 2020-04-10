using System;
using System.Collections;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Palindrom
{
    public class Palindrom
    {
        private readonly ITestOutputHelper _output;

        public Palindrom(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void IsPalindrom_ReverseApproach_ShouldReturnTrue()
        {
            // Arrange
            Node head = InsertBefore(InsertBefore(InsertBefore(InsertBefore(InsertBefore(null, 0), 1), 2), 1), 0);

            // Act
            bool result = IsPolindrom(head);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsPalindrom_ReverseApproach_ShouldReturnFalse()
        {
            // Arrange
            Node head = InsertBefore(InsertBefore(InsertBefore(InsertBefore(InsertBefore(null, 1), 1), 2), 1), 0);

            // Act
            bool result = IsPolindrom(head);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsPalindrom_ReverseIterativelyApproach_ShouldReturnTrue()
        {
            // Arrange
            Node head = InsertBefore(InsertBefore(InsertBefore(InsertBefore(InsertBefore(null, 0), 1), 2), 1), 0);

            // Act
            bool result = IsPolindromReverseIteratively(head);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsPalindrom_ReverseIterativelyApproach_ShouldReturnFalse()
        {
            // Arrange
            Node head = InsertBefore(InsertBefore(InsertBefore(InsertBefore(InsertBefore(null, 1), 1), 2), 1), 0);

            // Act
            bool result = IsPolindromReverseIteratively(head);

            // Assert
            Assert.False(result);
        }

        private int Count(Node head)
        {
            int counter = 0;

            while(head != null)
            {
                counter++;
                head = head.next;
            }

            return counter;
        }

        private Node InsertBefore(Node node, int value)
        {
            Node head = new Node { value = value, next = node };
            return head;
        }

        private Node InsertAfter(Node head, int value)
        {
            Node iter = head;
            while(iter.next != null)
                iter = iter.next;
                
            iter.next = new Node { value = value, next = null };
            return head;
        }

        private bool Compare(Node l1, Node l2, int count)
        {
            for(int i = 0; i < count; i++)
            {
                if (l1.value != l2.value)
                    return false;

                l1 = l1.next;
                l2 = l2.next;
            }

            return true;
        }

        Node Reverse(Node head)
        {
            if(head.next == null)
                return head;

            Node node = InsertAfter(Reverse(head.next), head.value);
            return node;
        }

        Node ReverseIteratively(Node head)
        {
            Node reversedHead = null;

            while(head != null)
            {
                reversedHead = InsertBefore(reversedHead, head.value);
                head = head.next;
            }

            return reversedHead;
        }

        bool IsPolindrom(Node head)
        {
            if(head == null)
                return false;

            Node reversed = Reverse(head);
            return Compare(head, reversed, Count(head) / 2);
        }

         bool IsPolindromReverseIteratively(Node head)
        {
            if(head == null)
                return false;

            Node reversed = ReverseIteratively(head);

            // Print to console
            PrintList(head, "Original list");
            PrintList(reversed, "Reversed list");

            return Compare(head, reversed, Count(head) / 2);
        }

         [Fact]
        public void IsPalindrom_IterativeApproach_ShouldReturnTrue()
        {
            // Arrange
            Node head = InsertBefore(InsertBefore(InsertBefore(InsertBefore(InsertBefore(null, 0), 1), 2), 1), 0);

            // Act
            bool result = IsPalindromeIterativeApproach(head);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsPalindrom_IterativeApproach_ShouldReturnFalse()
        {
            // Arrange
            Node head = InsertBefore(InsertBefore(InsertBefore(InsertBefore(InsertBefore(null, 1), 1), 2), 1), 0);

            // Act
            bool result = IsPalindromeIterativeApproach(head);

            // Assert
            Assert.False(result);
        }

        bool IsPalindromeIterativeApproach(Node head)
        {
            if(head == null ) return false;

            Stack listStack = new Stack();
            Node fast = head;
            Node slow = head;

            while(fast != null && fast.next != null)
            {
                listStack.Push(slow.value);
                slow = slow.next;
                fast = fast.next.next;
            }

            // Handle odd number of elements in list
            if(fast != null)
                slow = slow.next;

            while(slow != null)
            {
                if(Convert.ToInt32(listStack.Pop()) != slow.value)
                    return false;

                slow = slow.next;
            }

            return true;
        }
        
        private void PrintList(Node head, string listName)
        {
             Console.WriteLine($"-- {listName} --");
            _output.WriteLine($"-- {listName} --");

            StringBuilder message = new StringBuilder();
            message.Append("head");

            while(head != null)
            {
                message.Append( " -> " + head.value);
                head = head.next;
            }
            
            Console.WriteLine(message.ToString());
            _output.WriteLine(message.ToString());
            Console.WriteLine($"-- End {listName} --");
            _output.WriteLine($"-- End {listName} --");
        }

        // recursive approach
        bool IsPalindromRecursive(Node head)
        {
            int len = Count(head);
            return PalindromeRecursive(head, len).value;
        }


      [Fact]
        public void IsPalindrom_RecursiveApproach_ShouldReturnTrue()
        {
            // Arrange
            Node head = InsertBefore(InsertBefore(InsertBefore(InsertBefore(InsertBefore(null, 0), 1), 2), 1), 0);

            // Act
            bool result = IsPalindromRecursive(head);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsPalindrom_RecursiveApproach_ShouldReturnFalse()
        {
            // Arrange
            Node head = InsertBefore(InsertBefore(InsertBefore(InsertBefore(InsertBefore(null, 1), 1), 2), 1), 0);

            // Act
            bool result = IsPalindromRecursive(head);

            // Assert
            Assert.False(result);
        }

         [Fact]
        public void IsPalindrom_RecursiveApproach_ShouldReturnTrueScenario1()
        {
            // Arrange
            Node head = InsertBefore(null, 0);

            // Act
            bool result = IsPalindromRecursive(head);

            // Assert
            Assert.True(result);
        }

          [Fact]
        public void IsPalindrom_RecursiveApproach_ShouldReturnTrueScenario2()
        {
            // Arrange
            Node head = null;

            // Act
            bool result = IsPalindromRecursive(head);

            // Assert
            Assert.True(result);
        }

        Result PalindromeRecursive(Node node, int len)
        {
            // return point
           // if(node == null || len <= 0)
           if(len <= 0)
                return new Result{ value = true, node = node};
            else if (len == 1)
                return new Result{value = true, node = node.next};

            Result res = PalindromeRecursive(node.next, len - 2);

            // check for failure
           // if (!res.value || res.node == null)
           if (!res.value)
                return res;

            // compare
            res.value = res.node.value == node.value;
            res.node = res.node.next;

            return res;
        }
    }

    public class Node 
    {
        public int value;
        public Node next;
    }

    public class Result
    {
        public bool value;
        public Node node;
    }
}
