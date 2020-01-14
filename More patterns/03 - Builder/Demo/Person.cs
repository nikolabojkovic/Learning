using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public class Person
    {
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public IEnumerable<IContactInfo> Contacts => this.ContactsList;
        public IContactInfo PrimaryContact { get; internal set; }
        internal IList<IContactInfo> ContactsList { get; } = new List<IContactInfo>();

        internal Person() { }

        public static IFirstNameHolder Initialize() => new PersonBuilder();

        public override string ToString() =>
                $"{this.FirstName} {this.LastName} [{this.ContactsToString()}]";

        private string ContactsToString() =>
            string.Join(", ", this.EachContactAsString().ToArray());

        private IEnumerable<string> EachContactAsString() =>
            this.Contacts.Select(contact => this.ContactAsString(contact));

        private string ContactAsString(IContactInfo contact) =>
            $"{this.ContactMark(contact)}{contact.ToString()}";

        private string ContactMark(IContactInfo contact) =>
            this.PrimaryContact.Equals(contact) ? "*" : string.Empty;

    }
}
