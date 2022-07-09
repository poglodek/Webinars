using FluentAssertions;
using Webinars.Domain.ValueObjects.Webinar;
using Xunit;

namespace Webinars.UnitTest.Domain
{
    public class ReplayTest
    {
        [Fact]
        public void HasReplay_HasLink_ReturnTrue()
        {
            var replay = new Replay(new Link("yt.com", "wb.com"));

            var result = replay.HasReplay();

            result.Should().BeTrue();
        }

        [Fact]
        public void HasReplay_HasNotLink_ReturnFalse()
        {
            var replay = new Replay(null);

            var result = replay.HasReplay();

            result.Should().BeFalse();
        }
    }
}