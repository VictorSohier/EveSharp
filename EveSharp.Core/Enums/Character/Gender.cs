using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EveSharp.Core.Enums.Character
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum Gender
	{
		Female,
		Male
	}
}