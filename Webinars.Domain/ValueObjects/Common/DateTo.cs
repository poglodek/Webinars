using System;
using System.Collections.Generic;
using Webinars.Domain.Ddd;

namespace Webinars.Domain.ValueObjects.Common
{
    public class DateTo : ValueObject<CreatedTime>
    {
        public DateTo(DateTime toTime)
        {
            DateToTime = toTime;
        }

        public DateTime DateToTime { get; init; }

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