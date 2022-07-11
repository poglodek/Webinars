using Webinars.CQRS.Mapper.Dto;
using Webinars.CQRS.Mapper.Dto.Speaker;
using Webinars.CQRS.Webinar.Commands.CreateWebinar;
using Webinars.Domain.ValueObjects.Ids;
using Webinars.Domain.ValueObjects.Webinar;

namespace Webinars.Common.Builders
{
    public class CreateWebinarCommandBuilder
    {
        private SpeakerIdDto SpeakerId { get; set; }
        private WebinarNameDto WebinarName { get; set; }
        private DescriptionDto Description { get; set; }
        private LinkDto Link { get; set; }
        private ReplayDto Replay { get; set; }
        private CategoryDto Category { get; set; }

        public CreateWebinarCommandBuilder WithSpeakerId(int id)
        {
            SpeakerId = new SpeakerIdDto
            {
                Id = id
            };
            return this;
        }
        public CreateWebinarCommandBuilder WithWebinarName(string name)
        {
            WebinarName = new WebinarNameDto
            {
                Name = name
            };
            return this;
        }
        public CreateWebinarCommandBuilder WithDescription(string text)
        {
            Description = new DescriptionDto()
            {
                DescriptionText = text
            };
            return this;
        }
        public CreateWebinarCommandBuilder WithLink(string yt, string wb)
        {
            Link = new LinkDto()
            {
                Youtube = yt,
                Website = wb
            };
            return this;
        }
        public CreateWebinarCommandBuilder WithReplay(string yt, string wb)
        {
            Replay = new ReplayDto()
            {
                Youtube = yt,
                Website = wb
            };
            return this;
        }
        public CreateWebinarCommandBuilder WithCategory(CatergoryStatus status)
        {
            Category = new CategoryDto()
            {
                Status = status
            };
            return this;
        }
        public CreateWebinarCommand Build()
        {
            return new CreateWebinarCommand
            {
                Category = Category,
                Description = Description,
                Link = Link,
                WebinarName = WebinarName,
                Replay = Replay,
                SpeakerId = SpeakerId
                
            };
        }
    }
}