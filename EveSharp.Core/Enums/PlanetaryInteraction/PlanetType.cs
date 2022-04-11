using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EveSharp.Core.Enums.PlanetaryInteraction
{
	[JsonConverter(typeof(StringEnumConverter))]
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