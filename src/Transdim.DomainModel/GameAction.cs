namespace Transdim.DomainModel
{
    public class GameAction
    {
        public bool IsUndoCheckpoint { get; set; } = false;

        public Player Player { get; set; }

        public string LogText { get; set; }

        public int Points { get; set; }
    }
}
