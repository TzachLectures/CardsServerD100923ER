using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CardsServerD100923ER.Application.Filters
{
    public class ValidateModelFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var validationErrors = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "One or more validation errors occurred.",
                };

                context.Result = new BadRequestObjectResult(validationErrors);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // No action needed after the execution
        }
    }
}
