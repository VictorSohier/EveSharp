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
	
	public struct SoAAgentsResearch
	{
		public readonly int[] agentIds;
		public readonly float[] pointsPerDays;
		public readonly float[] remainderPointss;
		public readonly int[] skillTypeIds;
		public readonly DateTime[] startedAts;
		
		public SoAAgentsResearch(params AgentsResearch[] agentsResearches)
		{
			int count = agentsResearches.Length;
			agentIds = new int[count];
			pointsPerDays = new float[count];
			remainderPointss = new float[count];
			skillTypeIds = new int[count];
			startedAts = new DateTime[count];
			
			for (int i = 0; i < count; i++)
			{
				agentIds[i] = agentsResearches[i].agentId;
				pointsPerDays[i] = agentsResearches[i].pointsPerDay;
				remainderPointss[i] = agentsResearches[i].remainderPoints;
				skillTypeIds[i] = agentsResearches[i].skillTypeId;
				startedAts[i] = agentsResearches[i].startedAt;
			}
		}
	}
}