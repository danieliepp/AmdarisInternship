using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MovieZone.API.Exeptions
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ApiException apiExeption)
            {
                context.Result = new JsonResult(apiExeption.Message) { StatusCode = (int)apiExeption.StatusCode };
            }
        }
    }
}
