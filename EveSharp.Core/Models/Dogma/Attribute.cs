namespace EveSharp.Core.Models.Dogma
{
	public struct DogmaAttribute
	{
		public int attributeId;
		public float? defaultValue;
		public string description;
		public string displayName;
		public bool? highIsGood;
		public int? iconId;
		public string name;
		public bool? published;
		public bool? stackable;
		public int? unitId;
	}
	
	public struct SoADogmaAttribute
	{
		public readonly int[] attributeIds;
		public readonly float?[] defaultValues;
		public readonly string[] descriptions;
		public readonly string[] displayNames;
		public readonly bool?[] highIsGoods;
		public readonly int?[] iconIds;
		public readonly string[] names;
		public readonly bool?[] publisheds;
		public readonly bool?[] stackables;
		public readonly int?[] unitIds;
		
		public SoADogmaAttribute(params DogmaAttribute[] dogmaAttributes)
		{
			int count = dogmaAttributes.Length;
			attributeIds = new int[count];
			defaultValues = new float?[count];
			descriptions = new string[count];
			displayNames = new string[count];
			highIsGoods = new bool?[count];
			iconIds = new int?[count];
			names = new string[count];
			publisheds = new bool?[count];
			stackables = new bool?[count];
			unitIds = new int?[count];
			
			for (int i = 0; i < count; i++)
			{
				attributeIds[i] = dogmaAttributes[i].attributeId;
				defaultValues[i] = dogmaAttributes[i].defaultValue;
				descriptions[i] = dogmaAttributes[i].description;
				displayNames[i] = dogmaAttributes[i].displayName;
				highIsGoods[i] = dogmaAttributes[i].highIsGood;
				iconIds[i] = dogmaAttributes[i].iconId;
				names[i] = dogmaAttributes[i].name;
				publisheds[i] = dogmaAttributes[i].published;
				stackables[i] = dogmaAttributes[i].stackable;
				unitIds[i] = dogmaAttributes[i].unitId;
			}
		}
	}
}