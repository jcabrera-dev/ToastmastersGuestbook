using System.Data.Entity;
using System.Threading.Tasks;
using ToastmastersGuestBook.DataAccess;
using ToastmastersGuestBook.Model;

namespace ToastmastersGuestBook.UI.Data.Respositories
{
    public class GuestRespository : GenericRepository<Guest, GuestDbContext>, IGuestRespository
    {
        private GuestDbContext _context;

        public GuestRespository(GuestDbContext context) : base(context)
        {
            _context = context;
        }

        // Load data from a real database and using async
        public override async Task<Guest> GetByIdAsync(int guestId)
        {
            return await Context.Guests
                                .Include(g => g.GuestNumbers)
                                .Include(p => p.GuestDateSignins)
                                .SingleAsync(g => g.Id == guestId);
        }
        
        public void RemovePhoneNumber(GuestPhoneNumber model)
        {
            Context.GuestPhoneNumbers.Remove(model);
        }

        
    }
}
