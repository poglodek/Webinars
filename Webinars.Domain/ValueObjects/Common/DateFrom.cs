using System;
using System.Collections.Generic;
using Webinars.Domain.Ddd;

namespace Webinars.Domain.ValueObjects.Common
{
    public class DateFrom : ValueObject<CreatedTime>
    {
        public DateTime DateFromTime { get; init; }
        public DateFrom(DateTime fromTime)
        {
            DateFromTime = fromTime;
        }

        protected override IEnumerable<object> GetAttributesToEqualityCheck()
        {
            yield return DateFromTime;
        }

        public override string ToString()
        {
            return DateFromTime.ToString("g");
        }
    }
}
