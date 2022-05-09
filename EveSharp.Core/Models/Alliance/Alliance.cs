namespace EveSharp.Core.Models.Alliance
{
    public struct Alliance
    {
        public int creatorCorporationId;
        public int creatorId;
        public DateTime dateFounded;
        public int? executorCorporationId;
        public int? factionId;
        public string name;
        public string ticker;
    }
	
	public struct SoAAlliance
	{
        public readonly int[] creatorCorporationIds;
        public readonly int[] creatorIds;
        public readonly DateTime[] datesFounded;
        public readonly int?[] executorCorporationIds;
        public readonly int?[] factionIds;
        public readonly string[] names;
        public readonly string[] tickers;
		
		public SoAAlliance(params Alliance[] alliances)
		{
			int count = alliances.Length;
			creatorCorporationIds = new int[count];
			creatorIds = new int[count];
			datesFounded = new DateTime[count];
			executorCorporationIds = new int?[count];
			factionIds = new int?[count];
			names = new string[count];
			tickers = new string[count];
			
			for (int i = 0; i < count; i++)
			{
				creatorCorporationIds[i] = alliances[i].creatorCorporationId;
				creatorIds[i] = alliances[i].creatorId;
				datesFounded[i] = alliances[i].dateFounded;
				executorCorporationIds[i] = alliances[i].executorCorporationId;
				factionIds[i] = alliances[i].factionId;
				names[i] = alliances[i].name;
				tickers[i] = alliances[i].ticker;
			}
		}
	}
}