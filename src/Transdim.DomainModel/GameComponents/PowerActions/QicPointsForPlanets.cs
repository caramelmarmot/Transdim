namespace Transdim.DomainModel.GameComponents.PowerActions
{
    public class QicPointsForPlanets : IGameComponent
    {
        internal const GameComponentIdentifier _Identifier = GameComponentIdentifier.PowerActionQicPointsForPlanets;

        internal const string _ImagePath = "/Images/power-action-qic-points-for-planets.png";

        public QicPointsForPlanets() { }

        public GameComponentIdentifier Identifier => _Identifier;

        public string ImagePath => _ImagePath;

        public void OnActivate(Game game)
        {
            var activePlayer = game.ActivePlayer;

            game.GameActions.Add(new GameAction
            {
                Player = activePlayer,
                Points = 0,
                // TODO: What if this is the Hadsch Hallas? FactionIdentifier can't have spaces.
                LogText = $"{activePlayer.FactionIdentifier} is taking a power action..."
            });
        }

    }
}
