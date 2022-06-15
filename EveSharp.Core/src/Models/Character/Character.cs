using System.Security.AccessControl;
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
	
	public struct SoACharacter
	{
		public readonly int?[] allianceIds;
		public readonly DateTime[] birthdays;
		public readonly int[] bloodlineIds;
		public readonly int[] corporationIds;
		public readonly string[] descriptions;
		public readonly int?[] factionIds;
		public readonly Gender[] genders;
		public readonly string[] names;
		public readonly int[] raceIds;
		public readonly float?[] securityStatuses;
		public readonly string[] titles;
		
		public SoACharacter(params Character[] characters)
		{
			int count = characters.Length;
			allianceIds = new int?[count];
			birthdays = new DateTime[count];
			bloodlineIds = new int[count];
			corporationIds = new int[count];
			descriptions = new string[count];
			factionIds = new int?[count];
			genders = new Gender[count];
			names = new string[count];
			raceIds = new int[count];
			securityStatuses = new float?[count];
			titles = new string[count];
			
			for (int i = 0; i < count; i++)
			{
				allianceIds[i] = characters[i].allianceId;
				birthdays[i] = characters[i].birthday;
				bloodlineIds[i] = characters[i].bloodlineId;
				corporationIds[i] = characters[i].corporationId;
				descriptions[i] = characters[i].description;
				factionIds[i] = characters[i].factionId;
				genders[i] = characters[i].gender;
				names[i] = characters[i].name;
				raceIds[i] = characters[i].raceId;
				securityStatuses[i] = characters[i].securityStatus;
				titles[i] = characters[i].title;
			}
		}
	}
}