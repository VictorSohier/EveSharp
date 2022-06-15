using EveSharp.Core.Enums;

namespace EveSharp.Core.Models.Fitting
{
	public struct Item
	{
		public LocationFlag flag;
		public int quantity;
		public int typeId;
	}
	
	public struct SoAItem
	{
		public readonly LocationFlag[] flags;
		public readonly int[] quantitys;
		public readonly int[] typeIds;
		
		public SoAItem(params Item[] items)
		{
			int count = items.Length;
			flags = new LocationFlag[count];
			quantitys = new int[count];
			typeIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				flags[i] = items[i].flag;
				quantitys[i] = items[i].quantity;
				typeIds[i] = items[i].typeId;
			}
		}
	}
}