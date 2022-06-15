namespace EveSharp.Core.Models.Opportunities
{
	public struct Task
	{
		public string description;
		public string name;
		public string notification;
		public int taskId;
	}
	
	public struct SoATask
	{
		public readonly string[] descriptions;
		public readonly string[] names;
		public readonly string[] notifications;
		public readonly int[] taskIds;
		
		public SoATask(params Task[] tasks)
		{
			int count = tasks.Length;
			descriptions = new string[count];
			names = new string[count];
			notifications = new string[count];
			taskIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				descriptions[i] = tasks[i].description;
				names[i] = tasks[i].name;
				notifications[i] = tasks[i].notification;
				taskIds[i] = tasks[i].taskId;
			}
		}
	}
}