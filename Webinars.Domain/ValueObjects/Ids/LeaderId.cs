﻿using System.Collections.Generic;
using Webinars.Domain.Ddd;

namespace Webinars.Domain.ValueObjects.Ids
{
    public class LeaderId : ValueObject<LeaderId>
    {
        public int Id { get; set; }
        protected override IEnumerable<object> GetAttributesToEqualityCheck()
        {
            yield return Id;
        }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
