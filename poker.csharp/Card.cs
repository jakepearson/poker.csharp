using System;

namespace poker.csharp
{
	public class Card
	{
		public ESuit Suit { get; private set; }
		public ERank Rank { get; private set; }

		public Card(ESuit suit, ERank rank) {
			Suit = suit;
			Rank = rank;
		}


	}
}

