namespace Spieler.Domain
{
    public interface IKickerSpielerRepository
    {
        public Task Add(KickerSpieler spieler);
        public Task<IEnumerable<KickerSpieler>> GetKickerSpieler();
        public Task<KickerSpieler?> GetKickerSpielerById(string id);
    }
}