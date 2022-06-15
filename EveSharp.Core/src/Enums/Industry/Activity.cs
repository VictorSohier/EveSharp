using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace EveSharp.Core.Enums.Industry
{
	[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]

	public enum Activity
	{
		Copying,
		Duplicating,
		Invention,
		Manufacturing,
		None,
		Reaction,
		ResearchingMaterialEfficiency,
		ResearchingTechnology,
		ResearchingTimeEfficiency,
		ReverseEngineering
	}
}