﻿using System;
using Transdim.DomainModel;

namespace Transdim.Service.Services.Modal
{
    internal class ModalService : IModalService
    {
        public event Action<string, ModalIdentifier, ModalParameters> OnShow;

        public event Action<ModalResult> BeforeClose;

        public event Action<ModalResult> OnClose;

        public void Show(string title, ModalIdentifier modalIdentifier)
        {
            Show(title, modalIdentifier, new ModalParameters());
        }

        public void Show(string title, ModalIdentifier modalIdentifier, ModalParameters parameters)
        {
            OnShow?.Invoke(title, modalIdentifier, parameters);
        }

        public void Close(ModalResult modalResult)
        {
            BeforeClose?.Invoke(modalResult);
            OnClose?.Invoke(modalResult);
        }
    }
}