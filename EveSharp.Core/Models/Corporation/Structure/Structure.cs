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
	
	public struct SoAStructure
	{
		public readonly int[] corporationIds;
		public readonly DateTime[] fuelExpires;
		public readonly string[] names;
		public readonly DateTime[] nextReinforceApplys;
		public readonly int?[] nextReinforceHours;
		public readonly int[] profileIds;
		public readonly int?[] reinforceHours;
		public readonly SoAStructureService[] services;
		public readonly StructureState[] states;
		public readonly DateTime[] stateTimerEnds;
		public readonly DateTime[] stateTimerStarts;
		public readonly long[] structureIds;
		public readonly int[] systemIds;
		public readonly int[] typeIds;
		public readonly DateTime[] unanchorsAts;
		
		public SoAStructure(params Structure[] structures)
		{
			int count = structures.Length;
			corporationIds = new int[count];
			fuelExpires = new DateTime[count];
			names = new string[count];
			nextReinforceApplys = new DateTime[count];
			nextReinforceHours = new int?[count];
			profileIds = new int[count];
			reinforceHours = new int?[count];
			services = new SoAStructureService[count];
			states = new StructureState[count];
			stateTimerEnds = new DateTime[count];
			stateTimerStarts = new DateTime[count];
			structureIds = new long[count];
			systemIds = new int[count];
			typeIds = new int[count];
			unanchorsAts = new DateTime[count];
			
			for (int i = 0; i < count; i++)
			{
				corporationIds[i] = structures[i].corporationId;
				fuelExpires[i] = structures[i].fuelExpires;
				names[i] = structures[i].name;
				nextReinforceApplys[i] = structures[i].nextReinforceApply;
				nextReinforceHours[i] = structures[i].nextReinforceHour;
				profileIds[i] = structures[i].profileId;
				reinforceHours[i] = structures[i].reinforceHour;
				services[i] = new SoAStructureService(structures[i].services);
				states[i] = structures[i].state;
				stateTimerEnds[i] = structures[i].stateTimerEnd;
				stateTimerStarts[i] = structures[i].stateTimerStart;
				structureIds[i] = structures[i].structureId;
				systemIds[i] = structures[i].systemId;
				typeIds[i] = structures[i].typeId;
				unanchorsAts[i] = structures[i].unanchorsAt;
			}
		}
	}
}