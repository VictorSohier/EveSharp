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
		public readonly int?[] allianceId;
		public readonly int[] characterId;
		public readonly int[] corporationId;
		public readonly int?[] factitonId;
		
		public SoAAffiliation(params Affiliation[] affiliations)
		{
			int count = affiliations.Length;
			allianceId = new int?[count];
			characterId = new int[count];
			corporationId = new int[count];
			factitonId = new int?[count];
			
			for (int i = 0; i < count; i++)
			{
				allianceId[i] = affiliations[i].allianceId;
				characterId[i] = affiliations[i].characterId;
				corporationId[i] = affiliations[i].corporationId;
				factitonId[i] = affiliations[i].factitonId;
			}
		}
	}
}