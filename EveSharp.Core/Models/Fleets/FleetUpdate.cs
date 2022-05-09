namespace EveSharp.Core.Models.Fleets
{
	public struct FleetUpdate
	{
		public bool? isFreeMove;
		public string? motd;
	}
	
	public struct SoAFleetUpdate
	{
		public readonly bool?[] isFreeMoves;
		public readonly string?[] motds;
		
		public SoAFleetUpdate(params FleetUpdate[] fleetUpdates)
		{
			int count = fleetUpdates.Length;
			isFreeMoves = new bool?[count];
			motds = new string?[count];
			
			for (int i = 0; i < count; i++)
			{
				isFreeMoves[i] = fleetUpdates[i].isFreeMove;
				motds[i] = fleetUpdates[i].motd;
			}
		}
	}
}