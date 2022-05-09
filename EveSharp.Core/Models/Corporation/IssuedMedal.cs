using EveSharp.Core.Enums;

namespace EveSharp.Core.Models.Corporation
{
	public struct IssuedMedal
	{
		public int characterId;
		public DateTime issuedAt;
		public int issuerId;
		public int medalId;
		public string reason;
		public Status status;
	}
	
	public struct SoAIssuedMedal
	{
		public readonly int[] characterIds;
		public readonly DateTime[] issuedAts;
		public readonly int[] issuerIds;
		public readonly int[] medalIds;
		public readonly string[] reasons;
		public readonly Status[] statuses;
		
		public SoAIssuedMedal(params IssuedMedal[] issuedMedals)
		{
			int count = issuedMedals.Length;
			characterIds = new int[count];
			issuedAts = new DateTime[count];
			issuerIds = new int[count];
			medalIds = new int[count];
			reasons = new string[count];
			statuses = new Status[count];
			
			for (int i = 0; i < count; i++)
			{
				characterIds[i] = issuedMedals[i].characterId;
				issuedAts[i] = issuedMedals[i].issuedAt;
				issuerIds[i] = issuedMedals[i].issuerId;
				medalIds[i] = issuedMedals[i].medalId;
				reasons[i] = issuedMedals[i].reason;
				statuses[i] = issuedMedals[i].status;
			}
		}
	}
}