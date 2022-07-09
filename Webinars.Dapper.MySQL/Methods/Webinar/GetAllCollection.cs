using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using Webinars.Dapper.MySQL.TempClass;
using Webinars.Domain.ValueObjects.Webinar;

namespace Webinars.Dapper.MySQL.Methods.Webinar;

public interface IWebinarGetAllCollection
{
    Task<IReadOnlyCollection<Domain.Entities.Webinar>> Run(CatergoryStatus filter = CatergoryStatus.ALL, int page = 0);
}

public class WebinarWebinarGetAllCollection : IWebinarGetAllCollection
{
    private readonly IDbConnection _connection;
    private readonly IMapper _mapper;

    public WebinarWebinarGetAllCollection(IDbConnection connection, IMapper mapper)
    {
        _connection = connection;
        _mapper = mapper;
    }
    
    public async Task<IReadOnlyCollection<Domain.Entities.Webinar>> Run(CatergoryStatus filter = CatergoryStatus.ALL, int page = 0)
    { 
        string sql = @$"SELECT w.Name as 'WebinarName', w.Id as 'WebinarId', w.Description as 'Description', w.Youtube as 'YouTubeLink',
                        w.Website as 'WebsiteLink', w.YoutubeReplay as 'YoutubeReplay', w.WebsiteRepaly as 'WebsiteReplay', w.Category as 'CategoryInt', 
                        w.CreatedTime as 'CreatedDate', s.FirstName as 'SpeakerFirstName', s.LastName as 'SpeakerLastName'
                        from webinar w 
                        inner join speaker s on s.id = w.id
                        WHERE w.Category = @category LIMIT 10 OFFSET {page} ";
        var temp = await _connection.QueryAsync<WebinarTemp>(sql, new {category = (int)filter });
        return _mapper.Map<IReadOnlyCollection<Domain.Entities.Webinar>>(temp);

    }
}