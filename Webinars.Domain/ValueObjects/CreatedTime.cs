using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Webinars.Domain.Ddd;

namespace Webinars.Domain.ValueObjects
{
    public class CreatedTime : ValueObject<CreatedTime>
    {
        public DateTime CreatedDateTime { get; }
        public CreatedTime(DateTime createdTime)
        {
            CreatedDateTime = createdTime;
        }
        
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
