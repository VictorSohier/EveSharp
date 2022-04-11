namespace EveSharp.Core.Models.UserInterface
{
	public struct NewMail
	{
		public string body;
		public int[] recipients;
		public string subject;
		public int? toCorpOrAllianceId;
		public int? mailingListId;
	}
}