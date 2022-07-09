using Webinars.CQRS.Webinar.ViewModel;

namespace Webinars.CQRS.Webinar.Queries.GetWebinarById
{
    public class GetWebinarByIdHandlerResponse
    {
        public GetWebinarByIdHandlerResponse(WebinarViewModel webinar)
        {
            Webinar = webinar;
        }

        public WebinarViewModel Webinar { get; init; }
    }
}