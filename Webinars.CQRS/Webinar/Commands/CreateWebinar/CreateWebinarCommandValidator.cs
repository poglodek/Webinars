using FluentValidation;

namespace Webinars.CQRS.Webinar.Commands.CreateWebinar
{
    public class CreateWebinarCommandValidator : AbstractValidator<CreateWebinarCommand>
    {
        public CreateWebinarCommandValidator()
        {
            RuleFor(x=>x.SpeakerId.Id).GreaterThan(0).WithMessage("Speaker Id is required");
            RuleFor(x=>x.Description.DescriptionText).Length(10,255).WithMessage("Description must be between 10 and 255 characters");
            RuleFor(x=>x.Link.Youtube).Length(10,255).WithMessage("Youtube must be between 10 and 255 characters");
            RuleFor(x=>x.Replay.Youtube).Length(10,255).WithMessage("YoutubeReplay must be between 10 and 255 characters");
            RuleFor(x=>x.Link.Website).Length(10,255).WithMessage("Website must be between 10 and 255 characters");
            RuleFor(x=>x.Replay.Website).Length(10,255).WithMessage("WebsiteReplay must be between 10 and 255 characters");
            RuleFor(x=>x.Category).NotNull().WithMessage("Category is required");
        }
    }
}