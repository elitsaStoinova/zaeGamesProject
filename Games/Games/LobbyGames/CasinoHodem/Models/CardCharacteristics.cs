using System;
using System.Collections.Generic;
using System.Text;

namespace BLackJack.Models
{
   public static class CardCharacteristics
    {
        public static readonly List<string> Symbols = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        public static readonly List<string> Suits = new List<string>() { "club", "diamond", "heart", "spade" };
        public static readonly List<string> HandStrength = new List<string>() { "HighCard", "Pair", "DoublePair", "Set","Straight","Flush","FullHouse","Quads","StraightFlush" };
    }
}
