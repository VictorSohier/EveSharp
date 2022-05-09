namespace EveSharp.Core.Models
{
	public struct ItemStack
	{
		public long amount;
		public int typeId;
	}
	
	public struct SoAItemStack
	{
		public readonly long[] amounts;
		public readonly int[] typeIds;
		
		public SoAItemStack(params ItemStack[] itemStacks)
		{
			int count = itemStacks.Length;
			amounts = new long[count];
			typeIds = new int[count];
			
			for (int i = 0; i < count; i ++)
			{
				amounts[i] = itemStacks[i].amount;
				typeIds[i] = itemStacks[i].typeId;
			}
		}
	}
}