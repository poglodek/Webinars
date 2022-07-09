namespace Webinars.CQRS.Mapper.Dto
{
    public class ReplayDto
    {
        public ReplayDto(string yt, string wb)
        {
            Youtube = yt;
            Website = wb;
        }

        public string Youtube { get; set; }
        public string Website { get; set; }
    }
}