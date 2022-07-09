using AutoMapper;
using Webinars.Dapper.MySQL.TempClass;
using Webinars.Domain.Entities;
using Webinars.Domain.ValueObjects;
using Webinars.Domain.ValueObjects.Common;
using Webinars.Domain.ValueObjects.Ids;
using Webinars.Domain.ValueObjects.Webinar;

namespace Webinars.Dapper.MySQL.Converter;

public class WebinarTempConverter : ITypeConverter<WebinarTemp, Webinar>
{
    private readonly IMapper _mapper;

    public WebinarTempConverter(IMapper mapper)
    {
        _mapper = mapper;
    }

    public Webinar Convert(WebinarTemp source, Webinar destination, ResolutionContext context)
    {
        var category = _mapper.Map<Category>(source.CategoryInt);
        var description = _mapper.Map<Description>(source.Description);
        var id = _mapper.Map<WebinarId>(source.WebinarId);
        var link = new Link(source.YouTubeLink, source.WebsiteLink);
        var replay = new Replay(new Link(source.YoutubeReplay, source.WebsiteReplay));
        var createdTime = _mapper.Map<CreatedTime>(source.CreatedDate);
        var webinarName = _mapper.Map<WebinarName>(source.WebinarName);
        return new Webinar(id, webinarName, null, description, link, replay, createdTime, category);
        ;
    }
}