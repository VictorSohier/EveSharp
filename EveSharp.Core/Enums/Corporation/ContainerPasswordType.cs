using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EveSharp.Core.Enums.Corporation
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum ContainerPasswordType
	{
		Config,
		General
	}
}