using EveSharp.Core.Enums.Fleets;

namespace EveSharp.Core.Models.Fleets
{
	public struct FleetMember
	{
		public int CharacterId;
		public DateTime JoinTime;
		public Role Role;
		public string RoleName;
		public int ShipTypeId;
		public int SolarSystemId;
		public long SquadId;
		public long? StationId;
		public bool TakesFleetWarp;
		public long WingId;
	}
}