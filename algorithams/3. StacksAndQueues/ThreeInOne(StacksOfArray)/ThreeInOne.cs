using System;
using System.Text;
using Xunit;

namespace ThreeInOne_StacksOfArray_
{
    public class StacksOfArray
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

        // Flexible stacks
        [Fact]
        public void TestMultiStak_ShouldHaveElements()
        {
            // Arrange
            MultiStack stack = new MultiStack(3, 3);

            // Act
            stack.Push(0, 1);

            stack.Push(1, 2);
            stack.Push(1, 2);
            stack.Push(1, 2);
            stack.Push(1, 2);
            
            stack.Push(2, 3);
            stack.Push(2, 3);
            stack.Push(2, 3);

            // Console.WriteLine("in test: " + stack);

            // Assert
            Assert.Equal(2, stack.Peek(1));
        }

        [Fact]
        public void TestMultiStak_ShouldHaveAllElements()
        {
            // Arrange
            MultiStack stack = new MultiStack(3, 3);

            // Act
            stack.Push(0, 1);

            stack.Push(1, 2);
            stack.Push(1, 2);
            stack.Push(1, 2);
            stack.Push(1, 2);
            
            stack.Push(2, 3);
            stack.Push(2, 3);
            stack.Push(2, 3);            
            stack.Push(2, 3);  

            // Console.WriteLine("in test: " + stack);

            // Assert
            Assert.Equal(2, stack.Peek(1));
        }

         [Fact]
        public void TestMultiStak_ShouldThrowFullStackException()
        {
            // Arrange
            MultiStack stack = new MultiStack(3, 3);

            // Act
            stack.Push(0, 1);

            stack.Push(1, 2);
            stack.Push(1, 2);
            stack.Push(1, 2);
            stack.Push(1, 2);
            
            stack.Push(2, 3);
            stack.Push(2, 3);
            stack.Push(2, 3);            
            stack.Push(2, 3);     

            // Assert
            Assert.Throws<FullStackException>(() => stack.Push(2, 3));
        }

          [Fact]
        public void TestMultiStak_ShouldThrowEmptyStackException()
        {
            // Arrange
            MultiStack stack = new MultiStack(3, 3);

            // Act 

            // Assert
            Assert.Throws<EmptyStackException>(() => stack.Peek(2));
        }

