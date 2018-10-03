namespace Transdim.DomainModel
{
    public class GameAction
    {
        public Player Player { get; set; }

        public Player NextToPlay { get; set; }

        public string LogText { get; set; }
    }
}
