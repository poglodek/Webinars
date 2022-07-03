using MediatR;
using Webinars.CQRS.Webinar.ViewModel;

namespace Webinars.CQRS.Webinar.Queries.GetWebinarById
{
    public class GetWebinarById : IRequest<GetWebinarByIdHandlerResponse>
    {
        public int Id { get; set; }
    }
}