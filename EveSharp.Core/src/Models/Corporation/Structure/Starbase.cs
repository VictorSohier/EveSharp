using EveSharp.Core.Enums.Corporation.Structure;

namespace EveSharp.Core.Models.Corporation.Structure
{
	public struct Starbase
	{
		public int? moonId;
		public DateTime onlinedSince;
		public DateTime reinforcedUntil;
		public long starbaseId;
		public StarbaseState state;
		public int systemId;
		public int typeId;
		public DateTime unanchorAt;
	}
	
	public struct SoAStarbase
	{
		public readonly int?[] moonIds;
		public readonly DateTime[] onlinedSinces;
		public readonly DateTime[] reinforcedUntils;
		public readonly long[] starbaseIds;
		public readonly StarbaseState[] states;
		public readonly int[] systemIds;
		public readonly int[] typeIds;
		public readonly DateTime[] unanchorAts;
		
		public SoAStarbase(params Starbase[] starbases)
		{
			int count = starbases.Length;
			moonIds = new int?[count];
			onlinedSinces = new DateTime[count];
			reinforcedUntils = new DateTime[count];
			starbaseIds = new long[count];
			states = new StarbaseState[count];
			systemIds = new int[count];
			typeIds = new int[count];
			unanchorAts = new DateTime[count];
			
			for (int i = 0; i < count; i++)
			{
				moonIds[i] = starbases[i].moonId;
				onlinedSinces[i] = starbases[i].onlinedSince;
				reinforcedUntils[i] = starbases[i].reinforcedUntil;
				starbaseIds[i] = starbases[i].starbaseId;
				states[i] = starbases[i].state;
				systemIds[i] = starbases[i].systemId;
				typeIds[i] = starbases[i].typeId;
				unanchorAts[i] = starbases[i].unanchorAt;
			}
		}
	}
}