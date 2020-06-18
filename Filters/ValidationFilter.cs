using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebAPISample.WebAPI.Contracts.V1.Responses;

namespace AspNetCoreWebAPISample.WebAPI.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errorsInModelState = context.ModelState.Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage))
                    .ToArray();

                var responseErrors = errorsInModelState.SelectMany(x => x.Value.Select(msg => new ErrorModel
                {
                    FieldName = x.Key,
                    ErrorMessage = msg
                })).ToList();
                var response = new ErrorResponse
                {
                    Errors = responseErrors
                };
                context.Result = new BadRequestObjectResult(response);
                return;
            }

            await next();
        }
    }
}
