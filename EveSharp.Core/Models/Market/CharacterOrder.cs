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
}