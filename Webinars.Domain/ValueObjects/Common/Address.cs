using System;
using System.Collections.Generic;
using Webinars.Domain.Ddd;

namespace Webinars.Domain.ValueObjects.Speaker
{
    public class Address : ValueObject<Address>
    {
        public string Street { get; init; }
        public string City { get; init; }
        public string Country { get; init; }
        public string ZipCode { get; init; }
        public string Number { get; init; }
        public Address(string country, string city, string street, string zipCode, string number)
        {
            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentNullException("Street cannot be empty");
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentNullException("City cannot be empty");
            if (string.IsNullOrWhiteSpace(country))
                throw new ArgumentNullException("Country cannot be empty");
            if (string.IsNullOrWhiteSpace(zipCode))
                throw new ArgumentNullException("Zip code cannot be empty");
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentNullException("Number cannot be empty");
            Street = street;
            City = city;
            Country = country;
            ZipCode = zipCode;
            Number = number;
        }

        protected override IEnumerable<object> GetAttributesToEqualityCheck()
        {
            yield return Country;
            yield return City;
            yield return ZipCode;
            yield return Street;
            yield return Number;
        }

        public override string ToString()
        {
            return $"{City} {Street} {Number} \n {ZipCode} {Country}";
        }
    }
}
