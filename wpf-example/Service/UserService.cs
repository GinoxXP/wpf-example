using wpf_example.DB.Model;
using wpf_example.DB;
using System.Linq;
using System;

namespace wpf_example.Service
{
    public class UserService
    {
        public void Create(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username))
                throw new Exception("Invalid username");

            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
                throw new Exception("Invalid password");

            using (var context = new ApplicationContext())
            {
                if (context.Users.FirstOrDefault(x => x.Username == username) != null)
                    throw new Exception("Username already exists");

                var user = new User() { Username = username, Password = password };
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}
