using Spieler.Domain;

namespace Spieler.GraphQL
{
    public class QueryType
    {
        public async Task<IQueryable<KickerSpieler>> KickerSpielers([Service] IKickerSpielerRepository spielerRepository)
        {
            return (await spielerRepository.GetKickerSpieler()).AsQueryable();
        }

        public async Task<KickerSpieler?> KickerSpielerById([Service] IKickerSpielerRepository spielerRepository, string id)
        {
            return await spielerRepository.GetKickerSpielerById(id);
        }
    }
}
