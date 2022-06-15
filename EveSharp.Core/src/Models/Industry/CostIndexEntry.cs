using EveSharp.Core.Enums.Industry;

namespace EveSharp.Core.Models.Industry
{
	public struct CostIndexEntry
	{
		public Activity activity;
		public float costIndex;
	}
	
	public struct SoACostIndexEntry
	{
		public readonly Activity[] activitys;
		public readonly float[] costIndicies;
		
		public SoACostIndexEntry(params CostIndexEntry[] costIndexEntries)
		{
			int count = costIndexEntries.Length;
			activitys = new Activity[count];
			costIndicies = new float[count];
			
			for (int i = 0; i < count; i++)
			{
				activitys[i] = costIndexEntries[i].activity;
				costIndicies[i] = costIndexEntries[i].costIndex;
			}
		}
	}
}