using System;

namespace URLify
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] str = new char[17] {'M', 'r', ' ', 'J', 'o', 'h', 'n', ' ', 'S', 'm', 'i', 't', 'h', ' ', ' ', ' ', ' '};
           // char[] str = new char[14] {'M', 'r', ' ', 'J', 'o', 'h', 'n', ' ', 'S', 'm', 'i', 't', 'h', ' '};

            Console.WriteLine(str);

            replaceSpaces(str, 13);

            Console.WriteLine(str);
        }

        public static void replaceSpaces(char[] str, int trueLenght)
        {            
            int additionalSpaces = 0;
            int spaceCount = 0;
            int index = 0;

            for(int i = 0; i < trueLenght; i++)
            {
                if(str[i] == ' ')
                    spaceCount++;
            }

            additionalSpaces = spaceCount * 2;

            if (str.Length < trueLenght + additionalSpaces)
                throw new IndexOutOfRangeException("Not enough space");

            index =  trueLenght + additionalSpaces;

            for(int i = trueLenght - 1; i >= 0; i--)
            {
                if(str[i] == ' ')
                {
                    str[index - 1] = '0';
                    str[index - 2] = '2';
                    str[index - 3] = '%';
                    index = index - 3;
                }
                else 
                {
                    str[index - 1] = str[i];
                    index--;
                }
            }
        }
    }
}
