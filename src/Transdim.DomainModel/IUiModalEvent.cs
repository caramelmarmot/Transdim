namespace Transdim.DomainModel
{
    public interface IUiModalEvent : IUiEvent
    {
        string Title { get; set; }

        ModalIdentifier ModalToShow { get; set; }
    }
}
