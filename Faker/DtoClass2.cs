using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
	[Dto]
	public class DtoClass2
	{
		public string StringField { get; set; }
		public DateTime DateTimeField { get; set; }
		public List<int> IntList { get; set; }
		public DtoClass1 dtoClass1 { get; set; }
		private DtoClass2() { }
	}
}
