namespace EveSharp.Core.Models.Character.Skills
{
	public struct Skills
	{
		public Skill[] skills;
		public long totalSp;
		public int unallocatedSp;
	}
	
	public struct SoASkills
	{
		public SoASkill[] skills;
		public long[] totalSps;
		public int[] unallocatedSps;
		
		public SoASkills(params Skills[] skills)
		{
			int count = skills.Length;
			this.skills = new SoASkill[count];
			totalSps = new long[count];
			unallocatedSps = new int[count];
			
			for(int i = 0; i < count; i++)
			{
				this.skills[i] = new SoASkill(skills[i].skills);
				totalSps[i] = skills[i].totalSp;
				unallocatedSps[i] = skills[i].unallocatedSp;
			}
		}
	}
}