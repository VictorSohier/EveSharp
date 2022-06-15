namespace EveSharp.Core.Models.Insurance
{
	public struct Prices
	{
		public PriceLevel[] levels;
		public int typeId;
	}
	
	public struct SoAPrices
	{
		public readonly SoAPriceLevel[] levels;
		public readonly int[] typeIds;
		
		public SoAPrices(params Prices[] prices)
		{
			int count = prices.Length;
			levels = new SoAPriceLevel[count];
			typeIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				levels[i] = new(prices[i].levels);
				typeIds[i] = prices[i].typeId;
			}
		}
	}
}