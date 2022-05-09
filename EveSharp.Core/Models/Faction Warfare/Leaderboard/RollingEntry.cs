namespace EveSharp.Core.Models.FactionWarfare.Leaderboard
{
	public struct RollingEntry
	{
		public Count[] activeTotal;
		public Count[] lastWeek;
		public Count[] yesterday;
	}
	
	public struct SoARollingEntry
	{
		public readonly SoACount[] activeTotals;
		public readonly SoACount[] lastWeeks;
		public readonly SoACount[] yesterdays;
		
		public SoARollingEntry(int count)
		{
			activeTotals = new SoACount[count];
			lastWeeks = new SoACount[count];
			yesterdays = new SoACount[count];
		}
		
		public SoARollingEntry(params RollingEntry[] rollingEntries)
		{
			int count = rollingEntries.Length;
			activeTotals = new SoACount[count];
			lastWeeks = new SoACount[count];
			yesterdays = new SoACount[count];
			
			for (int i = 0; i < count; i++)
			{
				activeTotals[i] = new SoACount(rollingEntries[i].activeTotal);
				lastWeeks[i] = new SoACount(rollingEntries[i].lastWeek);
				yesterdays[i] = new SoACount(rollingEntries[i].yesterday);
			}
		}
	}
}