using Microsoft.AspNetCore.Blazor.Services;
using System;
using Transdim.DomainModel;

namespace Transdim.Utilities
{
    public class SetupNavigationUtility
    {
        private readonly IUriHelper uriHelper;

        public SetupNavigationUtility(IUriHelper uriHelper) => this.uriHelper = uriHelper ?? throw new ArgumentNullException(nameof(uriHelper));

        public void PreviousStep(Game game)
        {
            if (game.MapLink == null)
            {
                uriHelper.NavigateTo($"/new-game/");
            }
            else if (game.IsTechSetUp == false)
            {
                uriHelper.NavigateTo($"/setup/board/{game.Id}");
            }
        }

        public void NextStep(Game game)
        {
            if (game.MapLink == null)
            {
                uriHelper.NavigateTo($"/setup/board/{game.Id}");
            }
            else if (game.IsTechSetUp == false)
            {
                uriHelper.NavigateTo($"/setup/tech/{game.Id}");
            }
        }
    }
}
