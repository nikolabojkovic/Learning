using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<Person> personFactory =
                Person.Initialize()
                    .WithFirstName("Max")
                    .WithLastName("Planck")
                    .WithPrimaryContact(new EmailAddress("max.planck@my-institute"))
                    .WithAlternateContact(new EmailAddress("max@house-of-plancks"))
                    .AndNoMoreContacts()
                    .Build;

            Console.WriteLine(personFactory());
            Console.ReadLine();
        }
    }
}
