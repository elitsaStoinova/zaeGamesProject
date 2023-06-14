using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BLackJack.Models
{
    public class Hand
    {
        private Card card1=new Card();
        public Card Card1
        {
            get { return this.card1; }
            set { this.card1 = value; }
        }
        private Card card2= new Card();
        public Card Card2
        {
            get { return this.card2; }
            set { this.card2 = value; }
        }
        private List<Card> board = new List<Card>();
        public List<Card> Board
        {
            get { return this.board; }
            set 
            {
                this.board = value;
            }
        }
        public Hand(Card card1,Card card2,List<Card> board)
        {
            this.Card1 = card1;
            this.Card2 = card2;
            this.Board = board;
            this.FinalHandType=handDeterminer();
        }
        public List<Card> CheckForFlush() // False if Count is 0
        {
            List<Card> allCards = new List<Card>();
            foreach (var card in this.Board)
            {
                allCards.Add(new Card(card.Symbol, card.Suit));
            }
            allCards.Add(Card2);
            allCards.Add(Card1);
            var flushTester = allCards.OrderBy(x => x.Suit).ToList();
            int numberOfSameSuit=1;
            string flushSuit = "";
            
            for(int j=1;j< flushTester.Count;j++)
            {
                if(flushTester[j-1].Suit!= flushTester[j].Suit)               
                {
                    numberOfSameSuit = 1;
                }
                else 
                {
                    numberOfSameSuit++;
                }
                if(numberOfSameSuit == 5)
                {
                    flushSuit = flushTester[j].Suit;
                    break;
                }
            }
            List<Card> sameSuit = new List<Card>();
            if (numberOfSameSuit == 5)
                {
                
                foreach (var card in flushTester)
                    {
                        if (card.Suit == flushSuit)
                        {
                        sameSuit.Add(card);
                        }
                    }

                    
                }
            List<int> cardsStrength = new List<int>();
            foreach (var card in sameSuit)
            {
                cardsStrength.Add(CardCharacteristics.Symbols.IndexOf(card.Symbol)); // turns symbols into integer strength
            }
            cardsStrength.Sort();
            List<Card> finalHand = new List<Card>();
            int i = 0;
            if (cardsStrength.Count > 0)
            {
                while (i < 5)
                {
                    finalHand.Add(allCards.Find(x => x.Symbol == CardCharacteristics.Symbols[cardsStrength.Last() - i]));
                    i++;
                }
            }
            
            return finalHand;
            
        }
        public List<Card> CheckForStraight()// False if Count is 0
        {
            List<Card> allCards = new List<Card>();
            foreach (var card in this.Board)
            {
                allCards.Add(new Card(card.Symbol, card.Suit));
            }
            allCards.Add(Card2);
            allCards.Add(Card1);
            
            List<int> cardsStrngth = new List<int>();
            foreach (var card in allCards)
            {if (!cardsStrngth.Contains(CardCharacteristics.Symbols.IndexOf(card.Symbol)))
                {
                    cardsStrngth.Add(CardCharacteristics.Symbols.IndexOf(card.Symbol)); // turns symbols into integer strength
                }
            }
            cardsStrngth.Sort(); //oreders cars by strength
            int numberOfStrightCards = 1;
            int highCard = -1;
            for (int i = 1; i < cardsStrngth.Count; i++) //if there is a straight the difference between 5 cards in a row  will be 1
            {
                if (cardsStrngth[i] != cardsStrngth[i - 1] + 1)
                {
                    numberOfStrightCards = 1;
                }
                else
                {
                    numberOfStrightCards++;
                }
                if (numberOfStrightCards >4)
                {
                    highCard = cardsStrngth[i];
                    
                }
            }
            List<Card> finalHand = new List<Card>();
            if (highCard != -1)
            {

                for(int i=0;i<5;i++)
                {
                    finalHand.Add(allCards.Find(x => x.Symbol == CardCharacteristics.Symbols[highCard]));
                    highCard--;
                }
            }
            return finalHand;
        }
        public List<Card> CheckForQuads()// False if Count is 0
        {
            List<Card> allCards = new List<Card>();
            foreach (var card in this.Board)
            {
                allCards.Add(new Card(card.Symbol, card.Suit));
            }
            allCards.Add(Card2);
            allCards.Add(Card1);
            List<int> cardsStrngth = new List<int>();
            foreach (var card in allCards)
            {
                cardsStrngth.Add(CardCharacteristics.Symbols.IndexOf(card.Symbol)); // turns symbols into integer strength
            }
            cardsStrngth.Sort();
            int samecards=1;
            int quadsSymbolIndex=-1;
            for(int i=1;i<cardsStrngth.Count;i++)
            {
                if(cardsStrngth[i-1]== cardsStrngth[i])
                {
                    samecards++;
                }
                else
                {
                    samecards = 1;
                }
                if(samecards==4)
                {
                    quadsSymbolIndex = cardsStrngth[i];
                    samecards = 1;
                }
            }
            List<Card> finalHand = new List<Card>();
            if (quadsSymbolIndex!=-1)
            {
                 for(int i=0;i<4;i++)
                {
                    finalHand.Add(allCards.Find(x => x.Symbol == CardCharacteristics.Symbols[quadsSymbolIndex]));
                }
                 if(quadsSymbolIndex!=cardsStrngth.Last())
                {
                    finalHand.Add(allCards.Find(x => x.Symbol == CardCharacteristics.Symbols[cardsStrngth.Last()]));
                }
                else
                {
                    finalHand.Add(allCards.Find(x => x.Symbol == CardCharacteristics.Symbols[cardsStrngth[2]]));
                }
            }
            return finalHand;
        }
        public List<Card> CheckForFullHouse()// False if Count is 0
        {
            List<Card> allCards = new List<Card>();
            foreach (var card in this.Board)
            {
                allCards.Add(new Card(card.Symbol, card.Suit));
            }
            allCards.Add(Card2);
            allCards.Add(Card1);
            List<int> cardsStrngth = new List<int>();
            foreach (var card in allCards)
            {
                cardsStrngth.Add(CardCharacteristics.Symbols.IndexOf(card.Symbol)); // turns symbols into integer strength
            }
            cardsStrngth.Sort();
            int sameCardsCount = 1;
            int setSymbolIndex=-1;
            int pairSymbolIndex=-1;
            for(int i=4;i>=0;i--)//Last will be the strongest
            {
                if(cardsStrngth[i]== cardsStrngth[i+1]&& cardsStrngth[i+2] == cardsStrngth[i + 1])
                {
                    setSymbolIndex = cardsStrngth[i];
                    
                }
                
            }
            
            if (setSymbolIndex != -1)
            {
                for (int i = 5; i >=0; i--)
                {
                    if (cardsStrngth[i] == cardsStrngth[i + 1]&& cardsStrngth[i] != setSymbolIndex)
                    {
                        pairSymbolIndex = cardsStrngth[i];
                    }                    
                }
            }
            List<Card> finalHand = new List<Card>();
            if (pairSymbolIndex!=-1)
            {
                for (int i = 0; i < 3; i++)
                {
                    finalHand.Add(allCards.Find(x => x.Symbol == CardCharacteristics.Symbols[setSymbolIndex]));
                }
                for (int i = 0; i < 2; i++)
                {
                    finalHand.Add(allCards.Find(x => x.Symbol == CardCharacteristics.Symbols[pairSymbolIndex]));
                }
            }
            return finalHand;

        }
        public List<Card> CheckForStraightFlush()
        {

            var StraightCheck = this.CheckForStraight();
            
            
                var FlushCheck = StraightCheck.OrderBy(x => x.Suit).ToList();

            if (FlushCheck.Count != 0)
            {
                if (FlushCheck[0].Suit == FlushCheck.Last().Suit) //if true, all are the same suit(Sorted by suit)
                {
                    return FlushCheck.OrderBy(x => x.Symbol).ToList();
                }
                else
                {
                    FlushCheck.Clear();
                }
            }
            

            return FlushCheck;
        }

        public List<Card> CheckForSet()
        {
            List<Card> allCards = new List<Card>();
            foreach (var card in this.Board)
            {
                allCards.Add(new Card(card.Symbol, card.Suit));
            }
            allCards.Add(Card2);
            allCards.Add(Card1);
            List<int> cardsStrngth = new List<int>();
            foreach (var card in allCards)
            {
                cardsStrngth.Add(CardCharacteristics.Symbols.IndexOf(card.Symbol)); // turns symbols into integer strength
            }
            cardsStrngth.Sort();
            int sameCardsCount = 1;
            int setSymbolIndex = -1;            
            for (int i = 1; i < cardsStrngth.Count; i++)
            {
                if (cardsStrngth[i] == cardsStrngth[i - 1])
                {
                    sameCardsCount++;
                }
                else
                {
                    sameCardsCount = 1;
                }
                if (sameCardsCount == 3)
                {
                    setSymbolIndex = cardsStrngth[i];
                    sameCardsCount = 1;

                }
            }
            List<Card> finalHand = new List<Card>();
            if (setSymbolIndex != -1)
            {
                for (int i = 0; i < 3; i++)
                {
                    finalHand.Add(allCards.Find(x => x.Symbol == CardCharacteristics.Symbols[setSymbolIndex]));
                }

                if (CardCharacteristics.Symbols[setSymbolIndex] != CardCharacteristics.Symbols[cardsStrngth.Last()])
                {
                    finalHand.Add(allCards.Find(x => x.Symbol == CardCharacteristics.Symbols[cardsStrngth.Last()]));
                    if (CardCharacteristics.Symbols[setSymbolIndex] != CardCharacteristics.Symbols[cardsStrngth.Last()-1])
                    {
                        finalHand.Add(allCards.Find(x => x.Symbol == CardCharacteristics.Symbols[cardsStrngth.Last()-1]));
                    }
                    else 
                    {
                        finalHand.Add(allCards.Find(x => x.Symbol == CardCharacteristics.Symbols[cardsStrngth.Last()-4]));
                    }
                }
                else
                {
                    finalHand.Add(allCards.Find(x => x.Symbol == CardCharacteristics.Symbols[cardsStrngth.Last()-3]));
                    finalHand.Add(allCards.Find(x => x.Symbol == CardCharacteristics.Symbols[cardsStrngth.Last()-4]));
                }
                
                
            }
            return finalHand;
        }
        public List<Card> CheckForDoublePair()
        {
            List<Card> allCards = new List<Card>();
            foreach (var card in this.Board)
            {
                allCards.Add(new Card(card.Symbol, card.Suit));
            }
            allCards.Add(Card2);
            allCards.Add(Card1);
            List<int> cardsStrngth = new List<int>();
            foreach (var card in allCards)
            {
                cardsStrngth.Add(CardCharacteristics.Symbols.IndexOf(card.Symbol)); // turns symbols into integer strength
            }
            cardsStrngth.Sort();
            int pairOneIndex = -1;
            int pairTwoIndex = -1;
            for (int i = 5; i >= 0; i--)
            {
                if (cardsStrngth[i] == cardsStrngth[i + 1] && pairOneIndex != -1)
                {
                    pairTwoIndex = cardsStrngth[i];
                    break;
                }
                if (cardsStrngth[i]==cardsStrngth[i+1]&&pairOneIndex==-1)
                {
                    pairOneIndex = cardsStrngth[i];
                }
                

            }
            
            List<Card> finalHand = new List<Card>();
            if (pairOneIndex != -1 && pairTwoIndex != -1)
            {
                for (int i = 0; i < 2; i++)
                {
                    cardsStrngth.Remove(pairOneIndex);
                    cardsStrngth.Remove(pairTwoIndex);
                    
                }
                finalHand.Add(allCards.Find(x => x.Symbol == CardCharacteristics.Symbols[pairOneIndex]));
                finalHand.Add(allCards.Find(x => x.Symbol == CardCharacteristics.Symbols[pairOneIndex]));
                finalHand.Add(allCards.Find(x => x.Symbol == CardCharacteristics.Symbols[pairTwoIndex]));
                finalHand.Add(allCards.Find(x => x.Symbol == CardCharacteristics.Symbols[pairTwoIndex]));
                finalHand.Add(allCards.Find(x => x.Symbol == CardCharacteristics.Symbols[cardsStrngth.Last()]));

            }
            return finalHand;

        }
        public List<Card> CheckForPair()
        {
            List<Card> allCards = new List<Card>();
            foreach (var card in this.Board)
            {
                allCards.Add(new Card(card.Symbol, card.Suit));
            }
            allCards.Add(Card2);
            allCards.Add(Card1);
            List<int> cardsStrngth = new List<int>();
            foreach (var card in allCards)
            {
                cardsStrngth.Add(CardCharacteristics.Symbols.IndexOf(card.Symbol)); // turns symbols into integer strength
            }
            cardsStrngth.Sort();
            int pairOneIndex = -1;
            for (int i = 5; i >=0; i--)
            {
                if(cardsStrngth[i]==cardsStrngth[i+1])
                {
                    pairOneIndex = cardsStrngth[i];
                    break;
                }
            }
            List<Card> finalHand = new List<Card>();
            if(pairOneIndex!=-1)
            {
                cardsStrngth.Remove(pairOneIndex);
                cardsStrngth.Remove(pairOneIndex);
                finalHand.Add(allCards.Find(x => x.Symbol == CardCharacteristics.Symbols[pairOneIndex]));
                finalHand.Add(allCards.Find(x => x.Symbol == CardCharacteristics.Symbols[pairOneIndex]));
                for(int i=cardsStrngth.Count-1;i> cardsStrngth.Count - 4;i--)
                {
                    finalHand.Add(allCards.Find(x => x.Symbol == CardCharacteristics.Symbols[cardsStrngth[i]]));
                }
            }
            return finalHand;

        }
        public List<Card> HighCardComb()
        {
            List<Card> allCards = new List<Card>();
            foreach (var card in this.Board)
            {
                allCards.Add(new Card(card.Symbol, card.Suit));
            }
            allCards.Add(Card2);
            allCards.Add(Card1);
            List<int> cardsStrngth = new List<int>();
            foreach (var card in allCards)
            {
                cardsStrngth.Add(CardCharacteristics.Symbols.IndexOf(card.Symbol)); // turns symbols into integer strength
            }
            cardsStrngth.Sort();
            List<Card> finalHand = new List<Card>();
            while(cardsStrngth.Count>5)
            {
                cardsStrngth.RemoveAt(0);
            }
            for(int i=cardsStrngth.Count-1;i>=0;i--)
            {
                finalHand.Add(allCards.Find(x => x.Symbol == CardCharacteristics.Symbols[cardsStrngth[i]]));
            }
            return finalHand;
        }
        private List<Card> finalHand = new List<Card>();
        public List<Card> FinalHand
        {
            get { return this.finalHand; }
            set { this.finalHand = value; }
        }
        private string finalHandType;
        public string FinalHandType
        {
            get { return this.finalHandType; }
            set { this.finalHandType = value; }
        }
        public string handDeterminer()
        {
            if(this.CheckForStraightFlush().Count==0)
            {
                if (this.CheckForQuads().Count == 0)
                {
                    if (this.CheckForFullHouse().Count == 0)
                    {
                        if (this.CheckForFlush().Count == 0)
                        {
                            if (this.CheckForStraight().Count == 0)
                            {
                                if (this.CheckForSet().Count == 0)
                                {
                                    if (this.CheckForDoublePair().Count == 0)
                                    {
                                        if (this.CheckForPair().Count == 0)
                                        {
                                            this.FinalHand = this.HighCardComb();
                                            return "HighCard";
                                        }
                                        else
                                        {
                                            this.FinalHand = this.CheckForPair();
                                            return "Pair";
                                        }
                                    }
                                    else
                                    {
                                        this.FinalHand = this.CheckForDoublePair();
                                        return "DoublePair";
                                    }
                                }
                                else
                                {
                                    this.FinalHand = this.CheckForSet();
                                    return "Set";
                                }
                            }
                            else
                            {
                                this.FinalHand = this.CheckForStraight();
                                return "Straight";
                            }
                        }
                        else
                        {

                            this.FinalHand = this.CheckForFlush();
                            return "Flush";
                        }
                        
                        
                    }
                    else
                    {
                        this.FinalHand = this.CheckForFullHouse();
                        return "FullHouse";
                    }
                }
                else
                {
                    this.FinalHand = this.CheckForQuads();
                    return "Quads";
                }

            }
            else
            {
                this.FinalHand = this.CheckForStraightFlush();
                return "StraightFlush";
            }
        }


    }
}
