using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace EveSharp.Core.Enums.Mail
{
	[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]

	public enum RecipientType
	{
		 Alliance,
		 Character,
		 Corporation,
		 MailingList
	}
}