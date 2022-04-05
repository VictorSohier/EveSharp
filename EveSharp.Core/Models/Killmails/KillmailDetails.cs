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
}