using System.Threading.Tasks;
using Transdim.DomainModel;

namespace Transdim.Service.Services
{
    public interface IQueueManagementService
    {
        void AddImmediate(IUiEvent uiEvent);

        void Add(IUiEvent uiEvent);

        void AddFinal(IUiEvent uiEvent);

        IUiEvent TakeNextEvent();

        IUiEvent PreviewNextEvent();

        Task Execute();
    }
}