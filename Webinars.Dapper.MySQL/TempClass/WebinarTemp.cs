using System;

namespace Webinars.Dapper.MySQL.TempClass
{
    public class WebinarTemp
    {
        public int WebinarId { get; set; }
        public string WebinarName { get; set; }
        public string Description { get; set; }
        public string YouTubeLink { get; set; }
        public string WebsiteLink { get; set; }
        public string YoutubeReplay { get; set; }
        public string WebsiteReplay { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryInt { get; set; }
    }
}