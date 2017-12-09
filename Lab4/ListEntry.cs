using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
	public class ListEntry
	{
		public string NameCollection { get;  set; }
		public string EventMassage { get;  set; }
		public int NumberItem { get;  set; }

		public ListEntry()
		{
			NameCollection = null;
			EventMassage = null;
			NumberItem = 0;
		}

		public override string ToString()
		{
			return " Name: " + NameCollection + " Event: " + EventMassage + " Item: " + NumberItem;
		}

	}
}
