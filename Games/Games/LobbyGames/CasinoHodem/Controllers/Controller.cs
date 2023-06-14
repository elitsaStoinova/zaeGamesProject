using System;
using System.Collections.Generic;
using System.Text;
using BLackJack.Views;
using BLackJack.Models;
using System.Windows.Forms;
using Games.Data.Models;


namespace BLackJack.Controllers
{
   public class Controller
    {

        private Display display;
        public Display Display
        {
            get { return this.display; }
            set { this.display = value; }
        }
        private Game game;
        public Game Game
        {
            get { return this.game; }
            set { this.game = value; }
        }


        public Controller(TextBox SourceBox,List<PictureBox> pictureBoxesBoard,PictureBox Player1, PictureBox Player2, Button hideButton, Button showButton,Button showButton2,User user)
        {
            this.Display = new Display(SourceBox);
            this.Game = new Game(this.Display.Bet,user);
            this.Game.Start();
            display.SetBoardOne(pictureBoxesBoard, game.Board);
            display.ShowPlayerCards(Player1, Player2, game.PlayerHand.Card1, game.PlayerHand.Card2);
            display.HideButton(hideButton);
            display.ShowButton(showButton);
            display.ShowButton(showButton2);
            if(user.Money - this.Display.Bet<0)
            {
                throw new ArgumentException("No more money");
            }
            user.Money -= this.Display.Bet;
        }

        public void EndPhase(List<PictureBox> pictureBoxesBoard, PictureBox Computer1, PictureBox Computer2)
        {
            display.SetBoardTwo(pictureBoxesBoard, game.Board);
            display.ShowPlayerCards(Computer1, Computer2, game.ComputerHand.Card1, game.ComputerHand.Card2);
            
        }
    }

        
        

        
        
        
    }

