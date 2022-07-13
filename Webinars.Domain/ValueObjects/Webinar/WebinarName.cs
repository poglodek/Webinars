using System;
using System.Collections.Generic;
using Webinars.Domain.Ddd;

namespace Webinars.Domain.ValueObjects.Webinar
{
    public class WebinarName : ValueObject<WebinarName>
    {
        public WebinarName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name cannot be null");
            Name = name;
        }
        
        public string Name { get; init; }

        protected override IEnumerable<object> GetAttributesToEqualityCheck()
        {
            yield return Name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}