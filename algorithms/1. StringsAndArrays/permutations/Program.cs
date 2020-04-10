using System;
using System.Collections.Generic;

namespace permutations
{
    class Program
    {
        private static int counter = 0;
        static void Main(string[] args)
        {
            //string str = "abcdefg";
            string str = "abcd";
            //Permutation(str, "");
            var list = Permutation(str);
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Counter: " + counter);
        }

        private static void Permutation(string str, string prefix) // O(n * n!)
        {
            
            if(str.Length == 0)
            {
                counter ++;
                // Print permutation
                Console.WriteLine("Pref: " + prefix + " counter: " + counter);
            }
            else 
            {
                for(int i = 0; i < str.Length; i++)
                {                    
                    string rem = str.Substring(0, i) + str.Substring(i + 1);
                    //Console.WriteLine("Rem: " + rem);
                    Permutation(rem, prefix + str[i]);
                }
            }            
        }

        private static List<string> Permutation(string str) // O(n! * n) // all characters are unique
        {
            var result = new List<string>();
            if (str.Length == 1) 
            {
                result.Add(str);
                return result;
            }

            var rem = str.Substring(0, str.Length - 1);
            var c = str[str.Length-1];

            var list = Permutation(rem);

            foreach(var item in list)
            {
                for(int i = 0; i < str.Length; i++)
                {                   
                    result.Add(item.Insert(i, c.ToString()));
                }
            }

            return result;
        }
    }
}
