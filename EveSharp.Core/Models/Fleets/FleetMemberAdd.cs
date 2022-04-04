using EveSharp.Core.Enums.Fleets;

namespace EveSharp.Core.Models.Fleets
{
	public struct FleetMemberAdd
	{
		public int CharacterId;
		public Role Role;
		public long? SquadId;
		public long? WingId;
	}
}