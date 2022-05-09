namespace EveSharp.Core.Models.Corporation
{
	public struct Corporation
	{
		public int? allianceId;
		public int ceoId;
		public int creatorId;
		public DateTime dateFounded;
		public string description;
		public int? factionId;
		public int? homeStationId;
		public int memberCount;
		public string name;
		public long? shares;
		public float taxRate;
		public string ticker;
		public string url;
		public bool? warEligible;
	}
	
	public struct SoACorporation
	{
		public readonly int?[] allianceIds;
		public readonly int[] ceoIds;
		public readonly int[] creatorIds;
		public readonly DateTime[] dateFoundeds;
		public readonly string[] descriptions;
		public readonly int?[] factionIds;
		public readonly int?[] homeStationIds;
		public readonly int[] memberCounts;
		public readonly string[] names;
		public readonly long?[] shares;
		public readonly float[] taxRates;
		public readonly string[] tickers;
		public readonly string[] urls;
		public readonly bool?[] warEligibles;
		
		public SoACorporation(params Corporation[] corporations)
		{
			int count = corporations.Length;
			allianceIds = new int?[count];
			ceoIds = new int[count];
			creatorIds = new int[count];
			dateFoundeds = new DateTime[count];
			descriptions = new string[count];
			factionIds = new int?[count];
			homeStationIds = new int?[count];
			memberCounts = new int[count];
			names = new string[count];
			shares = new long?[count];
			taxRates = new float[count];
			tickers = new string[count];
			urls = new string[count];
			warEligibles = new bool?[count];
			
			for (int i = 0; i < count; i++)
			{
				allianceIds[i] = corporations[i].allianceId;
				ceoIds[i] = corporations[i].ceoId;
				creatorIds[i] = corporations[i].creatorId;
				dateFoundeds[i] = corporations[i].dateFounded;
				descriptions[i] = corporations[i].description;
				factionIds[i] = corporations[i].factionId;
				homeStationIds[i] = corporations[i].homeStationId;
				memberCounts[i] = corporations[i].memberCount;
				names[i] = corporations[i].name;
				shares[i] = corporations[i].shares;
				taxRates[i] = corporations[i].taxRate;
				tickers[i] = corporations[i].ticker;
				urls[i] = corporations[i].url;
				warEligibles[i] = corporations[i].warEligible;
			}
		}
	}
}