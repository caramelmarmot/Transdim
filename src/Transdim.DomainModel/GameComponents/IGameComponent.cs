﻿namespace Transdim.DomainModel.GameComponents
{
    public interface IGameComponent
    {
        GameComponentIdentifier Identifier { get; }

        string ImagePath { get; }

        void OnActivate(Game game);
    }
}
