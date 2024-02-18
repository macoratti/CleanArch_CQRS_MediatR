using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Filters;

public class CustomExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is FluentValidation.ValidationException validationException)
        {
            var errors = validationException.Errors
                .Select(error => $"{error.PropertyName}: {error.ErrorMessage}")
                .ToList();

            var result = new ObjectResult(new { Errors = errors })
            {
                StatusCode = 400, // Bad Request
            };

            context.Result = result;
            context.ExceptionHandled = true;
        }
        else if (context.Exception is ArgumentNullException ||
                   context.Exception is KeyNotFoundException)
        {
            // Tratar erro 404 (Não Encontrado)
            context.Result = new NotFoundObjectResult(new { Error = "Recurso não encontrado." });
            context.ExceptionHandled = true;
        }
        else if (context.Exception is HttpRequestException ||
                 context.Exception is InvalidOperationException)
        {
            // Tratar erro 500 (Erro Interno do Servidor)
            context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            context.ExceptionHandled = true;
        }
    }
}
