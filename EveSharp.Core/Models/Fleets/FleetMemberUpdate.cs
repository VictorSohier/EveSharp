using EveSharp.Core.Enums.Fleets;

namespace EveSharp.Core.Models.Fleets
{
	public struct FleetMemberUpdate
	{
		public Role Role;
		public long? SquadId;
		public long? WingId;
	}
}