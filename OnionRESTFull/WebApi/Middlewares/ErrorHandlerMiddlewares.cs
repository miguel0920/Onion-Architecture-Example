using Application.Wrappers;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace WebApi.Middlewares
{
    public class ErrorHandlerMiddlewares
    {
        public ErrorHandlerMiddlewares(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = MediaTypeNames.Application.Json;
                var responseModel = new Response<string> { Succeeded = false, Message = ex?.Message };

                switch (ex)
                {
                    case Application.Exceptions.ApiException e:
                        response.StatusCode = HttpStatusCode.BadRequest.GetHashCode();
                        break;
                    case Application.Exceptions.ValidationException e:
                        response.StatusCode = HttpStatusCode.BadRequest.GetHashCode();
                        responseModel.Errors = e.Errors.Errors;
                        break;
                    case KeyNotFoundException e:
                        response.StatusCode = HttpStatusCode.NotFound.GetHashCode();
                        break;
                    default:
                        response.StatusCode = HttpStatusCode.InternalServerError.GetHashCode();
                        break;
                }

                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }

        private readonly RequestDelegate _requestDelegate;
    }
}