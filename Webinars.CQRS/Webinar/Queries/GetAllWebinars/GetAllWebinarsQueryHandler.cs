using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Webinars.Contracts.Persistence;
using Webinars.CQRS.Mapper.Dto;
using Webinars.CQRS.Webinar.ViewModel;

namespace Webinars.CQRS.Webinar.Queries.GetAllWebinars
{
    public class GetAllWebinarsQueryHandler : IRequestHandler<GetAllWebinarsQuery, GetAllWebinarsQueryHandlerResponse>
    {
        private readonly IWebinarRepository _repository;
        private readonly IMapper _mapper;

        public GetAllWebinarsQueryHandler(IWebinarRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetAllWebinarsQueryHandlerResponse> Handle(GetAllWebinarsQuery request, CancellationToken cancellationToken)
        {
           var list =  await _repository.GetAllCollection(request.Filter, request.Page);
           return new GetAllWebinarsQueryHandlerResponse(_mapper.Map<IEnumerable<WebinarViewModel>>(list));
        }
    }
}
