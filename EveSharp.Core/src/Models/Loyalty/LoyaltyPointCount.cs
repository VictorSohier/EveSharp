namespace EveSharp.Core.Models.Loyalty
{
	public struct LoyaltyPointCount
	{
		public int corporationId;
		public int loyaltyPoints;
	}
	
	public struct SoALoyaltyPointCount
	{
		public readonly int[] corporationIds;
		public readonly int[] loyaltyPoints;
		
		public SoALoyaltyPointCount(params LoyaltyPointCount[] loyaltyPointCounts)
		{
			int count = loyaltyPointCounts.Length;
			corporationIds = new int[count];
			loyaltyPoints = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				corporationIds[i] = loyaltyPointCounts[i].corporationId;
				loyaltyPoints[i] = loyaltyPointCounts[i].loyaltyPoints;
			}
		}
	}
}