using AutoMapper;
using Webinars.CQRS.Mapper.Dto;
using Webinars.CQRS.Mapper.Dto.Speaker;
using Webinars.Domain.ValueObjects;
using Webinars.Domain.ValueObjects.Common;
using Webinars.Domain.ValueObjects.Ids;
using Webinars.Domain.ValueObjects.Webinar;

namespace Webinars.CQRS.Mapper
{
    public class MapperProperty : Profile
    {
        public MapperProperty()
        {
            CreateMap<WebinarName, WebinarNameDto>().ReverseMap();
            CreateMap<WebinarId, WebinarIdDto>().ReverseMap();
            CreateMap<Description, DescriptionDto>().ReverseMap();
            CreateMap<Link, LinkDto>().ConstructUsing(x => new LinkDto(x.Youtube, x.Website)).ReverseMap();
            CreateMap<Replay, ReplayDto>().ConstructUsing(x => new ReplayDto(x.Link.Youtube, x.Link.Website))
                .ReverseMap();
            CreateMap<CreatedTime, CreatedTimeDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<SpeakerIdDto, SpeakerId>().ReverseMap();
        }
    }
}