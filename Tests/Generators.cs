namespace Tests
{
	public class Generators
	{
		[Theory]
		[InlineData(typeof(int))]
		[InlineData(typeof(long))]
		[InlineData(typeof(double))]
		[InlineData(typeof(float))]
		[InlineData(typeof(bool))]
		[InlineData(typeof(char))]
		[InlineData(typeof(string))]
		[InlineData(typeof(DateTime))]
		public void RandomBasicTypes_Generation(Type type)
		{
			var result = Generator.GenerateRandom(type);

			Assert.NotNull(result);
			Assert.IsAssignableFrom(type, result);

			if (type == typeof(int))
			{
				int num1 = (int)result;
				var num2 = (int)Generator.GenerateRandom(typeof(int));
				Assert.NotEqual(num1, num2);
			}
			else if (type == typeof(long))
			{
				long num1 = (long)result;
				var num2 = (long)Generator.GenerateRandom(typeof(long));
				Assert.NotEqual(num1, num2);
			}
			else if (type == typeof(double))
			{
				double num1 = (double)result;
				var num2 = (double)Generator.GenerateRandom(typeof(double));
				Assert.NotEqual(num1, num2);
			}
			else if (type == typeof(float))
			{
				float num1 = (float)result;
				var num2 = (float)Generator.GenerateRandom(typeof(float));
				Assert.NotEqual(num1, num2);
			}
			else if (type == typeof(char))
			{
				char char1 = (char)result;
				var char2 = (char)Generator.GenerateRandom(typeof(char));
				Assert.NotEqual(char1, char2);
			}
			else if (type == typeof(string))
			{
				string str1 = (string)result;
				var str2 = (string)Generator.GenerateRandom(typeof(string));
				Assert.NotEqual(str1, str2);
			}
			else if (type == typeof(DateTime))
			{
				DateTime dt1 = (DateTime)result;
				var dt2 = (DateTime)Generator.GenerateRandom(typeof(DateTime));
				Assert.NotEqual(dt1, dt2);
			}
		}
		[Theory]
		[InlineData(typeof(List<int>))]
		[InlineData(typeof(List<string>))]
		[InlineData(typeof(List<float>))]
		public void RandomCollectionTypes_Generation(Type type)
		{
			var result = Generator.GenerateRandom(type);

			Assert.NotNull(result);
			Assert.IsAssignableFrom(type, result);

			if (type == typeof(List<int>))
			{
				var list1 = (List<int>)result;
				var list2 = (List<int>)Generator.GenerateRandom(typeof(List<int>));
				Assert.NotEqual(list1, list2);
			}
		}
		[Fact]
		public void NonExistentType_In_Generator()
		{
			var result = Generator.GenerateRandom(typeof(byte));

			Assert.NotNull(result);
			Assert.Equal(default(byte), (byte)result);
		}
	}
}