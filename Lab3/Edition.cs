using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
	class Edition : IComparable, IComparer<Edition>
	{
		protected string _titleEdition;
		protected int _circulationEdition;
		protected DateTime _releaseEdition;

		public string __titleEdition
		{
			get { return _titleEdition; }
			set { _titleEdition = value; }
		}

		public Edition(string titleEdition, DateTime releaseEdition, int circulationEdition)
		{
			_titleEdition = titleEdition;
			_releaseEdition = releaseEdition;
			_circulationEdition = circulationEdition;
		}
		public Edition() : this(titleEdition: string.Empty, releaseEdition: new DateTime(), circulationEdition: 0)
		{
		}
		public string TitleEdition
		{
			set { _titleEdition = value; }
			get { return _titleEdition; }
		}
		public DateTime ReleaseEdition
		{
			set { _releaseEdition = value; }
			get { return _releaseEdition; }
		}
		public int CirculationEdition
		{
			set
			{
				if (value < 0)
				{
					throw new System.ArgumentOutOfRangeException("Circulation must be positive integer number or 0!");
				}
				_circulationEdition = value;
			}
			get { return _circulationEdition; }
		}
		public virtual object DeepCopy()
		{
			Edition other = (Edition)MemberwiseClone();

			other.TitleEdition = string.Copy(TitleEdition);
			other.ReleaseEdition = new DateTime(other.ReleaseEdition.Year, other.ReleaseEdition.Month, other.ReleaseEdition.Day);
			other.CirculationEdition = CirculationEdition;

			return other;
		}
		public override bool Equals(object obj)
		{
			Edition edition = obj as Edition;

			return ((System.Object)edition != null) &&
					   (edition._titleEdition == _titleEdition) &&
					   (edition._releaseEdition == _releaseEdition) &&
					   (edition._circulationEdition == _circulationEdition);
		}
		public static bool operator ==(Edition editionFirst, Edition editionSecond)
		{
			if (System.Object.ReferenceEquals(editionFirst, editionSecond)) return true;

			if ((object)editionFirst == null || (object)editionSecond == null) return false;

			return editionFirst.Equals(editionSecond);
		}
		public static bool operator !=(Edition editionFirst, Edition editionSecond)
		{
			return !(editionFirst.Equals(editionSecond));
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int hash = 13;
				hash = (hash * 7) + (!Object.ReferenceEquals(null, TitleEdition) ? TitleEdition.GetHashCode() : 0);
				hash = (hash * 7) + (!Object.ReferenceEquals(null, CirculationEdition) ? CirculationEdition.GetHashCode() : 0);
				hash = (hash * 7) + (!Object.ReferenceEquals(null, ReleaseEdition) ? ReleaseEdition.GetHashCode() : 0);
				return hash;
			}
		}
		public override string ToString()
		{
			string str = " Title edition: [" + TitleEdition + "]  Release edition: [" + ReleaseEdition.ToShortDateString() + "] Circulation edition: [" + CirculationEdition + "] ";
			return str;
		}

		public int CompareTo(object obj)
		{

			Magazine edition1 = this as Magazine;
			Magazine edition2 = obj as Magazine;
			if (edition1.InformationListOfArticles[0].Title.Count() > edition2.InformationListOfArticles[0].Title.Count())
				return 1;
			if (edition1.InformationListOfArticles[0].Title.Count() < edition2.InformationListOfArticles[0].Title.Count())
				return -1;
			else return 0;

		}

		public int Compare(Edition x, Edition y)
		{
		    Magazine edition1 = x as Magazine;
			Magazine edition2 = y as Magazine;
			if (edition1.InformationEditors[0]._BirthDate < edition2.InformationEditors[0]._BirthDate)
				return 1;
			if (edition1.InformationEditors[0]._BirthDate > edition2.InformationEditors[0]._BirthDate)
				return -1;
			else return 0;
		}
	}
}
