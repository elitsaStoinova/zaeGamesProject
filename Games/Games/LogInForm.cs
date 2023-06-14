using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Games.Views;
using Games.Data.Models;

namespace Games
{
    public partial class LogInForm : Form
    {
        Display display = new Display();
        GamesHub gamesHub = new GamesHub();
        public static User logInUser;
        public LogInForm()
        {
            InitializeComponent();
        }

        private void usernameLabel_Click(object sender, EventArgs e)
        {

        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {
            display.LogInUsernameIsCorrectD(usernameTextBox, usernameErrorLabel);
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            display.LogInPasswordIsCorrectD(usernameTextBox, passwordTextBox, passwordErrorLabel);
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            logInUser = display.GetLogInUserD(usernameTextBox, passwordTextBox);
            string username = usernameTextBox.Text;
            logInUser.Money = display.GetLogInUserD(usernameTextBox, passwordTextBox).Money;
            if(logInUser.Money<0)
            {
                logInUser.Money = 0;
            }
            gamesHub.usernameLabel.Text = username;
            gamesHub.moneyLabel.Text = logInUser.Money.ToString();
            gamesHub.Show();
            this.Hide();
        }
    }
}
