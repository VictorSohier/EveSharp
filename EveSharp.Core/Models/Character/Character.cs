using EveSharp.Core.Enums.Character;

namespace EveSharp.Core.Models.Character
{
	public struct Character
	{
		public int? allianceId;
		public DateTime birthday;
		public int bloodlineId;
		public int corporationId;
		public string description;
		public int? factionId;
		public Gender gender;
		public string name;
		public int raceId;
		public float? securityStatus;
		public string title;
	}
}