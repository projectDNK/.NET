using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
	public delegate void MagazineListHandler(object source, MagazineListHandlerEventArgs args);

	class MagazineCollection
	{

		public event MagazineListHandler MagazineAdded;
		public event MagazineListHandler MagazineReplaced;

		private List<Magazine> _listMagazine = new List<Magazine>();

		public void AddDefaults()
		{
				MagazineListHandlerEventArgs arg = new MagazineListHandlerEventArgs();
				arg.NameCollection = "Magazine";
				arg.TypeOfChange = "AddDefaults";
				arg.NumberItem = _listMagazine.Count;
				_listMagazine.Add(new Magazine());

				if (MagazineAdded != null)
					MagazineAdded(this, arg);

		}



		public void AddMagazines(params Magazine[] listMagazines)
		{
			if (listMagazines.Length == 0) return;

			MagazineListHandlerEventArgs arg = new MagazineListHandlerEventArgs();
			arg.NameCollection = "Magazine";
			arg.TypeOfChange = "Add(params Magazine[])";
			arg.NumberItem = _listMagazine.Count;
			_listMagazine.Add(new Magazine());
			
		}

		public override string ToString()
		{
			StringBuilder str = new StringBuilder();

			foreach (Magazine magazine in _listMagazine)
			{
				str.Append(magazine.ToString());
			}
			return str.ToString();
		}
		public virtual string ToShortString()
		{
			StringBuilder str = new StringBuilder();

			foreach (Magazine magazine in _listMagazine)
			{
				str.Append(magazine.ToShortString()).Append(" Count articles: ").Append(magazine.ListArticles.Count + " ").Append(" Count editors: ").Append(magazine.ListEditors.Count + " ");
			}
			return str.ToString();
		}
		public void SortByTitle()
		{
			_listMagazine.Sort();
		}
		public void SortByCirculation()
		{
			ComparerEdition comparer = new ComparerEdition();
			_listMagazine.Sort(comparer);
		}
		public void SortByDateRelease()
		{
			Edition edition = new Edition();
			_listMagazine.Sort(edition);
		}

		public double MaxAverageRating
		{
			get
			{
				double max = 0.0d;
				if (_listMagazine.Count == 0) return max;
				max = _listMagazine.Max(magazine => magazine.AverageRating);
				return max;
			}
		}
		public IEnumerable<Magazine> MagazineWithFrequencyMontly
		{
			get
			{
				IEnumerable<Magazine> enumerator = _listMagazine.Where(magazine => magazine.FrequencyMagazine.Equals(Frequency.Montly));

				foreach (Magazine item in enumerator)
				{
					yield return item;
				}
			}
		}
		public List<Magazine> RatingGroup(double value)
		{
			IEnumerable<IGrouping<double, Magazine>> group = _listMagazine.Where(magazine => magazine.AverageRating >= value).GroupBy(magazine => magazine.AverageRating).ToList();

			List<Magazine> list = new List<Magazine>();

			foreach (IGrouping<double, Magazine> keyGroup in group)
			{
				foreach (Magazine item in keyGroup)
					list.Add(item);
			}

			return list;
		}
		public bool Replace(int j, Magazine magazine)
		{
			if (j < 0 || j >= _listMagazine.Count) return false;

			_listMagazine[j] = magazine;

			MagazineListHandlerEventArgs arg = new MagazineListHandlerEventArgs();
			arg.NameCollection = "Magazine";
			arg.TypeOfChange = "Replace(int,Magazine)";
			arg.NumberItem = _listMagazine.Count;
			_listMagazine.Add(new Magazine());

			if (MagazineAdded != null)
				MagazineReplaced(this, arg);
			
			return true;
		}
		public Magazine this[int index]
		{
			get { return _listMagazine[index]; }
			set
			{
				if (index >= 0 && index < _listMagazine.Count)
				{
					_listMagazine[index] = value;

					MagazineListHandlerEventArgs arg = new MagazineListHandlerEventArgs();
					arg.NameCollection = "Magazine";
					arg.TypeOfChange = "Replace[int]";
					arg.NumberItem = _listMagazine.Count;
					_listMagazine.Add(new Magazine());

					if (MagazineAdded != null)
						MagazineReplaced(this, arg);
				}
				else
				{
					string str = index + " is incorrect index for items!";
					throw new ArgumentOutOfRangeException(str);
				}
			}
		}
	}
}
