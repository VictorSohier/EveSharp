namespace EveSharp.Core.Models.Dogma.Dynamic
{
	public struct Item
	{
		public int CreatedBy;
		public Attribute[] DogmaAttributes;
		public Effect[] DogmaEffects;
		public int MutatorTypeId;
		public int SourceTypeId;
	}
}