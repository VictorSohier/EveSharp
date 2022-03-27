using EveSharp.Core.Enums.Corporation.Structure;

namespace EveSharp.Core.Models.Corporation.Structure
{
	public struct Starbase
	{
		public int MoonId;
		public DateTime OnlinedSince;
		public DateTime ReinforcedUntil;
		public long StarbaseId;
		public StarbaseState State;
		public int SystemId;
		public int TypeId;
		public DateTime UnanchorAt;
	}
}