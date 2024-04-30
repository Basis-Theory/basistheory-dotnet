using BasisTheory.net.Common.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace BasisTheory.net.AspNetCore
{
    public class BasisTheoryExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; set; } = int.MaxValue - 10;

        private readonly ILogger<BasisTheoryExceptionFilter> _logger;

        public BasisTheoryExceptionFilter(ILogger<BasisTheoryExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception == null || context.ExceptionHandled) return;

            _logger.LogError(context.Exception, "An error occurred processing the request");

            if (!(context.Exception is BasisTheoryException exception)) return;

            context.Result = new ObjectResult(exception.Error)
            {
                StatusCode = (int)exception.HttpStatusCode
            };
            context.ExceptionHandled = true;
        }
    }
}
