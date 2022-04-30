using Webinars.Domain.Ddd;
using Webinars.Domain.ValueObjects;
using Webinars.Domain.ValueObjects.Ids;
using Webinars.Domain.ValueObjects.Security;
using Webinars.Domain.ValueObjects.Speaker;

namespace Webinars.Domain.Entities
{
    public class Leader : Entity<LeaderId>
    {
        public Name Name { get; set; }
        public Email Email { get; set; }
        public Phone Phone { get; set; }
        public Address Address { get; set; }
        public CreatedTime CreatedTime { get; set; }
        public SocialMedia SocialMedia { get; set; }
        public Password Password { get; set; }
        public Leader(LeaderId leaderId, Name name, Email email, Phone phone, Address address, CreatedTime createdTime, SocialMedia socialMedia, Password password)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
            CreatedTime = createdTime;
            SocialMedia = socialMedia;
            Password = password;
            Id = leaderId;
        }
    }
}
