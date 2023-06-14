using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using BLackJack.Models;

namespace BLackJack.Views
{
    public class Display
    {
        public decimal GetBet(TextBox SourceTB)
        {
            decimal bet = decimal.Parse(SourceTB.Text);
            return bet;
        }
        private decimal bet;
        public decimal Bet
        {
            get { return this.bet; }
            set { this.bet = value; }
        }
        public void HideButton(Button button)
        {
            button.Visible = false;
        }
        public void ShowButton(Button button)
        {
            button.Visible = true;
        }
        public void SetBoardOne(List<PictureBox> BoardImages,List<Card>SourceCards)
        {
            for(int i=0;i<3;i++)
            {
                BoardImages[i].ImageLocation = @"Images\Cards\" + SourceCards[i].Symbol + "_" + SourceCards[i].Suit + ".jpg";
            }
        }
        public void ShowPlayerCards(PictureBox Card1, PictureBox Card2, Card SourceCard1,Card SourceCard2)
        {
            for (int i = 0; i < 5; i++)
            {
                Card1.ImageLocation = @"Images\Cards\" + SourceCard1.Symbol + "_" + SourceCard1.Suit + ".jpg";
                Card2.ImageLocation = @"Images\Cards\" + SourceCard2.Symbol + "_" + SourceCard2.Suit + ".jpg";
            }
        }
        public void SetBoardTwo(List<PictureBox> BoardImages, List<Card> SourceCards)
        {
            for (int i = 3; i < 5; i++)
            {
                BoardImages[i].ImageLocation = @"Images\Cards\" + SourceCards[i].Symbol + "_" + SourceCards[i].Suit + ".jpg";
            }
        }
        public void ShowComputerCards(PictureBox Card1, PictureBox Card2, Card SourceCard1, Card SourceCard2)
        {
            for (int i = 0; i < 5; i++)
            {
                Card1.ImageLocation = @"Images\Cards\" + SourceCard1.Symbol + "_" + SourceCard1.Suit + ".jpg";
                Card2.ImageLocation = @"Images\Cards\" + SourceCard2.Symbol + "_" + SourceCard2.Suit + ".jpg";
            }
        }
        public Display(TextBox SourceBox)
        { 
            this.Bet = this.GetBet(SourceBox);
        }
        public void clearImage(PictureBox Card1, PictureBox Card2, PictureBox Card3, PictureBox Card4, List<PictureBox> BoardImages)
        {
            Card1.ImageLocation = "error";
            Card2.ImageLocation = "error";
            Card3.ImageLocation = "error";
            Card4.ImageLocation = "error";
            foreach (var image in BoardImages)
            {
                image.ImageLocation = "error";
            }
            
        }
        
    }
}
