using System.Data;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using Webinars.Dapper.MySQL.TempClass;

namespace Webinars.Dapper.MySQL.Methods.Webinar;

public interface IGetWebinarById
{
    Task<Domain.Entities.Webinar> Run(int id);
}

public class GetWebinarWebinarById : IGetWebinarById
{
    private readonly IDbConnection _connection;
    private readonly IMapper _mapper;

    public GetWebinarWebinarById(IDbConnection connection, IMapper mapper)
    {
        _connection = connection;
        _mapper = mapper;
    }
    
    public async Task<Domain.Entities.Webinar> Run(int id)
    {
        string sql =
            @"SELECT w.Name as 'WebinarName', w.Id as 'WebinarId', w.Description as 'Description', w.Youtube as 'YouTubeLink',
                        w.Website as 'WebsiteLink', w.YoutubeReplay as 'YoutubeReplay', w.WebsiteRepaly as 'WebsiteReplay', w.Category as 'CategoryInt', 
                        w.CreatedTime as 'CreatedDate', s.FirstName as 'SpeakerFirstName', s.LastName as 'SpeakerLastName'
                        from webinar w 
                        inner join speaker s on s.id = w.id
                        WHERE w.Id = @id";
        var temp = await _connection.QuerySingleAsync<WebinarTemp>(sql, new {id});

        return _mapper.Map<Domain.Entities.Webinar>(temp);
    }
}