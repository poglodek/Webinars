using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webinars.Domain.Ddd;

namespace Webinars.Domain.ValueObjects.Message
{
    public class MessageScoreResult : ValueObject<MessageScoreResult>
    {
        public string RejectReason { get; set; }
        public bool IsReject { get; set; }

        public MessageScoreResult(bool isReject)
        {
            if (!isReject)
                throw new ArgumentException("Reject have to have reason");
            IsReject = isReject;
        }

        public MessageScoreResult(bool isReject, string rejectExplanation) : this(isReject)
        {
            if(string.IsNullOrWhiteSpace(rejectExplanation))
                throw new ArgumentException("Reject have to have reason");
            RejectReason = rejectExplanation;
        }

        protected override IEnumerable<object> GetAttributesToEqualityCheck()
        {
            yield return IsReject;
            yield return RejectReason;
        }

    }
}
