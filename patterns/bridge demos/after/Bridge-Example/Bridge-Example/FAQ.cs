using System;
using System.Collections.Generic;

namespace Bridge_Example
{
    public class FAQ : Manuscript
    {
        public string Title { get; set; }
        public Dictionary<string, string> Questions { get; set; }

        public FAQ(IFormatter formatter) : base(formatter)
        {
            Questions = new Dictionary<string, string>();
        }

        public override void Print()
        {
            Console.WriteLine(formatter.Format("Title", Title));
            foreach(var question in Questions)
            {
                Console.WriteLine(formatter.Format("   Question", question.Key));
                Console.WriteLine(formatter.Format("   Answer", question.Value));
            }
            Console.WriteLine();
        }
    }
}
