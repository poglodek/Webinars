using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Webinars.Contracts.Persistence;
using Webinars.Domain.Entities;
using Webinars.Domain.ValueObjects.Webinar;

namespace Webinars.Dapper.SQLServer.Repository
{
    public class WebinarRepository : IWebinarRepository
    {
        private readonly IDbConnection _connection;

        public WebinarRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<IReadOnlyList<Webinar>> GetAllCollection(CatergoryStatus filter = CatergoryStatus.ALL, int page = 0)
        {
            return new List<Webinar>(0);
        }
    }
}