﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webinars.Domain.Ddd;

namespace Webinars.Domain.ValueObjects
{
    public class Email : ValueObject<Email>
    {
        public string EmailAddress { get; }

        public Email(string emailAddress)
        {
            if (string.IsNullOrWhiteSpace(emailAddress))
                throw new ArgumentException("Email cannot be empty.");
            EmailAddress = emailAddress;
        }
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
