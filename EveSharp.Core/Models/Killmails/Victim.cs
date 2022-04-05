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
}