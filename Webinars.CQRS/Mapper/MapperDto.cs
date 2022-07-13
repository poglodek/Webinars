using AutoMapper;
using Webinars.CQRS.Mapper.Dto;
using Webinars.CQRS.Webinar.Commands.CreateWebinar;

namespace Webinars.CQRS.Mapper
{
    public class MapperDto : Profile
    {
        public MapperDto()
        {
            CreateMap<Domain.Entities.Webinar, WebinarDto>()
                .ForMember(x => x.WebinarId, opt => opt.MapFrom(y => y.Id))
                .ForMember(x => x.WebinarName, opt => opt.MapFrom(y => y.WebinarName))
                .ForMember(x => x.Speaker, opt => opt.MapFrom(y => y.Speaker))
                .ForMember(x => x.Description, opt => opt.MapFrom(y => y.Description))
                .ForMember(x => x.Link, opt => opt.MapFrom(y => y.Link))
                .ForMember(x => x.CreatedTime, opt => opt.MapFrom(y => y.CreatedTime))
                .ForMember(x => x.Category, opt => opt.MapFrom(y => y.Category))
                .ReverseMap();

            CreateMap<CreateWebinarCommand, Domain.Entities.Webinar>()
                .ForMember(x => x.Category, opt => opt.MapFrom(y => y.Category))
                .ForMember(x => x.Category, opt => opt.MapFrom(y => y.Description))
                .ForMember(x => x.Category, opt => opt.MapFrom(y => y.Link))
                .ForMember(x => x.Category, opt => opt.MapFrom(y => y.Replay))
                .ForMember(x => x.Category, opt => opt.MapFrom(y => y.SpeakerId))
                .ForMember(x => x.Category, opt => opt.MapFrom(y => y.WebinarName))
                .ReverseMap();
        }
    }
}