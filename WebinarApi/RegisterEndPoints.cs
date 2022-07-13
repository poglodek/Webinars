using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServiceBus.Consumer.Webinar;
using Webinars.Common;
using Webinars.CQRS.Mapper.Dto;
using Webinars.CQRS.Webinar.Commands.CreateWebinar;
using Webinars.CQRS.Webinar.Queries.GetAllWebinars;
using Webinars.CQRS.Webinar.Queries.GetWebinarById;
using Webinars.CQRS.Webinar.ViewModel;
using Webinars.Domain.Entities;
using Webinars.Domain.ValueObjects.Webinar;

namespace WebinarApi;

public static class RegisterEndPoints
{
    public static WebApplication RegisterEndpoints(this WebApplication app)
    {
        app.MapGet("/GetAll/{status}/{page}", GetAll)
            .Produces<GetAllWebinarsQueryHandlerResponse>()
            .Produces(StatusCodes.Status404NotFound)
            .WithTags("Webinars");

        app.MapGet("/Get/{id:int}", GetById)
            .Produces<GetWebinarByIdHandlerResponse>()
            .Produces(StatusCodes.Status404NotFound)
            .WithTags("Get Webinar");

        app.MapPost("/CreateWebinar", CreateWebinar)
            .Accepts<CreateWebinarCommand>("application/json")
            .Produces<OperationStatusCode>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithTags("Create Webinar");

        app.MapGet("/xd",GETXD);
        
        return app;
    }
    //DELETE, only for education 
    private static async Task<IResult> GETXD([FromServices] IRequestClient<WebinarIdDto> endpoint)
    {
        var a = await endpoint.GetResponse<WebinarViewModel>(new WebinarIdDto{Id = 1});
        return Results.Ok(a);
       
    }
    private static async Task<IResult> GetAll([FromServices] IMediator mediator, [FromRoute] int status,
        [FromRoute] int page)
    {
        var query = new GetAllWebinarsQuery
        {
            Filter = (CatergoryStatus) status,
            Page = page
        };
        var result = await mediator.Send(query);
        return Results.Ok(result);
    }

    private static async Task<IResult> GetById([FromServices] IMediator mediator, [FromRoute] int id)
    {
        var query = new GetWebinarById
        {
            Id = id
        };

        var result = await mediator.Send(query);
        return Results.Ok(result);
    }

    private static async Task<IResult> CreateWebinar([FromServices] IMediator mediator,
        [FromBody] CreateWebinarCommand command)
    {
        var result = await mediator.Send(command);
        
        if(result == OperationStatusCode.CREATED)
            return Results.Created("/get",null);
        return Results.Ok(result);
    }
}