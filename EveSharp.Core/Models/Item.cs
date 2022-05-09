namespace EveSharp.Core.Models
{
    public struct Item
    {
        public long itemId;
        public int typeId;
    }
	
    public struct SoAItem
    {
        public readonly long[] itemIds;
        public readonly int[] typeIds;
		
		public SoAItem(params Item[] items)
		{
			int count = items.Length;
			itemIds = new long[count];
			typeIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				itemIds[i] = items[i].itemId;
				typeIds[i] = items[i].typeId;
			}
		}
    }
}