using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webinars.Domain.Ddd;

namespace Webinars.Domain.ValueObjects.Message
{
    public class Message : ValueObject<Message>
    {
        public string Value { get; init; }
        public MessageScoreResult Score { get; set; }
        public CreatedTime CreatedTime { get; init; }

        public Message(string value, CreatedTime createdTime)
        {
            if(string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException("Message cannot be empty");
            Value = value;
            CreatedTime = createdTime;

        }
        public Message(string value, CreatedTime createdTime, MessageScoreResult score) : this(value, createdTime)
        {
            Score = score;
        }
        protected override IEnumerable<object> GetAttributesToEqualityCheck()
        {
            yield return Value;
            yield return CreatedTime;
        }

        public void Evaluate(MessageRules rules)
        {
            Score = rules.Evaluate(this);
        }

        public override string ToString()
        {
            return $"{Value} - {CreatedTime.CreatedDateTime}";
        }
    }
}
