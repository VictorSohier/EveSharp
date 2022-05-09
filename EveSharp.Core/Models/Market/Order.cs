using EveSharp.Core.Enums.Market;

namespace EveSharp.Core.Models.Market
{
	public struct Order
	{
		public int duration;
		public bool? isBuyOrder;
		public DateTime issued;
		public long locationId;
		public int? minVolume;
		public long orderId;
		public double price;
		public string range;
		public int systemId;
		public State state;
		public int typeId;
		public int volumeRemain;
		public int volumeTotal;
	}
	
	public struct SoAOrder
	{
		public readonly int[] durations;
		public readonly bool?[] isBuyOrders;
		public readonly DateTime[] issueds;
		public readonly long[] locationIds;
		public readonly int?[] minVolumes;
		public readonly long[] orderIds;
		public readonly double[] prices;
		public readonly string[] ranges;
		public readonly int[] systemIds;
		public readonly State[] states;
		public readonly int[] typeIds;
		public readonly int[] volumeRemains;
		public readonly int[] volumeTotals;
		
		public SoAOrder(params Order[] orders)
		{
			int count = orders.Length;
			durations = new int[count];
			isBuyOrders = new bool?[count];
			issueds = new DateTime[count];
			locationIds = new long[count];
			minVolumes = new int?[count];
			orderIds = new long[count];
			prices = new double[count];
			ranges = new string[count];
			systemIds = new int[count];
			states = new State[count];
			typeIds = new int[count];
			volumeRemains = new int[count];
			volumeTotals = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				durations[i] = orders[i].duration;
				isBuyOrders[i] = orders[i].isBuyOrder;
				issueds[i] = orders[i].issued;
				locationIds[i] = orders[i].locationId;
				minVolumes[i] = orders[i].minVolume;
				orderIds[i] = orders[i].orderId;
				prices[i] = orders[i].price;
				ranges[i] = orders[i].range;
				systemIds[i] = orders[i].systemId;
				states[i] = orders[i].state;
				typeIds[i] = orders[i].typeId;
				volumeRemains[i] = orders[i].volumeRemain;
				volumeTotals[i] = orders[i].volumeTotal;
			}
		}
	}
}