using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ToastmastersGuestBook.Model;

namespace ToastmastersGuestBook.DataAccess
{
    public class GuestDbContext:DbContext
    {
        public GuestDbContext():base("ToastmastersGuestBookDb")
        {

        }

        public DbSet<Guest> Guests { get; set; }

        public DbSet<SocialNetwork> SocialNetwork { get; set; }

        public DbSet<GuestPhoneNumber> GuestPhoneNumbers { get; set; }

        public DbSet<GuestSignin> GuestSignins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
