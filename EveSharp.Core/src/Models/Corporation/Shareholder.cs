using EveSharp.Core.Enums.Corporation;

namespace EveSharp.Core.Models.Corporation
{
	public struct Shareholder
	{
		public long shareCount;
		public int shareholderId;
		public ShareholderType shareholderType;
	}
	
	public struct SoAShareholder
	{
		public readonly long[] shareCounts;
		public readonly int[] shareholderIds;
		public readonly ShareholderType[] shareholderTypes;
		
		public SoAShareholder(params Shareholder[] shareholders)
		{
			int count = shareholders.Length;
			shareCounts = new long[count];
			shareholderIds = new int[count];
			shareholderTypes = new ShareholderType[count];
			
			for (int i = 0; i < count; i++)
			{
				shareCounts[i] = shareholders[i].shareCount;
				shareholderIds[i] = shareholders[i].shareholderId;
				shareholderTypes[i] = shareholders[i].shareholderType;
			}
		}
	}
}