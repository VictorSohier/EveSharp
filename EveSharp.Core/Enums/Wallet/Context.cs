using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EveSharp.Core.Enums.Wallet
{
	[JsonConverter(typeof(StringEnumConverter))]
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