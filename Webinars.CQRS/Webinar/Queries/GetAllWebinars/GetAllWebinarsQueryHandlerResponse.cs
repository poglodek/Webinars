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
        public List<WebinarInListViewModel> List { get; init; }
        public GetAllWebinarsQueryHandlerResponse(List<WebinarInListViewModel> list)
        {
            List = list;
        }

    }
}
