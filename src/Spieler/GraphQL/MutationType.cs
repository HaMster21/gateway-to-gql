using Spieler.Domain;
using Spieler.UseCase;

namespace Spieler.GraphQL
{
    public class MutationType
    {
        [UseMutationConvention]
        [Error(typeof(SpielernameUngueltigException))]
        public async Task<KickerSpieler> CreateSpieler([Service] SpielerAnlegen logic, string name) => await logic.Execute(name);
    }
}
