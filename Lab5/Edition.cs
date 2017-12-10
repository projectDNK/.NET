using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
	[Serializable]
	class Edition : IComparable, IComparer<Edition>
	{
		protected string _titleEdition;
		protected int _circulationEdition;
		protected DateTime _releaseEdition;

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
			string str = " Title edition: " + TitleEdition + " Release edition: " + ReleaseEdition.ToShortDateString() + " Circulation edition: " + CirculationEdition + " ";
			return str;
		}

		public int Compare(Edition first, Edition second)
		{

			if (DateTime.Compare(first.ReleaseEdition, second.ReleaseEdition) > 0)
				return 1;
			else if (DateTime.Compare(first.ReleaseEdition, second.ReleaseEdition) < 0)
				return -1;
			else
				return 0;
		}

		public int CompareTo(object obj)
		{
			Edition edition = obj as Edition;

			if (edition == null) return 1;

			if (String.Compare(TitleEdition, edition.TitleEdition) > 0)
				return 1;
			else if (String.Compare(TitleEdition, edition.TitleEdition) < 0)
				return -1;
			else
				return 0;
		}
	}
}
