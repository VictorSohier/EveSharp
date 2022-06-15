namespace EveSharp.Core.Models.Character.Skills
{
	public struct QueuedSkill
	{
		public DateTime finishDate;
		public int finishedLevel;
		public int? levelEndSp;
		public int? levelStartSp;
		public int queuePosition;
		public int skillId;
		public DateTime startDate;
		public int? trainingStartSp;
	}
	
	public struct SoAQueuedSkill
	{
		public readonly DateTime[] finishDates;
		public readonly int[] finishedLevels;
		public readonly int?[] levelEndSps;
		public readonly int?[] levelStartSps;
		public readonly int[] queuePositions;
		public readonly int[] skillIds;
		public readonly DateTime[] startDates;
		public readonly int?[] trainingStartSps;
		
		public SoAQueuedSkill(params QueuedSkill[] queuedSkills)
		{
			int count = queuedSkills.Length;
			finishDates = new DateTime[count];
			finishedLevels = new int[count];
			levelEndSps = new int?[count];
			levelStartSps = new int?[count];
			queuePositions = new int[count];
			skillIds = new int[count];
			startDates = new DateTime[count];
			trainingStartSps = new int?[count];
			
			for (int i = 0; i < count; i++)
			{
				finishDates[i] = queuedSkills[i].finishDate;
				finishedLevels[i] = queuedSkills[i].finishedLevel;
				levelEndSps[i] = queuedSkills[i].levelEndSp;
				levelStartSps[i] = queuedSkills[i].levelStartSp;
				queuePositions[i] = queuedSkills[i].queuePosition;
				skillIds[i] = queuedSkills[i].skillId;
				startDates[i] = queuedSkills[i].startDate;
				trainingStartSps[i] = queuedSkills[i].trainingStartSp;
			}
		}
	}
}