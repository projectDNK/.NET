using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab4
{
	class TestCollections
	{
		private List<Edition> _listEdition;
		private List<string> _listString;

		private Dictionary<Edition, Magazine> _dictionaryEditionMagazine;
		private Dictionary<string, Magazine> _dictionaryStringMagazine;

		public TestCollections(int count)
		{
			_listEdition = new List<Edition>(count);
			_listString = new List<string>(count);

			_dictionaryEditionMagazine = new Dictionary<Edition, Magazine>(count);
			_dictionaryStringMagazine = new Dictionary<string, Magazine>(count);

			for (int i = 0; i < count; ++i)
			{
				_listEdition.Add(GenerateItem(i).Edition);
				_listString.Add(GenerateItem(i).TitleEdition);

				_dictionaryEditionMagazine.Add(GenerateItem(i).Edition, GenerateItem(i));
				_dictionaryStringMagazine.Add(GenerateItem(i).TitleEdition, GenerateItem(i));
			}
		}

		public static Magazine GenerateItem(int key)
		{
			Person person = new Person("Name" + key, "Surname" + key, new DateTime(1995, 1, 2));
			Article article = new Article(person, "Article" + key, 6.6d);
			Edition edition = new Edition("Magazine" + key, new DateTime(1996, 5, 2), 100);

			List<Person> listEditors = new List<Person>();
			List<Article> listArticles = new List<Article>();

			listEditors.Add(person);
			listArticles.Add(article);

			Magazine magazine = new Magazine(edition.TitleEdition, Frequency.Montly, edition.ReleaseEdition, edition.CirculationEdition, listEditors, listArticles);

			return magazine;
		}

		public void TimeSearchingInListString(string item)
		{

			Stopwatch stopwatch = Stopwatch.StartNew();
			stopwatch.Start();

			foreach (string str in _listString)
				if (item.Equals(str)) break;
			stopwatch.Stop();

			Console.WriteLine("\t*** Total time taken by searching is: {0} milliseconds", stopwatch.ElapsedMilliseconds);
			Console.WriteLine("\t*** Total time taken by searching is: {0} ticks\n", stopwatch.ElapsedTicks);

			return;
		}

		public void TimeSearchingInListEdition(Edition item)
		{
			Stopwatch stopwatch = Stopwatch.StartNew();

			stopwatch.Start();

			foreach (Edition edition in _listEdition)
				if (item.Equals(edition)) break;

			stopwatch.Stop();

			Console.WriteLine("\t*** Total time taken by searching is: {0} milliseconds", stopwatch.ElapsedMilliseconds);
			Console.WriteLine("\t*** Total time taken by searching is: {0} ticks\n", stopwatch.ElapsedTicks);

			return;
		}

		public void TimeSearchingInDictionaryEditionMagazineByKey(Edition key)
		{
			Stopwatch stopwatch = Stopwatch.StartNew();

			stopwatch.Start();
			foreach (KeyValuePair<Edition, Magazine> item in _dictionaryEditionMagazine)
				if (item.Key.Equals(key)) break;
			stopwatch.Stop();

			Console.WriteLine("\t*** Total time taken by searching is: {0} milliseconds", stopwatch.ElapsedMilliseconds);
			Console.WriteLine("\t*** Total time taken by searching is: {0} ticks\n", stopwatch.ElapsedTicks);

			return;
		}

		public void TimeSearchingInDictionaryEditionMagazineByValue(Magazine value)
		{
			Stopwatch stopwatch = Stopwatch.StartNew();

			stopwatch.Start();

			foreach (KeyValuePair<Edition, Magazine> item in _dictionaryEditionMagazine)
				if (item.Value.Equals(value)) break;
			stopwatch.Stop();

			Console.WriteLine("\t*** Total time taken by searching is: {0} milliseconds", stopwatch.ElapsedMilliseconds);
			Console.WriteLine("\t*** Total time taken by searching is: {0} ticks\n", stopwatch.ElapsedTicks);

			return;
		}

		public void TimeSearchingInDictionaryStringMagazineByKey(string key)
		{
			Stopwatch stopwatch = Stopwatch.StartNew();

			stopwatch.Start();
			foreach (KeyValuePair<string, Magazine> item in _dictionaryStringMagazine)
				if (item.Key.Equals(key)) break;
			stopwatch.Stop();

			Console.WriteLine("\t*** Total time taken by searching is: {0} milliseconds", stopwatch.ElapsedMilliseconds);
			Console.WriteLine("\t*** Total time taken by searching is: {0} ticks\n", stopwatch.ElapsedTicks);

			return;
		}

		public void TimeSearchingInDictionaryStringMagazineByValue(Magazine value)
		{
			Stopwatch stopwatch = Stopwatch.StartNew();

			stopwatch.Start();
			foreach (KeyValuePair<string, Magazine> item in _dictionaryStringMagazine)
				if (item.Value.Equals(value)) break;
			stopwatch.Stop();

			Console.WriteLine("\t*** Total time taken by searching is: {0} milliseconds", stopwatch.ElapsedMilliseconds);
			Console.WriteLine("\t*** Total time taken by searching is: {0} ticks\n", stopwatch.ElapsedTicks);

			return;
		}

		public override string ToString()
		{
			Console.WriteLine("List string: \r\n");

			StringBuilder str = new StringBuilder();

			foreach (string item in _listString)
				str.Append(item.ToString() + "\n");

			return str.ToString();
		}
	}
}
