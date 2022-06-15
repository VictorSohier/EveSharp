namespace EveSharp.Core.Models.Opportunities
{
	public struct Opportunity
	{
		public DateTime completedAt;
		public int taskId;
	}
	
	public struct SoAOpportunity
	{
		public readonly DateTime[] completedAts;
		public readonly int[] taskIds;
		
		public SoAOpportunity(params Opportunity[] opportunities)
		{
			int count = opportunities.Length;
			completedAts = new DateTime[count];
			taskIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				completedAts[i] = opportunities[i].completedAt;
				taskIds[i] = opportunities[i].taskId;
			}
		}
	}
}