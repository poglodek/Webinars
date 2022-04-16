using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webinars.Domain.Ddd;

namespace Webinars.Domain.ValueObjects.Security
{
    public class Password : ValueObject<Password>
    {
        public Password(string password)
        {
            if(string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException("Password cannot be empty");
            Value = password;
        }
        public string Value { get; }
        public static Password Of(string value) => new (value);
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
