using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webinars.Domain.ValueObjects.Webinar;

namespace Webinars.Common.Builders
{
    public class LinkBuilder
    {
        private string _yt;
        private string _ws;

        public static LinkBuilder CreateLink() => new();

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
            => new Link(_yt, _ws);
    }
}
