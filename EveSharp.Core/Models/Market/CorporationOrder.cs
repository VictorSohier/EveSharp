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
}