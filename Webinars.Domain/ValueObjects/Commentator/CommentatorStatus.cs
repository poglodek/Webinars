using System.Collections.Generic;
using Webinars.Domain.Ddd;

namespace Webinars.Domain.ValueObjects.Commentator
{
    public class CommentatorStatus : ValueObject<CommentatorStatus>
    {
        public bool IsActive { get; init; }
        public bool Banned { get; init; }

        public CommentatorStatus(bool isActive, bool banned)
        {
            IsActive = isActive;
            Banned = banned;
        }

        public bool CanLogin() => IsActive && Banned;
        protected override IEnumerable<object> GetAttributesToEqualityCheck()
        {
            yield return IsActive;
            yield return Banned;
        }
    }
}
