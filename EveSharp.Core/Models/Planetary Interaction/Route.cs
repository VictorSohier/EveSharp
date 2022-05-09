using System.Runtime.Intrinsics.X86;

namespace EveSharp.Core.Models.PlanetaryInteraction
{
	public struct Route
	{
		public int contentTypeId;
		public long destinationPinId;
		public float quantity;
		public long routeId;
		public long sourcePinId;
		public long[] waypoints;
	}
	
	public struct SoARoute
	{
		public readonly int[] contentTypeIds;
		public readonly long[] destinationPinIds;
		public readonly float[] quantitys;
		public readonly long[] routeIds;
		public readonly long[] sourcePinIds;
		public readonly long[][] waypoints;
		
		public SoARoute(params Route[] routes)
		{
			int count = routes.Length;
			contentTypeIds = new int[count];
			destinationPinIds = new long[count];
			quantitys = new float[count];
			routeIds = new long[count];
			sourcePinIds = new long[count];
			waypoints = new long[count][];
			
			for (int i = 0; i < count; i++)
			{
				contentTypeIds[i] = routes[i].contentTypeId;
				destinationPinIds[i] = routes[i].destinationPinId;
				quantitys[i] = routes[i].quantity;
				routeIds[i] = routes[i].routeId;
				sourcePinIds[i] = routes[i].sourcePinId;
				waypoints[i] = routes[i].waypoints;
			}
		}
	}
}