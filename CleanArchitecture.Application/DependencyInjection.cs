using Application.Behaviors;
using Application.Settings;
using Application.Wrappers;
using FluentValidation;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Application;

public static class DependencyInjection
{
	/// <summary>
	///		This inject the repositories
	/// </summary>
	/// <param name="services"></param>
	/// <param name="configuration"></param>
	/// <returns></returns>
	public static IServiceCollection AddRepositories(this IServiceCollection services)
	{
		services.AddScoped<ICustomerRepository, CustomerRepository>();

		return services;
	}

	/// <summary>
	///		This inject the main application depencies
	/// </summary>
	/// <param name="services"></param>
	/// <param name="configuration"></param>
	/// <returns></returns>
	public static IServiceCollection AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
	{
		// Adding dependencies
		services.AddMapster();
		services.AddMediatR(m => m.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
		services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), includeInternalTypes: true);
		services.AddTransient(
			typeof(IPipelineBehavior<,>),
			typeof(ValidationBehavior<,>));

		// Configurations
		services.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));
		services.Configure<MailSettings>(configuration.GetSection("MailSettings"));

		// Services

		// Authentication
		services.AddAuthorization();
		services.AddAuthentication(options =>
		{
			options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
		})
		.AddJwtBearer(options =>
		{
			string key = configuration["JWTSettings:Key"]!;
			SymmetricSecurityKey signingKey = new(Encoding.UTF8.GetBytes(key));

			options.RequireHttpsMetadata = false;
			options.SaveToken = false;
			options.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidateLifetime = true,
				ClockSkew = TimeSpan.Zero,
				ValidIssuer = configuration["JWTSettings:Issuer"],
				ValidAudience = configuration["JWTSettings:Audience"],
				IssuerSigningKey = signingKey,
			};

			// Events
			options.Events = new JwtBearerEvents()
			{
				// Action when auth fail
				OnAuthenticationFailed = context =>
				{
					context.NoResult();
					context.Response.StatusCode = StatusCodes.Status401Unauthorized;
					context.Response.ContentType = "application/json";

					return Task.CompletedTask;
				},
				// When action is unauthorized
				OnChallenge = context =>
				{
					context.HandleResponse();
					if (!context.Response.HasStarted)
					{
						context.Response.StatusCode = StatusCodes.Status401Unauthorized;
						context.Response.ContentType = "application/json";
					}

					string result = JsonSerializer.Serialize(new Response<string>("Usted no esta autorizado para ejecutar esta acción"));
					return context.Response.WriteAsync(result);
				},
				// When the action is forbidden
				OnForbidden = context =>
				{
					context.Response.StatusCode = StatusCodes.Status403Forbidden;
					context.Response.ContentType = "application/json";

					string result = JsonSerializer.Serialize(new Response<string>("Debe iniciar sesión para ejecutar esta acción"));
					return context.Response.WriteAsync(result);
				}
			};
		});

		return services;
	}
}
