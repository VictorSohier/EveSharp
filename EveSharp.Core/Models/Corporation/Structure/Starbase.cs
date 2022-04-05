using EveSharp.Core.Enums.Corporation.Structure;

namespace EveSharp.Core.Models.Corporation.Structure
{
	public struct Starbase
	{
		public int? moonId;
		public DateTime onlinedSince;
		public DateTime reinforcedUntil;
		public long starbaseId;
		public StarbaseState state;
		public int systemId;
		public int typeId;
		public DateTime unanchorAt;
	}
}