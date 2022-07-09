using System.Collections.Generic;
using Webinars.Domain.Ddd;

namespace Webinars.Domain.ValueObjects.Webinar
{
    public enum CatergoryStatus
    {
        NEW = 1,
        IN_PROGRESS,
        ENDED,
        ALL
    }

    public class Category : ValueObject<Category>
    {
        public Category(CatergoryStatus status)
        {
            Status = status;
        }

        public CatergoryStatus Status { get; set; }

        protected override IEnumerable<object> GetAttributesToEqualityCheck()
        {
            yield return Status;
        }
    }
}