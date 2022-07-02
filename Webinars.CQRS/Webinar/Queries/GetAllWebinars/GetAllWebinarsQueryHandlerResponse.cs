using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Webinars.Domain.ValueObjects.Webinar;

namespace Webinars.CQRS.Webinar.Queries.GetAllWebinars
{
    public class GetAllWebinarsQueryHandlerResponse
    {
        public IEnumerable<WebinarViewModel> List { get; init; }
        public GetAllWebinarsQueryHandlerResponse(IEnumerable<WebinarViewModel> list)
        {
            List = list;
        }

    }
}
