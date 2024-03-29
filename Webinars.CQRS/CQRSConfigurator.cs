﻿using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Webinars.CQRS
{
    public static class CQRSConfigurator
    {
        public static IServiceCollection AddCQRS(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
            
            
            //serviceCollection.
            return serviceCollection;
        }
    }
}