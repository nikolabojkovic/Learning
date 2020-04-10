using System;

namespace PermutationsOfSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "cbabadcbbabbcbabaabccbabc";
            string pattern = "abbc";

            Console.WriteLine("Indexes: { " + SearchPermutationsWithSort(text, pattern) + " }");
        }

        public static string SearchPermutationsWithSort(string text, string pattern)
        {
            string indexes = string.Empty;
            int b = text.Length;
            int s = pattern.Length;
            var pcArray = pattern.ToCharArray();
            Array.Sort(pcArray); // O(s log s)
            pattern = new string(pcArray);

            for(int i = 0; i < b && i + s <= b; i++) // O(b)
            {
                var cArray = text.Substring(i, s).ToCharArray();
                Array.Sort(cArray); // O(s log s)
                var sortedWindow = new string(cArray);

                if (sortedWindow == pattern)
                    indexes = indexes + i + ", ";
            }

            // O(s log s + b x s log s)
            return indexes;
        }
    }
}
