using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Games.Business;
using System.Windows.Forms;
using Games.Data.Models;

namespace Games.Views
{
    public class Display
    {
        private UserController controller = new UserController();

        public void AddUserD(TextBox username, TextBox firstName, TextBox lastName, ComboBox age, TextBox password, TextBox emailTextBox, ComboBox gender) //adds new user
        {
            User user = new User(username.Text, firstName.Text, lastName.Text, int.Parse(age.SelectedItem.ToString()), password.Text, emailTextBox.Text, gender.SelectedItem.ToString());
            controller.AddUser(user);
        }

        public decimal GetCurrentMoneyAmountD(TextBox username, TextBox firstName, TextBox lastName, ComboBox age, TextBox password, TextBox email, ComboBox gender) //returns user's money
        {
            User user = new User(username.Text, firstName.Text, lastName.Text, int.Parse(age.Text), password.Text, email.Text, gender.SelectedItem.ToString());
            return controller.GetCurrentMoneyAmount(user);
        }

        public void AlreadyRegisteredAccountD(TextBox emailTextBox,Label emailErrorLabel) //if this account has already been created it returns an error message
        {
            if (controller.AlreadyRegistеredAccount(emailTextBox.Text) == true)
            {
                emailErrorLabel.Text = "An account has already been created with this email! " + "\n" + "     Please Log in or use another email.";
            }
            else
            {
                emailErrorLabel.Text = ""; 
            }
        }

        public void AlreadyUsedUsernameD(TextBox usernameTextBox,Label usernameErrorLabel) // if the username has already been used it returns an error message
        {
            if (controller.AlreadyUsedUsername(usernameTextBox.Text) == true)
            {
                usernameErrorLabel.Text = "This username is taken!Please choose another one!";
            }
            else
            {
                usernameErrorLabel.Text = "";
            }
        }

        public void IncorrectPasswordLengthD(TextBox passwordTextBox, Label passwordLabel) //if the password is shorter than 8 symbols it returns an error message
        {
            if (controller.IncorrectPasswordLength(passwordTextBox.Text) == true)
            {
                passwordLabel.Text = "The password can not be shorther than 8 symbols!";
            }
        }

        public void IncorrectPasswordUpperD(TextBox passwordTextBox, Label passwordLabel) //if the password doesn't conatin a capital letter it returns an error message only if the password's length is 8
        {
            if (controller.IncorrectPasswordLength(passwordTextBox.Text) == false)
            {
                if (controller.PasswordContainsUpper(passwordTextBox.Text) == true)
                {
                    passwordLabel.Text = "The password must contain at least one capital letter";
                }
            }
        }

        public void IncorrectPasswordDigitD(TextBox passwordTextBox, Label passwordLabel) //if the password doesn't contain digits it returns an error message only if the password's lenth is 8 and conatins a capital letter
        {
            if (controller.PasswordContainsUpper(passwordTextBox.Text) == true)
            {
                if (controller.PasswordContainsDigit(passwordTextBox.Text) == true)
                {
                    passwordLabel.Text = "The password must cointain at least one digit!";
                }
            }
            else
            {
                passwordLabel.Text = "";
            }
        }


        public void LogInUsernameIsCorrectD(TextBox usernameTextBox, Label usernameErrorLabel)// if an account hasn't been signed up with this username an error message is returned
        {
            if (controller.LogInUsernameIsCorrect(usernameTextBox.Text) == true)
            {
                usernameErrorLabel.Text = "This username doesn't exist!";
            }
            else
            {
                usernameErrorLabel.Text = "";
            }
        }

        public void LogInPasswordIsCorrectD(TextBox usernameTextBox, TextBox passwordTextBox, Label passwordErrorLabel) // if the password is not the same as the user's with this username it returns an error message
        {
            if (controller.LogInPasswordIsCorrect(usernameTextBox.Text, passwordTextBox.Text) == true)
            {
                passwordErrorLabel.Text = "This password is incorect!";
            }
            else
            {
                passwordErrorLabel.Text = "";
            }
        }

        public User GetLogInUserD(TextBox usernameTextBox, TextBox passwordTextBox) //saves the user that has loged in
        {
            User user = controller.GetLogInUser(usernameTextBox.Text, passwordTextBox.Text);
            return user;
        }

        public void UpdateCHMoney()
        {
            GamesContext context = new GamesContext();
            context.Users.FirstOrDefault(x => x.Username == LogInForm.logInUser.Username).Money = LogInForm.logInUser.Money;
            context.SaveChanges();
        }
    }
}
