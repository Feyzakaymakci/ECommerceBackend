using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackend.Infrastructure.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid) //Eğerki geçersizse errorları clienta geri döndürüyoruz.
            {
                var errors = context.ModelState
                    .Where(x => x.Value.Errors.Any())
                    .ToDictionary(e => e.Key, e => e.Value.Errors.Select(e => e.ErrorMessage)) //Buradaki key bze ilgili property yi getirecek.
                    .ToArray();  //Diziye dönüştürüyoruz.

                context.Result = new BadRequestObjectResult(errors);
                return;
            }
            await next();
        }
    }
}
 