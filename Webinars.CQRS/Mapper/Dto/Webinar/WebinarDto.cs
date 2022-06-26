namespace Webinars.CQRS.Mapper.Dto
{
    public class WebinarDto
    {
        public WebinarId Id { get; set; }
        public WebinarNameDto WebinarName { get; set; }
        public SpeakerDto Speaker { get; set; }
        public DescriptionDto Description { get; set; }
        public LinkDto Link { get; set; }
        public ReplayDto Replay { get; set; }
        public CreatedTimeDto CreatedTime { get; set; }
        public CategoryDto Category { get; set; }
    }
}