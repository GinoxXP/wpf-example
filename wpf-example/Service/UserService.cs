using wpf_example.DB.Model;
using wpf_example.DB;
using System.Linq;
using System;
using System.Security.Cryptography;
using System.Text;

namespace wpf_example.Service
{
    public class UserService : IUserService
    {
        public void SignUp(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username))
                throw new Exception("Invalid username");

            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
                throw new Exception("Invalid password");

            using (var context = new ApplicationContext())
            {
                if (context.Users.FirstOrDefault(x => x.Username == username) != null)
                    throw new Exception("Username already exists");

                var salt = Guid.NewGuid().ToString();
                var passwordHash = GenerateSaltedHash(password, salt);

                var user = new User() { Username = username, PasswordHash = passwordHash, Salt = salt};
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public void SignIn(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username))
                throw new Exception("Invalid username");

            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
                throw new Exception("Invalid password");

            using (var context = new ApplicationContext())
            {
                var user = context.Users.FirstOrDefault(x => x.Username == username);

                if (user == null)
                    throw new Exception("User dosn't exists");

                var passwordHasg = GenerateSaltedHash(password, user.Salt);

                if (user.PasswordHash != passwordHasg)
                    throw new Exception("Wrong password");
            }
        }

        private string GenerateSaltedHash(string password, string salt)
        {
            var saltedPassword = $"{password} . {salt}";
            var bytes = Encoding.UTF8.GetBytes(saltedPassword);

            byte[] saltedHash;

            using (SHA512 sha512 = SHA512.Create())
            {
                saltedHash = sha512.ComputeHash(bytes);
            }

            return Encoding.UTF8.GetString(saltedHash);
        }
    }
}
