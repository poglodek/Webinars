using System;
using System.Collections.Generic;
using Webinars.Domain.Ddd;

namespace Webinars.Domain.ValueObjects.Common
{
    public class DateFrom : ValueObject<CreatedTime>
    {
        public DateFrom(DateTime fromTime)
        {
            DateFromTime = fromTime;
        }

        public DateTime DateFromTime { get; init; }

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