using EveSharp.Core.Enums.Industry;

namespace EveSharp.Core.Models.Industry
{
	public struct MiningObserver
	{
		public DateTime lastUpdated;
		public long observerId;
		public ObserverType observerType;
	}
	
	public struct SoAMiningObserver
	{
		public readonly DateTime[] lastUpdateds;
		public readonly long[] observerIds;
		public readonly ObserverType[] observerTypes;
		
		public SoAMiningObserver(params MiningObserver[] miningObservers)
		{
			int count = miningObservers.Length;
			lastUpdateds = new DateTime[count];
			observerIds = new long[count];
			observerTypes = new ObserverType[count];
			
			for (int i = 0; i < count; i++)
			{
				lastUpdateds[i] = miningObservers[i].lastUpdated;
				observerIds[i] = miningObservers[i].observerId;
				observerTypes[i] = miningObservers[i].observerType;
			}
		}
	}
}