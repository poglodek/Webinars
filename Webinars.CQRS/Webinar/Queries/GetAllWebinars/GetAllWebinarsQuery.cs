using MediatR;
using Webinars.Domain.ValueObjects.Webinar;

namespace Webinars.CQRS.Webinar.Queries.GetAllWebinars
{
    public class GetAllWebinarsQuery : IRequest<GetAllWebinarsQueryHandlerResponse>
    {
        public CatergoryStatus Filter { get; set; }
        public int Page { get; set; }
    }
}