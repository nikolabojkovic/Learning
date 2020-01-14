using System;
using Xunit;

namespace ThreeInOne_StacksOfArray_
{
    public class UnitTest1
    {
        [Fact]
        public void TestStackOperations_ShouldBeSuccessful()
        {
            // Arrange
            FixedMultiStack stacks = new FixedMultiStack(3);

            // Act
            stacks.Push(1, 1);
            stacks.Push(1, 2);
            stacks.Push(2, 3);

            // Assert
            Assert.Equal(2, stacks.Pop(1));
            Assert.Equal(1, stacks.Peek(1));
            Assert.Equal(1, stacks.Pop(1));
            Assert.Equal(3, stacks.Peek(2));
            Assert.Equal(3, stacks.Peek(2));
        }

        [Fact]
        public void PopFromTheStack_ThrowsEmptyStackException()
        {
            // Arrange
            FixedMultiStack stacks = new FixedMultiStack(3);

            // Act
            

            // Assert
            Assert.Throws<EmptyStackException>(() => stacks.Pop(1));
        }

        [Fact]
        public void PopFromTheStack_ThrowsFullStackException()
        {
            // Arrange
            FixedMultiStack stacks = new FixedMultiStack(3);

            // Act
            stacks.Push(1, 1);
            stacks.Push(1, 2);
            stacks.Push(1, 3);

            // Assert
            Assert.Throws<FullStackException>(() => stacks.Push(1, 4));
        }

        [Fact]
        public void TestStackIsFull_ShouldReturnFalse()
        {
            // Arrange
            FixedMultiStack stacks = new FixedMultiStack(3);

            // Act
            stacks.Push(1, 1);
            stacks.Push(1, 2);

            // Assert
            Assert.False(stacks.IsFull(1));
        }

        [Fact]
        public void TestStackIsFull_ShouldReturnTrue()
        {
            // Arrange
            FixedMultiStack stacks = new FixedMultiStack(3);

            // Act
            stacks.Push(1, 1);
            stacks.Push(1, 2);            
            stacks.Push(1, 3);

            // Assert
            Assert.True(stacks.IsFull(1));
        }

        [Fact]
        public void TestStackIsEmpty_ShouldReturnFalse()
        {
            // Arrange
            FixedMultiStack stacks = new FixedMultiStack(3);

            // Act
            stacks.Push(1, 1);

            // Assert
            Assert.False(stacks.IsEmpty(1));
        }

        [Fact]
        public void TestStackIsEmpty_ShouldReturnTrue()
        {
            // Arrange
            FixedMultiStack stacks = new FixedMultiStack(3);

            // Act
            stacks.Push(1, 1);
            stacks.Push(1, 2);

            // Assert
            Assert.True(stacks.IsEmpty(2));
        }
    }

    public class FixedMultiStack
    {
        private int _stackCapacity;
        private int _numberOfStacks = 3;
        private int[] _array;
        private int[] _top;

        public FixedMultiStack(int stackCapacity)
        {
            _stackCapacity = stackCapacity;
            _array = new int[_stackCapacity * _numberOfStacks];
            _top = new int[_numberOfStacks];
        }

        // Push value onto stack
        public void Push(int stackNum, int value)
        {
            if (IsFull(stackNum))
                throw new FullStackException();

            _top[stackNum]++;
            _array[IndexOfTop(stackNum)] = value;
        }

        // Pop item from top stack
        public int Pop(int stackNum)
        {
            if (IsEmpty(stackNum))
                throw new EmptyStackException();

            int top = IndexOfTop(stackNum);
            int value = _array[top];
            _array[top] = 0; // reset 
            _top[stackNum]--; // clear

            return value;
        }

        // Get top element
        public int Peek(int stackNum)
        {
            if (IsEmpty(stackNum))
                throw new EmptyStackException();

            return _array[IndexOfTop(stackNum)];
        }

        public bool IsFull(int stackNum)
        {
            return _top[stackNum] == _stackCapacity;
        }

        public bool IsEmpty(int stackNum)
        {
            return _top[stackNum] == 0;
        }

        private int IndexOfTop(int stackNum)
        {
            int offset = _stackCapacity * stackNum;
            int size = _top[stackNum];
            
            return offset + size - 1;
        }
    }

    public class FullStackException : Exception
    {
        public FullStackException() {}

        public FullStackException(string message)
        {

        }
    }

    public class EmptyStackException : Exception
    {
        public EmptyStackException() {}

        public EmptyStackException(string message)
        {
            
        }
    }
}
