using kursa42.Models;
using System.Linq;

namespace kursa42
{
    public static class SampleData
    {
        public static void Initialize(UsersContext context)
        {
            if (!context.User.Any())
            {
                context.User.AddRange(
                    new Users
                    {
                        Email = "Admin",
                        Password = "admin228",
                        Roles = "Admin"
                    },
            new Users
            {
                Email = "Moderator",
                Password = "moder228",
                Roles = "Moderator"
            });
                context.SaveChanges();
            }

        }
    }
}
