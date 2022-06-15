namespace EveSharp.Core.Models.Industry
{
	public struct MoonExtraction
	{
		public DateTime chunkArrivalTime;
		public DateTime extractionStartTime;
		public int moonId;
		public DateTime naturalDecayTime;
		public long structureId;
	}
	
	public struct SoAMoonExtraction
	{
		public readonly DateTime[] chunkArrivalTimes;
		public readonly DateTime[] extractionStartTimes;
		public readonly int[] moonIds;
		public readonly DateTime[] naturalDecayTimes;
		public readonly long[] structureIds;
		
		public SoAMoonExtraction(params MoonExtraction[] moonExtractions)
		{
			int count = moonExtractions.Length;
			chunkArrivalTimes = new DateTime[count];
			extractionStartTimes = new DateTime[count];
			moonIds = new int[count];
			naturalDecayTimes = new DateTime[count];
			structureIds = new long[count];
			
			for (int i = 0; i < count; i++)
			{
				chunkArrivalTimes[i] = moonExtractions[i].chunkArrivalTime;
				extractionStartTimes[i] = moonExtractions[i].extractionStartTime;
				moonIds[i] = moonExtractions[i].moonId;
				naturalDecayTimes[i] = moonExtractions[i].naturalDecayTime;
				structureIds[i] = moonExtractions[i].structureId;
			}
		}
	}
}