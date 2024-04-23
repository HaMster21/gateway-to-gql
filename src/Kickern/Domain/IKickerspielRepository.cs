namespace Kickern.Domain
{
    public interface IKickerspielRepository
    {
        public Task Add(KickerSpiel spiel);
        public Task<KickerSpiel?> GetSpielById(string id);
        public Task<IQueryable<KickerSpiel>> GetSpiele();
    }
}