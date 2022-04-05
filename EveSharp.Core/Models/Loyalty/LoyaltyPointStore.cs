namespace EveSharp.Core.Models.Loyalty
{
	public struct LoyaltyPointStore
	{
		public int? aKCost;
		public long iSKCost;
		public int lPCost;
		public int offerId;
		public int quantity;
		public ExchangeItem[] requiredItems;
		public int typeId;
	}
}