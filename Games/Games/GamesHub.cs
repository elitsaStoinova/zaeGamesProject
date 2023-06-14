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
using Games.Data;

namespace Games
{
    public partial class GamesHub : Form
    {
        Display display = new Display();

        public GamesHub()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CasinoHoldem casinoHoldem = new CasinoHoldem();
            using (casinoHoldem)
            {
                if(casinoHoldem.ShowDialog()==DialogResult.OK)
                {
                    moneyLabel.Text = CasinoHoldem.Controller.Game.Player.Money.ToString();
                    display.UpdateCHMoney();
                    casinoHoldem.Hide();
                }
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            Close();
        }
    }
}
