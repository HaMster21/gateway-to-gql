namespace Kickern.Domain
{
    public record KickerSpiel
    {
        public string Id { get; init; }
        public string spielerBlau1ID { get; init; }
        public string spielerBlau2ID { get; init; }
        public string spielerRot1ID { get; init; }
        public string spielerRot2ID { get; init; }
        public int punkteBlau { get; init; }
        public int punkteRot { get; init; }
        public DateTimeOffset startzeit { get; init; }
        public DateTimeOffset? endzeit { get; init; }
    }
}