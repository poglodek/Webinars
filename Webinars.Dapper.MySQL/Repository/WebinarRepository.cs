using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using Webinars.Contracts.Persistence;
using Webinars.Dapper.MySQL.TempClass;
using Webinars.Domain.Entities;
using Webinars.Domain.ValueObjects.Webinar;

namespace Webinars.Dapper.MySQL.Repository
{
    public class WebinarRepository : IWebinarRepository
    {
        private readonly IDbConnection _connection;
        private readonly IMapper _mapper;

        public WebinarRepository(IDbConnection connection,
            IMapper mapper)
        {
            _connection = connection;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<Webinar>> GetAllCollection(CatergoryStatus filter = CatergoryStatus.ALL, int page = 0)
        {
            var sql = @$"SELECT w.Name as 'WebinarName', w.Webinar_Id as 'WebinarId', w.Description as 'Description', w.Youtube as 'YouTubeLink',
                        w.Website as 'WebsiteLink', w.YoutubeReplay as 'YoutubeReplay', w.WebsiteReplay as 'WebsiteReplay', w.Catergoria as 'CategoryInt', 
                        w.CreatedTime as 'CreatedDate', s.FirstName as 'SpeakerFirstName', s.LastName as 'SpeakerLastName'
                        from webinar w 
                        inner join speaker s on s.speaker_id = w.speaker_id
                        WHERE w.Catergoria = @category LIMIT 10 OFFSET {page} ";
            var temp = await _connection.QueryAsync<WebinarTemp>(sql, new {category = (int)filter });
            return _mapper.Map<IReadOnlyList<Webinar>>(temp);

        }
    }
}