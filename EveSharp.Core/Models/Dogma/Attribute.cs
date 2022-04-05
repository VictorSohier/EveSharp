using System.Runtime.InteropServices;

namespace EveSharp.Core.Models.Dogma
{
	public struct Attribute
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
}