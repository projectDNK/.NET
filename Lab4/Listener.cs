using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
	public class Listener
	{
		List<ListEntry> _listOfChanges = new List<ListEntry>();


		public void Magazine_Added(object sours, MagazineListHandlerEventArgs args)
		{
			ListEntry str = new ListEntry();
			str.NameCollection = args.NameCollection;
			str.EventMassage = args.TypeOfChange;
			str.NumberItem = args.NumberItem;
			_listOfChanges.Add(str);
		}


		// немає сенсу створювати два одиноковив
		public void Magazine_Replaced(object sours, MagazineListHandlerEventArgs args)
		{

			ListEntry str = new ListEntry();
			str.NameCollection = args.NameCollection;
			str.EventMassage = args.TypeOfChange;
			str.NumberItem = args.NumberItem;
			_listOfChanges.Add(str);

		}

		public override string ToString()
		{
			string res = "";
			foreach (ListEntry str in _listOfChanges)
				res += "\n" + str.ToString();
			return res;
		}

	}
}
