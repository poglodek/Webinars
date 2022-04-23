using Webinars.Domain.Ddd;
using Webinars.Domain.ValueObjects;
using Webinars.Domain.ValueObjects.Ids;
using Webinars.Domain.ValueObjects.Security;
using Webinars.Domain.ValueObjects.Speaker;

namespace Webinars.Domain.Entities
{
    public class Speaker : Entity<SpeakerId>
    {
        public SpeakerName SpeakerName { get; init; }
        public Phone Phone { get; init; }
        public Address Address { get; init; }
        public SocialMedia SocialMedia { get; init; }
        public CreatedTime CreatedTime { get; init; }
        public Password Password { get; init; }

        public Speaker(SpeakerId id, SpeakerName speakerName, Phone phone, Address address, SocialMedia socialMedia, CreatedTime createdTime, Password password) : base()
        {
            Id = id;
            SpeakerName = speakerName;
            Phone = phone;
            Address = address;
            SocialMedia = socialMedia;
            CreatedTime = createdTime;
            Password = password;
        }
    }
}
