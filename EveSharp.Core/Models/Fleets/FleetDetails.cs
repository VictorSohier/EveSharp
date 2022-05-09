namespace EveSharp.Core.Models.Fleets
{
	public struct FleetDetails
	{
		public bool isFreeMove;
		public bool isRegistered;
		public bool isVoiceEnabled;
		public string motd;
	}
	
	public struct SoAFleetDetails
	{
		public readonly bool[] isFreeMoves;
		public readonly bool[] isRegistereds;
		public readonly bool[] isVoiceEnableds;
		public readonly string[] motds;
		
		public SoAFleetDetails(params FleetDetails[] fleetDetails)
		{
			int count = fleetDetails.Length;
			isFreeMoves = new bool[count];
			isRegistereds = new bool[count];
			isVoiceEnableds = new bool[count];
			motds = new string[count];
			
			for (int i = 0; i < count; i++)
			{
				isFreeMoves[i] = fleetDetails[i].isFreeMove;
				isRegistereds[i] = fleetDetails[i].isRegistered;
				isVoiceEnableds[i] = fleetDetails[i].isVoiceEnabled;
				motds[i] = fleetDetails[i].motd;
			}
		}
	}
}