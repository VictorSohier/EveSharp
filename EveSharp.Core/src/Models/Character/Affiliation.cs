namespace EveSharp.Core.Models.Character
{
	public struct Affiliation
	{
		public int? allianceId;
		public int characterId;
		public int corporationId;
		public int? factitonId;
	}
	
	public struct SoAAffiliation
	{
		public readonly int?[] allianceIds;
		public readonly int[] characterIds;
		public readonly int[] corporationIds;
		public readonly int?[] factitonIds;
		
		public SoAAffiliation(params Affiliation[] affiliations)
		{
			int count = affiliations.Length;
			allianceIds = new int?[count];
			characterIds = new int[count];
			corporationIds = new int[count];
			factitonIds = new int?[count];
			
			for (int i = 0; i < count; i++)
			{
				allianceIds[i] = affiliations[i].allianceId;
				characterIds[i] = affiliations[i].characterId;
				corporationIds[i] = affiliations[i].corporationId;
				factitonIds[i] = affiliations[i].factitonId;
			}
		}
	}
}