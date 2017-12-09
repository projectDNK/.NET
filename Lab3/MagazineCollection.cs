using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
	class MagazineCollection : Magazine
	{
		private List<Magazine> magazine;

		public int Count => magazine.Count;

		public MagazineCollection()
		{
			magazine = new List<Magazine>();
		}

		public void AddDefaults()
		{
			Console.Write("Number of Magazine Default: ");
			int number = Convert.ToInt32(Console.ReadLine());
			Magazine mag = new Magazine();
			for (int i = 0; i < number; i++)
			{
				Person person1 = new Person("Ivan" + i, "Tor", new DateTime(1998, 7, 5));
				Person person2 = new Person("Evan" + i, "String", new DateTime(1950, 3, 1));
				Article article1 = new Article(person1, "Trollolo" + i, 198);
				Article article2 = new Article(person2, "Lalaland" + i, 456);

				mag.AddArticles(article1, article2);
				mag.AddEditors(person1, person2);
				mag.FrequencyMagazine =Frequenc.Montly;
				magazine.Add(mag);
			}

		}

		public void AddMagazine(params Magazine[] Mag)     //??????????????????????????????????
		{
			Console.WriteLine("Mag:{0}",Mag);
			foreach (Magazine mag in Mag)
			{
				magazine.Add(mag);

			}
		}

		public override string ToString()
		{
			string res = "";
			foreach (Magazine mag in magazine)
				res += mag.ToString() + "\n" + "----------------------" + "\n";
			return res;
		}

		public override string ToShortString()
		{
			string res = "";
			foreach (Magazine mag in magazine)
				res += mag.ToShortString() + "Count information Editors: " + mag.InformationEditors.Count + "Count information Articles: " + mag.InformationListOfArticles.Count + "\n";
			return res;
		}

		public double ReadAverageMaxRate
		{
			get
			{
				if (magazine == null)
					return 0;
				return magazine.Max(magazine => magazine.Average);
			}
		}

		public IEnumerable<Magazine> FrequencyMonthly
		{
			get
			{
				var monthly = from mag in magazine
							  where mag.FrequencyMagazine == Frequenc.Montly
							  select mag;

				return monthly.ToList();
			}
		}

		public object Frequency { get; private set; }

		public List<Magazine> RatingGroup(double value)
		{
			var mag = from magazine in magazine
					  where magazine.Average == value
					  select magazine;
			return mag.ToList();

		}

		public void SortByTitle()
		{
			magazine.Sort();
			
		}

		public void SortByDate()
		{
			magazine.Sort(new Edition());
		}

		public void SortByCirculation()
		{
			Console.WriteLine("ByCircula");
			magazine.Sort(new CompareEd());
		}
	}
}
