using Webinars.Domain.ValueObjects;
using Webinars.Domain.ValueObjects.Speaker;

namespace Webinars.Common.Builders
{
    public class SocialMediaBuilder
    {
        public static SocialMediaBuilder BuildSocialMedia() => new();
        private string _fb;
        private string _ig;
        private string _tt;
        private string _yt;
        private string _gh;
        private string _blog;

        public SocialMediaBuilder WithFacebook(string fb)
        {
            this._fb = fb;
            return this;
        }
        public SocialMediaBuilder WithInstagram(string ig)
        {
            this._ig = ig;
            return this;
        }
        public SocialMediaBuilder WithTwitter(string tt)
        {
            this._tt = tt;
            return this;
        }
        public SocialMediaBuilder WithYoutube(string yt)
        {
            this._yt = yt;
            return this;
        }
        public SocialMediaBuilder WithGithub(string gh)
        {
            this._gh = gh;
            return this;
        }
        public SocialMediaBuilder WithBlog(string blog)
        {
            this._blog = blog;
            return this;
        }
        public SocialMedia Build() => new(_fb, _ig, _tt, _yt, _gh, _blog);
    }
}
