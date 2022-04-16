using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webinars.Domain.Ddd;

namespace Webinars.Domain.ValueObjects
{
    public class Address : ValueObject<Address>
    {
        public string Street { get; }
        public string City { get; }
        public string Country { get; }
        public string ZipCode { get; }
        public string Number { get; }
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
