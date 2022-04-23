using Webinars.Domain.Ddd;
using Webinars.Domain.ValueObjects;
using Webinars.Domain.ValueObjects.Commentator;
using Webinars.Domain.ValueObjects.Ids;
using Webinars.Domain.ValueObjects.Security;

namespace Webinars.Domain.Entities
{
    public class Commentator : Entity<CommentatorId>
    {
        public Name Name { get; init; }
        public Email Email { get; init; }
        public CommentatorStatus CommentatorStatus { get; init; }
        public CreatedTime CreatedTime { get; init; }
        public Password Password { get; init; }

        public Commentator(CommentatorId commentatorId, Name name, Email email, CommentatorStatus status, CreatedTime time, Password password)
        {
            Id = commentatorId;
            Name = name;
            Email = email;
            CommentatorStatus = status;
            CreatedTime = time;
            Password = password;
        }

    }
}
