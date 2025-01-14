using System.Net;
using System.Text.Json;
using GoNet.Dto__DataTransferObject_;

namespace GoNet.Middlewares
{
    public class ExeptionHandlingMiddleware
    {
        // обрабатывает http запрос
        private readonly RequestDelegate _next; 
        private readonly ILogger<ExeptionHandlingMiddleware> _logger;

        // получим с ди контейнера
        public ExeptionHandlingMiddleware(RequestDelegate next, ILogger<ExeptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        // будем принимать хттп контекст запроса,этот метод будет вызван в цепочке вызовов пайнплайн дот нет, любые необработанные исключения будут падать сюда
        public async Task InvokeAsync(HttpContext httpContext)
        {
            
            try
            {
                // вызовем RequestDelegate, иначе мы разорвем цепочку вызовов
                await _next(httpContext);
            }
            catch (KeyNotFoundException ex)
            {
                await HandleExeptionAsync(httpContext, ex.Message, HttpStatusCode.NotFound, $"It's impossible, but no found object");
            }
            catch (Exception ex)
            {

                await HandleExeptionAsync(httpContext, ex.Message, HttpStatusCode.BadRequest, $"Exeption");
            }
        }

        private async Task HandleExeptionAsync(HttpContext context,
                                                string exMsg,
                                                HttpStatusCode httpStatusCode,
                                                string message)
        {
            _logger.LogError(exMsg);

            HttpResponse response = context.Response;

            response.ContentType = "application/json";
            response.StatusCode = (int)httpStatusCode;

            ErrorDto errorDto = new()
            {
                Message = message,
                StatusCode = (int)httpStatusCode
            };

            string result = JsonSerializer.Serialize(errorDto);
            await response.WriteAsJsonAsync(result);
        }

    }
}
