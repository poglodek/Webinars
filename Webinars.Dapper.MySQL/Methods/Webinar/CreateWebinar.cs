using System.Data;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using Webinars.Common;

namespace Webinars.Dapper.MySQL.Methods.Webinar;

public interface ICreateWebinar
{
    Task<OperationStatusCode> Run(Domain.Entities.Webinar webinar);
}

public class CreateWebinar : ICreateWebinar
{
    private readonly IDbConnection _connection;
    private readonly IMapper _mapper;

    public CreateWebinar(IDbConnection connection, IMapper mapper)
    {
        _connection = connection;
        _mapper = mapper;
    }
    public async Task<OperationStatusCode> Run(Domain.Entities.Webinar webinar)
    {
        await _connection.ExecuteAsync("");
        return OperationStatusCode.OK;
    }
}