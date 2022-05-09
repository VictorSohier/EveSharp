namespace EveSharp.Core.Models.Killmails
{
	public struct Victim
	{
		public int? allianceId;
		public int? characterId;
		public int? corporationId;
		public int damageTaken;
		public int? factionId;
		public Drop[] items;
		public Position position;
		public int shipTypeId;
	}
	
	public struct SoAVictim
	{
		public readonly int?[] allianceIds;
		public readonly int?[] characterIds;
		public readonly int?[] corporationIds;
		public readonly int[] damageTakens;
		public readonly int?[] factionIds;
		public readonly SoADrop[] items;
		public readonly SoAPosition positions;
		public readonly int[] shipTypeIds;
		
		public SoAVictim(int count)
		{
			allianceIds = new int?[count];
			characterIds = new int?[count];
			corporationIds = new int?[count];
			damageTakens = new int[count];
			factionIds = new int?[count];
			items = new SoADrop[count];
			positions = new SoAPosition(count);
			shipTypeIds = new int[count];
		}
		
		public SoAVictim(params Victim[] victims)
		{
			int count = victims.Length;
			allianceIds = new int?[count];
			characterIds = new int?[count];
			corporationIds = new int?[count];
			damageTakens = new int[count];
			factionIds = new int?[count];
			items = new SoADrop[count];
			positions = new SoAPosition(count);
			shipTypeIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				allianceIds[i] = victims[i].allianceId;
				characterIds[i] = victims[i].characterId;
				corporationIds[i] = victims[i].corporationId;
				damageTakens[i] = victims[i].damageTaken;
				factionIds[i] = victims[i].factionId;
				items[i] = new(victims[i].items);
				shipTypeIds[i] = victims[i].shipTypeId;
			}
		}
	}
}