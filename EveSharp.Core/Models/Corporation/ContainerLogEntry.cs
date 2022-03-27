using EveSharp.Core.Enums;
using EveSharp.Core.Enums.Corporation;

namespace EveSharp.Core.Models.Corporation
{
	public struct ContainerLogEntry
	{
		public ContainerLogActionType Action;
		public int CharacterId;
		public long ContainerId;
		public int ContainerTypeId;
		public LocationFlag LocationFlag;
		public long LocationId;
		public DateTime LoggedAt;
		public int NewConfigBitmask;
		public int OldConfigBitmask;
		public ContainerPasswordType PasswordType;
		public int Quantity;
		public int TypeId;
	}
}