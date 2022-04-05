using EveSharp.Core.Enums.Fleets;

namespace EveSharp.Core.Models.Fleets
{
	public struct FleetMember
	{
		public int characterId;
		public DateTime joinTime;
		public Role role;
		public string roleName;
		public int shipTypeId;
		public int solarSystemId;
		public long squadId;
		public long? stationId;
		public bool takesFleetWarp;
		public long wingId;
	}
}