using EveSharp.Core.Enums.Corporation.Structure;

namespace EveSharp.Core.Models.Corporation.Structure
{
	public struct Structure
	{
		public int corporationId;
		public DateTime fuelExpires;
		public string name;
		public DateTime nextReinforceApply;
		public int? nextReinforceHour;
		public int profileId;
		public int? reinforceHour;
		public StructureService[] services;
		public StructureState state;
		public DateTime stateTimerEnd;
		public DateTime stateTimerStart;
		public long structureId;
		public int systemId;
		public int typeId;
		public DateTime unanchorsAt;
	}
}