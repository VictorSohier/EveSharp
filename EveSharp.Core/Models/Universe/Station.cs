using EveSharp.Core.Enums.Universe;

namespace EveSharp.Core.Models.Universe
{
	public struct Station
	{
		public float maxDockableShipVolume;
		public string name;
		public float officeRentalCost;
		public Position position;
		public int? raceId;
		public float reprocessingEfficiency;
		public float reprocessingStationsTake;
		public Services[] services;
		public int stationId;
		public int systemId;
		public int typeId;
	}
}