using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace poker.csharp
{
	public static class Poker
	{
		public static readonly Func<IEnumerable<Card>, bool> Pair = HasGroup(2);
		public static readonly Func<IEnumerable<Card>, bool> TwoPair = HasGroup(2, 2);
		public static readonly Func<IEnumerable<Card>, bool> ThreeOfAKind = HasGroup(3);
		public static readonly Func<IEnumerable<Card>, bool> FourOfAKind = HasGroup(4);
		public static readonly Func<IEnumerable<Card>, bool> FullHouse = 
			h => ThreeOfAKind(h) && Pair(h);
		public static readonly Func<IEnumerable<Card>, bool> Flush = 
			h => h.Where(c => h.First().Suit == c.Suit).Count() == h.Count();

		public static readonly Func<IEnumerable<Card>, bool> Straight = 
			h => h.Select(c => (int)c.Rank).Max() - h.Select(c => (int)c.Rank).Min() == h.Count() - 1;

		public static readonly Func<IEnumerable<Card>, bool> StraightFlush = 
			h => Straight(h) && Flush(h);

		public static readonly Func<IEnumerable<Card>, bool> RoyalFlush = 
			h => StraightFlush(h) && h.Where(c => c.Rank == ERank.Ace).Any();

		static Func<IEnumerable<Card>, bool> HasGroup(int size, int count = 1) {
			return hand => hand.GroupBy(c => c.Rank).Where(g => g.Count() == size).Count() == count;
		}

		public static IEnumerable<EHandType> GetHandTypes(IEnumerable<Card> hand) {
			return Types.Where(t => t.Value(hand)).Select(t => t.Key);
		}

		static IEnumerable<KeyValuePair<EHandType, Func<IEnumerable<Card>, bool>>> Types {
			get {
				var pokerType = typeof(Poker);
				foreach(var type in Enum.GetValues(typeof(EHandType)).Cast<EHandType>()) {
					var field = pokerType.GetField(type.ToString(), BindingFlags.Static | BindingFlags.Public);
					var test = (Func<IEnumerable<Card>, bool>)field.GetValue(null);
					yield return new KeyValuePair<EHandType, Func<IEnumerable<Card>, bool>>(type, test);
				}

			}
		}
	}
}

