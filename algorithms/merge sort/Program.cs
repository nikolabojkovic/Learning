using System;
using System.Linq;

namespace merge_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 10;
            int[] array = new int[n] { 5,6,3,4,7,1,9,2,10,8 };
            //Print(array);

            array = Sort(array);

            Console.Write("Sorted: ");
            Print(array, ' ');
        }

        public static int[] Sort(int[] array)
        {
            Print(array,'-');
            if(array.Count() <= 1)
                return array;
                
            var middle = array.Count() / 2;

            var left = new int[middle];
            var right = new int[array.Count()-middle];

            for(int i = 0; i< middle; i++)
                left[i] = array[i];

            for(int i = middle; i< array.Count(); i++)
                right[i-middle] = array[i];

            left = Sort(left);
            right = Sort(right);

            return Merge(left,right);
        }

        private static int[] Merge(int[] left, int[] right)
        {
            var result = new int[left.Count() + right.Count()];

            var leftIndex = 0;
            var rightIndex = 0;
            var index = 0;

            while(leftIndex < left.Count() && rightIndex < right.Count())
            {
                if (left[leftIndex] > right[rightIndex])
                {
                    result[index] = right[rightIndex];
                    rightIndex++;
                }
                else
                {
                    result[index] = left[leftIndex];
                    leftIndex++;
                }

                index++;
            }

            while(leftIndex < left.Count())
            {
                result[index++] = left[leftIndex];
                leftIndex++;
            }

            while(rightIndex < right.Count())
            {
                result[index++] = right[rightIndex];
                rightIndex++;
            }

            Print(result, '+');
            return result;
        }

        public static void Print(int[] array, char sign)
        {
            foreach(var item in array)
            {
                Console.Write($"{sign}{item},");
            }

            Console.WriteLine();
        }
    }
}
