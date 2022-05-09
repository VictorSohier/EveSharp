using EveSharp.Core.Enums.Sovereignty;

namespace EveSharp.Core.Models.Sovereignty
{
	public struct Campaign
	{
		public float? attackersScore;
		public int campaignId;
		public int constellationId;
		public int? defenderId;
		public float? defenderScore;
		public EventType EventType;
		public Participant[] participants;
		public int solarSystemId;
		public DateTime startTime;
		public long structureId;
	}
	
	public struct SoACampaign
	{
		public readonly float?[] attackersScores;
		public readonly int[] campaignIds;
		public readonly int[] constellationIds;
		public readonly int?[] defenderIds;
		public readonly float?[] defenderScores;
		public readonly EventType[] EventTypes;
		public readonly SoAParticipant[] participants;
		public readonly int[] solarSystemIds;
		public readonly DateTime[] startTimes;
		public readonly long[] structureIds;
		
		public SoACampaign(params Campaign[] campaigns)
		{
			int count = campaigns.Length;
			attackersScores = new float?[count];
			campaignIds = new int[count];
			constellationIds = new int[count];
			defenderIds = new int?[count];
			defenderScores = new float?[count];
			EventTypes = new EventType[count];
			participants = new SoAParticipant[count];
			solarSystemIds = new int[count];
			startTimes = new DateTime[count];
			structureIds = new long[count];
			
			for (int i = 0; i < count; i++)
			{
				attackersScores[i] = campaigns[i].attackersScore;
				campaignIds[i] = campaigns[i].campaignId;
				constellationIds[i] = campaigns[i].constellationId;
				defenderIds[i] = campaigns[i].defenderId;
				defenderScores[i] = campaigns[i].defenderScore;
				EventTypes[i] = campaigns[i].EventType;
				participants[i] = new (campaigns[i].participants);
				solarSystemIds[i] = campaigns[i].solarSystemId;
				startTimes[i] = campaigns[i].startTime;
				structureIds[i] = campaigns[i].structureId;
			}
		}
	}
}