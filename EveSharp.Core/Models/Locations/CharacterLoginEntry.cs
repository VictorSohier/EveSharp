namespace EveSharp.Core.Models.Locations
{
	public struct CharacterLoginEntry
	{
		public DateTime lastLogin;
		public DateTime lastLogout;
		public int? logins;
		public bool online;
	}
}