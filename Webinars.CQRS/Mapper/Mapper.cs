using AutoMapper;
using Webinars.CQRS.Mapper.Dto;

namespace Webinars.CQRS.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Domain.Entities.Webinar, WebinarDto>()
                .ForMember(x=>x.Id, opt=>opt.MapFrom(y=>y.Id))
                .ForMember(x => x.WebinarName, opt => opt.MapFrom(y => y.WebinarName))
                .ForMember(x => x.Speaker, opt => opt.MapFrom(y => y.Speaker))
                .ForMember(x => x.Description, opt => opt.MapFrom(y => y.Description))
                .ForMember(x => x.Link, opt => opt.MapFrom(y => y.Link))
                .ForMember(x => x.CreatedTime, opt => opt.MapFrom(y => y.CreatedTime))
                .ForMember(x => x.Category, opt => opt.MapFrom(y => y.Category))
                .ReverseMap();
            

        }
    }
}