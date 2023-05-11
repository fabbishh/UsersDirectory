using UsersDirectory.API.Entities;

namespace UsersDirectory.API
{
    public static class SeedData
    {
        public static void Initialize(UserDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }

            var users = new User[]
            {
                new User { Id = 1, FirstName = "Lari", LastName = "Byrd", MiddleName = "Connor", AdLogin = "l.byrd" },
                new User { Id = 2, FirstName = "sdgs", LastName = "Bywerd", MiddleName = "Cewwer", AdLogin = "e.ewdeg" },
                new User { Id = 3, FirstName = "alex", LastName = "pain", MiddleName = "rain", AdLogin = "gain" },
                new User { Id = 4, FirstName = "soul", LastName = "reer", MiddleName = "ergeaa", AdLogin = "l.bvvc" },
                new User { Id = 5, FirstName = "hjlh", LastName = "dfdfh", MiddleName = "vbmvbm", AdLogin = "h.sdfsd" },
                new User { Id = 6, FirstName = "erreeh", LastName = "Bdffyrd", MiddleName = "jhjhk", AdLogin = "l.iliul"}
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
