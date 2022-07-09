namespace Webinars.CQRS.Mapper.Dto
{
    public class LinkDto
    {
        public LinkDto(string yt, string wb)
        {
            Youtube = yt;
            Website = wb;
        }

        public LinkDto()
        {
            
        }

        public string Youtube { get; set; }
        public string Website { get; set; }
    }
}