using EveSharp.Core.Enums.Corporation.Structure;

namespace EveSharp.Core.Models.Corporation.Structure
{
	public struct Structure
	{
		public int CorporationId;
		public DateTime FuelExpires;
		public string Name;
		public DateTime NextReinforceApply;
		public int? NextReinforceHour;
		public int ProfileId;
		public int? ReinforceHour;
		public StructureService[] Services;
		public StructureState State;
		public DateTime StateTimerEnd;
		public DateTime StateTimerStart;
		public long StructureId;
		public int SystemId;
		public int TypeId;
		public DateTime UnanchorsAt;
	}
}