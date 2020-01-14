using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace anagram_polindrom
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("madam", "mmaad", true)]
        [InlineData("madam", "maad", false)]        
        [InlineData("madam", "maada", false)]
        public void AreAnagramTest(string str1, string str2, bool result)
        {
            AreAnagram(str1, str2).Should().Be(result);
        }

        private bool AreAnagram(string str1, string str2)
        {
            if (str1.Length != str2.Length)
                return false;

            var str1Array = str1.ToArray();
            var str2Array = str2.ToArray();

            Array.Sort(str1Array, StringComparer.InvariantCulture);
            Array.Sort(str2Array, StringComparer.InvariantCulture);

            // Console.WriteLine(str1);
            // Console.WriteLine(str2);

            for(int i = 0; i < str1Array.Length; i++)
            {
                if (str1Array[i] != str2Array[i])
                    return false;
            }

            return true;
        }

        [Theory]
        [InlineData("madam", true)]        
        [InlineData("nurses run", true)]   
        [InlineData("nurses ru", false)]
        public void IsPolindromTest(string word, bool result)
        {
            word = word.Replace(" ", string.Empty);
            char[] wordArray = word.ToCharArray();

            IsPolindrom(wordArray).Should().Be(result);
        }

        private bool IsPolindrom(char[] wordArray)
        {
            for(int i = 0; i<wordArray.Length; i++)
            {
                if (wordArray[i] != wordArray[wordArray.Length-1-i])
                    return false;
            }

            return true;
        }

        [Theory]
        [InlineData(new int[] {4,1,5,3,7,2,9,10,6,8})]        
        [InlineData(new int[] {4,1,5,3,7,2,9,10,6,})]
        public void ReverseInPlaceTest(int[] array)
        {
            var origin = array.ToArray();

            ReverseInPlace(array);

            for(int i = 0; i < array.Length; i++)
            {
                array[i].Should().Be(origin[origin.Length-1-i]);
            }

            Console.WriteLine("Origin");
            PrintArray(origin);
            Console.WriteLine("Reversed");
            PrintArray(array);
        }

        private void ReverseInPlace(int[] array)
        {
            for(int i = 0; i < array.Length/2; i++)
            {
                swap(array, i, array.Length-1-i);
            }
        }

        private void swap(int[] array, int index1, int index2)
        {
            var temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        private void PrintArray(int[] array)
        {
            Console.WriteLine("Array: ");
            foreach(var item in array)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}
