using Mc2.CrudTest.Presentation.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Mc2.CrudTest.Presentation.Server;

public static class ExceptionFilter
{
    public static void UseExceptionFilter(this WebApplication app)
    {
        app.UseExceptionHandler(builder
            => builder.Run(async httpContext =>
            {
                var exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error!;
                var result = Results.Problem(statusCode: StatusCodes.Status500InternalServerError);

                switch (exception)
                {
                    case ValidationFailureException validationFailureException:
                        result = Results.ValidationProblem(validationFailureException.Failures);
                        break;
                }

                await result.ExecuteAsync(httpContext);
            }));
    }
}
