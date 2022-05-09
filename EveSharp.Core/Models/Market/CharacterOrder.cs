using EveSharp.Core.Enums.Market;

namespace EveSharp.Core.Models.Market
{
	public struct CharacterOrder
	{
		public int duration;
		public double? escrow;
		public bool? isBuyOrder;
		public bool isCorporation;
		public DateTime issued;
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
	}
	
	public struct SoACharacterOrder
	{
		public readonly int[] durations;
		public readonly double?[] escrows;
		public readonly bool?[] isBuyOrders;
		public readonly bool[] isCorporations;
		public readonly DateTime[] issueds;
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
		
		public SoACharacterOrder(params CharacterOrder[] characterOrders)
		{
			int count = characterOrders.Length;
			durations = new int[count];
			escrows = new double?[count];
			isBuyOrders = new bool?[count];
			isCorporations = new bool[count];
			issueds = new DateTime[count];
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
			
			for (int i = 0; i < count; i++)
			{
				durations[i] = characterOrders[i].duration;
				escrows[i] = characterOrders[i].escrow;
				isBuyOrders[i] = characterOrders[i].isBuyOrder;
				isCorporations[i] = characterOrders[i].isCorporation;
				issueds[i] = characterOrders[i].issued;
				locationIds[i] = characterOrders[i].locationId;
				minVolumes[i] = characterOrders[i].minVolume;
				orderIds[i] = characterOrders[i].orderId;
				prices[i] = characterOrders[i].price;
				ranges[i] = characterOrders[i].range;
				regionIds[i] = characterOrders[i].regionId;
				states[i] = characterOrders[i].state;
				typeIds[i] = characterOrders[i].typeId;
				volumeRemains[i] = characterOrders[i].volumeRemain;
				volumeTotals[i] = characterOrders[i].volumeTotal;
			}
		}
	}
}