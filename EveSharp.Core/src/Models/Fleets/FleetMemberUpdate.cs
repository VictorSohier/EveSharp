using EveSharp.Core.Enums.Fleets;

namespace EveSharp.Core.Models.Fleets
{
	public struct FleetMemberUpdate
	{
		public Role role;
		public long? squadId;
		public long? wingId;
	}
	
	public struct SoAFleetMemberUpdate
	{
		public readonly Role[] roles;
		public readonly long?[] squadIds;
		public readonly long?[] wingIds;
		
		public SoAFleetMemberUpdate(params FleetMemberUpdate[] fleetMemberUpdates)
		{
			int count = fleetMemberUpdates.Length;
			roles = new Role[count];
			squadIds = new long?[count];
			wingIds = new long?[count];
			
			for (int i = 0; i < count; i++)
			{
				roles[i] = fleetMemberUpdates[i].role;
				squadIds[i] = fleetMemberUpdates[i].squadId;
				wingIds[i] = fleetMemberUpdates[i].wingId;
			}
		}
	}
}