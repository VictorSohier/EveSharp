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
}