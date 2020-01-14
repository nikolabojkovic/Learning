using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    internal class PersonBuilder :
        IFirstNameHolder, ILastNameHolder,
        IPrimaryContactHolder, IAlternateContactHolder,
        IPersonBuilder
    {
        private string FirstName { get; set; }
        private string LastName { get; set; }

        private IList<IContactInfo> Contacts { get; set; } = new List<IContactInfo>();
        private IContactInfo PrimaryContact { get; set; }

        internal PersonBuilder() { }

        public ILastNameHolder WithFirstName(string firstName)
        {

            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentException();
            return new PersonBuilder()
            {
                FirstName = firstName
            };
        }

        public IPrimaryContactHolder WithLastName(string lastName)
        {

            if (string.IsNullOrEmpty(lastName))
                throw new ArgumentException();

            return new PersonBuilder()
            {
                FirstName = this.FirstName,
                LastName = lastName
            };
        }

        public IAlternateContactHolder WithPrimaryContact(IContactInfo contact)
        {

            if (contact == null)
                throw new ArgumentNullException();
            if (this.Contacts.Contains(contact))
                throw new ArgumentException();

            return new PersonBuilder()
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Contacts = new List<IContactInfo>(this.Contacts) { contact },
                PrimaryContact = contact
            };
        }

        public IAlternateContactHolder WithAlternateContact(IContactInfo contact)
        {

            if (contact == null)
                throw new ArgumentNullException();
            if (this.Contacts.Contains(contact))
                throw new ArgumentException();

            return new PersonBuilder()
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Contacts = new List<IContactInfo>(this.Contacts) { contact },
                PrimaryContact = this.PrimaryContact
            };
        }

        public IPersonBuilder AndNoMoreContacts() => this;

        public Person Build()
        {

            Person person = new Person();

            person.FirstName = this.FirstName;
            person.LastName = this.LastName;

            foreach (IContactInfo contact in this.Contacts)
                person.ContactsList.Add(contact);

            person.PrimaryContact = this.PrimaryContact;

            return person;
        }
    }
}
