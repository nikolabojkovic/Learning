using System;
using System.Collections.Generic;
using Xunit;

namespace SortStack
{
    public class SortStackTest
    {
        [Theory]
        [InlineData(new int[] { 10, 7, 12, 8, 3, 1 }, new int[] { 1, 3, 7, 8, 10, 12 })]
        [InlineData(new int[] { 1, 3, 7, 8, 10, 12 }, new int[] { 1, 3, 7, 8, 10, 12 })] 
        [InlineData(new int[] { 12, 10, 8, 7, 3, 1 }, new int[] { 1, 3, 7, 8, 10, 12 })]         
        [InlineData(new int[] { 12, 3, 7, 8, 10, 1 }, new int[] { 1, 3, 7, 8, 10, 12 })]
        [InlineData(new int[] {  }, new int[] {  })]
        public void SortStack_SortByFirtAlgorithm(int [] elements, int [] sortedElements)
        {
            // Arrange
            Stack<int> stack = new Stack<int>();
            foreach(int element in elements)
            {
                stack.Push(element);
            }

            // Act
            stack = stack.FirstSort();

            // Assert
            foreach(int expected in sortedElements)
            {
                Assert.Equal(expected, stack.Pop());
            }
        }

        [Theory]
        [InlineData(new int[] { 10, 7, 12, 8, 3, 1 }, new int[] { 1, 3, 7, 8, 10, 12 })]        
        [InlineData(new int[] { 1, 3, 7, 8, 10, 12 }, new int[] { 1, 3, 7, 8, 10, 12 })]   
        [InlineData(new int[] { 12, 10, 8, 7, 3, 1 }, new int[] { 1, 3, 7, 8, 10, 12 })]     
        [InlineData(new int[] { 12, 3, 7, 8, 10, 1 }, new int[] { 1, 3, 7, 8, 10, 12 })]    
        [InlineData(new int[] {  }, new int[] {  })]
        public void SortStack_SortBySecondAlgorithm(int [] elements, int [] sortedElements)
        {
            // Arrange
            Stack<int> stack = new Stack<int>();
            foreach(int element in elements)
            {
                stack.Push(element);
            }

            // Act
            stack = stack.SecondSort();

            // Assert
            foreach(int expected in sortedElements)
            {
                Assert.Equal(expected, stack.Pop());
            }
        }
    }

    public static class StackExtensions
    {
        public static Stack<int> FirstSort(this Stack<int> s)
        {
            Stack<int> t = new Stack<int>();
            int temp = 0;

            while (s.Count > 0)
            {
                temp = s.Pop();
                
                while (t.Count > 0 && t.Peek() > temp)
                {
                    s.Push(t.Pop());
                }

                t.Push(temp);
            }

            // transfere back to s stack
            while(t.Count > 0)
            {
                s.Push(t.Pop());
            }

            return s;
        }

        public static Stack<int> SecondSort(this Stack<int> s)
        {
            Stack<int> t = new Stack<int>();
            int temp = 0;

            while (s.Count > 0)
            {
                // (step 1) in case every next element is smaller then previous one, just move element to new stack
                if (t.Count == 0 || s.Peek() < t.Peek())
                {
                    t.Push(s.Pop());
                }
                // (step 2) in case rearrangment is needed
                // store greater element in temp,
                // transfere all smaller elements in first stack,
                // place element from temp into new stack at its appropriate place
                // and then continue with step 1 untill all elements are sorted
                else 
                {
                    temp = s.Pop();
                    
                    while (t.Count > 0 && t.Peek() < temp)
                    {
                        s.Push(t.Pop());
                    }

                    t.Push(temp);
                }
            }

            return t;
        }
    }
}
