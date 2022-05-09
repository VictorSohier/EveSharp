namespace EveSharp.Core.Models.FactionWarfare.Leaderboard
{
	public struct Leaderboard
	{
		public RollingEntry kills;
		public RollingEntry victoryPoints;
	}
	
	public struct SoALeaderboard
	{
		public readonly SoARollingEntry kills;
		public readonly SoARollingEntry victoryPoints;
		
		public SoALeaderboard(params Leaderboard[] leaderboards)
		{
			int count = leaderboards.Length;
			kills = new(count);
			victoryPoints = new(count);
			
			for (int i = 0; i < count; i++)
			{
				kills.lastWeeks[i] = new SoACount(leaderboards[i].kills.lastWeek);
				kills.yesterdays[i] = new SoACount(leaderboards[i].kills.yesterday);
				victoryPoints.lastWeeks[i] = new SoACount(leaderboards[i].victoryPoints.lastWeek);
				victoryPoints.yesterdays[i] = new SoACount(leaderboards[i].victoryPoints.yesterday);
			}
		}
	}
}