namespace EveSharp.Core.Models.Loyalty
{
	public struct LoyaltyPointStore
	{
		public int? AKCost;
		public long ISKCost;
		public int LPCost;
		public int OfferId;
		public int Quantity;
		public ExchangeItem[] RequiredItems;
		public int TypeId;
	}
}