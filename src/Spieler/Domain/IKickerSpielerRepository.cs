namespace Spieler.Domain
{
    public interface IKickerSpielerRepository
    {
        public Task Add(KickerSpieler spieler);
        public Task<IQueryable<KickerSpieler>> GetKickerSpieler();
        public Task<KickerSpieler?> GetKickerSpielerById(string id);
    }
}