         [Fact]
        public void TestMultiStak_ShouldHaveElementsIn2Stacks()
        {
            // Arrange
            MultiStack stack = new MultiStack(3, 3);

            // Act
            stack.Push(1, 2);
            stack.Push(1, 2);
            stack.Push(1, 2);
            stack.Push(1, 2);
            
            stack.Push(2, 3);
            stack.Push(2, 3);
            stack.Push(2, 3);            
            stack.Push(2, 3);            
            stack.Push(2, 3);

            // Console.WriteLine("in test: " + stack);

            // Assert
            Assert.Equal(2, stack.Peek(1));
            Assert.True(stack.AllStacksAreFull());
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

    // public class MultiStack 
    // {
    //     private class StackInfo
    //     {
    //         public int Start { get; set; }
    //         public int Size { get; set; }
    //         public int Capacity { get; set; }

    //         private MultiStack _stack { get; }

    //         public StackInfo(int start, int capacity, MultiStack stack)
    //         {
    //             Start = start;
    //             Capacity = capacity;
    //             _stack = stack;
    //         }

    //         public bool IsWithinStackCapacity(int index)
    //         {
    //             if (index < 0 || index >= _stack._values.Length)
    //                 return false;

    //             int contiguousIndex = index < Start ? index + _stack._values.Length : index;
    //             int end = Start + Capacity;
    //             return Start <= contiguousIndex && contiguousIndex < end;
    //         }

    //         public int LastElementIndex() => _stack.AdjustIndex(Start + Size - 1);

    //         public int LastCapacityInex() => _stack.AdjustIndex(Start + Capacity - 1);

    //         public bool IsEmpty() => Size == 0;
    //         public bool IsFull() => Size == Capacity;
    //     }

    //     private int[] _values;
    //     private StackInfo[] _info;

    //     public MultiStack(int numberOfStacks, int defaultSize)
    //     {
    //         _info = new StackInfo[numberOfStacks];
    //         for (int i = 0; i < _info.Length; i++)
    //             _info[i] = new StackInfo(defaultSize * i, defaultSize, this);

    //         _values = new int[numberOfStacks * defaultSize];
    //     }

    //     public void Push(int stackNum, int value)
    //     {
    //         if (AllStacksAreFull())
    //             throw new FullStackException();

    //         StackInfo stack = _info[stackNum];

    //         if (stack.IsFull())
    //             Expand(stackNum);

    //         stack.Size++;
    //         _values[stack.LastElementIndex()] = value;
    //     }

    //     public int Pop(int stackNum)
    //     {
    //         StackInfo stack = _info[stackNum];

    //         if (stack.IsEmpty())
    //             throw new EmptyStackException();

    //         int index = stack.LastElementIndex();
    //         int value = _values[index];
    //         _values[index] = 0; // clear item
    //         stack.Size--; // shink size

    //         return value;
    //     }

    //     public int Peek(int stackNum)
    //     {
    //         StackInfo stack = _info[stackNum];

    //         if (stack.IsEmpty())
    //             throw new EmptyStackException();

    //         return _values[stack.LastElementIndex()];
    //     }

    //     public bool AllStacksAreFull() => NumberOfElements() == _values.Length;

    //     public int NumberOfElements()
    //     {
    //         int size = 0;

    //         foreach(var stack in _info)
    //             size += stack.Size;

    //         return size;
    //     }

    //     private void Expand(int stackNum)
    //     {
    //         int nextStack = (stackNum + 1) % _info.Length;
    //         Shift(nextStack);
    //         _info[stackNum].Capacity++;
    //     }

    //     private void Shift(int stackNum)
    //     {
    //         StackInfo stack = _info[stackNum];

    //         //if (stack.Size >= stack.Capacity)
    //         if (stack.IsFull())
    //         {
    //             int nextStack = (stackNum + 1) % _info.Length;
    //             Shift(nextStack);
    //             stack.Capacity++;
    //         }

    //         // shift current stack
    //         int index = stack.LastCapacityInex();
    //         while(stack.IsWithinStackCapacity(index))
    //         {
    //             _values[index] = _values[PreviousIndex(index)];
    //             index = PreviousIndex(index);
    //         }

    //         // Adjust stack data
    //         _values[stack.Start] = 0;
    //         stack.Start = NextIndex(stack.Start); // move start to the next element
    //         stack.Capacity--; // shirnk capacity

            
    //        // Console.WriteLine("afet shifting: " + this);
    //     }

    //     public int AdjustIndex(int index)
    //     {
    //         int max = _values.Length;
    //         return ((index % max) + max) % max;
    //     }

    //     private int PreviousIndex(int index) => AdjustIndex(index - 1);
    //     private int NextIndex (int index) => AdjustIndex(index + 1);
        
    //     public override string ToString()
    //     {
    //         StringBuilder result = new StringBuilder();

    //         foreach(int value in _values)
    //             result.Append(value + ",");

    //         return result.ToString();
    //     }
    //}

    public class MultiStack 
    {
        private class StackInfo 
        {
            public int Start { get ;set; }
            public int Size { get ;set; }
            public int Capacity { get ;set; }
            private MultiStack _stack;

            public StackInfo(int start, int capacity, MultiStack stack)
            {
                Start = start;
                Capacity = capacity;
                _stack = stack;
            }

            public bool IsWithinStackCapacity(int index)
            {
                if (index < 0 || index >= _stack._values.Length)
                    return false;

                int contiguousIndex = index < Start ? index + _stack._values.Length : index;
                int end = Start + Capacity;
                return Start <= contiguousIndex && contiguousIndex < end;
            }

            public int LastElementIndex() => _stack.AdjustIndex(Start + Size - 1);
            public int LastCapacityIndex() => _stack.AdjustIndex(Start + Capacity - 1);
            public bool IsFull() => Size == Capacity;
            public bool IsEmpty() => Size == 0;
        }

        public MultiStack(int numberOfStacks, int defaultSize)
        {
            _info = new StackInfo[numberOfStacks];
            for(int i = 0; i < numberOfStacks; i++)
                _info[i] = new StackInfo(defaultSize * i, defaultSize, this);

            _values = new int[numberOfStacks * defaultSize];
        }

        private StackInfo[] _info;
        private int[] _values;

        public void Push(int stackNum, int value) 
        {
            if (AllStacksAreFull())
                throw new FullStackException();
            
            StackInfo stack = _info[stackNum];

            if (stack.IsFull())
                Expand(stackNum);

            stack.Size++;
            _values[stack.LastElementIndex()] = value;
        }

        public int Pop(int stackNum)
        {
            StackInfo stack = _info[stackNum];

            if(stack.IsEmpty())
                throw new EmptyStackException();

            // get value
            int value = _values[stack.LastElementIndex()];
            // clear value
            _values[stack.LastElementIndex()] = 0;
            // shrink size
            stack.Size--;

            return value;
        }

        public int Peek(int stackNum)
        {
            StackInfo stack = _info[stackNum];

            if(stack.IsEmpty())
                throw new EmptyStackException();

            return _values[stack.LastElementIndex()];
        }

        public bool AllStacksAreFull() => NumberOfElements() == _values.Length;

        public int NumberOfElements() {
            int size = 0;
            foreach(StackInfo stack in _info)
                size += stack.Size;

            return size;
        }

        public int AdjustIndex(int index)
        {
            int max = _values.Length;
            return ((index % max) + max) % max;
        }

        private void Expand(int stackNum) 
        {
            Shift((stackNum + 1) % _info.Length);
            _info[stackNum].Capacity++;
        }

        private void Shift(int stackNum)
        {
            StackInfo stack = _info[stackNum];

            // shift and get space from next stack
            if (stack.IsFull())
                Expand((stackNum + 1) % _info.Length);

            // shift current stack
            int index = stack.LastCapacityIndex();

            while(stack.IsWithinStackCapacity(index)) 
            {
                _values[index] = _values[PreviousIndex(index)];
                index = PreviousIndex(index);
            }

            // reset stack first element
            _values[index] = 0;
            // move start
            stack.Start = NextIndex(stack.Start);
            // shrink capacity
            stack.Capacity--;
        }

        private int PreviousIndex(int index) => AdjustIndex(index - 1);
        private int NextIndex(int index) => AdjustIndex(index + 1);

        public override string ToString() 
        {
            StringBuilder result = new StringBuilder();

            foreach(int item in _values)
                result.Append(item).Append(", ");

            return result.ToString();
        }
    }
}
