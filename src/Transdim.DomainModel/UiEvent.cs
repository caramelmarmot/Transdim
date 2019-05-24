using System;

namespace Transdim.DomainModel
{
    public class UiEvent
    {
        public UiEvent(string title, Modal modalToShow)
        {
            Title = title;
            ModalToShow = modalToShow;
        }

        public string Title { get; set; }

        public Modal ModalToShow { get; set; } 
    }
}
