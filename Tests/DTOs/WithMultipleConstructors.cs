using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.DTOs
{
	[Dto]
	internal class WithMultipleConstructors
	{
		public int IntProperty { get; set; }
		public long LongProperty { get; set; }
		public double DoubleProperty { get; set; }
		public float FloatProperty { get; set; }
		public bool BoolProperty { get; set; }
		public char CharProperty { get; set; }
		public string StringProperty { get; set; }
		public DateTime DateTimeProperty { get; set; }
		public List<int> IntList { get; set; }
		public List<string> StringList { get; set; }
		public SecondDto secondDto { get; set; }
		public WithMultipleConstructors() { }
		public WithMultipleConstructors(int intProperty, string stringProperty)
		{
			IntProperty = intProperty;
			StringProperty = stringProperty;
		}
		public WithMultipleConstructors(int intProperty, List<int> intList, SecondDto secondDto)
		{
			IntProperty = intProperty;
			IntList = intList;
			this.secondDto = secondDto;
		}
	}
}
