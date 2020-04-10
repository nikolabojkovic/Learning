using System;
using System.Text;

namespace StringComperisson
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("compress1");
            Console.WriteLine("aabcccccaa -> " + Compress("aabcccccaa"));
            Console.WriteLine("aabcd -> " + Compress("aabcd"));
            Console.WriteLine("aaaabbbcd -> " + Compress("aaaabbbcd"));            
            Console.WriteLine(" -> " + Compress(""));
            Console.WriteLine("abcd -> " + Compress("abcd")); 

            Console.WriteLine("compress2");
            Console.WriteLine("aabcccccaa -> " + Compress2("aabcccccaa"));
            Console.WriteLine("aabcd -> " + Compress2("aabcd"));
            Console.WriteLine("aaaabbbcd -> " + Compress2("aaaabbbcd"));            
            Console.WriteLine(" -> " + Compress2(""));
            Console.WriteLine("abcd -> " + Compress2("abcd"));  

            Console.WriteLine("compress3");
            Console.WriteLine("aabcccccaa -> " + Compress3("aabcccccaa"));
            Console.WriteLine("aabcd -> " + Compress3("aabcd"));
            Console.WriteLine("aaaabbbcd -> " + Compress3("aaaabbbcd"));            
            Console.WriteLine(" -> " + Compress3(""));
            Console.WriteLine("abcd -> " + Compress3("abcd"));  
        }

        static string Compress(string s) // O(s * k^2) because of string concatanation
        {
            if (string.IsNullOrEmpty(s))
                return s;
                
            char character = s[0];
            int conter = 0;
            string compressed = string.Empty;

            foreach(var c in s)
            {
                if(c == character)
                    conter++;
                else
                {
                    compressed += $"{character}{conter}";
                    conter = 1;
                    character = c;
                }
            }

            compressed += $"{character}{conter}";

            if(compressed.Length < s.Length)
                return compressed;

            return s;
        }

        static string Compress2(string s) // O(n)
        {
            int finalLength = CountCompressionSize(s);
            if(finalLength >= s.Length)
                return s;

            StringBuilder builder = new StringBuilder(finalLength);
            int counter = 0;

            for(int i = 0; i < s.Length; i++)
            {
                counter++;

                if((i + 1 >= s.Length) || s[i] != s[i + 1])
                {
                    builder.Append(s[i]);
                    builder.Append(counter);
                    counter = 0;
                }
            }

            return builder.Length < s.Length ? builder.ToString() : s;
        }

        static int CountCompressionSize(string s)
        {
            int compressionCount = 0;
            int counter = 0;

            
            for(int i = 0; i < s.Length; i++)
            {
                counter++;

                if((i + 1 >= s.Length) || s[i] != s[i + 1])
                {
                    compressionCount += 1 + counter.ToString().Length;
                    counter = 0;
                }
            }

            return compressionCount;
        }

        static string Compress3(string str)
        {
            if (str == null)
                return str;

            string compressed = string.Empty;
            int counter = 1;

            for (int i = 1; i < str.Length; i++)
            {
                if(str[i-1] == str[i])
                    counter++;

                if(str[i-1] != str[i])
                {
                    compressed += str[i-1].ToString() + counter;
                    counter = 1;
                }

                if(str.Length - 1 == i)
                    compressed += str[i].ToString() + counter;
            } 

            if (str.Length <= compressed.Length)
                return str;

            return compressed;
        }
    }
}
