using System;
using System.Collections.Generic;
using Webinars.Domain.Ddd;

namespace Webinars.Domain.ValueObjects.Security
{
    public class Password : ValueObject<Password>
    {
        public Password(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException("Password cannot be empty");
            Value = password;
        }

        public string Value { get; init; }

        public static Password Of(string value)
        {
            return new(value);
        }

        public static implicit operator string(Password password)
        {
            return password.Value;
        }

        protected override IEnumerable<object> GetAttributesToEqualityCheck()
        {
            yield return Value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}