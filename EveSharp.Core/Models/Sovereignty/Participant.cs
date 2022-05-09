namespace EveSharp.Core.Models.Sovereignty
{
	public struct Participant
	{
		public int allianceId;
		public float score;
	}
	
	public struct SoAParticipant
	{
		public readonly int[] allianceIds;
		public readonly float[] scores;
		
		public SoAParticipant(params Participant[] participants)
		{
			int count = participants.Length;
			allianceIds = new int[count];
			scores = new float[count];
			
			for (int i = 0; i < count; i++)
			{
				allianceIds[i] = participants[i].allianceId;
				scores[i] = participants[i].score;
			}
		}
	}
}