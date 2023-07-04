using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace ECommerceBackend.API.Extensions
{
    public static class ConfigureExceptionHandlerExtension
    {
        public static void ConfigureExceptionHandler<T>(this WebApplication application,ILogger<T>logger)
        {
            application.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = MediaTypeNames.Application.Json; //Hangi türde istiyorsak

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();  //Hatayla ilgili lazım olan tüm bilgileri getirecek.
                    if(contextFeature != null)
                    {
                        logger.LogError(contextFeature.Error.Message);
                        context.Response.WriteAsync(JsonSerializer.Serialize(new
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message,
                            Title = "Hata alındı."
                        }));
                    }
                });
            });
        }
    }
}
