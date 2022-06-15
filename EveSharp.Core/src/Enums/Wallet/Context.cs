using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace EveSharp.Core.Enums.Wallet
{
	[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]

	public enum Context
	{
		StructureId,
		StationId,
		MarketTransactionId,
		CharacterId,
		CorporationId,
		AllianceId,
		EveSystem,
		IndustryJobId,
		ContractId,
		PlanetId,
		SystemId,
		TypeId
	}
}