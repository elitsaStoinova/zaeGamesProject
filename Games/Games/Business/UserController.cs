using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Games.Data.Models;

namespace Games.Business
{
    public class UserController
    {
        private GamesContext context;

        private User logInUser;

        public User LogInUser
        {
            get { return logInUser; }
            set { logInUser = value; }
        }
        public UserController()
        {
            context = new GamesContext();
        }
        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public decimal GetCurrentMoneyAmount(User user)
        {
            return user.Money;
        }

        public void UpdateMoney(User user,decimal newAmount)
        {
            user.Money = newAmount;
            context.SaveChanges();
        }
        public bool AlreadyRegistеredAccount(string email)
        {
            bool error = false;
            if (context.Users.Any(x => x.Email == email))
            {
                error = true;
            }
            return error;
        }


        public bool AlreadyUsedUsername(string username)
        {
            bool error = false;
            if (context.Users.Any(x => x.Username == username))
            {
                error = true;
            }
            return error;
        }

        public bool IncorrectPasswordLength(string password)
        {
            bool error = false;
            if (password.Length < 8)
            {
                error = true;
            }
            return error;
        }

        public bool PasswordContainsUpper(string password)
        {
            bool error = false;
            if (!password.Any(char.IsUpper))
            {
                error = true;
            }
            return error;
        }

        public bool PasswordContainsDigit(string password)
        {
            bool error = false;
            if (!password.Any(char.IsDigit))
            {
                error = true;
            }
            return error;
        }

        public bool LogInUsernameIsCorrect(string username)
        {
            bool error = true;
            if (context.Users.Any(x => x.Username == username))
            {
                error = false;
            }
            return error;
        }

        public bool LogInPasswordIsCorrect(string username, string password)
        {
            bool error = true;
            User user = context.Users.FirstOrDefault(x => x.Username == username);
            if (user.Password == password)
            { 
                error = false;
            }
            return error;
        }

        public User GetLogInUser(string username, string password)
        {
            User logInUser = context.Users.FirstOrDefault(x => x.Username == username);
            return logInUser;
        }

    }
}
