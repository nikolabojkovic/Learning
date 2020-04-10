using System;

namespace IsUnique
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("IsUnique should be true -> " + IsUnique("abcdefg"));
            Console.WriteLine("IsUnique should be false -> " + IsUnique("aabcdefg"));

            Console.WriteLine("IsUniqueOptimizedRuntime should be true -> " + IsUniqueOptimizedRuntime("abcdefg"));
            Console.WriteLine("IsUniqueOptimizedRuntime should be false -> " + IsUniqueOptimizedRuntime("abcadefg"));

            Console.WriteLine("IsUniqueOptimizedBottleck should be true -> " + IsUniqueOptimizedBottleck("abcdefg"));
            Console.WriteLine("IsUniqueOptimizedBottleck should be false -> " + IsUniqueOptimizedBottleck("abcadefg"));

            Console.WriteLine("IsUniqueOptimizedDuplicatedWork should be true -> " + IsUniqueOptimizedDuplicatedWork("abcdefg"));
            Console.WriteLine("IsUniqueOptimizedDuplicatedWork should be false -> " + IsUniqueOptimizedDuplicatedWork("abcadefg"));

        }

        static bool IsUnique(string s) // Brute force O(n^2)
        {
            if(string.IsNullOrEmpty(s)) return false;
            if(s.Length > 256) return false;

            for(int i = 0; i < s.Length; i++)
            {
                for(int j = i+1; j < s.Length; j++)
                {
                    if(s[i] == s[j])
                        return false;
                }
            }

            return true;
        }

        static bool IsUniqueOptimizedRuntime(string s) // Optimized runtime force O(n log n)
        {
            if(string.IsNullOrEmpty(s)) return false;
            if(s.Length > 256) return false;

            var array = s.ToCharArray();
            Array.Sort(array); // quick sort - no aditional space // O(n log n)
            s = new string(array);

            for(int i = 1; i < s.Length; i++)
            {
                if(s[i] == s[i-1])
                    return false;
            }

            return true;
        }

          
        static bool IsUniqueOptimizedBottleck(string s) // Optimized bottleck O(n)
        {
            if(string.IsNullOrEmpty(s)) return false;
            if(s.Length > 256) return false;

            int[] table = new int[256];

            foreach(var c in s)
            {
                table[Convert.ToInt32(c)]++;
            }

            foreach(var item in table)
            {
                if(item > 1)
                    return false;
            }

            return true;
        }

        static bool IsUniqueOptimizedDuplicatedWork(string s) // Optimized dupblicated work O(n)
        {
            if(string.IsNullOrEmpty(s)) return false;
            if(s.Length > 256) return false;

            bool[] table = new bool[256];

            for(int i = 0; i < s.Length; i++)
            {
                if(table[Convert.ToInt32(s[i])])
                    return false;
                
                table[Convert.ToInt32(s[i])] = true;
            }            

            return true;
        }
    }
}
