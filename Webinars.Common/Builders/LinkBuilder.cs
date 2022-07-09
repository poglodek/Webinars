using Webinars.Domain.ValueObjects.Webinar;

namespace Webinars.Common.Builders
{
    public class LinkBuilder
    {
        private string _ws;
        private string _yt;

        public static LinkBuilder CreateLink()
        {
            return new();
        }

        public LinkBuilder WithYoutube(string yt)
        {
            _yt = yt;
            return this;
        }

        public LinkBuilder WithWebsite(string ws)
        {
            _ws = ws;
            return this;
        }

        public Link Build()
        {
            return new(_yt, _ws);
        }
    }
}