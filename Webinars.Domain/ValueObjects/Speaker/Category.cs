using System.Collections.Generic;
using Webinars.Domain.Ddd;

namespace Webinars.Domain.ValueObjects
{
    public enum CatergoryStatus
    {
        NEW,
        IN_PROGRESS,
        ENDED
    }
    public class Category : ValueObject<Category>
    {
        public CatergoryStatus Status { get; set; }

        public Category(CatergoryStatus status)
        {
            Status = status;
        }
        protected override IEnumerable<object> GetAttributesToEqualityCheck()
        {
            yield return Status;
        }
    }
}
