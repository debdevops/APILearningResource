using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MathAPI.ExceptionHandler
{
    /// <summary>
    /// Global exception handler
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Diagnostics.IExceptionHandler" />
    internal sealed class GlobalExceptionHandler : IExceptionHandler
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<GlobalExceptionHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalExceptionHandler"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Tries to handle the specified exception asynchronously within the ASP.NET Core pipeline.
        /// Implementations of this method can provide custom exception-handling logic for different scenarios.
        /// </summary>
        /// <param name="httpContext">The <see cref="T:Microsoft.AspNetCore.Http.HttpContext" /> for the request.</param>
        /// <param name="exception">The unhandled exception.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// A task that represents the asynchronous read operation. The value of its <see cref="P:System.Threading.Tasks.ValueTask`1.Result" />
        /// property contains the result of the handling operation.
        /// <see langword="true" /> if the exception was handled successfully; otherwise <see langword="false" />.
        /// </returns>
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, 
                    Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, exception.Message);
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Detail = exception.Message,
                Title = "Internal server error"
            };
            httpContext.Response.StatusCode = problemDetails.Status.Value;

            await httpContext.Response.WriteAsJsonAsync(problemDetails, 
                            cancellationToken);
            return true;
        }
    }
}
