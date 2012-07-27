using System;

namespace poker.csharp
{
	public enum ESuit {
		Diamonds,
		Spades,
		Hearts,
		Clubs
	}

	public enum ERank {
		Two,
		Three,
		Four,
		Five,
		Six,
		Seven,
		Eight,
		Nine,
		Ten,
		Jack,
		Queen,
		King,
		Ace
	}

	public enum EHandType {
		RoyalFlush,
		StraightFlush,
		Flush,
		Straight,
		FullHouse,
		FourOfAKind,
		ThreeOfAKind,
		TwoPair,
		Pair,
		None
	}
}

