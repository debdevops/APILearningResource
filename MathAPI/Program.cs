//using APIClient;
//using MathAPI.Class;
//using MathAPI.Controllers;
//using MathAPI.Interface;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<IHttpClientWrapper, HttpClientWrapper>();
//builder.Services.AddScoped<APIClient.APIHttpClient>();
//builder.Services.AddTransient<IMathCalculations, MathCalculations>();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

using APIClient;
using MathAPI.Class;
using MathAPI.Controllers;
using MathAPI.Interface;

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

