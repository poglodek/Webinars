using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Webinars.Common;
using Webinars.Contracts.Persistence;
using Webinars.Dapper.MySQL.Methods.Webinar;
using Webinars.Domain.Entities;
using Webinars.Domain.ValueObjects.Webinar;

namespace Webinars.Dapper.MySQL.Repository;

public class WebinarRepository : IWebinarRepository
{
    private readonly IWebinarGetAllCollection _getAllCollection;
    private readonly IGetWebinarById _getWebinarById;

    public WebinarRepository(IGetWebinarById getWebinarById, IWebinarGetAllCollection getAllCollection)
    {
        _getWebinarById = getWebinarById;
        _getAllCollection = getAllCollection;
    }

    public async Task<IReadOnlyCollection<Webinar>> GetAllCollection(CatergoryStatus filter = CatergoryStatus.ALL,
        int page = 0)
    {
        return await _getAllCollection.Run(filter, page);
    }

    public async Task<Webinar> GetById(int id)
    {
        return await _getWebinarById.Run(id);
    }

    public async Task<OperationStatusCode> Create(Webinar webinar)
    {
        throw new NotImplementedException();
    }
}