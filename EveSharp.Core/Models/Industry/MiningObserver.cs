using EveSharp.Core.Enums.Industry;

namespace EveSharp.Core.Models.Industry
{
	public struct MiningObserver
	{
		public DateTime lastUpdated;
		public long observerId;
		public ObserverType observerType;
	}
}