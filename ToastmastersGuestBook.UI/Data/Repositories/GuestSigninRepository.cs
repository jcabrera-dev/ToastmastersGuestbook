using System.Threading.Tasks;
using ToastmastersGuestBook.DataAccess;
using ToastmastersGuestBook.Model;
using ToastmastersGuestBook.UI.Data.Respositories;
using System.Data.Entity;

namespace ToastmastersGuestBook.UI.Data.Repositories
{
    public class GuestSigninRepository : GenericRepository<GuestSignin, GuestDbContext>, IGuestSigninRepository
    {
        protected GuestSigninRepository(GuestDbContext context) : base(context)
        {
        }

        public async override Task<GuestSignin> GetByIdAsync(int id)
        {
            return await Context.GuestSignins
                                .Include(g => g.Guest)
                                .SingleAsync(g => g.Id == id);
        }
    }
}
