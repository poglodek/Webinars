using System;
using System.Collections.Generic;
using Webinars.Domain.Ddd;

namespace Webinars.Domain.ValueObjects.Common
{
    public class DateTo : ValueObject<CreatedTime>
    {
        public DateTime DateToTime { get; init; }
        public DateTo(DateTime toTime)
        {
            DateToTime = toTime;
        }

        protected override IEnumerable<object> GetAttributesToEqualityCheck()
        {
            yield return DateToTime;
        }

        public override string ToString()
        {
            return DateToTime.ToString("g");
        }
    }
}
