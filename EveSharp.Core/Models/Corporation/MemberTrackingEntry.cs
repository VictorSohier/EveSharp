namespace EveSharp.Core.Models.Corporation
{
	public struct MemberTrackingEntry
	{
		public int? baseId;
		public int characterId;
		public long? locationId;
		public DateTime logoffDate;
		public DateTime logonDate;
		public int? shipTypeId;
		public DateTime startDate;
	}
}