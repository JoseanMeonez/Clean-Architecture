using Api;
using Application;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
	.AddPresentation()
	.AddApplicationLayer(builder.Configuration)
	.AddRepositories()
	.AddCors(options =>
	{
		options.AddDefaultPolicy(policy =>
		{
			policy.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
				.AllowAnyHeader()
				.AllowAnyMethod()
				.AllowCredentials();
		});
	})
	.AddDbContext<MainContext>(options =>
	{
		options.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseContext"));
	});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{

}

app.UseErrorHandlingMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
