using System;
using Xunit;
using System.Collections.Generic;

namespace StackMin
{
    public class StackMinTest
    {
        // tests for solution #1
        [Fact]
        public void GetMin_ShouldReturnCorrectValue()
        {
            var stack = new MinStack();

            stack.Push(1);
            stack.Push(3);
            stack.Push(2);

            Assert.Equal(2, stack.Peek());
            Assert.Equal(1, stack.Min());
        }

        [Fact]
        public void GetMin_ShouldSearchForMinValue()
        {
            var stack = new MinStack();

            stack.Push(2);
            stack.Push(3);
            stack.Push(1);

            Assert.Equal(1, stack.Peek());
            Assert.Equal(1, stack.Pop());
            Assert.Equal(2, stack.Min());
        }

        [Fact]
        public void Test_Stack_IsEmtpy()
        {
            var stack = new MinStack();

           

            Assert.True(stack.ToArray().Length == 0);
        }

        // tests for solution #2
        [Fact]
        public void GetMin_ShouldReturnCorrectValue2()
        {
            var stack = new MinStackNode();

            stack.Push(1);
            stack.Push(3);
            stack.Push(2);

            Assert.Equal(2, stack.Peek()._value);
            Assert.Equal(1, stack.Min());
        }

        [Fact]
        public void GetMin_ShouldSearchForMinValue2()
        {
            var stack = new MinStackNode();

            stack.Push(2);
            stack.Push(3);
            stack.Push(1);

            Assert.Equal(1, stack.Peek()._value);
            Assert.Equal(1, stack.Pop()._value);
            Assert.Equal(2, stack.Min());
        }
    }

    // solution #1 - one int temp variable - non eficient
    public class MinStack : Stack<int> 
    {
        private int _min = int.MaxValue;

        public new void Push(int value)
        {
            if (value < _min)
                _min = value;

            base.Push(value);
        }

        public new int Pop()
        {
            int value = base.Pop();
            if (value == _min)
               _min = SearchForMin();

            return value;
        }

        public int Min()
        {
            if (this.ToArray().Length == 0)
                throw new EmptyStackException();

            return _min;
        }

        private int SearchForMin()
        {
            var array = this.ToArray();

            if (array.Length == 0)
                throw new EmptyStackException();

            int min = array[0];

            foreach(var item in array) {
                if (item < min)
                    min = item;
            }

            return min;
        }
    }

    // solution #2 - store min value in every node - O(1) runtime
    public class NodeWithMin 
    {
        public int _value;
        public int _min;

        public NodeWithMin(int value, int min)
        {
            _value = value;
            _min = min;
        }
    }

    public class MinStackNode : Stack<NodeWithMin>
    {
        public void Push(int value)
        {
            int min = Math.Min(value, Min());
            base.Push(new NodeWithMin(value, min));
        }

        public int Min()
        {
            if (this.ToArray().Length == 0)
                return int.MaxValue;

            return base.Peek()._min;
        }
    }

    // solution #3 - store min values in additional array - O(1) runtime, memory eficient


    public class EmptyStackException : Exception 
    {
   
    }
}
