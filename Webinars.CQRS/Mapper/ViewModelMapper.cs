using System.Collections.Generic;
using AutoMapper;
using Webinars.CQRS.Webinar.Queries.GetAllWebinars;

namespace Webinars.CQRS.Mapper
{
    public class ViewModelMapper : Profile
    {
        public ViewModelMapper()
        {
            CreateMap<WebinarViewModel, Domain.Entities.Webinar>().ReverseMap();
        }
    }
}