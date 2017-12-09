using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
	class Program
	{
		static void Main(string[] args)
		{
			MagazineCollection collection1 = new MagazineCollection();
			MagazineCollection collection2 = new MagazineCollection();

			Listener listener1 = new Listener();
			Listener listener2 = new Listener();

			collection1.MagazineAdded += listener1.Magazine_Added;
			collection1.MagazineReplaced += listener1.Magazine_Replaced;

			collection1.MagazineAdded += listener2.Magazine_Replaced;
			collection1.MagazineReplaced += listener2.Magazine_Replaced;

			collection2.MagazineAdded += listener2.Magazine_Added;
			collection2.MagazineAdded += listener2.Magazine_Replaced;

			Magazine magazine = new Magazine("IT", Frequency.Montly, new DateTime(), 1000, new List<Person>(), new List<Article>());

			collection1.AddDefaults();
			collection1.AddMagazines(magazine);

			collection2.AddDefaults();
			collection2.AddMagazines();

			collection1.Replace(0, new Magazine());
			collection2.Replace(1, new Magazine());

			collection1[0] = new Magazine();

			Console.WriteLine("Firts listener: \n" + listener1.ToString());
			Console.WriteLine("Second listener: \n" + listener2.ToString());

			Console.ReadKey();
		}
	}
}
