using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLackJack.Controllers;
using BLackJack.Models;
using BLackJack.Views;
using Games.Data.Models;
using Games.Data;
using Games.Business;

namespace Games
{
    public partial class CasinoHoldem : Form
    {
        List<PictureBox> pB = new List<PictureBox>();

        public static Controller Controller;

        UserController userController = new UserController();
        public CasinoHoldem()
        {
            InitializeComponent();
            pB.Add(pictureBox5);
            pB.Add(pictureBox6);
            pB.Add(pictureBox7);
            pB.Add(pictureBox8);
            pB.Add(pictureBox9);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controller = new Controller(textBox1, pB, pictureBox1, pictureBox2, button1, button2, button3,LogInForm.logInUser); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Controller.EndPhase(pB, pictureBox3, pictureBox4);
            if (MessageBox.Show(Controller.Game.Winner(), "Winner") == DialogResult.OK)
            {
                Controller.Display.clearImage(pictureBox1, pictureBox2, pictureBox3, pictureBox4, pB);
                Controller.Display.HideButton(button2);
                Controller.Display.HideButton(button3);
                Controller.Display.ShowButton(button1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Controller.Display.clearImage(pictureBox1, pictureBox2, pictureBox3, pictureBox4, pB);
            Controller.Display.HideButton(button2);
            Controller.Display.HideButton(button3);
            Controller.Display.ShowButton(button1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
