using Webinars.Domain.Ddd;
using Webinars.Domain.ValueObjects;
using Webinars.Domain.ValueObjects.Common;
using Webinars.Domain.ValueObjects.Ids;
using Webinars.Domain.ValueObjects.Webinar;

namespace Webinars.Domain.Entities
{
    public class Webinar : Entity<WebinarId>
    {
        public Webinar(WebinarId webinarId, WebinarName webinarName, Speaker speaker, Description description,
            Link link,
            Replay replay, CreatedTime createdTime, Category category)
        {
            Id = webinarId;
            WebinarName = webinarName;
            Speaker = speaker;
            Description = description;
            Link = link;
            Replay = replay;
            CreatedTime = createdTime;
            Category = category;
        }

        public WebinarName WebinarName { get; init; }
        public Speaker Speaker { get; init; }
        public Description Description { get; init; }
        public Link Link { get; init; }
        public Replay Replay { get; init; }
        public CreatedTime CreatedTime { get; init; }
        public Category Category { get; init; }
    }
}