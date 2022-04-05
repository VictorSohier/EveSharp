using EveSharp.Core.Enums.Fleets;

namespace EveSharp.Core.Models.Fleets
{
	public struct FleetMemberUpdate
	{
		public Role role;
		public long? squadId;
		public long? wingId;
	}
}