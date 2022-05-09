namespace EveSharp.Core.Models.Universe
{
	public struct Bloodline
	{
		public int bloodlineId;
		public int charisma;
		public int corporationId;
		public string description;
		public int intelligence;
		public int memory;
		public string name;
		public int perception;
		public int raceId;
		public int shipTypeId;
		public int willpower;
	}
	
	public struct SoABloodline
	{
		public readonly int[] bloodlineIds;
		public readonly int[] charismas;
		public readonly int[] corporationIds;
		public readonly string[] descriptions;
		public readonly int[] intelligences;
		public readonly int[] memorys;
		public readonly string[] names;
		public readonly int[] perceptions;
		public readonly int[] raceIds;
		public readonly int[] shipTypeIds;
		public readonly int[] willpowers;
		
		public SoABloodline(params Bloodline[] bloodlines)
		{
			int count = bloodlines.Length;
			bloodlineIds = new int[count];
			charismas = new int[count];
			corporationIds = new int[count];
			descriptions = new string[count];
			intelligences = new int[count];
			memorys = new int[count];
			names = new string[count];
			perceptions = new int[count];
			raceIds = new int[count];
			shipTypeIds = new int[count];
			willpowers = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				bloodlineIds[i] = bloodlines[i].bloodlineId;
				charismas[i] = bloodlines[i].charisma;
				corporationIds[i] = bloodlines[i].corporationId;
				descriptions[i] = bloodlines[i].description;
				intelligences[i] = bloodlines[i].intelligence;
				memorys[i] = bloodlines[i].memory;
				names[i] = bloodlines[i].name;
				perceptions[i] = bloodlines[i].perception;
				raceIds[i] = bloodlines[i].raceId;
				shipTypeIds[i] = bloodlines[i].shipTypeId;
				willpowers[i] = bloodlines[i].willpower;
			}
		}
	}
}