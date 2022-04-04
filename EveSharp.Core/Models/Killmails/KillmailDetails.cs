namespace EveSharp.Core.Models.Killmails
{
	public struct KillmailDetails
	{
		public Attacker[] Attackers;
		public int KillmailId;
		public DateTime KillmailTime;
		public int? MoonId;
		public int SolarSystemId;
		public Victim Victim;
		public int? WarId;
	}
}