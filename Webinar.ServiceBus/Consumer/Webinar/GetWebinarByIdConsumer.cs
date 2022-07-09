using AutoMapper;
using MassTransit;
using MassTransit.Mediator;
using Webinars.Contracts.Persistence;
using Webinars.CQRS.Mapper.Dto;
using Webinars.CQRS.Webinar.Queries.GetWebinarById;
using Webinars.CQRS.Webinar.ViewModel;
using Webinars.Domain.ValueObjects.Ids;

namespace ServiceBus.Consumer.Webinar;

public class GetWebinarByIdConsumer : IConsumer<WebinarIdDto>
{
    private readonly IWebinarRepository _repository;
    private readonly IMapper _mapper;


    public GetWebinarByIdConsumer(IWebinarRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task Consume(ConsumeContext<WebinarIdDto> context)
    {
        var webinar = await _repository.GetById(context.Message.Id);
        var dto = _mapper.Map<WebinarViewModel>(webinar);
        await context.RespondAsync(dto);
    }
}