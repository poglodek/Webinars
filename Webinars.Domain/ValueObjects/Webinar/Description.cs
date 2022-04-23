﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webinars.Domain.Ddd;

namespace Webinars.Domain.ValueObjects.Webinar
{
    public class Description : ValueObject<Description>
    {
        public string DescriptionText { get; set; }

        public Description(string text)
        {
            if(string.IsNullOrWhiteSpace(text))
                throw new ArgumentNullException("text cannot be empty");
            if (text.Length > 5000)
                throw new ArgumentException("text cannot be longer than 5000 chars");
            DescriptionText = text;
        }
        protected override IEnumerable<object> GetAttributesToEqualityCheck()
        {
            yield return DescriptionText;
        }

        public override string ToString()
        {
            return DescriptionText;
        }
    }
}
