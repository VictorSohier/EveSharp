using EveSharp.Core.Enums.Fleets;

namespace EveSharp.Core.Models.Fleets
{
	public struct FleetMemberAdd
	{
		public int characterId;
		public Role role;
		public long? squadId;
		public long? wingId;
	}
}