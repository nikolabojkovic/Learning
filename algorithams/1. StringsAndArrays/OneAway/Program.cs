using System;
using System.Collections.Generic;
using System.Collections;

namespace OneAway
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Are one away: pale, ple -> " + AreOneAway("pale", "ple"));
            Console.WriteLine("Are one away: pale, pel -> " + AreOneAway("pale", "pel"));
            Console.WriteLine("Are one away: pales, pale -> " + AreOneAway("pales", "pale"));
            Console.WriteLine("Are one away: pale, bale -> " + AreOneAway("pale", "bale"));
            Console.WriteLine("Are one away: pale, bae -> " + AreOneAway("pale", "bae"));            
            Console.WriteLine("Are one away: pape, bape -> " + AreOneAway("pape", "bape"));
            Console.WriteLine("Are one away: pape, ple -> " + AreOneAway("pape", "ple"));            
            Console.WriteLine("Are one away: pale, ple -> " + AreOneAway("pale", "pale"));          
            Console.WriteLine("Are one away: pple, ple -> " + AreOneAway("pple", "ple"));         
            Console.WriteLine("Are one away: aaaap, aapp -> " + AreOneAway("aaaap", "aapp"));    
            Console.WriteLine("Are one away: aaap, aapp -> " + AreOneAway("aaap", "aapp"));
        }

        static bool AreOneAway(string first, string second)
        {
            if(first.Length == second.Length)
                return AreOneEditReplace(first, second);
            if(first.Length + 1 == second.Length)
                return AreOneEditInsert(first, second);
            if(first.Length - 1 == second.Length)
                return AreOneEditInsert(second, first);

            return false;
        }

        static bool AreOneEditReplace(string first, string second)
        {
            bool foundDifferece = false;

            for(int i = 0; i < first.Length; i++)
            {
                if(first[i] != second[i])
                {
                    if(foundDifferece)
                        return false;
                    
                    foundDifferece = true;
                }
            }

            return true;
        }

        static bool AreOneEditInsert(string shorter, string longer)
        {
            int indexL = 0;
            int indexS = 0;

            while(indexL < longer.Length && indexS < shorter.Length)
            {
                if(longer[indexL] != shorter[indexS])
                {
                    if(indexL != indexS)
                        return false;
                    
                    indexL++;
                }
                else 
                {
                    indexL++;
                    indexS++;
                }
            }

            return true;
        }
    }
}
