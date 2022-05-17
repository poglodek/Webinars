using MediatR;
using Microsoft.AspNetCore.Mvc;
using Webinars.CQRS.Webinar.Queries.GetAllWebinars;
using Webinars.Domain.ValueObjects.Webinar;

namespace Webinars.Api.Controllers
{
    [Route("api/[controller]")]
    public class WebinarController : Controller
    {
        private readonly IMediator _mediator;

        public WebinarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all/{filter}", Name = "getallwebinars")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<WebinarInListViewModel>>> GetAllWebinars(int filter)
        {
            var query = new GetAllWebinarsQuery
            {
                Filter = (CatergoryStatus)filter
            };
            var response = await _mediator.Send(query);

            return Ok(response.List);
        }
    }
}
