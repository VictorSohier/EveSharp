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
}