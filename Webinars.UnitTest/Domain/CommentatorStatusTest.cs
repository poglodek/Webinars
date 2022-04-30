using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Webinars.Domain.ValueObjects.Commentator;
using Xunit;

namespace Webinars.UnitTest.Domain
{
    public class CommentatorStatusTest
    {
        [Fact]
        public void CanLogin_IsBannedAndIsActive_ReturnFalse()
        {
            var commentator = new CommentatorStatus(true, true);

            var result = commentator.CanLogin();
            result.Should().BeTrue();
        }
        [Fact]
        public void CanLogin_IsNotBannedAndIsActive_ReturnTrue()
        {
            var commentator = new CommentatorStatus(true, false);

            var result = commentator.CanLogin();
            result.Should().BeFalse();
        }
        [Fact]
        public void CanLogin_IsNotBannedAndIsNotActive_ReturnFalse()
        {
            var commentator = new CommentatorStatus(false, false);

            var result = commentator.CanLogin();
            result.Should().BeFalse();
        }
        [Fact]
        public void CanLogin_IsBannedAndIsNotActive_ReturnFalse()
        {
            var commentator = new CommentatorStatus(false, false);

            var result = commentator.CanLogin();
            result.Should().BeFalse();
        }
    }
}
