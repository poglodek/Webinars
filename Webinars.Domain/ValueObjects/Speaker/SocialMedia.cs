using System.Collections.Generic;
using Webinars.Domain.Ddd;

namespace Webinars.Domain.ValueObjects
{
    public class SocialMedia : ValueObject<SocialMedia>
    {
        public string Facebook { get; init; }
        public string Instagram { get; init; }
        public string Twitter { get; init; }
        public string Youtube { get; init; }
        public string Github { get; init; }
        public string Blog { get; init; }

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
            foreach (string item in GetAttributesToEqualityCheck())
            {
                if (!string.IsNullOrWhiteSpace(item))
                    socials.Add(item);
            }
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
