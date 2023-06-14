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

namespace Games
{
    public partial class SingUpForm : Form
    {
        GamesHub hubForm = new GamesHub();
        LogInForm logInForm = new LogInForm();
        Display display = new Display();
        public SingUpForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            display.AddUserD(signUpUsernameTextBox, firstNameTextBox, lastNameTextBox, ageComboBox, signUpPasswordTextBox, signUpEmailTextBox, genderComboBox);
            logInForm.Show();
            this.Hide();
        }

        private void firstNameTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void lastNameTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void ageTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void genderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void signUpUsernameTextBox_TextChanged(object sender, EventArgs e)
        {
            display.AlreadyUsedUsernameD(signUpUsernameTextBox, usernameErrorLabel);
        }

        private void signUpPasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            display.IncorrectPasswordLengthD(signUpPasswordTextBox, passwordErrorLabel);
            display.IncorrectPasswordUpperD(signUpPasswordTextBox, passwordErrorLabel);
            display.IncorrectPasswordDigitD(signUpPasswordTextBox, passwordErrorLabel);
        }

        private void signUpEmailTextBox_TextChanged(object sender, EventArgs e)
        {
            display.AlreadyRegisteredAccountD(signUpEmailTextBox, existingAccountErrorLabel);
        }

        private void firstNameLabel_Click(object sender, EventArgs e)
        {
        }

        private void lastNameLabel_Click(object sender, EventArgs e)
        {
        }

        private void ageLabel_Click(object sender, EventArgs e)
        {
        }

        private void genderLabel_Click(object sender, EventArgs e)
        {
        }

        private void singUpUsernameLabel_Click(object sender, EventArgs e)
        {
        }

        private void signUpPassword_Click(object sender, EventArgs e)
        {
        }

        private void signUpEmailLabel_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        { 
        }

        private void label3_Click(object sender, EventArgs e)
        {
            logInForm.Show();
            this.Hide();
        }
    }
}
