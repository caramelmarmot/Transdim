using System;

namespace Transdim.DomainModel
{
    public class UiModalEvent : IUiModalEvent
    {
        public UiModalEvent(string title, Modal modalToShow)
        {
            Title = title;
            ModalToShow = modalToShow;
        }

        public string Title { get; set; }

        public Modal ModalToShow { get; set; } 
    }
}
