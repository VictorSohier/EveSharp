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
	
	public struct SoAFleetMember
	{
		public readonly int[] characterIds;
		public readonly DateTime[] joinTimes;
		public readonly Role[] roles;
		public readonly string[] roleNames;
		public readonly int[] shipTypeIds;
		public readonly int[] solarSystemIds;
		public readonly long[] squadIds;
		public readonly long?[] stationIds;
		public readonly bool[] takesFleetWarps;
		public readonly long[] wingIds;
		
		public SoAFleetMember(params FleetMember[] fleetMembers)
		{
			int count = fleetMembers.Length;
			characterIds = new int[count];
			joinTimes = new DateTime[count];
			roles = new Role[count];
			roleNames = new string[count];
			shipTypeIds = new int[count];
			solarSystemIds = new int[count];
			squadIds = new long[count];
			stationIds = new long?[count];
			takesFleetWarps = new bool[count];
			wingIds = new long[count];
			
			for (int i = 0; i < count; i++)
			{
				characterIds[i] = fleetMembers[i].characterId;
				joinTimes[i] = fleetMembers[i].joinTime;
				roles[i] = fleetMembers[i].role;
				roleNames[i] = fleetMembers[i].roleName;
				shipTypeIds[i] = fleetMembers[i].shipTypeId;
				solarSystemIds[i] = fleetMembers[i].solarSystemId;
				squadIds[i] = fleetMembers[i].squadId;
				stationIds[i] = fleetMembers[i].stationId;
				takesFleetWarps[i] = fleetMembers[i].takesFleetWarp;
				wingIds[i] = fleetMembers[i].wingId;
			}
		}
	}
}