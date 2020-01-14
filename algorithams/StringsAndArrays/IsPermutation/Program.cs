using System;

namespace IsPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("abcda");
            Console.WriteLine("aabcd -> true = " + IsPermutation("abcda", "aabcd"));

            Console.WriteLine("abcda");
            Console.WriteLine("aabbc -> false = " + IsPermutation("abcda", "aabbc"));
        }

        static bool IsPermutation(string s1, string s2)
        {
            if(s1 == null || s2 == null)
                return false;

            if(s1.Length != s2.Length)
                return false;

            int[] table = new int[128];

            for(int i = 0; i < s1.Length; i++)
            {
                table[Convert.ToInt32(s1[i])]++;
                table[Convert.ToInt32(s2[i])]--;
            }

            foreach(var letterCount in table)
            {
                if(letterCount != 0)
                    return false;
            }

            return true;
        }
    }
}
