using System.Threading.Tasks;

namespace ToastmastersGuestBook.UI.Data.Respositories
{
    public interface IGenericRepositoy<T>
    {
        Task<T> GetByIdAsync(int id);
        Task SaveAsync();
        bool HasChanges();
        void Add(T model);
        void Remove(T model);
    }
}