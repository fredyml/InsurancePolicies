using InsurancePolicies.Domain.Interfaces;
using InsurancePolicies.Filters;
using InsurancePolicies.Infrastructure.Repository;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

var mongoHost = Environment.GetEnvironmentVariable("MONGO_HOST");
var mongoPort = Environment.GetEnvironmentVariable("MONGO_PORT");
var mongoDatabase = Environment.GetEnvironmentVariable("MONGO_DATABASE");
var connectionString = $"mongodb://{mongoHost}:{mongoPort}";
builder.Services.AddSingleton<IMongoClient>(new MongoClient(connectionString));
builder.Services.AddScoped<IMongoDatabase>(provider =>
{
    var client = provider.GetService<IMongoClient>();
    return client.GetDatabase(mongoDatabase);
});

builder.Services.AddScoped<IInsurancePolicyRepository, InsurancePolicyRepository>();

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new CustomExceptionFilter());
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Insurance API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    
    app.UseSwagger();
    
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Insurance API V1");
    });
}

app.UseHttpsRedirection();
app.UseRouting();

//app.UseAuthorization();

app.MapControllers();

app.Run();
