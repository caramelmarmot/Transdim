namespace Transdim.DomainModel
{
    public interface IUiModalEvent : IUiEvent
    {
        string Title { get; set; }

        ModalIdentifier ModalIdentifier { get; set; }
    }
}
