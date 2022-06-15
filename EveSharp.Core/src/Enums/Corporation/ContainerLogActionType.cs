using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace EveSharp.Core.Enums.Corporation
{
	[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]

	public enum ContainerLogActionType
	{
		Add,
		Assemble,
		Configure,
		EnterPassword,
		Lock,
		Move,
		Repackage,
		SetName,
		SetPassword,
		Unlock
	}
}