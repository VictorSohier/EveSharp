using EveSharp.Core.Enums.Industry;

namespace EveSharp.Core.Models.Industry
{
	public struct Job
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
		public long outputLocationId;
		public DateTime pauseDate;
		public float? probability;
		public int? productTypeId;
		public int runs;
		public DateTime startDate;
		public long stationId;
		public Status status;
		public int? successfulRuns;
	}
	
	public struct SoAJob
	{
		public readonly int[] activityIds;
		public readonly long[] blueprintIds;
		public readonly long[] blueprintLocationIds;
		public readonly int[] blueprintTypeIds;
		public readonly int?[] completedCharacterIds;
		public readonly DateTime[] completedDates;
		public readonly double?[] costs;
		public readonly int[] durations;
		public readonly DateTime[] endDates;
		public readonly long[] facilityIds;
		public readonly int[] installerIds;
		public readonly int[] jobIds;
		public readonly int?[] licensedRuns;
		public readonly long[] outputLocationIds;
		public readonly DateTime[] pauseDates;
		public readonly float?[] probabilitys;
		public readonly int?[] productTypeIds;
		public readonly int[] runs;
		public readonly DateTime[] startDates;
		public readonly long[] stationIds;
		public readonly Status[] statuses;
		public readonly int?[] successfulRuns;
		
		public SoAJob(params Job[] jobs)
		{
			int count = jobs.Length;
			activityIds = new int[count];
			blueprintIds = new long[count];
			blueprintLocationIds = new long[count];
			blueprintTypeIds = new int[count];
			completedCharacterIds = new int?[count];
			completedDates = new DateTime[count];
			costs = new double?[count];
			durations = new int[count];
			endDates = new DateTime[count];
			facilityIds = new long[count];
			installerIds = new int[count];
			jobIds = new int[count];
			licensedRuns = new int?[count];
			outputLocationIds = new long[count];
			pauseDates = new DateTime[count];
			probabilitys = new float?[count];
			productTypeIds = new int?[count];
			runs = new int[count];
			startDates = new DateTime[count];
			stationIds = new long[count];
			statuses = new Status[count];
			successfulRuns = new int?[count];
			
			for (int i = 0; i < count; i++)
			{
				activityIds[i] = jobs[i].activityId;
				blueprintIds[i] = jobs[i].blueprintId;
				blueprintLocationIds[i] = jobs[i].blueprintLocationId;
				blueprintTypeIds[i] = jobs[i].blueprintTypeId;
				completedCharacterIds[i] = jobs[i].completedCharacterId;
				completedDates[i] = jobs[i].completedDate;
				costs[i] = jobs[i].cost;
				durations[i] = jobs[i].duration;
				endDates[i] = jobs[i].endDate;
				facilityIds[i] = jobs[i].facilityId;
				installerIds[i] = jobs[i].installerId;
				jobIds[i] = jobs[i].jobId;
				licensedRuns[i] = jobs[i].licensedRuns;
				outputLocationIds[i] = jobs[i].outputLocationId;
				pauseDates[i] = jobs[i].pauseDate;
				probabilitys[i] = jobs[i].probability;
				productTypeIds[i] = jobs[i].productTypeId;
				runs[i] = jobs[i].runs;
				startDates[i] = jobs[i].startDate;
				stationIds[i] = jobs[i].stationId;
				statuses[i] = jobs[i].status;
				successfulRuns[i] = jobs[i].successfulRuns;
			}
		}
	}
}