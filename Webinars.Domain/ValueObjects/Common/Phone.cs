﻿using System.Collections.Generic;
using Webinars.Domain.Ddd;

namespace Webinars.Domain.ValueObjects
{
    public class Phone : ValueObject<Phone>
    {
        public int PhoneNumber { get; }
        public Phone(int phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        protected override IEnumerable<object> GetAttributesToEqualityCheck()
        {
            yield return PhoneNumber;
        }

        public override string ToString()
        {
            return PhoneNumber.ToString();
        }
    }
}