namespace EveSharp.Core.Models.Market
{
	public struct HistoryEntry
	{
		public double average;
		public DateTime date;
		public double highest;
		public double lowest;
		public long orderCount;
		public long volume;
	}
	
	
	public struct SoAHistoryEntry
	{
		public readonly double[] averages;
		public readonly DateTime[] dates;
		public readonly double[] highests;
		public readonly double[] lowests;
		public readonly long[] orderCounts;
		public readonly long[] volumes;
		
		public SoAHistoryEntry(params HistoryEntry[] historyEntries)
		{
			int count = historyEntries.Length;
			averages = new double[count];
			dates = new DateTime[count];
			highests = new double[count];
			lowests = new double[count];
			orderCounts = new long[count];
			volumes = new long[count];
			
			for (int i = 0; i < count; i++)
			{
				averages[i] = historyEntries[i].average;
				dates[i] = historyEntries[i].date;
				highests[i] = historyEntries[i].highest;
				lowests[i] = historyEntries[i].lowest;
				orderCounts[i] = historyEntries[i].orderCount;
				volumes[i] = historyEntries[i].volume;
			}
		}
	}
}