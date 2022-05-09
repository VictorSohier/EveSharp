namespace EveSharp.Core.Models.Killmails
{
	public struct Drop
	{
		public int flag;
		public int itemTypeId;
		public Drop[] items;
		public long quantityDestroyed;
		public long quantityDropped;
		public int singleton;
	}
	
	public struct SoADrop
	{
		public readonly int[] flags;
		public readonly int[] itemTypeIds;
		public readonly SoADrop[] items;
		public readonly long[] quantityDestroyeds;
		public readonly long[] quantityDroppeds;
		public readonly int[] singletons;
		
		public SoADrop(params Drop[] drops)
		{
			int count = drops.Length;
			flags = new int[count];
			itemTypeIds = new int[count];
			items = new SoADrop[count];
			quantityDestroyeds = new long[count];
			quantityDroppeds = new long[count];
			singletons = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				flags[i] = drops[i].flag;
				itemTypeIds[i] = drops[i].itemTypeId;
				items[i] = new(drops[i].items);
				quantityDestroyeds[i] = drops[i].quantityDestroyed;
				quantityDroppeds[i] = drops[i].quantityDropped;
				singletons[i] = drops[i].singleton;
			}
		}
	}
}