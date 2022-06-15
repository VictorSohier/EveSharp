namespace EveSharp.Core.Models.Server
{
	public struct Status
	{
		public int players;
		public string serverVersion;
		public DateTime startTime;
		public bool? vip;
	}
	
	public struct SoAStatus
	{
		public readonly int[] players;
		public readonly string[] serverVersions;
		public readonly DateTime[] startTimes;
		public readonly bool?[] vips;
		
		public SoAStatus(params Status[] statuses)
		{
			int count = statuses.Length;
			players = new int[count];
			serverVersions = new string[count];
			startTimes = new DateTime[count];
			vips = new bool?[count];
			
			for (int i = 0; i < count; i++)
			{
				players[i] = statuses[i].players;
				serverVersions[i] = statuses[i].serverVersion;
				startTimes[i] = statuses[i].startTime;
				vips[i] = statuses[i].vip;
			}
		}
	}
}