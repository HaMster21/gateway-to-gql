var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddGraphQLServer();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGraphQL();

app.Run();