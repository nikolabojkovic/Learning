using System;
using System.Collections.Generic;
using Xunit;

namespace StackOfPlates
{
    public class StackOfPlatesTest
    {
        [Fact]
        public void Push_ShouldPushNewElementIntoTheSecondStack()
        {
            // Arrange
            var stackOfPlates = new StackOfStacks(3);

            // Act
            stackOfPlates.Push(1);
            stackOfPlates.Push(2);
            stackOfPlates.Push(3);
            stackOfPlates.Push(4);

            // Assert
            Assert.Equal(4, stackOfPlates.Pop());
        }

        [Fact]
        public void Peek_ShouldReturnElementFromTheTop()
        {
            // Arrange
            var stackOfPlates = new StackOfStacks(3);

            // Act
            stackOfPlates.Push(1);
            stackOfPlates.Push(2);
            stackOfPlates.Push(3);
            stackOfPlates.Push(4);

            // Assert
            Assert.Equal(4, stackOfPlates.Peek());
        }

        [Fact]
        public void Pop_ShouldPopFromFirstStackInContainer()
        {
            // Arrange
            var stackOfPlates = new StackOfStacks(3);

            // Act
            stackOfPlates.Push(1);
            stackOfPlates.Push(2);
            stackOfPlates.Push(3);
            stackOfPlates.Push(4);
            stackOfPlates.Pop();

            // Assert
            Assert.Equal(3, stackOfPlates.Pop());
        }

        [Fact]
        public void Push_ShouldPushNewElementIntoTheFirstStack()
        {
            // Arrange
            var stackOfPlates = new StackOfStacks(3);

            // Act
            stackOfPlates.Push(1);
            stackOfPlates.Push(2);
            stackOfPlates.Pop();
            stackOfPlates.Pop();
            stackOfPlates.Push(3);

            // Assert
            Assert.Equal(3, stackOfPlates.Pop());
        }

        [Fact]
        public void Push_ShouldPushNewElementIntoTheStackV2()
        {
            // Arrange
            var stackOfPlates = new StackOfStacksV2(3);

            // Act
            stackOfPlates.Push(1);
            stackOfPlates.Push(2);
            stackOfPlates.Pop();
            stackOfPlates.Pop();
            stackOfPlates.Push(3);

            // Assert
            Assert.Equal(3, stackOfPlates.Pop());
        }

        [Fact]
        public void PopAt_ShouldPopAtFromStackV2()
        {
            // Arrange
            var stackOfPlates = new StackOfStacksV2(3);

            // Act
            stackOfPlates.Push(1); // first stack, (0) index
            stackOfPlates.Push(2); // first stack, (0)
            stackOfPlates.Push(3); // first stack, (0)
            stackOfPlates.Push(4); // second stack, (1)
            stackOfPlates.Push(5); // second stack, (1)
            stackOfPlates.Push(6); // second stack, (1)

            // Assert
            Assert.Equal(3, stackOfPlates.PopAt(0));
            Assert.Equal(4, stackOfPlates.PopAt(0));
            Assert.Equal(6, stackOfPlates.Pop());
        }
    }

    public class StackOfStacks : Stack<Stack<int>>
    {
        private int _capacityPerStack;

        public StackOfStacks(int capacityPerStack)
        {
            _capacityPerStack = capacityPerStack;
        }

        public void Push(int value)
        {
            if (base.Count > 0 && base.Peek().Count < _capacityPerStack)
            {
                base.Peek().Push(value);
                return;
            }

            var newStack = new Stack<int>();
            newStack.Push(value);
            base.Push(newStack);

            Console.WriteLine("Container count: " + base.Count);
            Console.WriteLine("Stack count: " + base.Peek().Count);
        }

        public new int Pop()
        {
            if (base.Peek().Count > 0)
                return base.Peek().Pop();

            base.Pop();
            return base.Peek().Pop();            
        }

        public new int Peek()
        {
            if (base.Peek().Count > 0)
                return base.Peek().Peek();

            base.Pop();
            return base.Peek().Peek();
        }
    }

    public class StackOfStacksV2
    {
        private readonly bool POP_ELEMENT = true;
        private readonly bool REMOVE_BOTTOM_ELEMENT = false;

        private readonly int _capacity;
        private List<Stack> _stacks;

        public StackOfStacksV2(int capacity)
        {
            _capacity = capacity;
            _stacks = new List<Stack>();
        }

        public bool IsEmpty() => GetLastStack().Exists() || GetLastStack().IsEmpty();

        private Stack GetLastStack()
        {
            if (_stacks.Count == 0)
                return null;

            return _stacks[_stacks.Count - 1];
        }

        public void Push(int value)
        {
            var stack = GetLastStack();

            if (!stack.Exists() || stack.IsFull())
            {
                stack = new Stack(_capacity);
                _stacks.Add(stack);
            }
            
            stack.Push(value);
        }

        public int Pop()
        {
            var stack = GetLastStack();

            if (!stack.Exists() || stack.IsEmpty())
                throw new EmptyStackException();

            var value = stack.Pop();

            if (stack.IsEmpty())
                _stacks.RemoveAt(_stacks.Count - 1);

            return value;
        }

        public int PopAt(int index)
        {
            if (index >= _stacks.Count || index < 0)
                throw new IndexOutOfRangeException();

            if (_stacks.Count == 0)
                throw new EmptyStackException();

            return LeftShift(index, POP_ELEMENT);
        }

        private int LeftShift(int index, bool removeTop)
        {
            int removedItem;
            var stack = _stacks[index];

            if (removeTop)
                removedItem = stack.Pop();
            else 
                removedItem = stack.RemoveBottom();

            // clean up stack if it is empty or get item from next stack
            if (stack.IsEmpty())
                _stacks.RemoveAt(index);
            else if (index + 1 < _stacks.Count)
            {
                int value = LeftShift(index + 1, REMOVE_BOTTOM_ELEMENT);
                stack.Push(value);
            }

            return removedItem;
        }
    }

    public class Stack
    {
        private readonly int _capacity;
        private int _size;
        private Node _top;
        private Node _bottom;


        public Stack(int capacity)
        {
            _capacity = capacity;
        }

        public void Push(int value) 
        {
            if (IsFull())
                throw new FullStacException();

            var node = new Node(value);
            node.Below = _top;

            if (_top.HasValue())
            {
                _top.Above = node;
                MoveTopUp();
            }
            else 
            {
                _top = node;
            }

            _size++;
            
            if (_size == 1)
                _bottom = node;
        }

        public int Pop()
        {
            if (IsEmpty())
                throw new EmptyStackException();

            var node = _top;
            MoveTopDown();
            _size--;

            return node.Value;
        }

        public bool IsEmpty() => _size == 0;
        public bool IsFull() => _size == _capacity;

        public int RemoveBottom()
        {
            var node = _bottom;
            MoveBottomUp();
            _size--;

            return node.Value;
        }

        private void MoveTopUp() => _top = _top.Above;
        private void MoveTopDown() => _top = _top.Below;
        private void MoveBottomUp() => _bottom = _bottom.Above;
    }

    public static class StackExtentions
    {
        public static bool Exists(this Stack stack) => stack != null;

        public static bool HasValue(this Node node) => node != null;
    }

    public class EmptyStackException : Exception {}
    public class FullStacException : Exception {}

    public class Node 
    {
        public  Node Above { get; set; }
        public Node Below { get; set; }

        public int Value { get; private set; }

        public Node(int value)
        {
            Value = value;
        }
    }
}
