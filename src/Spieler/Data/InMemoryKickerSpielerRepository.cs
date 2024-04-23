using System.Collections.Concurrent;

using Spieler.Domain;

namespace Spieler.Data
{
    public class InMemoryKickerSpielerRepository : IKickerSpielerRepository
    {
        private readonly ConcurrentBag<KickerSpieler> _spieler = [];

        public Task Add(KickerSpieler spieler)
        {
            _spieler.Add(spieler);
            return Task.CompletedTask;
        }

        public Task<KickerSpieler?> GetKickerSpielerById(string id)
            => Task.FromResult(_spieler.FirstOrDefault(s => s.Id == id));

        public Task<IQueryable<KickerSpieler>> GetKickerSpieler()
            => Task.FromResult(_spieler.AsQueryable());
    }
}
