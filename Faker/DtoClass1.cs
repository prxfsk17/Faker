using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
	[Dto]
	public class DtoClass1
	{
		public byte field {  get; set; }
		public int IntField { get; set; }
		public long LongField { get; set; }
		public double DoubleField { get; set; }
		public float FloatField { get; set; }
		public bool BoolField { get; set; }
		public char CharField { get; set; }
		public string StringField { get; set; }
		public DateTime DateTimeField { get; set; }
		public List<int> IntList { get; set; }
		public List<string> StringList { get; set; }
		public DtoClass2 dtoClass { get; set; }
		public DtoClass1() { }
		public DtoClass1(int intField, string stringField)
		{
			IntField = intField;
			StringField = stringField;
		}
		public DtoClass1(int intField, List<int> intList, DtoClass2 dtoClass)
		{
			IntField = intField;
			IntList = intList;
			this.dtoClass = dtoClass;
		}
	}

}
