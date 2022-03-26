namespace EveSharp.Core.Models.Contracts
{
	public struct PublicContractItem
	{
		public bool IsIncluded;
		public bool IsSingleton;
		public int Quantity;
		public int RawQuantity;
		public long RecordId;
		public int TypeId;
		public bool IsBlueprintCopy;
		public long ItemId;
		public int MaterialEfficiency;
		public int Runs;
		public int TimeEfficiency;
	}
}