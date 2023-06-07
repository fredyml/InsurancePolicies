using InsurancePolicies.Domain;
using InsurancePolicies.Infrastructure;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Configuración de la conexión a MongoDB desde variables de entorno
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

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
