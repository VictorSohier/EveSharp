using EveSharp.Core.Enums.Industry;
using EveSharp.Core.Models.Corporation;

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
	
	public struct SoACorporationJob
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
		public readonly long[] locationIds;
		public readonly long[] outputLocationIds;
		public readonly DateTime[] pauseDates;
		public readonly float?[] probabilitys;
		public readonly int?[] productTypeIds;
		public readonly int[] runs;
		public readonly DateTime[] startDates;
		public readonly Status[] statuses;
		public readonly int?[] successfulRuns;
		
		public SoACorporationJob(params CorporationJob[] corporationJobs)
		{
			int count = corporationJobs.Length;
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
			locationIds = new long[count];
			outputLocationIds = new long[count];
			pauseDates = new DateTime[count];
			probabilitys = new float?[count];
			productTypeIds = new int?[count];
			runs = new int[count];
			startDates = new DateTime[count];
			statuses = new Status[count];
			successfulRuns = new int?[count];
			
			for (int i = 0; i < count; i++)
			{
				activityIds[i] = corporationJobs[i].activityId;
				blueprintIds[i] = corporationJobs[i].blueprintId;
				blueprintLocationIds[i] = corporationJobs[i].blueprintLocationId;
				blueprintTypeIds[i] = corporationJobs[i].blueprintTypeId;
				completedCharacterIds[i] = corporationJobs[i].completedCharacterId;
				completedDates[i] = corporationJobs[i].completedDate;
				costs[i] = corporationJobs[i].cost;
				durations[i] = corporationJobs[i].duration;
				endDates[i] = corporationJobs[i].endDate;
				facilityIds[i] = corporationJobs[i].facilityId;
				installerIds[i] = corporationJobs[i].installerId;
				jobIds[i] = corporationJobs[i].jobId;
				licensedRuns[i] = corporationJobs[i].licensedRuns;
				locationIds[i] = corporationJobs[i].locationId;
				outputLocationIds[i] = corporationJobs[i].outputLocationId;
				pauseDates[i] = corporationJobs[i].pauseDate;
				probabilitys[i] = corporationJobs[i].probability;
				productTypeIds[i] = corporationJobs[i].productTypeId;
				runs[i] = corporationJobs[i].runs;
				startDates[i] = corporationJobs[i].startDate;
				statuses[i] = corporationJobs[i].status;
				successfulRuns[i] = corporationJobs[i].successfulRuns;
			}
		}
	}
}