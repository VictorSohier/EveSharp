namespace EveSharp.Core.Models.Character
{
	public struct JumpFatigue
	{
		public DateTime jumpFatigueExpireDate;
		public DateTime lastJumpDate;
		public DateTime lastUpdateDate;
	}
	
	public struct SoAJumpFatigue
	{
		public readonly DateTime[] jumpFatigueExpireDates;
		public readonly DateTime[] lastJumpDates;
		public readonly DateTime[] lastUpdateDates;
		
		public SoAJumpFatigue(params JumpFatigue[] jumpFatigues)
		{
			int count = jumpFatigues.Length;
			jumpFatigueExpireDates = new DateTime[count];
			lastJumpDates = new DateTime[count];
			lastUpdateDates = new DateTime[count];
			
			for (int i = 0; i < count; i++)
			{
				jumpFatigueExpireDates[i] = jumpFatigues[i].jumpFatigueExpireDate;
				lastJumpDates[i] = jumpFatigues[i].lastJumpDate;
				lastUpdateDates[i] = jumpFatigues[i].lastUpdateDate;
			}
		}
	}
}