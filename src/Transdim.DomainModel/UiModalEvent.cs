using System;

namespace Transdim.DomainModel
{
    public class UiModalEvent : IUiModalEvent
    {
        public UiModalEvent(string title, ModalIdentifier modalIdentifier)
        {
            Title = title;
            ModalIdentifier = modalIdentifier;
        }

        public string Title { get; set; }

        public ModalIdentifier ModalIdentifier { get; set; } 
    }
}
