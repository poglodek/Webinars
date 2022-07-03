using Webinars.CQRS.Webinar.ViewModel;

namespace Webinars.CQRS.Webinar.Queries.GetWebinarById
{
    public class GetWebinarByIdHandlerResponse
    {
        public WebinarViewModel Webinar { get; init; }

        public GetWebinarByIdHandlerResponse(WebinarViewModel webinar)
        {
            Webinar = webinar;
        }
    }
}