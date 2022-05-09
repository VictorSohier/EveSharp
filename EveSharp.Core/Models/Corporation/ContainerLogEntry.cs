using EveSharp.Core.Enums;
using EveSharp.Core.Enums.Corporation;

namespace EveSharp.Core.Models.Corporation
{
	public struct ContainerLogEntry
	{
		public ContainerLogActionType action;
		public int characterId;
		public long containerId;
		public int containerTypeId;
		public LocationFlag locationFlag;
		public long locationId;
		public DateTime loggedAt;
		public int? newConfigBitmask;
		public int? oldConfigBitmask;
		public ContainerPasswordType passwordType;
		public int? quantity;
		public int? typeId;
	}
	
	public struct SoAContainerLogEntry
	{
		public readonly ContainerLogActionType[] actions;
		public readonly int[] characterIds;
		public readonly long[] containerIds;
		public readonly int[] containerTypeIds;
		public readonly LocationFlag[] locationFlags;
		public readonly long[] locationIds;
		public readonly DateTime[] loggedAts;
		public readonly int?[] newConfigBitmasks;
		public readonly int?[] oldConfigBitmasks;
		public readonly ContainerPasswordType[] passwordTypes;
		public readonly int?[] quantitys;
		public readonly int?[] typeIds;
		
		public SoAContainerLogEntry(params ContainerLogEntry[] containerLogEntries)
		{
			int count = containerLogEntries.Length;
			actions = new ContainerLogActionType[count];
			characterIds = new int[count];
			containerIds = new long[count];
			containerTypeIds = new int[count];
			locationFlags = new LocationFlag[count];
			locationIds = new long[count];
			loggedAts = new DateTime[count];
			newConfigBitmasks = new int?[count];
			oldConfigBitmasks = new int?[count];
			passwordTypes = new ContainerPasswordType[count];
			quantitys = new int?[count];
			typeIds = new int?[count];
			
			for (int i = 0; i < count; i++)
			{
				actions[i] = containerLogEntries[i].action;
				characterIds[i] = containerLogEntries[i].characterId;
				containerIds[i] = containerLogEntries[i].containerId;
				containerTypeIds[i] = containerLogEntries[i].containerTypeId;
				locationFlags[i] = containerLogEntries[i].locationFlag;
				locationIds[i] = containerLogEntries[i].locationId;
				loggedAts[i] = containerLogEntries[i].loggedAt;
				newConfigBitmasks[i] = containerLogEntries[i].newConfigBitmask;
				oldConfigBitmasks[i] = containerLogEntries[i].oldConfigBitmask;
				passwordTypes[i] = containerLogEntries[i].passwordType;
				quantitys[i] = containerLogEntries[i].quantity;
				typeIds[i] = containerLogEntries[i].typeId;
			}
		}
	}
}