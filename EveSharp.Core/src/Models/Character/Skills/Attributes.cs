namespace EveSharp.Core.Models.Character.Skills
{
	public struct Attributes
	{
		public DateTime accruedRemapCooldownDate;
		public int? bonusRemaps;
		public int charisma;
		public int intelligence;
		public DateTime lastRemapDate;
		public int memory;
		public int perception;
		public int willpower;
	}
	
	public struct SoAAttributes
	{
		public readonly DateTime[] accruedRemapCooldownDates;
		public readonly int?[] bonusRemapss;
		public readonly int[] charismas;
		public readonly int[] intelligences;
		public readonly DateTime[] lastRemapDates;
		public readonly int[] memorys;
		public readonly int[] perceptions;
		public readonly int[] willpowers;
		
		public SoAAttributes(params Attributes[] attributes)
		{
			int count = attributes.Length;
			accruedRemapCooldownDates = new DateTime[count];
			bonusRemapss = new int?[count];
			charismas = new int[count];
			intelligences = new int[count];
			lastRemapDates = new DateTime[count];
			memorys = new int[count];
			perceptions = new int[count];
			willpowers = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				accruedRemapCooldownDates[i] = attributes[i].accruedRemapCooldownDate;
				bonusRemapss[i] = attributes[i].bonusRemaps;
				charismas[i] = attributes[i].charisma;
				intelligences[i] = attributes[i].intelligence;
				lastRemapDates[i] = attributes[i].lastRemapDate;
				memorys[i] = attributes[i].memory;
				perceptions[i] = attributes[i].perception;
				willpowers[i] = attributes[i].willpower;
			}
		}
	}
}