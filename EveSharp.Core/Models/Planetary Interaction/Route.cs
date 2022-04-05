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
}