namespace ToastmastersGuestBook.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ToastmastersGuestBook.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<ToastmastersGuestBook.DataAccess.GuestDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ToastmastersGuestBook.DataAccess.GuestDbContext context)
        {
            context.Guests.AddOrUpdate(g => g.GuestName,
                new Guest { GuestName = "Jose", GuestEmail = "jcdeveloper7@gmail.com" },
                new Guest { GuestName = "Aarron", GuestEmail = "aaron7@gmail.com" });

            context.SocialNetwork.AddOrUpdate(sn => sn.Name, 
                    new SocialNetwork { Name = "Meetup" },
                    new SocialNetwork { Name = "Facebook" },
                    new SocialNetwork { Name = "Email" });

            context.SaveChanges();

            context.GuestPhoneNumbers.AddOrUpdate(pn => pn.Number, 
                new GuestPhoneNumber { Number = "5598699600", GuestId = context.Guests.First().Id });

            context.GuestSignins.AddOrUpdate(g => g.DateSignin, 
                new GuestSignin {
                    DateSignin  = new DateTime(2018, 9, 23),
                    GuestId     = context.Guests.First().Id
                });
        }
    }
}
