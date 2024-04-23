using System.Collections.Concurrent;

using Kickern.Domain;

namespace Kickern.Data
{
    public class InMemoryKickerspielRepository : IKickerspielRepository
    {
        private readonly ConcurrentBag<KickerSpiel> _spiele = [];
        public Task Add(KickerSpiel spiel)
        {
            _spiele.Add(spiel);
            return Task.CompletedTask;
        }
    }
}
