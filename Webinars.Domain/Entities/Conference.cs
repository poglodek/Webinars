using System;
using System.Collections.Generic;
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
        public Conference(ConferenceId conferenceId, Name name, DateFrom dateFrom, DateTo dateTo, Address address,
            CreatedTime createdTime, Leader leader, Category category, List<Webinar> webinars)
        {
            if (dateFrom.DateFromTime > dateTo.DateToTime)
                throw new ArgumentException("Start date time cannot be later than end date time");
            Id = conferenceId;
            Name = name;
            DateFrom = dateFrom;
            DateTo = dateTo;
            Address = address;
            CreatedTime = createdTime;
            Leader = leader;
            Category = category;
            Webinars = webinars;
        }

        public Name Name { get; set; }
        public DateFrom DateFrom { get; set; }
        public DateTo DateTo { get; set; }
        public Address Address { get; set; }
        public CreatedTime CreatedTime { get; set; }
        public Leader Leader { get; set; }
        public Category Category { get; set; }
        public List<Webinar> Webinars { get; set; }

        public void AddWebinar(Webinar webinar)
        {
            if (Webinars.Contains(webinar))
                return;
            Webinars.Add(webinar);
        }

        public void RemoveWebinar(Webinar webinar)
        {
            if (!Webinars.Contains(webinar))
                return;
            Webinars.Remove(webinar);
        }

        public void ChangeDate(DateTime startTime, DateTime endDateTime)
        {
            DateFrom = new DateFrom(startTime);
            DateTo = new DateTo(endDateTime);
        }
    }
}