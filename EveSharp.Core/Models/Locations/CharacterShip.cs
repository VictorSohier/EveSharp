namespace EveSharp.Core.Models.Locations
{
	public struct CharacterShip
	{
		public long shipItemId;
		public string shipName;
		public int shipTypeId;
	}
	
	public struct SoACharacterShip
	{
		public readonly long[] shipItemIds;
		public readonly string[] shipNames;
		public readonly int[] shipTypeIds;
		
		public SoACharacterShip(params CharacterShip[] characterShips)
		{
			int count = characterShips.Length;
			shipItemIds = new long[count];
			shipNames = new string[count];
			shipTypeIds = new int[count];
			
			for (int i = 0; i < count; i++)
			{
				shipItemIds[i] = characterShips[i].shipItemId;
				shipNames[i] = characterShips[i].shipName;
				shipTypeIds[i] = characterShips[i].shipTypeId;
			}
		}
	}
}