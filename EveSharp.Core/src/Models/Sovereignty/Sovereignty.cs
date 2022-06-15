namespace EveSharp.Core.Models.Sovereignty
{
	public struct Sovereignty
	{
		public int? allianceId;
		public int? corporationId;
		public int? factionId;
		public int systemId;
	}
	
	public struct SoASovereignty
	{
		public readonly int?[] allianceIds;
		public readonly int?[] corporationIds;
		public readonly int?[] factionIds;
		public readonly int[] systemIds;
		
		public SoASovereignty(params Sovereignty[] sovereignties)
		{
			int count = sovereignties.Length;
			allianceIds = new int?[count];
			corporationIds = new int?[count];
			factionIds = new int?[count];
			systemIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				allianceIds[i] = sovereignties[i].allianceId;
				corporationIds[i] = sovereignties[i].corporationId;
				factionIds[i] = sovereignties[i].factionId;
				systemIds[i] = sovereignties[i].systemId;
			}
		}
	}
}