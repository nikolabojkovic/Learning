namespace Demo
{
    public interface IFirstNameHolder
    {
        ILastNameHolder WithFirstName(string firstName);
    }

    public interface ILastNameHolder
    {
        IPrimaryContactHolder WithLastName(string lastName);
    }

    public interface IPrimaryContactHolder
    {
        IAlternateContactHolder WithPrimaryContact(IContactInfo contact);
    }

    public interface IAlternateContactHolder
    {
        IAlternateContactHolder WithAlternateContact(IContactInfo contact);
        IPersonBuilder AndNoMoreContacts();
    }

    public interface IPersonBuilder
    {
        Person Build();
    }
}
