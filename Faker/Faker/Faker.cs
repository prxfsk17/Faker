using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Faker
{
	public class Faker : IFaker
	{
		private HashSet<Type> hashSet = new HashSet<Type>();
		public T Create<T>()
		{
			return (T)Create(typeof(T));
		}
		private object Create(Type type)
		{
			if (hashSet.Contains(type))
			{
				return null;
			}
			if (type.GetCustomAttributes(typeof(DtoAttribute), true).Length > 0)
			{

				//var constructors = type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
				var constructors = type.GetConstructors();
				var constructor = constructors.OrderByDescending(c => c.GetParameters().Length).FirstOrDefault();
				object? instance = null;

				if (constructor != null)
				{

					var parameters = constructor.GetParameters();
					object[] args = new object[parameters.Length];

					for (int i = 0; i < parameters.Length; i++)
					{
						var parameterType = parameters[i].ParameterType;

						if (parameterType.GetCustomAttributes(typeof(DtoAttribute), true).Length > 0)
						{
							args[i] = Create(parameterType);
						}
						else
						{
							args[i] = Generator.GenerateRandom(parameterType);
						}
					}
					hashSet.Clear();
					instance = constructor.Invoke(args);
				}
				else
				{
					constructor = type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, Type.EmptyTypes, null);
					instance = constructor.Invoke(null);
				}

				hashSet.Add(type);

				var propertiesAndFields = type.GetMembers(BindingFlags.Instance | BindingFlags.NonPublic)
											   .Where(member => member.MemberType == MemberTypes.Field || member.MemberType == MemberTypes.Property)
											   .ToList();

				foreach (var member in propertiesAndFields)
				{
					var memberType = member is PropertyInfo ? ((PropertyInfo)member).PropertyType : ((FieldInfo)member).FieldType;

					if (memberType.GetCustomAttributes(typeof(DtoAttribute), true).Length > 0)
					{

						var memberValue = Create(memberType);

						if (member is PropertyInfo property)
						{
							property.SetValue(instance, memberValue);
						}
						else if (member is FieldInfo field)
						{
							field.SetValue(instance, memberValue);
						}
					}
					else
					{
						var randomValue = Generator.GenerateRandom(memberType);
						if (member is PropertyInfo property)
						{
							property.SetValue(instance, randomValue);
						}
						else if (member is FieldInfo field)
						{
							field.SetValue(instance, randomValue);
						}
					}
				}

				return instance;
			}

			else
			{
				return Generator.GenerateRandom(type);
			}
		}

	}

}
