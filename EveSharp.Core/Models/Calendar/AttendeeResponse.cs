using EveSharp.Core.Enums.Calendar;

namespace EveSharp.Core.Models.Calendar
{
	public struct AttendeeResponse
	{
		public int? characterId;
		public Response eventResponse;
	}
	
	public struct SoAAttendeeResponse
	{
		public readonly int?[] characterIds;
		public readonly Response[] eventResponses;
		
		public SoAAttendeeResponse(params AttendeeResponse[] attendeeResponses)
		{
			int count = attendeeResponses.Length;
			characterIds = new int?[count];
			eventResponses = new Response[count];
			
			for (int i = 0; i < count; i++)
			{
				characterIds[i] = attendeeResponses[i].characterId;
				eventResponses[i] = attendeeResponses[i].eventResponse;
			}
		}
	}
}