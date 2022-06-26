using System.Collections.Generic;
using System.Threading.Tasks;
using Webinars.Domain.Entities;
using Webinars.Domain.ValueObjects.Webinar;

namespace Webinars.Contracts.Persistence
{
    public interface IWebinarRepository
    {
        public Task<IReadOnlyList<Webinar>> GetAllCollection(CatergoryStatus filter = CatergoryStatus.ALL);
    }
}