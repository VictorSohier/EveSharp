namespace EveSharp.Core.Models.Killmails
{
	public struct Victim
	{
		public int? AllianceId;
		public int? CharacterId;
		public int? CorporationId;
		public int DamageTaken;
		public int? FactionId;
		public Drop[] Items;
		public Position Position;
		public int ShipTypeId;
	}
}