namespace EveSharp.Core.Models.Insurance
{
	public struct PriceLevel
	{
		public float cost;
		public string name;
		public float payout;
	}
	
	public struct SoAPriceLevel
	{
		public readonly float[] costs;
		public readonly string[] names;
		public readonly float[] payouts;
		
		public SoAPriceLevel(params PriceLevel[] priceLevels)
		{
			int count = priceLevels.Length;
			costs = new float[count];
			names = new string[count];
			payouts = new float[count];
			
			for (int i = 0; i < count; i++)
			{
				costs[i] = priceLevels[i].cost;
				names[i] = priceLevels[i].name;
				payouts[i] = priceLevels[i].payout;
			}
		}
	}
}