using EveSharp.Core.Enums.Calendar;

namespace EveSharp.Core.Models.Calendar
{
	public struct EventDetails
	{
		public DateTime date;
		public int duration;
		public int eventId;
		public int importance;
		public int ownerId;
		public string ownerName;
		public EventOwnerType ownerType;
		public string response;
		public string text;
		public string title;
	}
	
	public struct AoSEventDetails
	{
		public readonly DateTime[] dates;
		public readonly int[] durations;
		public readonly int[] eventIds;
		public readonly int[] importances;
		public readonly int[] ownerIds;
		public readonly string[] ownerNames;
		public readonly EventOwnerType[] ownerTypes;
		public readonly string[] responses;
		public readonly string[] texts;
		public readonly string[] titles;
		
		public AoSEventDetails(EventDetails[] eventDetails)
		{
			int count = eventDetails.Length;
			dates = new DateTime[count];
			durations = new int[count];
			eventIds = new int[count];
			importances = new int[count];
			ownerIds = new int[count];
			ownerNames = new string[count];
			ownerTypes = new EventOwnerType[count];
			responses = new string[count];
			texts = new string[count];
			titles = new string[count];
			
			for (int i = 0; i < count; i++)
			{
				dates[i] = eventDetails[i].date;
				durations[i] = eventDetails[i].duration;
				eventIds[i] = eventDetails[i].eventId;
				importances[i] = eventDetails[i].importance;
				ownerIds[i] = eventDetails[i].ownerId;
				ownerNames[i] = eventDetails[i].ownerName;
				ownerTypes[i] = eventDetails[i].ownerType;
				responses[i] = eventDetails[i].response;
				texts[i] = eventDetails[i].text;
				titles[i] = eventDetails[i].title;
			}
		}
	}
}