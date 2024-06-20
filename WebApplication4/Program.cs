using Microsoft.Azure.Cosmos;
using WebApplication4.Common;
using WebApplication4.Cosmos;
using WebApplication4.Interface;
using WebApplication4.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddSingleton(sp =>
{
    // Retrieve connection details from Credential class
    var cosmosUrl = Credentials.cosmosEndpoint;
    var primaryKey = Credentials.primaryKey;

    if (string.IsNullOrEmpty(cosmosUrl) || string.IsNullOrEmpty(primaryKey))
    {
        throw new InvalidOperationException("CosmosDB connection details are missing");
    }

    // Create and return the CosmosClient instance
    return new CosmosClient(cosmosUrl, primaryKey);
});

builder.Services.AddScoped<StudentInterface,StudentService>();
builder.Services.AddScoped<ICosmosService,CosmosService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
