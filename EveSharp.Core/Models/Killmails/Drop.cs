namespace EveSharp.Core.Models.Killmails
{
	public struct Drop
	{
		public int Flag;
		public int ItemTypeId;
		public Drop[] Items;
		public long QuantityDestroyed;
		public long QuantityDropped;
		public int Singleton;
	}
}