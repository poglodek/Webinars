using Webinars.Domain.ValueObjects.Speaker;

namespace Webinars.Common.Builders
{
    public class SocialMediaBuilder
    {
        private string _blog;
        private string _fb;
        private string _gh;
        private string _ig;
        private string _tt;
        private string _yt;

        public static SocialMediaBuilder BuildSocialMedia()
        {
            return new();
        }

        public SocialMediaBuilder WithFacebook(string fb)
        {
            _fb = fb;
            return this;
        }

        public SocialMediaBuilder WithInstagram(string ig)
        {
            _ig = ig;
            return this;
        }

        public SocialMediaBuilder WithTwitter(string tt)
        {
            _tt = tt;
            return this;
        }

        public SocialMediaBuilder WithYoutube(string yt)
        {
            _yt = yt;
            return this;
        }

        public SocialMediaBuilder WithGithub(string gh)
        {
            _gh = gh;
            return this;
        }

        public SocialMediaBuilder WithBlog(string blog)
        {
            _blog = blog;
            return this;
        }

        public SocialMedia Build()
        {
            return new(_fb, _ig, _tt, _yt, _gh, _blog);
        }
    }
}