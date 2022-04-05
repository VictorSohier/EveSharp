namespace EveSharp.Core.Models.Dogma.Dynamic
{
	public struct Item
	{
		public int createdBy;
		public Attribute[] dogmaAttributes;
		public Effect[] dogmaEffects;
		public int mutatorTypeId;
		public int sourceTypeId;
	}
}