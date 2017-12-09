using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
	class Magazine : Edition, IRateAndCopy
	{
		private Frequency _frequencyMagazine;

		private List<Person> _listEditors;
		private List<Article> _listArticles;

		public double Rating { get; }

		public Magazine(string titleMagazine, Frequency frequency, DateTime releaseMagazine, int circulationMagazine, List<Person> listEditors, List<Article> listArticles)
			: base(titleEdition: titleMagazine, releaseEdition: releaseMagazine, circulationEdition: circulationMagazine)
		{
			FrequencyMagazine = frequency;
			ListEditors = listEditors;
			ListArticles = listArticles;
		}
		public Magazine() : this(titleMagazine: string.Empty, frequency: Frequency.Weekly, releaseMagazine: new DateTime(), circulationMagazine: 0, listEditors: new List<Person>(0), listArticles: new List<Article>(0))
		{
		}
		public double AverageRating
		{
			get
			{
				double sum = 0;
				if (ListArticles.Count == 0) return 0;
				foreach (Article article in ListArticles)
				{
					sum += article.Rating;
				}
				return sum / ListArticles.Count;
			}
		}
		public Frequency FrequencyMagazine
		{
			get { return _frequencyMagazine; }
			set { _frequencyMagazine = value; }
		}

		public bool this[Frequency f]
		{
			get
			{
				return FrequencyMagazine == f;
			}
		}
		public Edition EditionValue
		{
			get
			{
				return new Edition(TitleEdition, ReleaseEdition, CirculationEdition);
			}
			set
			{
				TitleEdition = value.TitleEdition;
				ReleaseEdition = value.ReleaseEdition;
				CirculationEdition = value.CirculationEdition;
			}
		}
		public List<Article> ListArticles
		{
			get { return _listArticles; }
			set { _listArticles = value; }
		}
		public List<Person> ListEditors
		{
			get { return _listEditors; }
			set { _listEditors = value; }
		}
		public void AddArticles(params Article[] articles)
		{
			foreach (Article item in articles)
				ListArticles.Add(item);
		}

		public void AddEditors(params Person[] editors)
		{
			foreach (Person item in editors)
				ListEditors.Add(item);
		}

		public override string ToString()
		{
			string str = base.ToString() + " Frequency magazine: " + FrequencyMagazine + " ";

			StringBuilder strNew = new StringBuilder();

			strNew.Append(str);

			int count = 0;

			strNew.Append("\n List Articles: ");
			foreach (Article item in ListArticles)
			{
				string str1 = "\n" + (count + 1) + ":";
				strNew.Append(str1);
				strNew.Append(item.ToString());
				count++;

			}
			count = 0;
			strNew.Append("\n");
			strNew.Append(" List Editors: ");
			foreach (Person item in ListEditors)
			{
				string str1 = "\n" + (count + 1) + ":";
				strNew.Append(str1);
				strNew.Append(item.ToString());
				count++;
			}
			strNew.Append("\n\n");
			return strNew.ToString();
		}
		public virtual string ToShortString()
		{
			string str = " Frequency: " + FrequencyMagazine + " Average rate: " + AverageRating + " ";
			return str;

		}
		public override bool Equals(object obj)
		{

			Magazine magazine = obj as Magazine;

			return ((System.Object)magazine != null) &&
						(magazine.FrequencyMagazine == FrequencyMagazine) &&
						(magazine.ListArticles == ListArticles) &&
						(magazine.ListEditors == ListEditors);
		}
		public static bool operator ==(Magazine magazineFirst, Magazine magazineSecond)
		{
			if (System.Object.ReferenceEquals(magazineFirst, magazineSecond)) return true;
			if ((object)magazineFirst == null || (object)magazineSecond == null) return false;

			return magazineFirst.Equals(magazineSecond);
		}
		public static bool operator !=(Magazine magazineFirst, Magazine magazineSecond) => !(magazineFirst.Equals(magazineSecond));
		public override int GetHashCode()
		{
			unchecked
			{
				int hash = 13;
				hash = (hash * 7) + (!Object.ReferenceEquals(null, FrequencyMagazine) ? FrequencyMagazine.GetHashCode() : 0);
				hash = (hash * 7) + (!Object.ReferenceEquals(null, ListArticles) ? ListArticles.GetHashCode() : 0);
				hash = (hash * 7) + (!Object.ReferenceEquals(null, ListEditors) ? ListEditors.GetHashCode() : 0);
				return hash;
			}
		}
		public override object DeepCopy()
		{
			Magazine other = (Magazine)MemberwiseClone();


			other.FrequencyMagazine = FrequencyMagazine;
			List<Person> listEditors = new List<Person>();
			List<Article> listArticles = new List<Article>();

			foreach (Article item in ListArticles)
			{
				listArticles.Add((Article)item.DeepCopy());
			}
			foreach (Person item in ListEditors)
			{
				listEditors.Add(item.DeepCopy());
			}

			other.ListArticles = listArticles;
			other.ListEditors = listEditors;
			return other;
		}
		public Edition Edition
		{
			get { return this; }
		}
		public IEnumerable<Article> ListArticlesWithRatingMoreThen(double rate)
		{
			foreach (Article item in ListArticles)
			{
				if (item.Rating > rate) yield return item;
			}
		}
		public IEnumerable<Article> ListArticlesWithSubTitle(string str)
		{
			foreach (Article item in ListArticles)
			{
				if (item.Title.IndexOf(str, StringComparison.OrdinalIgnoreCase) >= 0) yield return item;
			}
		}

	}
}
