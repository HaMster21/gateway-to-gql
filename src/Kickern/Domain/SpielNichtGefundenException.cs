using Kickern.Domain;

namespace Kickern.UseCase
{
    internal class SpielNichtGefundenException : InteraktionFehlgeschlagenException
    {
        public string SpielID { get; }
        public SpielNichtGefundenException(string spielID) : base($"Es wurde kein Spiel mit der ID {spielID} gefunden", "WoLaufenSieDenn")
        {
            SpielID = spielID;
        }
    }
}
