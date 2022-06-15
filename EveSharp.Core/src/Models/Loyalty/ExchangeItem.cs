namespace EveSharp.Core.Models.Loyalty
{
	public struct ExchangeItem
	{
		public int quantity;
		public int typeId;
	}
	
	public struct SoAExchangeItem
	{
		public readonly int[] quantities;
		public readonly int[] typeIds;
		
		public SoAExchangeItem(params ExchangeItem[] exchangeItems)
		{
			int count = exchangeItems.Length;
			quantities = new int[count];
			typeIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				quantities[i] = exchangeItems[i].quantity;
				typeIds[i] = exchangeItems[i].typeId;
			}
		}
	}
}