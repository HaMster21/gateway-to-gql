using Kickern.Domain;
using Kickern.UseCase;

namespace Kickern.GraphQL
{
    public class MutationType
    {
        [UseMutationConvention]
        [GraphQLDescription("Startet ein neues Spiel mit den angegebenen Spielern")]
        public async Task<KickerSpiel> SpielStarten(string spielerRot1ID, string spielerRot2ID, string spielerBlau1ID, string spielerBlau2ID, [Service] SpielStarten spielStarten) => await spielStarten.Execute(spielerRot1ID, spielerRot2ID, spielerBlau1ID, spielerBlau2ID);

        [UseMutationConvention]
        [GraphQLDescription("Die rote Mannschaft hat ein Tor geschossen")]
        [Error(typeof(SpielNichtGefundenException))]
        [Error(typeof(SpielBereitsBeendetException))]
        public async Task<KickerSpiel> TorFuerRot(string spielID, string torschuetzeSpielerID, [Service] TorFuerRot torFuerRot) => await torFuerRot.Execute(spielID, torschuetzeSpielerID);
    }
}
