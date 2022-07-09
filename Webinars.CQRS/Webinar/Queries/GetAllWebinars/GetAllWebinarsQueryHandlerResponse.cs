using System.Collections.Generic;
using Webinars.CQRS.Webinar.ViewModel;

namespace Webinars.CQRS.Webinar.Queries.GetAllWebinars
{
    public class GetAllWebinarsQueryHandlerResponse
    {
        public GetAllWebinarsQueryHandlerResponse(IEnumerable<WebinarViewModel> list)
        {
            List = list;
        }

        public IEnumerable<WebinarViewModel> List { get; init; }
    }
}