using AutoMapper;
using Webinars.CQRS.Mapper.Dto;
using Webinars.Domain.Entities;
using Webinars.Domain.ValueObjects;
using Webinars.Domain.ValueObjects.Common;
using Webinars.Domain.ValueObjects.Webinar;
using WebinarId = Webinars.Domain.ValueObjects.Ids.WebinarId;

namespace Webinars.CQRS.Mapper
{
    public class MapperProperty : Profile
    {
        public MapperProperty()
        {
            CreateMap<WebinarName, WebinarNameDto>();
            CreateMap<WebinarId, int>().ConstructUsing(x => x.Id);
            CreateMap<Description, DescriptionDto>();
            CreateMap<Link, LinkDto>().ConstructUsing(x=> new LinkDto(x.Youtube,x.Website));
            CreateMap<Replay, ReplayDto>().ConstructUsing(x => new ReplayDto(x.Link.Youtube,x.Link.Website));
            CreateMap<CreatedTime, CreatedTimeDto>();
            CreateMap<Category, CategoryDto>();
        }
    }
}