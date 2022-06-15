namespace EveSharp.Core.Models.Character
{
	public struct Title
	{
		public string name;
		public int? titleId;
	}
	
	public struct SoATitle
	{
		public readonly string[] names;
		public readonly int?[] titleIds;
		
		public SoATitle(params Title[] titles)
		{
			int count = titles.Length;
			names = new string[count];
			titleIds = new int?[count];
			
			for (int i = 0; i < count; i++)
			{
				names[i] = titles[i].name;
				titleIds[i] = titles[i].titleId;
			}
		}
	}
}