namespace EveSharp.Core.Models.Character.Skills
{
	public struct Skill
	{
		public int activeSkillLevel;
		public int skillId;
		public long skillpointsInSkill;
		public int trainedSkillLevel;
	}
	
	public struct SoASkill
	{
		public readonly int[] activeSkillLevels;
		public readonly int[] skillIds;
		public readonly long[] skillpointsInSkills;
		public readonly int[] trainedSkillLevels;
		
		public SoASkill(params Skill[] skills)
		{
			int count = skills.Length;
			activeSkillLevels = new int[count];
			skillIds = new int[count];
			skillpointsInSkills = new long[count];
			trainedSkillLevels = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				activeSkillLevels[i] = skills[i].activeSkillLevel;
				skillIds[i] = skills[i].skillId;
				skillpointsInSkills[i] = skills[i].skillpointsInSkill;
				trainedSkillLevels[i] = skills[i].trainedSkillLevel;
			}
		}
	}
}