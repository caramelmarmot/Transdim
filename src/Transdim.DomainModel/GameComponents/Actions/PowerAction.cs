using System;
using System.Collections.Generic;
using System.Text;

namespace Transdim.DomainModel.GameComponents.Actions
{
    public class PowerAction : IGameComponent
    {
        internal const string _ImagePath = "/Images/tech-charge-four-power.png";

        public PowerAction() { }

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
