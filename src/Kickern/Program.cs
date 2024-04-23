using Kickern.Data;
using Kickern.Domain;
using Kickern.GraphQL;
using Kickern.UseCase;

namespace Kickern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<IKickerspielRepository, InMemoryKickerspielRepository>();
            
            builder.Services.AddScoped<SpielStarten>();

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
