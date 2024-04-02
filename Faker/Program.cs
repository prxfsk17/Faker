namespace Faker
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var faker = new Faker.Faker();
			DtoClass1 testClass = faker.Create<DtoClass1>();
		}
	}
}
