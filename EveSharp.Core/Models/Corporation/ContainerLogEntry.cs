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
}