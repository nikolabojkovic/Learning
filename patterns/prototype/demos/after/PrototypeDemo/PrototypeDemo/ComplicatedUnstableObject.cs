using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrototypeDemo
{
    public class ComplicatedUnstableObject : ICloneable
    {
        internal ComplicatedUnstableObject(string a, int b, int c, char d, string e)
        {
            
        }

        internal ComplicatedUnstableObject(int ba, int c, char d, string e)
        {

        }

        internal ComplicatedUnstableObject(string a, char da, string e)
        {

        }

        internal ComplicatedUnstableObject(string a, int c, char d, string e, string f)
        {

        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
