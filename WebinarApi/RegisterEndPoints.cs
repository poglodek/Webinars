using MediatR;
using Microsoft.AspNetCore.Mvc;
using Webinars.CQRS.Webinar.Queries.GetAllWebinars;
using Webinars.Domain.ValueObjects.Webinar;

namespace WebinarApi;

public static class RegisterEndPoints
{
    public static WebApplication RegisterEndpoints(this WebApplication app)
    {
        app.MapGet("/GetAll/{status}/{page}", async ([FromServices]IMediator mediator,[FromRoute] int status,[FromRoute] int page) =>
        {
            var query = new GetAllWebinarsQuery
            {
                Filter = (CatergoryStatus)status,
                Page = page
            };
            var result = await mediator.Send(query);
            return Results.Ok(result);
        });
        return app;
    }
}