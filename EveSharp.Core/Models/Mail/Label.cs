namespace EveSharp.Core.Models.Mail
{
	public struct Label
	{
		public string color;
		public int? labelId;
		public string name;
		public int? unreadCount;
	}
	
	public struct SoALabel
	{
		public readonly string[] colors;
		public readonly int?[] labelIds;
		public readonly string[] names;
		public readonly int?[] unreadCounts;
		
		public SoALabel(params Label[] labels)
		{
			int count = labels.Length;
			colors = new string[count];
			labelIds = new int?[count];
			names = new string[count];
			unreadCounts = new int?[count];
			
			for (int i = 0; i < count; i++)
			{
				colors[i] = labels[i].color;
				labelIds[i] = labels[i].labelId;
				names[i] = labels[i].name;
				unreadCounts[i] = labels[i].unreadCount;
			}
		}
	}
}