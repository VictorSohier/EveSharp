using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EveSharp.Core.Enums.Industry
{
	[JsonConverter(typeof(StringEnumConverter))]
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