namespace EveSharp.Core.Models.Industry
{
	public struct SystemCostIndex
	{
		public CostIndexEntry[] costIndicies;
		public int solarSystemId;
	}
	
	public struct SoASystemCostIndex
	{
		public readonly SoACostIndexEntry[] costIndicies;
		public readonly int[] solarSystemIds;
		
		public SoASystemCostIndex(params SystemCostIndex[] systemCostIndices)
		{
			int count = systemCostIndices.Length;
			costIndicies = new SoACostIndexEntry[count];
			solarSystemIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				costIndicies[i] = new(systemCostIndices[i].costIndicies);
				solarSystemIds[i] = systemCostIndices[i].solarSystemId;
			}
		}
	}
}