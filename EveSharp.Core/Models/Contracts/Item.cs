namespace EveSharp.Core.Models.Contracts
{
	public struct Item
	{
		public bool isIncluded;
		public bool isSingleton;
		public int quantity;
		public int rawQuantity;
		public long recordId;
		public int typeId;
		public bool? isBlueprintCopy;
		public long? itemId;
		public int? materialEfficiency;
		public int? runs;
		public int? timeEfficiency;
	}
	
	public struct SoAItem
	{
		public readonly bool[] isIncludeds;
		public readonly bool[] isSingletons;
		public readonly int[] quantitys;
		public readonly int[] rawQuantitys;
		public readonly long[] recordIds;
		public readonly int[] typeIds;
		public readonly bool?[] isBlueprintCopys;
		public readonly long?[] itemIds;
		public readonly int?[] materialEfficiencys;
		public readonly int?[] runs;
		public readonly int?[] timeEfficiencys;
		
		public SoAItem(params Item[] items)
		{
			int count = items.Length;
			isIncludeds = new bool[count];
			isSingletons = new bool[count];
			quantitys = new int[count];
			rawQuantitys = new int[count];
			recordIds = new long[count];
			typeIds = new int[count];
			isBlueprintCopys = new bool?[count];
			itemIds = new long?[count];
			materialEfficiencys = new int?[count];
			runs = new int?[count];
			timeEfficiencys = new int?[count];
			
			for (int i = 0; i < count; i++)
			{
				isIncludeds[i] = items[i].isIncluded;
				isSingletons[i] = items[i].isSingleton;
				quantitys[i] = items[i].quantity;
				rawQuantitys[i] = items[i].rawQuantity;
				recordIds[i] = items[i].recordId;
				typeIds[i] = items[i].typeId;
				isBlueprintCopys[i] = items[i].isBlueprintCopy;
				itemIds[i] = items[i].itemId;
				materialEfficiencys[i] = items[i].materialEfficiency;
				runs[i] = items[i].runs;
				timeEfficiencys[i] = items[i].timeEfficiency;
			}
		}
	}
}