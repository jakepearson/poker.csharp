using System;

namespace poker.csharp
{
	public enum ESuit 
	{
		Diamonds,
		Spades,
		Hearts,
		Clubs
	}

	public enum ERank
	{
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

	public enum EHandType
	{
		Pair,
		TwoPair,
		ThreeOfAKind,
		FourOfAKind,
		FullHouse,
		Straight,
		Flush,
		RoyalFlush
	}
}

