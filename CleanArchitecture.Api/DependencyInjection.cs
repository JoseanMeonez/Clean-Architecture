using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace Api;

public static class DependencyInjection
{
	/// <summary>
	///		Injects the error handler middleware
	/// </summary>
	/// <param name="app"></param>
	public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
	{
		app.UseMiddleware<ErrorHandlerMiddleware>();
	}

	/// <summary>
	///		Shows information about the application and adds the authentication with JWT in swagger
	/// </summary>
	/// <param name="services"></param>
	/// <returns></returns>
	public static IServiceCollection AddPresentation(this IServiceCollection services)
	{
		services.AddControllers();
		services.AddEndpointsApiExplorer();

		OpenApiInfo openApi = new OpenApiInfo
		{
			Title = "PSI",
			Version = "v1",
			Description = "API para aplicación de PSI.",
			Contact = new OpenApiContact
			{
				Name = "Contacto",
				Url = new Uri("https://github.com/JoseanMeonez")
			}
		};

		services.AddSwaggerGen(opt =>
		{
			openApi.Version = "v1";
			opt.SwaggerDoc("v1", openApi);

			OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme
			{
				Name = "JWT Authentication",
				Description = "JWT Bearer Token",
				In = ParameterLocation.Header,
				Type = SecuritySchemeType.Http,
				Scheme = "Bearer",
				BearerFormat = "JWT",
				Reference = new OpenApiReference
				{
					Id = JwtBearerDefaults.AuthenticationScheme,
					Type = ReferenceType.SecurityScheme
				}
			};

			opt.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
			opt.AddSecurityRequirement(new OpenApiSecurityRequirement
			{
					{ securityScheme, Array.Empty<string>() }
			});
		});

		services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

		return services;
	}
}
