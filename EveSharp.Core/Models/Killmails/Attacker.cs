namespace EveSharp.Core.Models.Killmails
{
	public struct Attacker
	{
		public int? allianceId;
		public int? characterId;
		public int? corporationId;
		public int damageDone;
		public int? factionId;
		public bool finalBlow;
		public float securityStatus;
		public int? shipTypeId;
		public int? weaponTypeId;
	}
	
	public struct SoAAttacker
	{
		public readonly int?[] allianceIds;
		public readonly int?[] characterIds;
		public readonly int?[] corporationIds;
		public readonly int[] damageDones;
		public readonly int?[] factionIds;
		public readonly bool[] finalBlows;
		public readonly float[] securityStatuss;
		public readonly int?[] shipTypeIds;
		public readonly int?[] weaponTypeIds;
		
		public SoAAttacker(params Attacker[] attackers)
		{
			int count = attackers.Length;
			allianceIds = new int?[count];
			characterIds = new int?[count];
			corporationIds = new int?[count];
			damageDones = new int[count];
			factionIds = new int?[count];
			finalBlows = new bool[count];
			securityStatuss = new float[count];
			shipTypeIds = new int?[count];
			weaponTypeIds = new int?[count];
			
			for (int i = 0; i < count; i++)
			{
				allianceIds[i] = attackers[i].allianceId;
				characterIds[i] = attackers[i].characterId;
				corporationIds[i] = attackers[i].corporationId;
				damageDones[i] = attackers[i].damageDone;
				factionIds[i] = attackers[i].factionId;
				finalBlows[i] = attackers[i].finalBlow;
				securityStatuss[i] = attackers[i].securityStatus;
				shipTypeIds[i] = attackers[i].shipTypeId;
				weaponTypeIds[i] = attackers[i].weaponTypeId;
			}
		}
	}
}