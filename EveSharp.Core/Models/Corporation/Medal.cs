namespace EveSharp.Core.Models.Corporation
{
	public struct Medal
	{
		public DateTime createdAt;
		public int creatorId;
		public string description;
		public int medalId;
		public string title;
	}
	
	public struct SoAMedal
	{
		public readonly DateTime[] createdAts;
		public readonly int[] creatorIds;
		public readonly string[] descriptions;
		public readonly int[] medalIds;
		public readonly string[] titles;
		
		public SoAMedal(params Medal[] medals)
		{
			int count = medals.Length;
			createdAts = new DateTime[count];
			creatorIds = new int[count];
			descriptions = new string[count];
			medalIds = new int[count];
			titles = new string[count];
			
			for (int i = 0; i < count; i++)
			{
				createdAts[i] = medals[i].createdAt;
				creatorIds[i] = medals[i].creatorId;
				descriptions[i] = medals[i].description;
				medalIds[i] = medals[i].medalId;
				titles[i] = medals[i].title;
			}
		}
	}
}