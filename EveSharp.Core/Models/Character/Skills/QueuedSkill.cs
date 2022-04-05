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
}