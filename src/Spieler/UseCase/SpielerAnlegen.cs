using Spieler.Domain;

namespace Spieler.UseCase
{
    public class SpielerAnlegen(IKickerSpielerRepository spielerRepository)
    {
        internal static bool NameGültigValidation(string name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }

        public async Task<KickerSpieler> Execute(string name)
        {
            if (!NameGültigValidation(name))
            {
                throw new SpielernameUngueltigException($"{name} ist ungültig weil er leer ist oder aus Leerzeichen besteht");
            }

            var spieler = new KickerSpieler
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
            };

            await spielerRepository.Add(spieler);

            return spieler;
        }
    }

    public interface ISpielerAnlegenFehler
    {
        public string Fehlermeldung { get; }
        public string Fehlercode { get; }
    }

    public class SpielernameUngueltigException : InteraktionFehlgeschlagenException, ISpielerAnlegenFehler
    {
        public SpielernameUngueltigException(string fehlermeldung) : base(fehlermeldung, "WhoAmI")
        {
        }
    }
}
