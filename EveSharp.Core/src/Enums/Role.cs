using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace EveSharp.Core.Enums
{
	[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]

	public enum Role
	{
		AccountTake1,
		AccountTake2,
		AccountTake3,
		AccountTake4,
		AccountTake5,
		AccountTake6,
		AccountTake7,
		Accountant,
		Auditor,
		CommunicationsOfficer,
		ConfigEquipment,
		ConfigStarbaseEquipment,
		ContainerTake1,
		ContainerTake2,
		ContainerTake3,
		ContainerTake4,
		ContainerTake5,
		ContainerTake6,
		ContainerTake7,
		ContractManager,
		Diplomat,
		Director,
		FactoryManager,
		FittingManager,
		HangarQuery1,
		HangarQuery2,
		HangarQuery3,
		HangarQuery4,
		HangarQuery5,
		HangarQuery6,
		HangarQuery7,
		HangarTake1,
		HangarTake2,
		HangarTake3,
		HangarTake4,
		HangarTake5,
		HangarTake6,
		HangarTake7,
		JuniorAccountant,
		PersonnelManager,
		RentFactoryFacility,
		RentOffice,
		RentResearchFacility,
		SecurityOfficer,
		StarbaseDefenseOperator,
		StarbaseFuelTechnician,
		StationManager,
		Trader
	}
}