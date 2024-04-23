using Kickern.Domain;

namespace Kickern.UseCase
{
    internal class SpielBereitsBeendetException : InteraktionFehlgeschlagenException
    {
        public string SpielID { get; }
        public DateTimeOffset Endzeit { get; }

        public SpielBereitsBeendetException(string spielID, DateTimeOffset endzeit) : base($"Das Spiel mit der ID {spielID} ist bereits beendet und es können keine Tore mehr erfasst werden", "KeineToreNichtSenden")
        {
            SpielID = spielID;
            Endzeit = endzeit;
        }
    }
}
