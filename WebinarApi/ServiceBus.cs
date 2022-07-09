using MassTransit;
using MassTransit.MultiBus;
using ServiceBus.Consumer.Webinar;
using Webinars.CQRS.Mapper.Dto;
using Webinars.CQRS.Webinar.Queries.GetWebinarById;
using Webinars.CQRS.Webinar.ViewModel;

namespace WebinarApi;

public static class ServiceBus
{
    public static IServiceCollection AddServiceBus(this IServiceCollection services)
    {
        services.AddMassTransit(config =>
        {
            config.AddConsumer<GetWebinarByIdConsumer>();

            config.AddRequestClient<WebinarIdDto>();
            
            config.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host("amqp://guest:guest@localhost:5672");
                cfg.ReceiveEndpoint("WebinarVM-queue", e =>
                {
                    e.ConfigureConsumer<GetWebinarByIdConsumer>(ctx);
                });
            });
            
            
        });
        
        
        return services;
    }
}