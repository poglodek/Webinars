using System;
using System.Collections.Generic;
using Webinars.Domain.Ddd;

namespace Webinars.Domain.ValueObjects.Security
{
    public class Password : ValueObject<Password>
    {
        public string Value { get; init; }
        public Password(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException("Password cannot be empty");
            Value = password;
        }
        public static Password Of(string value) => new(value);
        public static implicit operator string(Password password) => password.Value;
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
