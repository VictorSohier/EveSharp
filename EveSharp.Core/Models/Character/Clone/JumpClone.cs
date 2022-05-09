using EveSharp.Core.Enums;

namespace EveSharp.Core.Models.Character.Clone
{
	public struct JumpClone
	{
		public int[] implants;
		public int jumpCloneId;
		public long locationId;
		public LocationType locationType;
		public string name;
	}
	
	public struct SoAJumpClone
	{
		public readonly int[][] implants;
		public readonly int[] jumpCloneIds;
		public readonly long[] locationIds;
		public readonly LocationType[] locationTypes;
		public readonly string[] names;
		
		public SoAJumpClone(params JumpClone[] jumpClones)
		{
			int count = jumpClones.Length;
			implants = new int[count][];
			jumpCloneIds = new int[count];
			locationIds = new long[count];
			locationTypes = new LocationType[count];
			names = new string[count];
			
			for (int i = 0; i < count; i++)
			{
				int implantsLength = jumpClones[i].implants.Length;
				implants[i] = new int[implantsLength];
				jumpCloneIds[i] = jumpClones[i].jumpCloneId;
				locationIds[i] = jumpClones[i].locationId;
				locationTypes[i] = jumpClones[i].locationType;
				names[i] = jumpClones[i].name;
				Array.Copy(jumpClones[i].implants, implants, implantsLength);
			}
		}
	}
}