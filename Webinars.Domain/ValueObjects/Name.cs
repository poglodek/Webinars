using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webinars.Domain.Ddd;

namespace Webinars.Domain.ValueObjects
{
    public class Name : ValueObject<Name>
    {
        public string FirstName { get; }
        public string LastName { get; }

        public Name(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name cannot be empty");
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name cannot be empty");
            FirstName = firstName;
            LastName = lastName;
        }
        protected override IEnumerable<object> GetAttributesToEqualityCheck()
        {
            yield return FirstName;
            yield return LastName;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
