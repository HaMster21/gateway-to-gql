using Kickern.Domain;

namespace Kickern.UseCase
{
    public class SpielStarten(IKickerspielRepository kickerspielRepository)
    {
        public async Task<KickerSpiel> Execute(string spielerRot1ID, string spielerRot2ID, string spielerBlau1ID, string spielerBlau2ID)
        {
            var spiel = new KickerSpiel()
            {
                Id = Guid.NewGuid().ToString(),
                spielerBlau1ID = spielerBlau1ID,
                spielerBlau2ID = spielerBlau2ID,
                spielerRot1ID = spielerRot1ID,
                spielerRot2ID = spielerRot2ID,
                punkteBlau = 0,
                punkteRot = 0,
                startzeit = DateTimeOffset.Now,
            };

            await kickerspielRepository.Add(spiel);

            return spiel;
        }
    }
}
