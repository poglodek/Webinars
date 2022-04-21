using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Webinars.Common.Builders;
using Xunit;

namespace Webinars.UnitTest.Domain
{
    public class SocialMediaTest
    {
        [Fact]
        public void SocialMedia_HasMedia_WithMedia_ReturnTrue()
        {
            var sm = SocialMediaBuilder.BuildSocialMedia().WithBlog("Blog.com").Build();

            Assert.True(sm.HasSocialMedia());
        }
        [Fact]
        public void SocialMedia_HasMedia_WithMediaNull_ReturnFalse()
        {
            var sm = SocialMediaBuilder.BuildSocialMedia().WithBlog(null).Build();

            Assert.False(sm.HasSocialMedia());
        }


        [Fact]
        public void SocialMedia_GetAllSocialMedia_With3Media_Return3()
        {
            var sm = SocialMediaBuilder.BuildSocialMedia().
                WithBlog("Blog.com").
                WithFacebook("fb.com")
                .WithInstagram("ig.com")
                .Build();

            var media = sm.GetAllSocialMedia();
            media.Count.Should().Be(3);
        }


    }
}
