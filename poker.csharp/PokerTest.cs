using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace poker.csharp
{
	[TestFixture()]
	public class PokerTest
	{
		IEnumerable<Card> EmptyHand = new [] { "CA", "C3", "C2", "D6", "D7" }.ToHand();
		IEnumerable<Card> PairHand = new [] { "C3", "D3", "C4", "C5", "C6" }.ToHand();
		IEnumerable<Card> TwoPairHand = new[] { "CA", "DA", "H2", "D2" }.ToHand();
		IEnumerable<Card> ThreeOfAKindHand = new[] { "CA", "DA", "HA", "D2" }.ToHand();
		IEnumerable<Card> FourOfAKindHand = new[] { "CA", "DA", "HA", "SA" }.ToHand();
		IEnumerable<Card> FullHouseHand = new[] { "CA", "DA", "H2", "D2", "S2" }.ToHand();
		IEnumerable<Card> FlushHand = new[] { "DK", "DA", "D4", "D2", "D3" }.ToHand();
		IEnumerable<Card> StraightHand = new[] { "C2", "D3", "H4", "D6", "D5" }.ToHand();
		IEnumerable<Card> StraightFlushHand = new[] { "D2", "D3", "D4", "D6", "D5" }.ToHand();
		IEnumerable<Card> RoyalFlushHand = new[] { "DA", "DK", "DJ", "DQ", "D10" }.ToHand();

		[Test, TestCaseSource("TestSource")]
		public void Test(Func<IEnumerable<Card>, bool> handTest, IEnumerable<Card> hand, EHandType type) {
			Assert.IsTrue(handTest(hand), "Good hand");
			Assert.IsFalse(handTest(EmptyHand), "Bad hand");

			Assert.AreEqual(type, Poker.GetHandType(hand));
		}

		public IEnumerable<TestCaseData> TestSource() {
			yield return new TestCaseData(Poker.Pair, PairHand, EHandType.Pair).SetName("Pair");
			yield return new TestCaseData(Poker.TwoPair, TwoPairHand, EHandType.TwoPair).SetName("Two Pair");
			yield return new TestCaseData(Poker.ThreeOfAKind, ThreeOfAKindHand, EHandType.ThreeOfAKind).SetName("Three of a Kind");
			yield return new TestCaseData(Poker.FourOfAKind, FourOfAKindHand, EHandType.FourOfAKind).SetName("Four of a Kind");
			yield return new TestCaseData(Poker.FullHouse, FullHouseHand, EHandType.FullHouse).SetName("Full House");
			yield return new TestCaseData(Poker.Flush, FlushHand, EHandType.Flush).SetName("Flush");
			yield return new TestCaseData(Poker.Straight, StraightHand, EHandType.Straight).SetName("Straight");
			yield return new TestCaseData(Poker.StraightFlush, StraightFlushHand, EHandType.StraightFlush).SetName("Straight Flush");
			yield return new TestCaseData(Poker.RoyalFlush, RoyalFlushHand, EHandType.RoyalFlush).SetName("Royal Flush");
		}
	}
}

