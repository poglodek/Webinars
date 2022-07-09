using System;
using System.Collections.Generic;
using Webinars.Domain.Ddd;

namespace Webinars.Domain.ValueObjects
{
    public class Email : ValueObject<Email>
    {
        public Email(string emailAddress)
        {
            if (string.IsNullOrWhiteSpace(emailAddress))
                throw new ArgumentException("Email cannot be empty.");
            EmailAddress = emailAddress;
        }

        public string EmailAddress { get; init; }

        protected override IEnumerable<object> GetAttributesToEqualityCheck()
        {
            yield return EmailAddress;
        }

        public override string ToString()
        {
            return EmailAddress;
        }
    }
}