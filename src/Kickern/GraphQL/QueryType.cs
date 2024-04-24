using Kickern.Domain;

namespace Kickern.GraphQL
{
    public class QueryType
    {
        public async Task<IQueryable<KickerSpiel>> LaufendeSpiele([Service] IKickerspielRepository kickerspielRepository) => (await kickerspielRepository.GetSpiele()).Where(spiel => !spiel.endzeit.HasValue);
    }
}
