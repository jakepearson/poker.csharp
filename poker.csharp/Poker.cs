using System;
using System.Collections.Generic;
using System.Linq;


namespace poker.csharp
{
	public class Poker
	{
		Dictionary<EHandType, Func<Hand, bool>> types;

		Func<Hand, bool> HasGroup(int size, int count)
		{
			return hand => hand.GroupBy(c => c.Suit).Where(g => g.Count() == size).Count() == count;
		}

		public Dictionary<EHandType, Func<Hand, bool>> Types
		{
			get
			{
				if(types == null)
				{
					types = new Dictionary<EHandType, Func<Hand, bool>>
					{
						{ EHandType.Pair, HasGroup(2, 1) },
						{ EHandType.TwoPair, HasGroup(2, 2) }
					};
				}
				return types;
			}
		}
	}
}

