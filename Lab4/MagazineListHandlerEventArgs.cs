using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
	public class MagazineListHandlerEventArgs : EventArgs
	{
		public string NameCollection { get;  set; }
		public string TypeOfChange { get;  set; }
		public int NumberItem { get;  set; }

		public MagazineListHandlerEventArgs(string nameCollection, string typeOfChange, int numberItem)
		{
			NameCollection = nameCollection;
			TypeOfChange = typeOfChange;
			NumberItem = numberItem;
		}
		public MagazineListHandlerEventArgs() : this(nameCollection: string.Empty, typeOfChange: string.Empty, numberItem: -1)
		{

		}
		public override string ToString()
		{
			return " Name collection: " + NameCollection + " Type changes: " + TypeOfChange + " Number item: " + NumberItem;
		}
	}
}
