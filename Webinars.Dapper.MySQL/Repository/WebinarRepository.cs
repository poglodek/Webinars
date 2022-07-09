using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using Webinars.Common;
using Webinars.Contracts.Persistence;
using Webinars.Dapper.MySQL.Methods.Webinar;
using Webinars.Dapper.MySQL.TempClass;
using Webinars.Domain.Entities;
using Webinars.Domain.ValueObjects.Webinar;

namespace Webinars.Dapper.MySQL.Repository
{
    public class WebinarRepository : IWebinarRepository
    {
        private readonly IGetWebinarById _getWebinarById;
        private readonly IWebinarGetAllCollection _getAllCollection;

        public WebinarRepository(IGetWebinarById getWebinarById, IWebinarGetAllCollection getAllCollection)
        {
            _getWebinarById = getWebinarById;
            _getAllCollection = getAllCollection;
        }
        public async Task<IReadOnlyCollection<Webinar>> GetAllCollection(CatergoryStatus filter = CatergoryStatus.ALL, int page = 0)
        {
            return await _getAllCollection.Run(filter, page);
        }

        public async Task<Webinar> GetById(int id)
        {
            return await _getWebinarById.Run(id);
        }

        public async Task<OperationStatusCode> Create(Webinar webinar)
        {
            throw new System.NotImplementedException();
        }
    }
}