using System.Collections.Concurrent;

using HotChocolate.Language;

using Kickern.Domain;

namespace Kickern.Data
{
    public class InMemoryKickerspielRepository : IKickerspielRepository
    {
        private readonly ConcurrentDictionary<string, KickerSpiel> _spiele = [];
        public Task Add(KickerSpiel spiel)
        {
            _spiele.TryAdd(spiel.Id, spiel);
            return Task.CompletedTask;
        }

        public async Task<KickerSpiel?> GetSpielById(string id)
            => _spiele.TryGetValue(id, out var spiel) ? spiel : null;

        public Task<IQueryable<KickerSpiel>> GetSpiele()
            => Task.FromResult(_spiele.Select(eintrag => eintrag.Value).AsQueryable());

        public Task UpdateSpiel(KickerSpiel spiel)
        {
            if (_spiele.TryGetValue(spiel.Id, out var stored))
            {
                _spiele.TryUpdate(spiel.Id, spiel, stored);
            }

            return Task.CompletedTask;
        }
    }
}
