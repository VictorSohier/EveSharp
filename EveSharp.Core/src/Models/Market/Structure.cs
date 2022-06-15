namespace EveSharp.Core.Models.Market
{
	public struct Structure
	{
		public int duration;
		public bool isBuyOrder;
		public DateTime issued;
		public long locationId;
		public int minVolume;
		public long orderId;
		public double price;
		public string range;
		public int typeId;
		public int volumeRemain;
		public int volumeTotal;
	}
	
	public struct SoAStructure
	{
		public readonly int[] durations;
		public readonly bool[] isBuyOrders;
		public readonly DateTime[] issueds;
		public readonly long[] locationIds;
		public readonly int[] minVolumes;
		public readonly long[] orderIds;
		public readonly double[] prices;
		public readonly string[] ranges;
		public readonly int[] typeIds;
		public readonly int[] volumeRemains;
		public readonly int[] volumeTotals;
		
		public SoAStructure(params Structure[] structures)
		{
			int count = structures.Length;
			durations = new int[count];
			isBuyOrders = new bool[count];
			issueds = new DateTime[count];
			locationIds = new long[count];
			minVolumes = new int[count];
			orderIds = new long[count];
			prices = new double[count];
			ranges = new string[count];
			typeIds = new int[count];
			volumeRemains = new int[count];
			volumeTotals = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				durations[i] = structures[i].duration;
				isBuyOrders[i] = structures[i].isBuyOrder;
				issueds[i] = structures[i].issued;
				locationIds[i] = structures[i].locationId;
				minVolumes[i] = structures[i].minVolume;
				orderIds[i] = structures[i].orderId;
				prices[i] = structures[i].price;
				ranges[i] = structures[i].range;
				typeIds[i] = structures[i].typeId;
				volumeRemains[i] = structures[i].volumeRemain;
				volumeTotals[i] = structures[i].volumeTotal;
			}
		}
	}
}