using EveSharp.Core.Enums.Corporation;

namespace EveSharp.Core.Models.Corporation
{
	public struct Shareholder
	{
		public long ShareCount;
		public int ShareholderId;
		public ShareholderType ShareholderType;
	}
}