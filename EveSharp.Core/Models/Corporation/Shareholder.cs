using EveSharp.Core.Enums.Corporation;

namespace EveSharp.Core.Models.Corporation
{
	public struct Shareholder
	{
		public long shareCount;
		public int shareholderId;
		public ShareholderType shareholderType;
	}
}