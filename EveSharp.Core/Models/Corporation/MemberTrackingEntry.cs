namespace EveSharp.Core.Models.Corporation
{
	public struct MemberTrackingEntry
	{
		public int BaseId;
		public int CharacterId;
		public long LocationId;
		public DateTime LogoffDate;
		public DateTime LogonDate;
		public int ShipTypeId;
		public DateTime StartDate;
	}
}