using Spieler.Data;
using Spieler.Domain;
using Spieler.GraphQL;
using Spieler.UseCase;

namespace Spieler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<IKickerSpielerRepository, InMemoryKickerSpielerRepository>();
            builder.Services.AddScoped<SpielerAnlegen>();

            builder.Services.AddGraphQLServer()
                            .AddQueryType<QueryType>()
                            .AddMutationType<MutationType>()
                            .AddMutationConventions(applyToAllMutations: false);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapGraphQL();

            app.Run();
        }
    }
}
