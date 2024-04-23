namespace Spieler.Domain
{
    public class InteraktionFehlgeschlagenException : Exception
    {
        public string Fehlermeldung { get; }
        public string Fehlercode { get; }

        public InteraktionFehlgeschlagenException(string fehlermeldung, string fehlercode)
        {
            Fehlermeldung = fehlermeldung;
            Fehlercode = fehlercode;
        }
    }
}
