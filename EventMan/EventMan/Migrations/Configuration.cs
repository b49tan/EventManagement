namespace EventMan.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EventMan.EventManDbEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EventMan.EventManDbEntities context)
        {
            //  This method will be called after migrating to the latest version.


            context.Events.AddOrUpdate(
                e => e.Id,
                new Event { Id = 1, Name = "SQL ka Injection", Description = "Work your minds around sql", Time = DateTime.Parse("2015-10-11 00:00:00"), Url = "google.com" },
                new Event { Id = 2, Name = "Rangrezz", Description = "Folk dance coming soon", Time = DateTime.Parse("2015-10-11 00:00:00"), Url = "google.com" },
                new Event { Id = 3, Name = "Mast Kalandar", Description = "Delicious food", Time = DateTime.Parse("2015-10-11 00:00:00"), Url = "google.com" },
                new Event { Id = 4, Name = "Sangeetam", Description = "Vocal harmony", Time = DateTime.Parse("2015-10-11 00:00:00"), Url = "google.com" },
                new Event { Id = 5, Name = "Shangrila", Description = "Highest abode", Time = DateTime.Parse("2015-10-11 00:00:00"), Url = "google.com" },
                new Event { Id = 6, Name = "Eloquence", Description = "We deb(ate) with eloquence", Time = DateTime.Parse("2015-10-11 00:00:00"), Url = "google.com" },
                new Event { Id = 7, Name = "Bob the coder", Description = "Coding prowess!", Time = DateTime.Parse("2015-10-11 00:00:00"), Url = "google.com" },
                new Event { Id = 8, Name = "GraphicsKings", Description = "Model, World, Viewport!", Time = DateTime.Parse("2015-10-11 00:00:00"), Url = "google.com" },
                new Event { Id = 9, Name = "Programmer's Ink", Description = "Code to glory!", Time = DateTime.Parse("2015-10-11 00:00:00"), Url = "google.com" },
                new Event { Id = 10, Name = "Roboficial", Description = "I am Robot. ", Time = DateTime.Parse("2015-10-11 00:00:00"), Url = "google.com" }
            );

            context.Registrations.AddOrUpdate(
                r => new { r.EventId, r.StakeHolderId },
                new Registration { EventId = 1, StakeHolderId = 0 },
                new Registration { EventId = 1, StakeHolderId = 1 },
                new Registration { EventId = 1, StakeHolderId = 2 },
                new Registration { EventId = 1, StakeHolderId = 3 },
                new Registration { EventId = 1, StakeHolderId = 5 },
                new Registration { EventId = 1, StakeHolderId = 6 },
                new Registration { EventId = 2, StakeHolderId = 1 },
                new Registration { EventId = 2, StakeHolderId = 2 },
                new Registration { EventId = 2, StakeHolderId = 4 },
                new Registration { EventId = 2, StakeHolderId = 5 },
                new Registration { EventId = 2, StakeHolderId = 6 },
                new Registration { EventId = 3, StakeHolderId = 1 },
                new Registration { EventId = 3, StakeHolderId = 2 },
                new Registration { EventId = 3, StakeHolderId = 4 },
                new Registration { EventId = 3, StakeHolderId = 7 },
                new Registration { EventId = 4, StakeHolderId = 1 },
                new Registration { EventId = 4, StakeHolderId = 4 },
                new Registration { EventId = 4, StakeHolderId = 6 },
                new Registration { EventId = 4, StakeHolderId = 8 },
                new Registration { EventId = 7, StakeHolderId = 1 },
                new Registration { EventId = 7, StakeHolderId = 4 },
                new Registration { EventId = 8, StakeHolderId = 1 },
                new Registration { EventId = 8, StakeHolderId = 4 }
            );

            context.Sponsors.AddOrUpdate(
                s => new { s.Id },
                new Sponsor { Id = 1, Name = "Adobe", Description = "Leading Software Co", Mobile = "2314234211", Url = "www.adobe.com" },
                new Sponsor { Id = 2, Name = "Google", Description = "Leading Software Co", Mobile = "2314234211", Url = "www.google.com" },
                new Sponsor { Id = 3, Name = "Microsoft", Description = "Leading Software Co", Mobile = "2314234211", Url = "www.microsoft.com" },
                new Sponsor { Id = 4, Name = "Apple", Description = "Leading Software Co", Mobile = "2314234211", Url = "www.apple.com" },
                new Sponsor { Id = 5, Name = "Snapdeal", Description = "Leading Software Co", Mobile = "2314234211", Url = "www.snapdeal.com" },
                new Sponsor { Id = 6, Name = "Flipkart", Description = "Leading Software Co", Mobile = "2314234211", Url = "www.flipkart.com" },
                new Sponsor { Id = 7, Name = "Expedia", Description = "Leading Software Co", Mobile = "2314234211", Url = "www.expedia.com" },
                new Sponsor { Id = 8, Name = "Morgan Stanley", Description = "Leading Software Co", Mobile = "2314234211", Url = "www.morganstanley.com" }
            );

            context.StakeHolders.AddOrUpdate(
                st => new  { st.Id },
                new StakeHolder { Id = 0, Name = "Sudha", Username = "sudha1", Email = "invalid1@gmail.com", Mobile = 1234514221, Password = "123", Type = 1 },
                new StakeHolder { Id = 1, Name = "Shikha", Username = "shikha1", Email = "invalid2@gmail.com", Mobile = 1234514221, Password = "123", Type = 1 },
                new StakeHolder { Id = 2, Name = "Tanu", Username = "tanu1", Email = "invalid3@gmail.com", Mobile = 1234123311, Password = "123", Type = 2 },
                new StakeHolder { Id = 3, Name = "Nidhi", Username = "nidhi1", Email = "invalid4@gmail.com", Mobile = 1321234121, Password = "123", Type = 2 },
                new StakeHolder { Id = 4, Name = "Paridhi", Username = "paridhi1", Email = "invalid5@gmail.com", Mobile = 1231231231, Password = "123", Type = 2 },
                new StakeHolder { Id = 5, Name = "Ayushi", Username = "ayushi1", Email = "invalid6@gmail.com", Mobile = 2341421341, Password = "123", Type = 1 },
                new StakeHolder { Id = 6, Name = "Ashita", Username = "ashita1", Email = "invalid7@gmail.com", Mobile = 1234514221, Password = "123", Type = 1 },
                new StakeHolder { Id = 7, Name = "Bhawna", Username = "bhawna1", Email = "invalid8@gmail.com", Mobile = 1234514221, Password = "123", Type = 1 },
                new StakeHolder { Id = 9, Name = "Neha", Username = "neha1", Email = "invalid9@gmail.com", Mobile = 1234514221, Password = "123", Type = 1 },
                new StakeHolder { Id = 10, Name = "Renu", Username = "renu1", Email = "invalid10@gmail.com", Mobile = 1234514221, Password = "123", Type = 1 },
                new StakeHolder { Id = 11, Name = "Himani", Username = "himani1", Email = "invalid11@gmail.com", Mobile = 12231434131, Password = "123", Type = 1 }
            );

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
