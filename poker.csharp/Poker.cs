using System;
using System.Collections.Generic;
using System.Linq;


namespace poker.csharp
{
	public static class Poker
	{
		public static readonly Func<IEnumerable<Card>, bool> Pair = HasGroup(2, 1);
		public static readonly Func<IEnumerable<Card>, bool> TwoPair = HasGroup(2, 2);
		public static readonly Func<IEnumerable<Card>, bool> ThreeOfAKind = HasGroup(3);
		public static readonly Func<IEnumerable<Card>, bool> FourOfAKind = HasGroup(4);
		public static readonly Func<IEnumerable<Card>, bool> FullHouse = And(HasGroup(3), HasGroup(2));
		public static readonly Func<IEnumerable<Card>, bool> Flush = 
			h => h.Where(c => h.First().Suit == c.Suit).Count() == h.Count();

		public static readonly Func<IEnumerable<Card>, bool> Straight = 
			h => h.Select(c => (int)c.Rank).Max() - h.Select(c => (int)c.Rank).Min() == h.Count() - 1;

		public static readonly Func<IEnumerable<Card>, bool> StraightFlush = And(Straight, Flush);
		public static readonly Func<IEnumerable<Card>, bool> RoyalFlush = 
			And(StraightFlush, h => (ERank)h.Select(c => (int)c.Rank).Max() == ERank.Ace);

		static Func<IEnumerable<Card>, bool> HasGroup(int size, int count = 1) {
			return hand => hand.GroupBy(c => c.Rank).Where(g => g.Count() == size).Count() == count;
		}

		static Func<IEnumerable<Card>, bool> And(params Func<IEnumerable<Card>, bool>[] tests) {
			return hand => {
				foreach(var test in tests) {
					if(!test(hand)) return false;
				}
				return true;
			};
		}
	}
}

