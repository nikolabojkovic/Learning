using System;
using System.Collections.Generic;
using Xunit;

namespace QueueViaStacks
{
    public class UnitTest1
    {
        [Fact]
        public void Dequeue_ShouldReturnCorrectElement()
        {
            // Arrange
            var queue = new QueueViaStacks<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            // Act
            var expected = queue.Dequeue();
            var secondExpected = queue.Dequeue();

            // Assert
            Assert.Equal(1, expected);
            Assert.Equal(2, secondExpected);
        }

        [Fact]
        public void Enqueue_ShouldNotInteraptSecondStack()
        {
            // Arrange
            var queue = new QueueViaStacks<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Dequeue();            
            queue.Enqueue(4);            
            queue.Enqueue(5);

            // Act
            var expected = queue.Dequeue();
            var secondExpected = queue.Dequeue();

            // Assert
            Assert.Equal(2, expected);
            Assert.Equal(3, secondExpected);
        }

        [Fact]
        public void GetQueueCount_ShouldSizeOfQueue()
        {
            // Arrange
            var queue = new QueueViaStacks<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Dequeue();            
            queue.Enqueue(4);            
            queue.Enqueue(5);

            // Act
            var expected = queue.Count();

            // Assert
            Assert.Equal(4, expected);
        }

        [Fact]
        public void Dequeue_ShouldThrowEmptyQueueException()
        {
            // Arrange
            var queue = new QueueViaStacks<int>();

            // Assert
            Assert.Throws<EmptyQueueException>(() => queue.Dequeue());
        }
    }

    public class QueueViaStacks<T>
    {
        private Stack<T> _stackInput;
        private Stack<T> _stackOutput;

        public QueueViaStacks()
        {
            _stackInput = new Stack<T>();
            _stackOutput = new Stack<T>();
        }

        public void Enqueue(T value)
        {
            _stackInput.Push(value);
        }

        public T Dequeue()
        {
            TrafereStaks();

            if (_stackOutput.IsEmpty())
                throw new EmptyQueueException();

            return _stackOutput.Pop();
        }

        public T Peek()
        {
            TrafereStaks();

            if (_stackOutput.IsEmpty())
                throw new EmptyQueueException();

            return _stackOutput.Peek();
        }

        private void TrafereStaks()
        {
            if (!_stackOutput.IsEmpty())
                return;

            while(!_stackInput.IsEmpty())
            {
                _stackOutput.Push(_stackInput.Pop());
            }
        }

        public int Count() => _stackInput.Count + _stackOutput.Count;
    }

    public class EmptyQueueException : Exception {}

    public static class Extensions
    {
        public static bool IsEmpty<T>(this Stack<T> s) => s.Count == 0;
    }
}
