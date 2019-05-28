namespace Transdim.DomainModel
{
    public interface IUiModalEvent : IUiEvent
    {
        string Title { get; set; }

        Modal ModalToShow { get; set; }
    }
}
