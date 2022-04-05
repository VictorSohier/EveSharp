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
}