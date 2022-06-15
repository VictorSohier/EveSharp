namespace EveSharp.Core.Models.Fitting
{
	public struct Fit
	{
		public string description;
		public int fittingId;
		public Item[] items;
		public string name;
		public int shipTypeId;
	}
	
	public struct SoAFit
	{
		public readonly string[] descriptions;
		public readonly int[] fittingIds;
		public readonly SoAItem[] items;
		public readonly string[] names;
		public readonly int[] shipTypeIds;
		
		public SoAFit(params Fit[] fits)
		{
			int count = fits.Length;
			descriptions = new string[count];
			fittingIds = new int[count];
			items = new SoAItem[count];
			names = new string[count];
			shipTypeIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				descriptions[i] = fits[i].description;
				fittingIds[i] = fits[i].fittingId;
				items[i] = new(fits[i].items);
				names[i] = fits[i].name;
				shipTypeIds[i] = fits[i].shipTypeId;
			}
		}
	}
}