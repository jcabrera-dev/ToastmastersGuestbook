using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ToastmastersGuestBook.DataAccess;
using ToastmastersGuestBook.Model;

namespace ToastmastersGuestBook.UI.Data.Lookups
{
    public class LookupDataService : IGuestLookupDataService, ISocialNetworkLookupDataService
    {
        private Func<GuestDbContext> _contextCreator;

        public LookupDataService(Func<GuestDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public async Task<IEnumerable<LookupItem>> GetGuestLookupAsync()
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Guests.AsNoTracking()
                    .Select(g =>
                        new LookupItem
                        {
                            Id = g.Id,
                            DisplayGuest = g.GuestName
                        }).ToListAsync();

            }
        }

        public async Task<IEnumerable<LookupItem>> GetSocialNetWorkLookupAsync()
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.SocialNetwork.AsNoTracking().Select(s => new LookupItem
                {
                    Id = s.Id,
                    DisplayGuest = s.Name
                }).ToListAsync();
            }
        }

        public async Task<List<LookupItem>> GetSigninLookupAsync()
        {
            using (var ctx = _contextCreator())
            {
                var items = await ctx.GuestSignins
                                     .AsNoTracking()
                                     .Select(s => 
                                     new LookupItem {
                                         Id = s.Id,
                                         DisplayGuest = s.DateSignin.ToLongDateString()
                }).ToListAsync();

                return items;
            }
        }
    }
}
