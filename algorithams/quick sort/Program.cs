using System;

namespace quick_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 6;
            int[] array = new int[n] { 6,3,10,7,4,5 };

            Console.Write("Unsorted array: ");
            printArray(array);
            quickSort(array, 0, n-1);
            Console.Write("Sorted array: ");
            printArray(array);
        }

        public static int devision(int[] array, int low, int heigh) 
        {
            var pivot = heigh;
            var i = low - 1;

            for(int j = low; j<= heigh; j++)
            {
                if(array[j] < array[pivot])
                {
                    i++;
                    swap(array, j, i);
                }
            }
            
            swap(array, i+1, pivot);

            return i+1;
        }

        public static void quickSort(int[] array, int low, int heigh)
        {        
            if(low < heigh)
            {
                var pivot = devision(array, low, heigh);
                quickSort(array, low, pivot-1);
                quickSort(array, pivot+1, heigh);
            }
        }

        public static void printArray(int[] array) 
        {
            Console.WriteLine();
            foreach(int item in array)
            {
                Console.Write($"{item}, ");
            }            
            Console.WriteLine();
        }

        public static void swap(int[] array, int i, int j)
        {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
