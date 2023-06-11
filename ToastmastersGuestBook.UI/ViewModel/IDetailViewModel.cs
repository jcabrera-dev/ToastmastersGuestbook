using System.Threading.Tasks;

namespace ToastmastersGuestBook.UI.ViewModel
{
    public interface IDetailViewModel
    {
        Task LoadAsync(int? id);

        bool HasChanges { get; }
    }
}