using System.Collections.Generic;
using Webinars.Domain.Ddd;

namespace Webinars.Domain.ValueObjects
{
    public class Phone : ValueObject<Phone>
    {
        public Phone(int phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public int PhoneNumber { get; init; }

        protected override IEnumerable<object> GetAttributesToEqualityCheck()
        {
            yield return PhoneNumber;
        }

        public override string ToString()
        {
            return PhoneNumber.ToString();
        }
    }
}