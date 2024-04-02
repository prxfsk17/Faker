using Faker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.DTOs
{
	[Dto]
	internal class SecondDto
	{
		public string StringField { get; set; }
		public DateTime DateTimeField { get; set; }
		public List<int> IntList { get; set; }
		public WithPublicProperties FirstDto { get; set; }
		private SecondDto() { }
	}
}
