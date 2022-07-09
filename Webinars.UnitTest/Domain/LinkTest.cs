using FluentAssertions;
using Webinars.Common.Builders;
using Xunit;

namespace Webinars.UnitTest.Domain
{
    public class LinkTest
    {
        [Fact]
        public void CreateLinkWithYtAndWs_HasLink_RetrunTrue()
        {
            var link = LinkBuilder.CreateLink()
                .WithYoutube("yt.com")
                .WithWebsite("google.com")
                .Build();

            var result = link.HasStream();

            Assert.True(result);
        }

        [Fact]
        public void CreateLinkWithWs_HasLink_RetrunTrue()
        {
            var link = LinkBuilder.CreateLink()
                .WithWebsite("google.com")
                .Build();

            var result = link.HasStream();

            result.Should().BeTrue();
        }

        [Fact]
        public void CreateLinkWithYt_HasLink_RetrunTrue()
        {
            var link = LinkBuilder.CreateLink()
                .WithYoutube("yt.com")
                .Build();

            var result = link.HasStream();

            result.Should().BeTrue();
        }

        [Fact]
        public void CreateLinkWithYt_GetAllLink_Retrun1()
        {
            var link = LinkBuilder.CreateLink()
                .WithYoutube("yt.com")
                .Build();
            var result = link.GetAllLink();

            result.Should().HaveCount(1);
        }

        [Fact]
        public void CreateLinkWithYtAndWs_GetAllLink_Retrun2()
        {
            var link = LinkBuilder.CreateLink()
                .WithYoutube("yt.com")
                .WithWebsite("ws.com")
                .Build();
            var result = link.GetAllLink();

            result.Should().HaveCount(2);
        }
    }
}