using System;
using System.Collections.Generic;
using System.Text;
using Games.Data.Models;

namespace BLackJack.Models
{
    public class Game
    {
        private Hand playerHand;
        public Hand PlayerHand
        {
            get { return this.playerHand; }
            set { this.playerHand = value; }
        }
        private Hand computerHand;
        public Hand ComputerHand
        {
            get { return this.computerHand; }
            set { this.computerHand = value; }
        }
        private decimal bet;
        public decimal Bet
        {
            get { return this.bet; }
            set { this.bet = value; }
        }
        private List<Card> board = new List<Card>();
        public List<Card> Board
        {
            get { return this.board; }
            set { this.board = value; }
        }
        public Game(decimal bet, User player)
        {
            this.Bet = bet;
            this.Player = player;
        }

        private User player;

        public User Player
        {
            get { return this.player; }
            set { this.player = value; }
        }

        public void Start()
        {
            Random r = new Random();
            List<string> loadedCards = new List<string>();
            this.Board = new List<Card>();
            while(this.Board.Count<=5)
            {
                string suit = CardCharacteristics.Suits[r.Next(0, 4)];
                string symbol = CardCharacteristics.Symbols[r.Next(0, 13)];
                if(!loadedCards.Contains(suit+symbol))
                {
                    loadedCards.Add(suit + symbol);
                    this.Board.Add(new Card(symbol, suit));
                }
            }
            List<Card> OtherCards = new List<Card>();
            while (OtherCards.Count <= 3)
            {
                string suit = CardCharacteristics.Suits[r.Next(0, 4)];
                string symbol = CardCharacteristics.Symbols[r.Next(0, 13)];
                if (!loadedCards.Contains(suit + symbol))
                {
                    loadedCards.Add(suit + symbol);
                    OtherCards.Add(new Card(symbol, suit));
                }
            }
            this.Board.RemoveRange(5, this.Board.Count - 5);
            this.PlayerHand = new Hand(OtherCards[0], OtherCards[1], this.Board);
            this.ComputerHand = new Hand(OtherCards[2], OtherCards[3], this.Board);
            


        }
        public string Winner()
        {
            if (CardCharacteristics.HandStrength.IndexOf(this.PlayerHand.FinalHandType) > CardCharacteristics.HandStrength.IndexOf(this.computerHand.FinalHandType))
            {
                player.Money += this.Bet *2;
                return "Player"; 
            }
            else if (CardCharacteristics.HandStrength.IndexOf(this.PlayerHand.FinalHandType) < CardCharacteristics.HandStrength.IndexOf(this.computerHand.FinalHandType))
            {
                return "Computer";
            }
            else
            {
                switch(this.PlayerHand.FinalHandType)
                {
                    case "StraightFlush":return StraightC();
                    case "Quads": return QuadsC();
                    case "FullHouse":return FullHouseC();
                    case "Flush": return HightCardC();
                    case "Straight": return StraightC();
                    case "Set": return SetC();
                    case "DoublePair": return DoublePairC();
                    case "Pair": return PairC();
                    default : return HightCardC();
                        
                }
            }
        }        
        public string QuadsC()
        {
            if (CardCharacteristics.Symbols.IndexOf(this.PlayerHand.FinalHand[1].Symbol) > CardCharacteristics.Symbols.IndexOf(this.computerHand.FinalHand[1].Symbol))
            {
                player.Money += this.Bet * 2;
                return "Player";
            }
            else if (CardCharacteristics.Symbols.IndexOf(this.PlayerHand.FinalHand[1].Symbol) < CardCharacteristics.Symbols.IndexOf(this.computerHand.FinalHand[1].Symbol))
            {
                return "Computer";
            }
            else
            {
                if (CardCharacteristics.Symbols.IndexOf(this.playerHand.FinalHand[4].Symbol) > CardCharacteristics.Symbols.IndexOf(this.computerHand.FinalHand[4].Symbol))
                {
                    player.Money += this.Bet * 2;
                    return "Player";
                }
                else if (CardCharacteristics.Symbols.IndexOf(this.playerHand.FinalHand[4].Symbol) < CardCharacteristics.Symbols.IndexOf(this.computerHand.FinalHand[4].Symbol))
                {
                    return "Computer";
                }
                else 
                {
                    player.Money += this.Bet;
                    return "Split";
                }
            }
        }
        public string FullHouseC()
        {
            if (CardCharacteristics.Symbols.IndexOf(this.playerHand.FinalHand[1].Symbol) > CardCharacteristics.Symbols.IndexOf(this.computerHand.FinalHand[1].Symbol))
            {
                player.Money += this.Bet * 2;
                return "Player";
            }
            else if (CardCharacteristics.Symbols.IndexOf(this.playerHand.FinalHand[1].Symbol) < CardCharacteristics.Symbols.IndexOf(this.computerHand.FinalHand[1].Symbol))
            {
                return "Computer";
            }
            else
            {
                if (CardCharacteristics.Symbols.IndexOf(this.playerHand.FinalHand[4].Symbol) > CardCharacteristics.Symbols.IndexOf(this.computerHand.FinalHand[4].Symbol))
                {
                    player.Money += this.Bet * 2;
                    return "Player";
                }
                else if (CardCharacteristics.Symbols.IndexOf(this.playerHand.FinalHand[4].Symbol) < CardCharacteristics.Symbols.IndexOf(this.computerHand.FinalHand[4].Symbol))
                {
                    return "Computer";
                }
                else
                {
                    player.Money += this.Bet;
                    return "Split";
                }
            }
        }       
        public string StraightC()
        {
            if (CardCharacteristics.Symbols.IndexOf(this.playerHand.FinalHand[0].Symbol) > CardCharacteristics.Symbols.IndexOf(this.computerHand.FinalHand[0].Symbol))
            {
                player.Money += this.Bet * 2;
                return "Player";
            }
            else if (CardCharacteristics.Symbols.IndexOf(this.playerHand.FinalHand[0].Symbol) < CardCharacteristics.Symbols.IndexOf(this.computerHand.FinalHand[0].Symbol))
            {
                return "Computer";
            }
            else
            {
                player.Money += this.Bet;
                return "Split";
            }
        }
        public string SetC()
        {
            if (CardCharacteristics.Symbols.IndexOf(this.playerHand.FinalHand[0].Symbol) > CardCharacteristics.Symbols.IndexOf(this.computerHand.FinalHand[0].Symbol))
            {
                player.Money += this.Bet * 2;
                return "Player";
            }
            else if (CardCharacteristics.Symbols.IndexOf(this.playerHand.FinalHand[0].Symbol) < CardCharacteristics.Symbols.IndexOf(this.computerHand.FinalHand[0].Symbol))
            {
                return "Computer";
            }
            else
            {
                for(int i = 3; i < 5; i++)
                {
                    if (CardCharacteristics.Symbols.IndexOf(this.PlayerHand.FinalHand[i].Symbol) > CardCharacteristics.Symbols.IndexOf(this.ComputerHand.FinalHand[i].Symbol))
                    {
                        player.Money += this.Bet * 2;
                        return "Player";
                    }
                    if (CardCharacteristics.Symbols.IndexOf(this.PlayerHand.FinalHand[i].Symbol) < CardCharacteristics.Symbols.IndexOf(this.ComputerHand.FinalHand[i].Symbol))
                    {
                        return "Computer";
                    }
                }
                player.Money += this.Bet;
                return "Split";
            }
        }
        public string DoublePairC()
        {
            if (CardCharacteristics.Symbols.IndexOf(this.playerHand.FinalHand[0].Symbol) > CardCharacteristics.Symbols.IndexOf(this.computerHand.FinalHand[0].Symbol))
            {
                player.Money += this.Bet * 2;
                return "Player";
            }
            else if (CardCharacteristics.Symbols.IndexOf(this.playerHand.FinalHand[0].Symbol) < CardCharacteristics.Symbols.IndexOf(this.computerHand.FinalHand[0].Symbol))
            {
                return "Computer";
            }
            else if (CardCharacteristics.Symbols.IndexOf(this.playerHand.FinalHand[2].Symbol) > CardCharacteristics.Symbols.IndexOf(this.computerHand.FinalHand[2].Symbol))
            {
                player.Money += this.Bet * 2;
                return "Player";
            }
            else if (CardCharacteristics.Symbols.IndexOf(this.playerHand.FinalHand[2].Symbol) < CardCharacteristics.Symbols.IndexOf(this.computerHand.FinalHand[2].Symbol))
            {
                return "Computer";
            }
            else if (CardCharacteristics.Symbols.IndexOf(this.playerHand.FinalHand[4].Symbol) > CardCharacteristics.Symbols.IndexOf(this.computerHand.FinalHand[4].Symbol))
            {
                player.Money += this.Bet * 2;
                return "Player";
            }
            else if (CardCharacteristics.Symbols.IndexOf(this.playerHand.FinalHand[4].Symbol) < CardCharacteristics.Symbols.IndexOf(this.computerHand.FinalHand[4].Symbol))
            {
                return "Computer";
            }
            else
            {
                player.Money += this.Bet;
                return "Split";
            }
        }
        public string PairC()
        {
            if (CardCharacteristics.Symbols.IndexOf(this.playerHand.FinalHand[0].Symbol) > CardCharacteristics.Symbols.IndexOf(this.computerHand.FinalHand[0].Symbol))
            {
                player.Money += this.Bet * 2;
                return "Player";
            }
            else if (CardCharacteristics.Symbols.IndexOf(this.playerHand.FinalHand[0].Symbol) < CardCharacteristics.Symbols.IndexOf(this.computerHand.FinalHand[0].Symbol))
            {
                return "Computer";
            }
            else
            {
                for (int i = 1; i < 5; i++)
                {
                    if (CardCharacteristics.Symbols.IndexOf(this.PlayerHand.FinalHand[i].Symbol) > CardCharacteristics.Symbols.IndexOf(this.ComputerHand.FinalHand[i].Symbol))
                    {
                        player.Money += this.Bet * 2;
                        return "Player";
                    }
                    if (CardCharacteristics.Symbols.IndexOf(this.PlayerHand.FinalHand[i].Symbol) < CardCharacteristics.Symbols.IndexOf(this.ComputerHand.FinalHand[i].Symbol))
                    { 
                        return "Computer";
                    }
                }
                player.Money += this.Bet;
                return "Split";
            }
        }
        public string HightCardC()
        {
            for (int i = 0; i < 5; i++)
            {
                if (CardCharacteristics.Symbols.IndexOf(this.PlayerHand.FinalHand[i].Symbol) > CardCharacteristics.Symbols.IndexOf(this.ComputerHand.FinalHand[i].Symbol))
                {
                    player.Money += this.Bet * 2;
                    return "Player";
                }
                if (CardCharacteristics.Symbols.IndexOf(this.PlayerHand.FinalHand[i].Symbol) < CardCharacteristics.Symbols.IndexOf(this.ComputerHand.FinalHand[i].Symbol))
                {
                    return "Computer";
                }
            }
            player.Money += this.Bet;
            return "Split";
        }


    }
}
