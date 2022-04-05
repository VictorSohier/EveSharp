using EveSharp.Core.Enums;

namespace EveSharp.Core.Models
{
	public struct Blueprint
	{
		public long itemId;
		public LocationFlag locationFlag;
		public long locationId;
		public int materialEfficiency;
		public int quantity;
		public int runs;
		public int timeEfficiency;
		public int typeId;
	}
}