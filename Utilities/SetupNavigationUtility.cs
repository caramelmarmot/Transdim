using Microsoft.AspNetCore.Components;
using System;
using Transdim.DomainModel;

namespace Transdim.Utilities
{
    public class SetupNavigationUtility
    {
        private readonly NavigationManager navigationManager;

        public SetupNavigationUtility(NavigationManager navigationManager) => this.navigationManager = navigationManager ?? throw new ArgumentNullException(nameof(navigationManager));

        public void PreviousStep(Game game)
        {
            if (game.MapLink == null)
            {
                navigationManager.NavigateTo($"/new-game");
            }
            else if (game.TechTrack == null)
            {
                navigationManager.NavigateTo($"/setup/board/{game.Id}");
            }
        }

        public void NextStep(Game game)
        {
            if (game.MapLink == null)
            {
                navigationManager.NavigateTo($"/setup/board/{game.Id}");
            }
            else if (game.TechTrack == null)
            {
                navigationManager.NavigateTo($"/setup/tech/{game.Id}");
            }
            else
            {
                navigationManager.NavigateTo($"/game/{game.Id}");
            }
        }
    }
}
