using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Webinars.CQRS
{
    public static class CQRSConfigurator
    {
        public static IServiceCollection AddCQRS(this ServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
            
            return serviceCollection;
        }
    }
}