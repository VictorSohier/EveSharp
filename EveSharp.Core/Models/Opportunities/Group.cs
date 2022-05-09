namespace EveSharp.Core.Models.Opportunities
{
	public struct Group
	{
		public int[] connectedGroups;
		public string description;
		public int groupId;
		public string name;
		public string notification;
		public int[] requiredTasks;
	}
	
	public struct SoAGroup
	{
		public readonly int[][] connectedGroups;
		public readonly string[] descriptions;
		public readonly int[] groupIds;
		public readonly string[] names;
		public readonly string[] notifications;
		public readonly int[][] requiredTasks;
		
		public SoAGroup(params Group[] groups)
		{
			int count = groups.Length;
			connectedGroups = new int[count][];
			descriptions = new string[count];
			groupIds = new int[count];
			names = new string[count];
			notifications = new string[count];
			requiredTasks = new int[count][];
			
			for (int i = 0; i < count; i++)
			{
				connectedGroups[i] = groups[i].connectedGroups;
				descriptions[i] = groups[i].description;
				groupIds[i] = groups[i].groupId;
				names[i] = groups[i].name;
				notifications[i] = groups[i].notification;
				requiredTasks[i] = groups[i].requiredTasks;
			}
		}
	}
}