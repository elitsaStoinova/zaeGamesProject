using System;
using System.Collections.Generic;
using System.Text;

namespace BLackJack.Models

{
    
    public class Card
    {
        private string symbol;
        public string Symbol
        {
            get
            {
                return this.symbol; 
            }
            set
            {
                if(CardCharacteristics.Symbols.Contains(value))
                {
                    this.symbol = value;
                }
                else
                {
                    throw new ArgumentException("Invalid Symbol");
                }
            }
        }
        private string suit;
        public string Suit
        {
            get 
            { 
                return this.suit;
            }
            set
            {
                if(CardCharacteristics.Suits.Contains(value))
                {
                    this.suit = value;
                }
                else
                {
                    throw new ArgumentException("Invalid Suit");
                }
            }
        }
        public Card(string symbol,string suit)
        {
            this.Suit = suit;
            this.Symbol = symbol;
        }
        public Card()
        {

        }
    }
}
