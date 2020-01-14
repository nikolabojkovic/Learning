using System;
using System.Collections.Generic;

namespace Bridge_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Manuscript> documents = new List<Manuscript>();
            var formatter = new FancyFormatter();

            var faq = new FAQ(formatter);
            faq.Title = "The Bridge Pattern FAQ";
            faq.Questions.Add("What is it?", "A design pattern");
            faq.Questions.Add("When do we use it?", "When you need to separate an abstraction from an implementation.");
            documents.Add(faq);

            var book = new Book(formatter)
                       {
                           Title = "Lots of Patterns",
                           Author = "John Sonmez",
                           Text = "Blah blah blah..."
                       };
            documents.Add(book);

            var paper = new TermPaper(formatter)
                        {
                            Class = "Design Patterns",
                            Student = "Joe N00b",
                            Text = "Blah blah blah...",
                            References = "GOF"
                        };
            documents.Add(paper);

            foreach(var doc in documents)
            {
                doc.Print();
            }

            Console.ReadKey();
        }
    }
}
