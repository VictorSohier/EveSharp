using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace EveSharp.Core.Enums.PlanetaryInteraction
{
	[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]

	public enum PlanetType
	{
		Temperate,
		Barren,
		Oceanic,
		Ice,
		Gas,
		Lava,
		Storm
		
	}
}