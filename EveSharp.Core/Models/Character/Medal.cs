using EveSharp.Core.Enums;

namespace EveSharp.Core.Models.Character
{
	public struct Medal
	{
		public int corporationId;
		public DateTime date;
		public string description;
		public int issuerId;
		public int medalId;
		public string reason;
		public string title;
		public GraphicComponent[] graphics;
		public Status status;
	}
	
	public struct SoAMedal
	{
		public readonly int[] corporationIds;
		public readonly DateTime[] dates;
		public readonly string[] descriptions;
		public readonly int[] issuerIds;
		public readonly int[] medalIds;
		public readonly string[] reasons;
		public readonly string[] titles;
		public readonly SoAGraphicComponent[] graphics;
		public readonly Status[] statuses;
		
		public SoAMedal(params Medal[] medals)
		{
			int count = medals.Length;
			corporationIds = new int[count];
			dates = new DateTime[count];
			descriptions = new string[count];
			issuerIds = new int[count];
			medalIds = new int[count];
			reasons = new string[count];
			titles = new string[count];
			graphics = new SoAGraphicComponent[count];
			statuses = new Status[count];
			
			for (int i = 0; i < count; i++)
			{
				corporationIds[i] = medals[i].corporationId;
				dates[i] = medals[i].date;
				descriptions[i] = medals[i].description;
				issuerIds[i] = medals[i].issuerId;
				medalIds[i] = medals[i].medalId;
				reasons[i] = medals[i].reason;
				titles[i] = medals[i].title;
				graphics[i] = new SoAGraphicComponent(medals[i].graphics);
				statuses[i] = medals[i].status;
			}
		}
	}
}