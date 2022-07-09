using AutoMapper;
using Webinars.CQRS.Webinar.Commands.CreateWebinar;
using Webinars.CQRS.Webinar.ViewModel;

namespace Webinars.CQRS.Mapper
{
    public class ViewModelMapper : Profile
    {
        public ViewModelMapper()
        {
            CreateMap<WebinarViewModel, Domain.Entities.Webinar>().ReverseMap();
            CreateMap<CreateWebinarCommand, Domain.Entities.Webinar>().ReverseMap();
        }
    }
}