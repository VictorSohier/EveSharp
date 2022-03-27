using System.Diagnostics.Contracts;

namespace EveSharp.Core.Models.Dogma.Effect
{
	public struct Modifier
	{
		public string Domain;
		public int? EffectId;
		public string Func;
		public int? ModifiedAttributeId;
		public int? ModifyingAttributeId;
		public int? Operator;
	}
}