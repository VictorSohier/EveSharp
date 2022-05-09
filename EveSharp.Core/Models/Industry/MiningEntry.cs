namespace EveSharp.Core.Models.Industry
{
	public struct MiningEntry
	{
		public DateTime date;
		public long quantity;
		public int solarSystemId;
		public int typeId;
	}
	
	public struct SoAMiningEntry
	{
		public readonly DateTime[] dates;
		public readonly long[] quantitys;
		public readonly int[] solarSystemIds;
		public readonly int[] typeIds;
		
		public SoAMiningEntry(params MiningEntry[] miningEntries)
		{
			int count = miningEntries.Length;
			dates = new DateTime[count];
			quantitys = new long[count];
			solarSystemIds = new int[count];
			typeIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				dates[i] = miningEntries[i].date;
				quantitys[i] = miningEntries[i].quantity;
				solarSystemIds[i] = miningEntries[i].solarSystemId;
				typeIds[i] = miningEntries[i].typeId;
			}
		}
	}
}