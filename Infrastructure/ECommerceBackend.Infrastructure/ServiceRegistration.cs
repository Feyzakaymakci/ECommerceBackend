﻿using ECommerceBackend.Application.Abstractions.Services;
using ECommerceBackend.Application.Abstractions.Services.Configurations;
using ECommerceBackend.Application.Abstractions.Storage;
using ECommerceBackend.Application.Abstractions.Storage.Local;
using ECommerceBackend.Application.Abstractions.Token;
using ECommerceBackend.Infrastructure.Enums;
using ECommerceBackend.Infrastructure.Services;
using ECommerceBackend.Infrastructure.Services.Configurations;
using ECommerceBackend.Infrastructure.Services.Storage;
using ECommerceBackend.Infrastructure.Services.Storage.Azure;
using ECommerceBackend.Infrastructure.Services.Storage.Local;
using ECommerceBackend.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackend.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IStorageService, StorageService>();
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
            serviceCollection.AddScoped<IMailService, MailService>();
            serviceCollection.AddScoped<IApplicationService, ApplicationService>();
        }
        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : Storage, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }
        public static void AddStorage(this IServiceCollection serviceCollection, StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Local:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageType.Azure:
                    serviceCollection.AddScoped<AzureStorage>();
                    break;
                case StorageType.AWS:
                    break;
                default:
                    break;
            }
        }
    }
}
