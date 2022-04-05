using EveSharp.Core.Enums.Industry;

namespace EveSharp.Core.Models.Industry
{
	public struct CorporationJob
	{
		public int activityId;
		public long blueprintId;
		public long blueprintLocationId;
		public int blueprintTypeId;
		public int? completedCharacterId;
		public DateTime completedDate;
		public double? cost;
		public int duration;
		public DateTime endDate;
		public long facilityId;
		public int installerId;
		public int jobId;
		public int? licensedRuns;
		public long locationId;
		public long outputLocationId;
		public DateTime pauseDate;
		public float? probability;
		public int? productTypeId;
		public int runs;
		public DateTime startDate;
		public Status status;
		public int? successfulRuns;
	}
}