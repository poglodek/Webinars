using Webinars.Domain.Ddd;
using Webinars.Domain.ValueObjects;
using Webinars.Domain.ValueObjects.Ids;
using Webinars.Domain.ValueObjects.Security;
using Webinars.Domain.ValueObjects.Speaker;

namespace Webinars.Domain.Entities
{
    public class Speaker : Entity<SpeakerId>
    {
        public Name Name { get; set; }
        public Phone Phone { get; set; }
        public Address Address { get; set; }
        public SocialMedia SocialMedia { get; set; }
        public CreatedTime CreatedTime { get; set; }
        public Password Password { get; set; }

        public Speaker(SpeakerId id, Name name, Phone phone, Address address, SocialMedia socialMedia, CreatedTime createdTime, Password password)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Address = address;
            SocialMedia = socialMedia;
            CreatedTime = createdTime;
            Password = password;
        }
    }
}
