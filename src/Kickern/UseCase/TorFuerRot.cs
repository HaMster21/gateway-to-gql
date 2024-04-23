using System.Runtime.Serialization;

using Kickern.Domain;

namespace Kickern.UseCase
{
    public class TorFuerRot(IKickerspielRepository kickerspielRepository)
    {
        public async Task<KickerSpiel> Execute(string spielID, string torschuetzeSpielerID)
        {
            var spiel = await kickerspielRepository.GetSpielById(spielID);

            if (spiel is null)
            {
                throw new SpielNichtGefundenException(spielID);
            }

            if (spiel.endzeit is not null)
            {
                throw new SpielBereitsBeendetException(spielID, spiel.endzeit.Value);
            }

            spiel = spiel with
            {
                punkteRot = spiel.punkteRot + 1
            };

            if (spiel.punkteRot >= 10)
            {
                spiel = spiel with { endzeit = DateTimeOffset.Now };
            }

            await kickerspielRepository.UpdateSpiel(spiel);

            return spiel;
        }
    }
}
