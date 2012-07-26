using System;
using System.Linq;
using System.Collections.Generic;

namespace poker.csharp
{
	public static class Extension
	{
		public static IEnumerable<Card> ToHand(this IEnumerable<String> cards) {
			return cards.Select(c => ToCard(c));
		}

		static Card ToCard(string value) {
			value = value.ToLower();
			var suit = GetSuit(value.Substring(0, 1));
			var rank = GetRank(value.Substring(1));
			return new Card(suit, rank);
		}

		static ESuit GetSuit(string suit) {
			switch(suit) {
				case "c": return ESuit.Clubs;
				case "d": return ESuit.Diamonds;
				case "h": return ESuit.Hearts;
				case "s": return ESuit.Spades;
				default: throw new NotImplementedException();
			}
		}

		static ERank GetRank(string rank) {
			switch(rank) {
				case "2": return ERank.Two;
				case "3": return ERank.Three;
				case "4": return ERank.Four;
				case "5": return ERank.Five;
				case "6": return ERank.Six;
				case "7": return ERank.Seven;
				case "8": return ERank.Eight;
				case "9": return ERank.Nine;
				case "10": return ERank.Ten;
				case "j": return ERank.Jack;
				case "q": return ERank.Queen;
				case "k": return ERank.King;
				case "a": return ERank.Ace;
				default: throw new NotImplementedException();
			}
		}
	}
}

