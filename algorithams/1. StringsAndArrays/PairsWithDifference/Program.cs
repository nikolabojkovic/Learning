using System;
using System.Diagnostics;
using System.Threading;
using System.Collections;
using System.Linq;

namespace PairsWithDifference
{
    class Program
    {
        // NOTE: Time will increase with complexity 
        //       Case 1 (n^2) is the fastest case for simple example,
        //       but will slow down faster then other cases when array increases in size
        // TASK: Count all pairs (with difference of k) in the array
        static void Main(string[] args)
        {
            Stopwatch _timer = new Stopwatch();
            int k = 2; 
            int counter = 0;
            Random rnd = new Random();

            for(int iter = 0; iter < 10; iter++)
            {
                Console.WriteLine($"---------- {iter + 1} iteration -------------");
                int[] array = Enumerable.Range(0, 300*(iter+1)).ToArray();

                // Shuffle array
                Console.WriteLine("Array length: " + array.Length);
                for(int i = 0; i < array.Length; i++)
                {
                    int randomIndex = rnd.Next(array.Length);
                    int temp = array[randomIndex];
                    array[randomIndex] = array[i];
                    array[i] = temp;
                }

                counter = 0;         
                // sorted { 1, 2, 3, 5, 7, 9, 12 }
                // paris (1, 3), (3, 5), (7, 9) (9, 12)

                // Case 1: Brute force - O(n^2)
                // linear search (sequential search)
                _timer.Start();
                for(int i = 0; i < array.Length; i++)
                {
                    for(int j = 0; j < array.Length; j++)
                    {
                        if (array[j] == array[i] + k)
                            counter++;
                    }
                }
                _timer.Stop();
                Console.WriteLine("(Case 1 - O(n2))      Counter: " + counter + "    Time : " + _timer.Elapsed.TotalMilliseconds * 1000000 + "(ns)      " +  _timer.Elapsed.TotalMilliseconds + "(ms)");
                _timer.Reset();

                // Case 2: Sort and Binary search - O(n log n)
                counter = 0;
                _timer.Start();
                
                Array.Sort(array);

                foreach(var item in array)
                {
                    var result = BinarySearch(array, 0, array.Length - 1, item + k);
                    // var result = Array.BinarySearch(array, item + k);
                    if (result != -1)
                        counter++;
                }
                
                _timer.Stop();
                Console.WriteLine("(Case 2 - O(n log n)) Counter: " + counter + "    Time : " + _timer.Elapsed.TotalMilliseconds * 1000000 + "(ns)      " +  _timer.Elapsed.TotalMilliseconds + "(ms)");
                _timer.Reset();

                // Case 3: HasTable - O(n)
                counter = 0;
                var table = new Hashtable(7 * (iter + 1));

                for(int i = 0; i < array.Length; i++)
                {
                    table.Add(array[i], array[i]);
                }

                _timer.Start();
                
                foreach(var item in array)
                {
                    if (table.ContainsKey(item + k))
                        counter++;
                }
                
                _timer.Stop();
                Console.WriteLine("(Case 3 - O(n))       Counter: " + counter + "    Time : " + _timer.Elapsed.TotalMilliseconds * 1000000 + "(ns)      " +  _timer.Elapsed.TotalMilliseconds + "(ms)");
                _timer.Reset();
            }
        }

        private static int BinarySearch(int[] array, int startIndex, int endIndex, int value)
        {
            var middle = (startIndex + endIndex) / 2;
            var result = -1;

            if (array[middle] == value)
                return middle;

            if (startIndex == endIndex && array[middle] != value)
                return -1;

            if (array[middle] > value)
                result = BinarySearch(array, startIndex, middle - 1, value);

            if (array[middle] < value)
                result = BinarySearch(array, middle + 1, endIndex, value);

            return result;
        }
    }
}
