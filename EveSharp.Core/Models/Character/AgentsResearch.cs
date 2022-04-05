namespace EveSharp.Core.Models.Character
{
	public struct AgentsResearch
	{
		public int agentId;
		public float pointsPerDay;
		public float remainderPoints;
		public int skillTypeId;
		public DateTime startedAt;
	}
}