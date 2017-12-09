using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
	class TestCollections
	{
		private List<Person> Key;
		private List<string> NameList;
		private Dictionary<Person, Magazine> NameDictionaryPerson;
		private Dictionary<string, Magazine> NameDictionaryMagazine;

		public Magazine Force(int t)
		{
			Magazine mag = new Magazine();
			return mag;
		}

		public TestCollections(int t)
		{
			for (int i = 0; i < t; i++)
			{
				Key.Add(new Person { });
				NameList.Add("");
				NameDictionaryPerson.Add(new Person { }, new Magazine { });
				NameDictionaryMagazine.Add("", new Magazine { });
			}

		}
	}
}
