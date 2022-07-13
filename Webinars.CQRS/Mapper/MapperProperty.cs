using System;
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
            CreateMap<WebinarName, WebinarNameDto>();
            CreateMap<WebinarId, WebinarIdDto>();
            CreateMap<Description, DescriptionDto>();
            CreateMap<Link, LinkDto>().ConstructUsing(x => new LinkDto(x.Youtube, x.Website));
            CreateMap<Replay, ReplayDto>().ConstructUsing(x => new ReplayDto(x.Link.Youtube, x.Link.Website));
            CreateMap<CreatedTime, CreatedTimeDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<SpeakerIdDto, SpeakerId>();
            
            CreateMap<WebinarNameDto,WebinarName>().ConstructUsing(x=>new WebinarName(x.Name));
            CreateMap<WebinarIdDto,WebinarId>().ConstructUsing(x=>new WebinarId(x.Id));
            CreateMap<DescriptionDto,Description>().ConstructUsing(x=>new Description(x.DescriptionText));
            CreateMap<LinkDto,Link>().ConstructUsing(x => new Link(x.Youtube, x.Website));
            CreateMap<ReplayDto,Replay>().ConstructUsing(x => new Replay(new Link(x.Youtube, x.Website)));
            CreateMap<CreatedTimeDto,CreatedTime>().ConstructUsing(x=> new CreatedTime(DateTime.Now));
            CreateMap<CategoryDto, Category>().ConstructUsing(x => new Category(x.Status));
            CreateMap<SpeakerIdDto,SpeakerId>().ConstructUsing(x=> new SpeakerId(x.Id));

        }
    }
}