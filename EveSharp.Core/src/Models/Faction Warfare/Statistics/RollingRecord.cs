namespace EveSharp.Core.Models.FactionWarfare.Statistics
{
	public struct RollingRecord
	{
		public int lastWeek;
		public int total;
		public int yesterday;
	}
	
	public struct SoARollingRecord
	{
		public readonly int[] lastWeeks;
		public readonly int[] totals;
		public readonly int[] yesterdays;
		
		public SoARollingRecord(int count)
		{
			lastWeeks = new int[count];
			totals = new int[count];
			yesterdays = new int[count];
		}
		
		public SoARollingRecord(params RollingRecord[] rollingRecords)
		{
			int count = rollingRecords.Length;
			lastWeeks = new int[count];
			totals = new int[count];
			yesterdays = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				lastWeeks[i] = rollingRecords[i].lastWeek;
				totals[i] = rollingRecords[i].total;
				yesterdays[i] = rollingRecords[i].yesterday;
			}
		}
	}
}