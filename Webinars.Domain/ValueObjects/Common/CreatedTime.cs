using System;
using System.Collections.Generic;
using Webinars.Domain.Ddd;

namespace Webinars.Domain.ValueObjects
{
    public class CreatedTime : ValueObject<CreatedTime>
    {
        public CreatedTime(DateTime createdTime)
        {
            CreatedDateTime = createdTime;
        }

        public DateTime CreatedDateTime { get; init; }

        protected override IEnumerable<object> GetAttributesToEqualityCheck()
        {
            yield return CreatedDateTime;
        }

        public override string ToString()
        {
            return CreatedDateTime.ToString("g");
        }
    }
}