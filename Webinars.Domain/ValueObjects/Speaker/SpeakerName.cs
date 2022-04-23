using System;
using System.Collections.Generic;
using Webinars.Domain.Ddd;

namespace Webinars.Domain.ValueObjects
{
    public class SpeakerName : ValueObject<SpeakerName>
    {
        public string FirstName { get; }
        public string LastName { get; }

        public SpeakerName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First speakerName cannot be empty");
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last speakerName cannot be empty");
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
