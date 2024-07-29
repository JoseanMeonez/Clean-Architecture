using Application.Exceptions;
using Application.Wrappers;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Api;

public class ErrorHandlerMiddleware(RequestDelegate next)
{
	public async Task Invoke(HttpContext context)
	{
		try
		{
			await next(context);
		}
		catch (Exception error)
		{
			var response = context.Response;
			response.ContentType = "application/json";
			var responseModel = new Response<string>()
			{
				Succeeded = false,
				Message = error.Message,
			};

			switch (error)
			{
				// Custom application api error
				case ApiException e:
					response.StatusCode = StatusCodes.Status400BadRequest;
					break;

				// Custom application error
				case ValidationException e:
					response.StatusCode = StatusCodes.Status400BadRequest;
					responseModel.Errors = e.Errors;
					break;

				// Unathorized exception
				case InvalidOperationException:
					response.StatusCode = StatusCodes.Status401Unauthorized;
					break;

				// Forbidden exception
				case HttpRequestException e:
					response.StatusCode = StatusCodes.Status403Forbidden;
					break;

				// Not found error
				case KeyNotFoundException:
					response.StatusCode = StatusCodes.Status404NotFound;
					break;

				// Database error
				case DbUpdateException:
					responseModel.Message = "Ha ocurrido un error con la base de datos.";
					response.StatusCode = StatusCodes.Status500InternalServerError;
					break;

				// Unhandled error
				default:
					responseModel.Message = "Ha ocurrido un error al realizar esta acción.";
					response.StatusCode = StatusCodes.Status500InternalServerError;
					break;
			}

			var result = JsonSerializer.Serialize(responseModel);

			await response.WriteAsync(result);
		}
	}
}
