// Copyright Information
// ==================================
// AutoLot-APIs - AutoLot.Api - CustomExceptionFilterAttribute.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Api.Filters;

public class CustomExceptionFilterAttribute(
    IWebHostEnvironment hostEnvironment) : ExceptionFilterAttribute
{
    public override void OnException(
        ExceptionContext context)
    {
        var ex = context.Exception;

        var statusCode = ex is DbUpdateConcurrencyException ? 400 : 500;
        var title = ex is DbUpdateConcurrencyException ? "Concurrency Issue." : "General Error.";

        var problemDetails =
            new ProblemDetails
            {
                Title = title,
                Detail = ex.Message,
                Status = statusCode
            };

        if (hostEnvironment.IsDevelopment() && !string.IsNullOrWhiteSpace(ex.StackTrace))
        {
            problemDetails.Extensions["stackTrace"] = ex.StackTrace;
            problemDetails.Detail = ex.Message;
        }

        context.Result = new ObjectResult(problemDetails) { StatusCode = statusCode };

        //If this is uncommented, the exception is swallowed
        context.ExceptionHandled = true;
    }
}