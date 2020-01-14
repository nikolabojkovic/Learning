using System;

namespace PolindromPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Solution: 1 - O(n)");
            Console.WriteLine("Tact coa -> " + isPermutationOfAPolindrom("Tact coa"));
            Console.WriteLine("Tact coae -> " + isPermutationOfAPolindrom("Tact coae"));
            Console.WriteLine("Ana voli Milovana -> " + isPermutationOfAPolindrom("Ana voli Milovana"));
            
            Console.WriteLine("Solution: 2 - O(n)");
            Console.WriteLine("Tact coa -> " + isPermutationOfAPolindrom2("Tact coa"));
            Console.WriteLine("Tact coae -> " + isPermutationOfAPolindrom2("Tact coae"));
            Console.WriteLine("Ana voli Milovana -> " + isPermutationOfAPolindrom2("Ana voli Milovana"));
        }

        // Solution 1
        static bool isPermutationOfAPolindrom(string phrase) // O(n)
        {
            int [] table = BuildCharFrequencyTable(phrase.ToLower());
            return HasMaxOneOddChar(table);
        }

        static int [] BuildCharFrequencyTable(string phrase)
        {
            int[] table = new int[Convert.ToInt32('z') - Convert.ToInt32('a') + 1];
            foreach(var c in phrase)
            {
                int cNumber = GetCharNumber(c);
                // Console.Write(" c: " + cNumber + " ");
                if(cNumber != -1)
                {
                    table[cNumber]++;
                }
            }

            return table;
        }

        static int GetCharNumber(char character)
        {
            int a = Convert.ToInt32('a');
            int z = Convert.ToInt32('z');
            int value = Convert.ToInt32(character);

            if(a <= value && value <= z)
                return value - a;

            return -1;
        }

        static bool HasMaxOneOddChar(int[] table)
        {
            bool foundOdd = false;

            foreach(var item in table)
            {
                if(item % 2 == 1)
                {
                    if(foundOdd)
                        return false;

                    foundOdd = true;
                }
            }
            
            return true;
        }

        // Solution: 2
        static bool isPermutationOfAPolindrom2(string phrase) // O(n)
        {
            int[] table = new int[Convert.ToInt32('z') - Convert.ToInt32('a') + 1];

            int oddCharCount = 0;
            int cNumber = 0;

            foreach(char c in phrase.ToLower())
            {
                cNumber = GetCharNumber(c);

                if(cNumber != -1)
                {
                    table[cNumber]++;

                    if(table[cNumber] % 2 == 1)
                        oddCharCount++;
                    else
                        oddCharCount--;
                }
            }

            return oddCharCount <= 1;
        }
    }
}
