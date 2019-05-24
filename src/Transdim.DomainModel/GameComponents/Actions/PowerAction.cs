﻿using Transdim.DomainModel.GameComponents.Interfaces;

namespace Transdim.DomainModel.GameComponents.Actions
{
    public class PowerAction : IGameComponent, IPowerActionTaker
    {
        internal const GameComponentIdentifier _Identifier = GameComponentIdentifier.ActionPowerAction;

        internal const string _ImagePath = "/Images/tech-charge-four-power.png";
        
        public PowerAction() { }

        public GameComponentIdentifier Identifier => _Identifier;

        public string ImagePath => _ImagePath;  
    }
}
