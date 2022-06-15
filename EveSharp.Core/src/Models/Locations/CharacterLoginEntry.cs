namespace EveSharp.Core.Models.Locations
{
	public struct CharacterLoginEntry
	{
		public DateTime lastLogin;
		public DateTime lastLogout;
		public int? logins;
		public bool online;
	}
	
	public struct SoACharacterLoginEntry
	{
		public readonly DateTime[] lastLogins;
		public readonly DateTime[] lastLogouts;
		public readonly int?[] logins;
		public readonly bool[] onlines;
		
		public SoACharacterLoginEntry(params CharacterLoginEntry[] characterLoginEntries)
		{
			int count = characterLoginEntries.Length;
			lastLogins = new DateTime[count];
			lastLogouts = new DateTime[count];
			logins = new int?[count];
			onlines = new bool[count];
			
			for (int i = 0; i < count; i++)
			{
				lastLogins[i] = characterLoginEntries[i].lastLogin;
				lastLogouts[i] = characterLoginEntries[i].lastLogout;
				logins[i] = characterLoginEntries[i].logins;
				onlines[i] = characterLoginEntries[i].online;
			}
		}
	}
}