using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webinars.Domain.Ddd;

namespace Webinars.Domain.ValueObjects
{
    public class SocialMedia : ValueObject<SocialMedia>
    {
        public string Facebook { get; }
        public string Instagram { get; }
        public string Twitter { get; }
        public string Youtube { get; }
        public string Github { get; }
        public string Blog { get; }

        public SocialMedia(string facebook, string instagram, string twitter, string youtube, string github, string blog)
        {
            Facebook = facebook;
            Instagram = instagram;
            Twitter = twitter;
            Youtube = youtube;
            Github = github;
            Blog = blog;
        }

        public bool HasSocialMedia()
        {
            if (!string.IsNullOrWhiteSpace(Facebook) 
                || !string.IsNullOrWhiteSpace(Instagram)
                || !string.IsNullOrWhiteSpace(Twitter)
                || !string.IsNullOrWhiteSpace(Youtube)
                || !string.IsNullOrWhiteSpace(Github)
                || !string.IsNullOrWhiteSpace(Blog))
                return true;
            return false;
        }

        public List<string> GetAllSocialMedia()
        {
            var socials = new List<string>();
            socials.AddRange(GetAttributesToEqualityCheck().Where(x => x != null) as IEnumerable<string> ?? Array.Empty<string>());
            return socials;
        }
        protected override IEnumerable<object> GetAttributesToEqualityCheck()
        {
            yield return Facebook;
            yield return Instagram;
            yield return Twitter;
            yield return Youtube;
            yield return Github;
            yield return Blog;
        }
    }
}
