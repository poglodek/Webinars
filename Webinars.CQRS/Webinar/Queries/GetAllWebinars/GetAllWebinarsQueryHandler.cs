using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Webinars.Contracts.Persistence;
using Webinars.CQRS.Mapper.Dto;

namespace Webinars.CQRS.Webinar.Queries.GetAllWebinars
{
    public class GetAllWebinarsQueryHandler : IRequestHandler<GetAllWebinarsQuery, GetAllWebinarsQueryHandlerResponse>
    {
        private readonly IWebinarRepository _repository;

        public GetAllWebinarsQueryHandler(IWebinarRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetAllWebinarsQueryHandlerResponse> Handle(GetAllWebinarsQuery request, CancellationToken cancellationToken)
        {
           await _repository.GetAllCollection(request.Filter, request.Page);
           return null;
        }
    }
}
