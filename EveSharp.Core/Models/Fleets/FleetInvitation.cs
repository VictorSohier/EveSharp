using EveSharp.Core.Enums.Fleets;

namespace EveSharp.Core.Models.Fleets
{
	public struct FleetInvitation
	{
		public int characterId;
		public Role role;
		public long? squadId;
		public long? wingId;
	}
	
	public struct SoAFleetInvitation
	{
		public readonly int[] characterIds;
		public readonly Role[] roles;
		public readonly long?[] squadIds;
		public readonly long?[] wingIds;
		
		public SoAFleetInvitation(params FleetInvitation[] fleetInvitations)
		{
			int count = fleetInvitations.Length;
			characterIds = new int[count];
			roles = new Role[count];
			squadIds = new long?[count];
			wingIds = new long?[count];
			
			for (int i = 0; i < count; i++)
			{
				characterIds[i] = fleetInvitations[i].characterId;
				roles[i] = fleetInvitations[i].role;
				squadIds[i] = fleetInvitations[i].squadId;
				wingIds[i] = fleetInvitations[i].wingId;
			}
		}
	}
}