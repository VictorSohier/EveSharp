using System.Diagnostics.Contracts;

namespace EveSharp.Core.Models.Dogma.Effect
{
	public struct Modifier
	{
		public string domain;
		public int? effectId;
		public string func;
		public int? modifiedAttributeId;
		public int? modifyingAttributeId;
		public int? @operator;
	}
	
	public struct SoAModifier
	{
		public readonly string[] domains;
		public readonly int?[] effectIds;
		public readonly string[] funcs;
		public readonly int?[] modifiedAttributeIds;
		public readonly int?[] modifyingAttributeIds;
		public readonly int?[] operators;
		
		public SoAModifier(params Modifier[] modifiers)
		{
			int count = modifiers.Length;
			domains = new string[count];
			effectIds = new int?[count];
			funcs = new string[count];
			modifiedAttributeIds = new int?[count];
			modifyingAttributeIds = new int?[count];
			operators = new int?[count];
			
			for (int i = 0; i < count; i++)
			{
				domains[i] = modifiers[i].domain;
				effectIds[i] = modifiers[i].effectId;
				funcs[i] = modifiers[i].func;
				modifiedAttributeIds[i] = modifiers[i].modifiedAttributeId;
				modifyingAttributeIds[i] = modifiers[i].modifyingAttributeId;
				operators[i] = modifiers[i].@operator;
			}
		}
	}
}