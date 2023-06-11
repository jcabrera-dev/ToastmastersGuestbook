using ToastmastersGuestBook.Model;

namespace ToastmastersGuestBook.UI.Data.Respositories
{
    public interface IGuestRespository:IGenericRepositoy<Guest>
    {
        void RemovePhoneNumber(GuestPhoneNumber model);
    }
}