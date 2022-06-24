using System.Collections.Generic;
using Webinars.Domain.Ddd;
using Webinars.Domain.ValueObjects;
using Webinars.Domain.ValueObjects.Commentator;
using Webinars.Domain.ValueObjects.Ids;
using Webinars.Domain.ValueObjects.Message;
using Webinars.Domain.ValueObjects.Security;

namespace Webinars.Domain.Entities
{
    public class Commentator : Entity<CommentatorId>
    {
        public Name Name { get; set; }
        public Email Email { get; set; }
        public CommentatorStatus CommentatorStatus { get; set; }
        public CreatedTime CreatedTime { get; set; }
        public Password Password { get; set; }
        public List<Message> Messages { get; set; }

        public Commentator(CommentatorId commentatorId, Name name, Email email, CommentatorStatus status, CreatedTime time, Password password, List<Message> messages)
        {
            Id = commentatorId;
            Name = name;
            Email = email;
            CommentatorStatus = status;
            CreatedTime = time;
            Password = password;
            Messages = messages;
        }

        public void BanCommentator()
        {
            CommentatorStatus = new CommentatorStatus(CommentatorStatus.IsActive, true);
        }

        public void UnBanCommentator()
        {
            CommentatorStatus = new CommentatorStatus(CommentatorStatus.IsActive, false);
        }

        public void Active()
        {
            CommentatorStatus = new CommentatorStatus(true, CommentatorStatus.Banned);
        }

        public void InActive()
        {
            CommentatorStatus = new CommentatorStatus(true, CommentatorStatus.Banned);
        }

        public void SetPassword(string password)
        {
            Password = new Password(password);
        }

        public void ChangeName(string firstName, string lastName)
        {
            Name = new Name(firstName, lastName);
        }
        
    }
}
