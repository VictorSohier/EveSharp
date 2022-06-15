namespace EveSharp.Core.Models.Dogma.Dynamic
{
	public struct Item
	{
		public int createdBy;
		public Attribute[] dogmaAttributes;
		public Effect[] dogmaEffects;
		public int mutatorTypeId;
		public int sourceTypeId;
	}
	
	public struct SoAItem
	{
		public readonly int[] createdBys;
		public readonly SoAAttribute[] dogmaAttributes;
		public readonly SoAEffect[] dogmaEffects;
		public readonly int[] mutatorTypeIds;
		public readonly int[] sourceTypeIds;
		
		public SoAItem(params Item[] items)
		{
			int count = items.Length;
			createdBys = new int[count];
			dogmaAttributes = new SoAAttribute[count];
			dogmaEffects = new SoAEffect[count];
			mutatorTypeIds = new int[count];
			sourceTypeIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				createdBys[i] = items[i].createdBy;
				dogmaAttributes[i] = new SoAAttribute(items[i].dogmaAttributes);
				dogmaEffects[i] = new SoAEffect(items[i].dogmaEffects);
				mutatorTypeIds[i] = items[i].mutatorTypeId;
				sourceTypeIds[i] = items[i].sourceTypeId;
			}
		}
	}
}