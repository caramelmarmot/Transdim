using System;

namespace Transdim.DomainModel
{
    public class UiModalEvent : IUiModalEvent
    {
        public UiModalEvent(string title, ModalIdentifier modalToShow)
        {
            Title = title;
            ModalToShow = modalToShow;
        }

        public string Title { get; set; }

        public ModalIdentifier ModalToShow { get; set; } 
    }
}
