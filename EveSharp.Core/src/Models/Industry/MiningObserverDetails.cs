namespace EveSharp.Core.Models.Industry
{
	public struct MiningObserverDetails
	{
		public int characterId;
		public DateTime lastUpdated;
		public long quantity;
		public int recordedCorporationId;
		public int typeId;
	}
	
	public struct SoAMiningObserverDetails
	{
		public readonly int[] characterIds;
		public readonly DateTime[] lastUpdateds;
		public readonly long[] quantitys;
		public readonly int[] recordedCorporationIds;
		public readonly int[] typeIds;
		
		public SoAMiningObserverDetails(params MiningObserverDetails[] miningObserverDetails)
		{
			int count = miningObserverDetails.Length;
			characterIds = new int[count];
			lastUpdateds = new DateTime[count];
			quantitys = new long[count];
			recordedCorporationIds = new int[count];
			typeIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				characterIds[i] = miningObserverDetails[i].characterId;
				lastUpdateds[i] = miningObserverDetails[i].lastUpdated;
				quantitys[i] = miningObserverDetails[i].quantity;
				recordedCorporationIds[i] = miningObserverDetails[i].recordedCorporationId;
				typeIds[i] = miningObserverDetails[i].typeId;
			}
		}
	}
}