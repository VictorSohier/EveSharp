using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EveSharp.Core.Enums.Mail
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum RecipientType
	{
		 Alliance,
		 Character,
		 Corporation,
		 MailingList
	}
}