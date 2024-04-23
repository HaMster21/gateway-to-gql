using System.Net;

using gateway;
using gateway.GraphQL;

using Polly;
using Polly.Extensions.Http;

static IAsyncPolicy<HttpResponseMessage> DefaultRetryPolicy()
    => HttpPolicyExtensions.HandleTransientHttpError()
                           .OrResult(msg => msg.StatusCode == HttpStatusCode.NotFound)
                           .OrResult(msg => msg.StatusCode == HttpStatusCode.BadGateway)
                           .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient(ServiceSchemas.Spieler.ServiceName, c => c.BaseAddress = ServiceSchemas.Spieler.SchemaEndpoint)
                .SetHandlerLifetime(TimeSpan.FromSeconds(3))
                .AddPolicyHandler(DefaultRetryPolicy());

builder.Services.AddGraphQLServer()
                .AddRemoteSchema(ServiceSchemas.Spieler.ServiceName);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGraphQL();

app.Run();