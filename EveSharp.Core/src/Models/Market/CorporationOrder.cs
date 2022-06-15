using EveSharp.Core.Enums.Market;

namespace EveSharp.Core.Models.Market
{
	public struct CorporationOrder
	{
		public int duration;
		public double? escrow;
		public bool? isBuyOrder;
		public DateTime issued;
		public int issuedBy;
		public long locationId;
		public int? minVolume;
		public long orderId;
		public double price;
		public string range;
		public int regionId;
		public State state;
		public int typeId;
		public int volumeRemain;
		public int volumeTotal;
		public int walletDivisions;
	}
	
	public struct SoACorporationOrder
	{
		public readonly int[] durations;
		public readonly double?[] escrows;
		public readonly bool?[] isBuyOrders;
		public readonly DateTime[] issueds;
		public readonly int[] issuedBys;
		public readonly long[] locationIds;
		public readonly int?[] minVolumes;
		public readonly long[] orderIds;
		public readonly double[] prices;
		public readonly string[] ranges;
		public readonly int[] regionIds;
		public readonly State[] states;
		public readonly int[] typeIds;
		public readonly int[] volumeRemains;
		public readonly int[] volumeTotals;
		public readonly int[] walletDivisions;
		
		public SoACorporationOrder(params CorporationOrder[] corporationOrders)
		{
			int count = corporationOrders.Length;
			durations = new int[count];
			escrows = new double?[count];
			isBuyOrders = new bool?[count];
			issueds = new DateTime[count];
			issuedBys = new int[count];
			locationIds = new long[count];
			minVolumes = new int?[count];
			orderIds = new long[count];
			prices = new double[count];
			ranges = new string[count];
			regionIds = new int[count];
			states = new State[count];
			typeIds = new int[count];
			volumeRemains = new int[count];
			volumeTotals = new int[count];
			walletDivisions = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				durations[i] = corporationOrders[i].duration;
				escrows[i] = corporationOrders[i].escrow;
				isBuyOrders[i] = corporationOrders[i].isBuyOrder;
				issueds[i] = corporationOrders[i].issued;
				issuedBys[i] = corporationOrders[i].issuedBy;
				locationIds[i] = corporationOrders[i].locationId;
				minVolumes[i] = corporationOrders[i].minVolume;
				orderIds[i] = corporationOrders[i].orderId;
				prices[i] = corporationOrders[i].price;
				ranges[i] = corporationOrders[i].range;
				regionIds[i] = corporationOrders[i].regionId;
				states[i] = corporationOrders[i].state;
				typeIds[i] = corporationOrders[i].typeId;
				volumeRemains[i] = corporationOrders[i].volumeRemain;
				volumeTotals[i] = corporationOrders[i].volumeTotal;
				walletDivisions[i] = corporationOrders[i].walletDivisions;
			}
		}
	}
}