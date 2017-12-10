using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab5
{
	class Program
	{
		static void Main(string[] args)
		{
			T mag1 = new T();

			Person person1 = new Person("Eva", "Bell", new DateTime(1945, 5, 10));
			Article article1 = new Article(person1, "BRoom", 9.8d);
			mag1.FrequencyMagazine = Frequency.Montly;
			mag1.AddEditors(person1);
			mag1.AddArticles(article1);


			T magCopy = (T)mag1.DeepCopy();
			Console.WriteLine("-------------->1");

			Console.WriteLine("------------------------------------->Original");
			Console.WriteLine(mag1.ToString());
			Console.WriteLine("------------------------------------->Copy");
			Console.WriteLine(magCopy.ToString());

			Console.WriteLine("file:");
			string filename = Console.ReadLine() + ".dat";
			try
			{ 
				FileStream file = new FileStream(filename, FileMode.Open,FileAccess.Write,FileShare.Write);
				file.Close();
				Console.WriteLine(mag1.Load(filename));
				Console.WriteLine("Open File");
			}
			catch
			{
				Console.WriteLine("Create File");
				FileStream file = new FileStream(filename, FileMode.Create);
				file.Close();
			}
		
			//3
			Console.WriteLine("---------------->3");
			Console.WriteLine(mag1.ToString());
			//4
			Console.WriteLine("---------------->4");
			Console.WriteLine(mag1.AddFromConsole());
			Console.WriteLine(mag1.Save(filename));
			Console.WriteLine(mag1.ToString());
			Console.ReadLine();
			//5
			T test = new T();
			Console.WriteLine("---------------->5");
			Console.WriteLine(T.Load(filename, mag1));
			Console.WriteLine(mag1.AddFromConsole());
			Console.WriteLine(T.Save(filename, mag1));
			//6
			Console.WriteLine("---------------->6");
			Console.WriteLine(mag1.ToString());



			Console.ReadLine();
		}
	}
}
