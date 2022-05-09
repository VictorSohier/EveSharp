namespace EveSharp.Core.Models.Market
{
	public struct Price
	{
		public double? adjustedPrice;
		public double? averagePrice;
		public int typeId;
	}
	
	public struct SoAPrice
	{
		public readonly double?[] adjustedPrices;
		public readonly double?[] averagePrices;
		public readonly int[] typeIds;
		
		public SoAPrice(params Price[] prices)
		{
			int count = prices.Length;
			adjustedPrices = new double?[count];
			averagePrices = new double?[count];
			typeIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				adjustedPrices[i] = prices[i].adjustedPrice;
				averagePrices[i] = prices[i].averagePrice;
				typeIds[i] = prices[i].typeId;
			}
		}
	}
}