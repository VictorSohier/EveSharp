using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EveSharp.Core.Enums.Universe
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum Services
	{
		BountyMissions,
		AssasinationMissions,
		CourierMissions,
		Interbus,
		ReprocessingPlant,
		Refinery,
		Market,
		BlackMarket,
		StockExchange,
		Cloning,
		Surgery,
		DnaTherapy,
		RepairFacilities,
		Factory,
		Labratory,
		Gambling,
		Fitting,
		Paintshop,
		News,
		Storage,
		Insurance,
		Docking,
		OfficeRental,
		JumpCloneFacility,
		LoyaltyPointStore,
		NavyOffices,
		SecurityOffices
	}
}