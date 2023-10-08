using Auth_Bearer_JWT.Models;

namespace Auth_Bearer_JWT.Repositories
{
    public class UserRepository
    {
        public static User? Get(string name, string password)
        {
            List<User> users = new()
            {
                new User()
                {
                    UserId = 1,
                    Name = "Batman",
                    Password = "batman123",
                    Role = "boss"
                },

                new User()
                {
                    UserId = 2,
                    Name = "Robin",
                    Password = "robin123",
                    Role = "employee"
                },

                new User()
                {
                    UserId = 3,
                    Name = "Coringa",
                    Password = "coringa123",
                    Role = "blocked"
                }
            };

            return users.FirstOrDefault(x =>
                                        x.Name.ToLower() == name.ToLower() &&
                                        x.Password == password);
        }
    }
}
