using System;

namespace Demo
{
    class EmailAddress : IContactInfo
    {

        private string Address { get; }

        public EmailAddress(string address)
        {
            if (string.IsNullOrEmpty(address))
                throw new ArgumentException();
            this.Address = address;
        }

        public override bool Equals(object obj)
        {
            EmailAddress other = obj as EmailAddress;
            return other != null && this.Address.ToLower() == other.Address.ToLower();
        }

        public override int GetHashCode() =>
            this.Address.ToLower().GetHashCode();

        public override string ToString() => this.Address;

    }
}
