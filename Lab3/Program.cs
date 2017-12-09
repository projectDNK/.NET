using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
	class Program
	{
		static void Main(string[] args)
		{

			MagazineCollection magColl = new MagazineCollection();
			Magazine mag1 = new Magazine();

			Person person1 = new Person("Eva", "Bell", new DateTime(1945, 5, 10));
			Article article1 = new Article(person1, "BRoom", 9.8d);
			mag1.FrequencyMagazine = Frequenc.Montly;
			mag1.AddEditors(person1);
			mag1.AddArticles(article1);
			magColl.AddMagazine(mag1);
			mag1 = new Magazine();
			
			Person person2 = new Person("Edvard", "Collins", new DateTime(1978, 10, 12));
			Article article2 = new Article(person2, "CTable", 3.4d);
			mag1.AddEditors(person2);
			mag1.FrequencyMagazine = Frequenc.Yearly;
			mag1.AddArticles(article2);
			magColl.AddMagazine(mag1);
			mag1 = new Magazine();


			Person person3 = new Person("Andre", "AAAAAAAAAA", new DateTime(1997, 5, 21));
			Article article3 = new Article(person3, "APen", 3.4d);
			mag1.FrequencyMagazine = Frequenc.Montly;
			mag1.AddEditors(person3);
			mag1.AddArticles(article3);
			magColl.AddMagazine(mag1);
	        
			Console.WriteLine(magColl.ToString());

			//сортування по алфавіту
			Console.WriteLine("----------------------------------->SortByTitle");
			magColl.SortByTitle();
			Console.WriteLine(magColl.ToString());

			// сортування від най молодшого
			Console.WriteLine("----------------------------------->SortByDate");
			magColl.SortByDate();
			Console.WriteLine(magColl.ToString());

			// Сортування від більшого до меншого
			Console.WriteLine("----------------------------------->SortByCirculation");
			magColl.SortByCirculation();
			Console.WriteLine(magColl.ToString());

			Console.WriteLine("----------------------------------->ReadAverageMaxRate\n");
			Console.WriteLine("Max:{0}",magColl.ReadAverageMaxRate);
			
			// виводить групу в якій є співпадіння по полю Monthly
			Console.WriteLine("----------------------------------->FrequencyMonthly\n");
			foreach (var str in magColl.FrequencyMonthly)
				Console.WriteLine(str.ToString());

			Console.WriteLine("----------------------------------->RatingGroup\n");
			foreach (var str in magColl.RatingGroup(10d))
				Console.WriteLine(str.ToString());

			Console.ReadLine();


		}
	}
}
