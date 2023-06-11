using System.Collections.Generic;
using System.Threading.Tasks;
using ToastmastersGuestBook.Model;

namespace ToastmastersGuestBook.UI.Data.Lookups
{
    public interface IGuestLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetGuestLookupAsync();
    }
}