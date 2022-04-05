namespace EveSharp.Core.Models.Killmails
{
	public struct Drop
	{
		public int flag;
		public int itemTypeId;
		public Drop[] items;
		public long quantityDestroyed;
		public long quantityDropped;
		public int singleton;
	}
}