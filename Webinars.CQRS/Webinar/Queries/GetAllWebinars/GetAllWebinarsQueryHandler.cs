using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Webinars.CQRS.Webinar.Queries.GetAllWebinars
{
    public class GetAllWebinarsQueryHandler : IRequestHandler<GetAllWebinarsQuery, GetAllWebinarsQueryHandlerResponse>
    {
        public Task<GetAllWebinarsQueryHandlerResponse> Handle(GetAllWebinarsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
