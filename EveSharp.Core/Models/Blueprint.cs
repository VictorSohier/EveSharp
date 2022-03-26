using EveSharp.Core.Enums;

namespace EveSharp.Core.Models
{
	public struct Blueprint
	{
		public long ItemId;
		public LocationFlag LocationFlag;
		public long LocationId;
		public int MaterialEfficiency;
		public int Quantity;
		public int Runs;
		public int TimeEfficiency;
		public int TypeId;
	}
}