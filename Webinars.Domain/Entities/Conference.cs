using Webinars.Domain.Ddd;
using Webinars.Domain.ValueObjects;
using Webinars.Domain.ValueObjects.Common;
using Webinars.Domain.ValueObjects.Ids;
using Webinars.Domain.ValueObjects.Speaker;
using Webinars.Domain.ValueObjects.Webinar;

namespace Webinars.Domain.Entities
{
    public class Conference : Entity<ConferenceId>
    {
        public Name Name { get; set; }
        public DateFrom DateFrom { get; set; }
        public DateTo DateTo { get; set; }
        public Address Address { get; set; }
        public CreatedTime CreatedTime { get; set; }
        public Leader Leader { get; set; }
        public Category Category { get; set; }

        public Conference(ConferenceId conferenceId,Name name, DateFrom dateFrom, DateTo dateTo, Address address, CreatedTime createdTime, Leader leader, Category category)
        {
            Id = conferenceId;
            Name = name;
            DateFrom = dateFrom;
            DateTo = dateTo;
            Address = address;
            CreatedTime = createdTime;
            Leader = leader;
            Category = category;
        }
    }
}
