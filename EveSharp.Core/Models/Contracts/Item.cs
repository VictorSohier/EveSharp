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
}