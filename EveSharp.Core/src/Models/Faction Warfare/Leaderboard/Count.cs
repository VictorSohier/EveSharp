namespace EveSharp.Core.Models.FactionWarfare.Leaderboard
{
	public struct Count
	{
		public int amount;
		public int factionId;
	}
	
	public struct SoACount
	{
		public readonly int[] amounts;
		public readonly int[] factionIds;
		
		public SoACount(params Count[] counts)
		{
			int count = counts.Length;
			amounts = new int[count];
			factionIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				amounts[i] = counts[i].amount;
				factionIds[i] = counts[i].factionId;
			}
		}
	}
}