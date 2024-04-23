namespace Kickern.Domain
{
    public interface IKickerspielRepository
    {
        public Task Add(KickerSpiel spiel);
    }
}