using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using Omegahash.Api.Middlewares;
using Omegahash.Endpoints.Marketings.RegisterToNewsletter;
using Omegahash.Infrastructure;
using Omegahash.Infrastructure.Data;
using Omegahash.Options;

var builder = WebApplication.CreateBuilder(args);

var mongo = builder.Configuration.GetSection(nameof(Mongo)).Get<Mongo>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IMongoClient>(new MongoClient(mongo?.ConnectionString));
builder.Services.AddSwaggerGenNewtonsoftSupport();
builder.Services.AddProblemDetails();
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

builder.Services.AddInfrastructureData();
builder.Services.AddInfrastructure();

builder.Services.AddSwaggerGen(c => new OpenApiInfo
{
    Version = "v1",
    Title = "Omegahash API",
    Description = "An ASP.NET Core Web API for managing Omegahash",
    TermsOfService = new Uri("https://omegahash.app/terms"),
    Contact = new OpenApiContact
    {
        Name = "Omegahash Contact",
        Url = new Uri("https://omegahash.com/contact")
    },
    License = new OpenApiLicense
    {
        Name = "Omegahash License",
        Url = new Uri("https://omegahash.com/license")
    }
});

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "OmegahashAPI V1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapNewsletterInsert();

app.Run();
