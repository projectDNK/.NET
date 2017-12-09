using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
	class Magazine : Edition, IRateAndCopy
	{
		private Frequenc _frequencyMagazine;
		private List<Person> informationEditors;
		private List<Article> informationListOfArticles;

		public double Rating { get; }


		public Magazine(string titleMagazine, Frequenc frequency, DateTime releaseMagazine, int circulationMagazine, List<Person> listEditors, List<Article> listArticles)
			: base(titleEdition: titleMagazine, releaseEdition: releaseMagazine, circulationEdition: circulationMagazine)
		{
			FrequencyMagazine = frequency;
			InformationEditors = listEditors;
			InformationListOfArticles = listArticles;
		}

		public Magazine() : this(titleMagazine: string.Empty, frequency: Frequenc.Weekly, releaseMagazine: new DateTime(), circulationMagazine: 0, listEditors: new List<Person>(0), listArticles: new List<Article>(0))
		{
		}

		public double AverageRating
		{
			get
			{
				double sum = 0;
				if (InformationListOfArticles.Count == 0) return 0;
				foreach (Article article in InformationListOfArticles)
				{
					sum += article.Rating;
				}
				return sum / InformationListOfArticles.Count;
			}
		}

		public Frequenc FrequencyMagazine
		{
			get { return _frequencyMagazine; }
			set { _frequencyMagazine = value; }
		}

		public bool this[Frequenc f]
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

		public List<Person> InformationEditors
		{
			get { return informationEditors; }
			set { informationEditors = value; }
		}

		public List<Article> InformationListOfArticles
		{
			get { return informationListOfArticles; }
			set { informationListOfArticles = value; }
		}

		public void AddArticles(params Article[] articles)
		{
			foreach (Article a in articles)
				InformationListOfArticles.Add(a);
		}

		public void AddEditors(params Person[] editors)
		{
			foreach (Person p in editors)
				InformationEditors.Add(p);
		}

		public override string ToString()
		{
			string str = base.ToString() + " Frequency magazine: [" + FrequencyMagazine + "] ";

			StringBuilder strNew = new StringBuilder();

			strNew.Append(str);
			strNew.Append("\n List Articles: ");
			foreach (Article item in InformationListOfArticles)
			{
				strNew.Append("\n[");
				strNew.Append(item.ToString());
				strNew.Append("]");

			}
			strNew.Append("\n");
			strNew.Append(" Editors of magazine: ");
			foreach (Person item in InformationEditors)
			{
				strNew.Append("\n[");
				strNew.Append(item.ToString());
				strNew.Append("]");
			}
			strNew.Append("\n");
			return strNew.ToString();
		}

		public virtual string ToShortString()
		{
			string str = " Frequency: [" + FrequencyMagazine + "] Average rate: [" + AverageRating + "] ";
			return str;

		}

		public override bool Equals(object obj)
		{

			Magazine magazine = obj as Magazine;

			return ((System.Object)magazine != null) &&
						(magazine.FrequencyMagazine == FrequencyMagazine) &&
						(magazine.InformationListOfArticles == InformationListOfArticles) &&
						(magazine.InformationEditors == InformationEditors);
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
				int hash = 11;
				hash = (hash * 5) + (!Object.ReferenceEquals(null, FrequencyMagazine) ? FrequencyMagazine.GetHashCode() : 0);
				hash = (hash * 5) + (!Object.ReferenceEquals(null, InformationListOfArticles) ? InformationListOfArticles.GetHashCode() : 0);
				hash = (hash * 5) + (!Object.ReferenceEquals(null, InformationEditors) ? InformationEditors.GetHashCode() : 0);
				return hash;
			}
		}

		public override object DeepCopy()
		{
			Magazine other = (Magazine)MemberwiseClone();


			other.FrequencyMagazine = FrequencyMagazine;
			List<Person> listEditors = new List<Person>();
			List<Article> listArticles = new List<Article>();

			foreach (Article item in InformationListOfArticles)
			{
				listArticles.Add((Article)item.DeepCopy());
			}
			foreach (Person item in InformationEditors)
			{
				listEditors.Add(item.DeepCopy());
			}

			other.InformationListOfArticles = listArticles;
			other.InformationEditors = listEditors;

			return other;
		}

		public Edition Edition
		{
			get { return this; }
		}

		public IEnumerable<Article> InformationListOfArticlesWithRatingMoreThen(double rate)
		{
			foreach (Article item in InformationListOfArticles)
			{
				if (item.Rating > rate) yield return item;
			}
		}

		public IEnumerable<Article> InformationListOfArticlesWithSubTitle(string str)
		{
			foreach (Article item in InformationListOfArticles)
			{
				if (item.Title.IndexOf(str, StringComparison.OrdinalIgnoreCase) >= 0) yield return item;
			}
		}

		public double Average
		{
			get
			{
				double sum = 0;
				int count = 0;
				foreach (Article articleInf in InformationListOfArticles)
				{
					sum += Convert.ToInt32(articleInf.Rating);
					count++;
				}
				return sum / count;
			}
		}
	}
}
