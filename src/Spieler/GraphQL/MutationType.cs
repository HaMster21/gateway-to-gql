using Spieler.Domain;
using Spieler.UseCase;

namespace Spieler.GraphQL
{
    public class MutationType
    {
        [UseMutationConvention]
        [GraphQLDescription("Erstellt einen neuen Spieler mit dem angegebenen Namen")]
        [Error(typeof(SpielernameUngueltigException))]
        [Error(typeof(SpielernameExistiertBereitsException))]
        public async Task<KickerSpieler> CreateSpieler([Service] SpielerAnlegen logic, string name) => await logic.Execute(name);
    }
}
