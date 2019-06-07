using System;

namespace Transdim.DomainModel
{
    public class UiModalEvent : IUiModalEvent
    {
        public UiModalEvent(string title, ModalIdentifier modalIdentifier, ModalParameters modalParameters = null)
        {
            Title = title;
            ModalIdentifier = modalIdentifier;
            ModalParameters = modalParameters;
        }

        public string Title { get; set; }

        public ModalIdentifier ModalIdentifier { get; set; }

        // To use the ModalParameters that you send in, your consuming modal must have the following parameter:
        // 
        // [CascadingParameter]
        // public ModalParameters Parameters { get; set; }
        public ModalParameters ModalParameters { get; set; }
    }
}
