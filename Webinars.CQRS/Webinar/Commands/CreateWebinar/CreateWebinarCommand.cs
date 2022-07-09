using MediatR;
using Webinars.Common;
using Webinars.CQRS.Mapper.Dto;
using Webinars.CQRS.Mapper.Dto.Speaker;

namespace Webinars.CQRS.Webinar.Commands.CreateWebinar
{
    public class CreateWebinarCommand : IRequest<OperationStatusCode>
    {
        public SpeakerIdDto SpeakerId { get; set; }
        public WebinarNameDto WebinarName { get; set; }
        public DescriptionDto Description { get; set; }
        public LinkDto Link { get; set; }
        public ReplayDto Replay { get; set; }
        public CategoryDto Category { get; set; }
    }
}