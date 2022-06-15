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
	
	public struct SoALoyaltyPointStore
	{
		public readonly int?[] aKCosts;
		public readonly long[] iSKCosts;
		public readonly int[] lPCosts;
		public readonly int[] offerIds;
		public readonly int[] quantitys;
		public readonly SoAExchangeItem[] requiredItems;
		public readonly int[] typeIds;
		
		public SoALoyaltyPointStore(params LoyaltyPointStore[] loyaltyPointStores)
		{
			int count = loyaltyPointStores.Length;
			aKCosts = new int?[count];
			iSKCosts = new long[count];
			lPCosts = new int[count];
			offerIds = new int[count];
			quantitys = new int[count];
			requiredItems = new SoAExchangeItem[count];
			typeIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				aKCosts[i] = loyaltyPointStores[i].aKCost;
				iSKCosts[i] = loyaltyPointStores[i].iSKCost;
				lPCosts[i] = loyaltyPointStores[i].lPCost;
				offerIds[i] = loyaltyPointStores[i].offerId;
				quantitys[i] = loyaltyPointStores[i].quantity;
				requiredItems[i] = new(loyaltyPointStores[i].requiredItems);
				typeIds[i] = loyaltyPointStores[i].typeId;
			}
		}
	}
}