using InsurancePolicies.Application.Services;
using InsurancePolicies.Application.Services.Interfaces;
using InsurancePolicies.Domain.Interfaces;
using InsurancePolicies.Filters;
using InsurancePolicies.Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var mongoHost = Environment.GetEnvironmentVariable("MONGO_HOST");
var mongoPort = Environment.GetEnvironmentVariable("MONGO_PORT");
var mongoDatabase = Environment.GetEnvironmentVariable("MONGO_DATABASE");
var connectionString = $"mongodb://{mongoHost}:{mongoPort}/";

builder.Services.AddSingleton<IMongoClient>(new MongoClient(connectionString));
builder.Services.AddScoped<IMongoDatabase>(provider =>
{
    var client = provider.GetService<IMongoClient>();
    return client.GetDatabase(mongoDatabase);
});

builder.Services.AddScoped<IInsurancePolicyService, InsurancePolicyService>();
builder.Services.AddScoped<IInsurancePolicyRepository, InsurancePolicyRepository>();

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new CustomExceptionFilter());
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true, 
                ValidateAudience = true, 
                ValidateLifetime = true, 
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("KEY"))),
                ValidIssuer = "https://test.com",
                ValidAudience = "InsurancePolicy"
            };
        });


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Insurance API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });
    c.OperationFilter<AuthenticationRequirementOperationFilter>();
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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
