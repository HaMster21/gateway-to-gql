using gateway.GraphQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddGraphQLServer()
                .AddQueryType<QueryType>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGraphQL();

app.Run();