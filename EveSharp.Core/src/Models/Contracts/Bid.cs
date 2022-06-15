namespace EveSharp.Core.Models.Contracts
{
	public struct Bid
	{
		public float amount;
		public int bidId;
		public int? bidderId;
		public DateTime dateBid;
	}
	
	public struct SoABid
	{
		public readonly float[] amounts;
		public readonly int[] bidIds;
		public readonly int?[] bidderIds;
		public readonly DateTime[] dateBids;
		
		public SoABid(params Bid[] bids)
		{
			int count = bids.Length;
			amounts = new float[count];
			bidIds = new int[count];
			bidderIds = new int?[count];
			dateBids = new DateTime[count];
			
			for (int i = 0; i < count; i++)
			{
				amounts[i] = bids[i].amount;
				bidIds[i] = bids[i].bidId;
				bidderIds[i] = bids[i].bidderId;
				dateBids[i] = bids[i].dateBid;
			}
		}
	}
}