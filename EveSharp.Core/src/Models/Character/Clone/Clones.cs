namespace EveSharp.Core.Models.Character.Clone
{
	public struct Clones
	{
		public DateTime lastCloneJumpDate;
		public DateTime lastStationChangeDate;
		public JumpClone[] jumpClones;
		public Location homeLocation;
	}
	
	public struct SoAClones
	{
		public readonly DateTime[] lastCloneJumpDates;
		public readonly DateTime[] lastStationChangeDates;
		public readonly SoAJumpClone[] jumpClones;
		public readonly SoALocation homeLocations;
		
		public SoAClones(params Clones[] clones)
		{
			int count = clones.Length;
			lastCloneJumpDates = new DateTime[count];
			lastStationChangeDates = new DateTime[count];
			jumpClones = new SoAJumpClone[count];
			homeLocations = new SoALocation(count);
			
			for (int i = 0; i < count; i++)
			{
				lastCloneJumpDates[i] = clones[i].lastCloneJumpDate;
				lastStationChangeDates[i] = clones[i].lastStationChangeDate;
				jumpClones[i] = new SoAJumpClone(clones[i].jumpClones);
				homeLocations.locationIds[i] = clones[i].homeLocation.locationId;
				homeLocations.locationTypes[i] = clones[i].homeLocation.locationType;
			}
		}
	}
}