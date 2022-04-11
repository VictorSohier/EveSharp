using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EveSharp.Core.Enums.Corporation
{
	[JsonConverter(typeof(StringEnumConverter))]
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