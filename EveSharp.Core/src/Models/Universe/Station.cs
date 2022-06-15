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
	
	public struct SoAStation
	{
		public readonly float[] maxDockableShipVolumes;
		public readonly string[] names;
		public readonly float[] officeRentalCosts;
		public readonly SoAPosition positions;
		public readonly int?[] raceIds;
		public readonly float[] reprocessingEfficiencys;
		public readonly float[] reprocessingStationsTakes;
		public readonly Services[][] services;
		public readonly int[] stationIds;
		public readonly int[] systemIds;
		public readonly int[] typeIds;
		
		public SoAStation(params Station[] stations)
		{
			int count = stations.Length;
			maxDockableShipVolumes = new float[count];
			names = new string[count];
			officeRentalCosts = new float[count];
			positions = new SoAPosition(count);
			raceIds = new int?[count];
			reprocessingEfficiencys = new float[count];
			reprocessingStationsTakes = new float[count];
			services = new Services[count][];
			stationIds = new int[count];
			systemIds = new int[count];
			typeIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				int servicesLength = stations[i].services.Length;
				maxDockableShipVolumes[i] = stations[i].maxDockableShipVolume;
				names[i] = stations[i].name;
				officeRentalCosts[i] = stations[i].officeRentalCost;
				positions.xs[i] = stations[i].position.x;
				positions.ys[i] = stations[i].position.y;
				positions.zs[i] = stations[i].position.z;
				raceIds[i] = stations[i].raceId;
				reprocessingEfficiencys[i] = stations[i].reprocessingEfficiency;
				reprocessingStationsTakes[i] = stations[i].reprocessingStationsTake;
				services[i] = new Services[servicesLength];
				stationIds[i] = stations[i].stationId;
				systemIds[i] = stations[i].systemId;
				typeIds[i] = stations[i].typeId;
				Array.Copy(stations[i].services, services[i], servicesLength);
			}
		}
	}
}