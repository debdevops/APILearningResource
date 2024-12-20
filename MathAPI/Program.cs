using APIClient;
using MathAPI.Class;
using MathAPI.Controllers;
using MathAPI.ExceptionHandler;
using MathAPI.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using SampleDALEF.DbContext;
using SampleDALEF.Repository;
using SampleDALEF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register IHttpClientWrapper with HttpClient using AddHttpClient
builder.Services.AddHttpClient<APIClient.IHttpClientWrapper, APIClient.HttpClientWrapper>();

// Register IAPIHttpClient with its implementation
builder.Services.AddScoped<APIClient.IAPIHttpClient, APIClient.APIHttpClient>();

// Register other services
builder.Services.AddTransient<IMathCalculations, MathCalculations>();

builder.Services.AddScoped<IConsumeAPI, ConsumeAPI>();

// Register DbContext
builder.Services.AddDbContext<CentralDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Repositories and Unit of Work
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

// Add Health Checks
builder.Services.AddHealthChecks().AddCheck("Example Check", () => HealthCheckResult.Healthy("The check indicates a healthy result."));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/health");

app.Run();

