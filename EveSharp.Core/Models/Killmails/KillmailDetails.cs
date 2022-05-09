namespace EveSharp.Core.Models.Killmails
{
	public struct KillmailDetails
	{
		public Attacker[] attackers;
		public int killmailId;
		public DateTime killmailTime;
		public int? moonId;
		public int solarSystemId;
		public Victim victim;
		public int? warId;
	}
	
	public struct SoAKillmailDetails
	{
		public readonly SoAAttacker[] attackers;
		public readonly int[] killmailIds;
		public readonly DateTime[] killmailTimes;
		public readonly int?[] moonIds;
		public readonly int[] solarSystemIds;
		public readonly SoAVictim victims;
		public readonly int?[] warIds;
		
		public SoAKillmailDetails(params KillmailDetails[] killmailDetails)
		{
			int count = killmailDetails.Length;
			attackers = new SoAAttacker[count];
			killmailIds = new int[count];
			killmailTimes = new DateTime[count];
			moonIds = new int?[count];
			solarSystemIds = new int[count];
			victims = new SoAVictim(count);
			warIds = new int?[count];
			
			for (int i = 0; i < count; i++)
			{
				attackers[i] = new(killmailDetails[i].attackers);
				killmailIds[i] = killmailDetails[i].killmailId;
				killmailTimes[i] = killmailDetails[i].killmailTime;
				moonIds[i] = killmailDetails[i].moonId;
				solarSystemIds[i] = killmailDetails[i].solarSystemId;
				victims.allianceIds[i] = killmailDetails[i].victim.allianceId;
				victims.characterIds[i] = killmailDetails[i].victim.characterId;
				victims.corporationIds[i] = killmailDetails[i].victim.corporationId;
				victims.damageTakens[i] = killmailDetails[i].victim.damageTaken;
				victims.factionIds[i] = killmailDetails[i].victim.factionId;
				victims.items[i] = new(killmailDetails[i].victim.items);
				victims.positions.xs[i] = killmailDetails[i].victim.position.x;
				victims.positions.ys[i] = killmailDetails[i].victim.position.y;
				victims.positions.zs[i] = killmailDetails[i].victim.position.z;
				victims.shipTypeIds[i] = killmailDetails[i].victim.shipTypeId;
				warIds[i] = killmailDetails[i].warId;
			}
		}
	}
}