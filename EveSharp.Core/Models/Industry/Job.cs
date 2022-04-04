using EveSharp.Core.Enums.Industry;

namespace EveSharp.Core.Models.Industry
{
	public struct Job
	{
		public int ActivityId;
		public long BlueprintId;
		public long BlueprintLocationId;
		public int BlueprintTypeId;
		public int? CompletedCharacterId;
		public DateTime CompletedDate;
		public double? Cost;
		public int Duration;
		public DateTime EndDate;
		public long FacilityId;
		public int InstallerId;
		public int JobId;
		public int? LicensedRuns;
		public long OutputLocationId;
		public DateTime PauseDate;
		public float? Probability;
		public int? ProductTypeId;
		public int Runs;
		public DateTime StartDate;
		public long StationId;
		public Status Status;
		public int? SuccessfulRuns;
	}
}