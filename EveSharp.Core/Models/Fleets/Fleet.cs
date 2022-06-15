using EveSharp.Core.Enums.Fleets;

namespace EveSharp.Core.Models.Fleets
{
	public struct Fleet
	{
		public long fleetId;
		public Role role;
		public long squadId;
		public long wingId;
		public long fleetBossId;
	}
	
	public struct SoAFleet
	{
		public readonly long[] fleetIds;
		public readonly Role[] roles;
		public readonly long[] squadIds;
		public readonly long[] wingIds;
		public readonly long[] fleetBossIds;
		
		public SoAFleet(params Fleet[] fleets)
		{
			int count = fleets.Length;
			fleetIds = new long[count];
			roles = new Role[count];
			squadIds = new long[count];
			wingIds = new long[count];
			fleetBossIds = new long[count];
			
			for (int i = 0; i < count; i++)
			{
				fleetIds[i] = fleets[i].fleetId;
				roles[i] = fleets[i].role;
				squadIds[i] = fleets[i].squadId;
				wingIds[i] = fleets[i].wingId;
				fleetBossIds[i] = fleets[i].fleetBossId;
			}
		}
	}
}