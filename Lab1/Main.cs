using System;

namespace Lab1
{
    class MainPrograme
            {
        static void Main(string[] args)
        {
            Person author = new Person("Denys", "Deineko", new DateTime(1997, 8, 24));

            Article article1 = new Article(author, "Libero", 7.9d);
            Article article2 = new Article(author, "Fenomen Zizu", 8.7d);
            Article article3 = new Article(author, "History of Neymar", 9.0d);
            
            Article[] listArticles = new Article[3];
            listArticles[0] = article1;
            listArticles[1] = article2;
            listArticles[2] = article3;

            Magazine magazine1 = new Magazine("About Football", Frequency.Montly, new DateTime(2017, 2, 19), 30, listArticles);

            Console.WriteLine(magazine1.ToShortString());
            Console.WriteLine();
          
            Console.WriteLine("Indexers value for Megazine#1[Frequency.Yearly] = {0}", magazine1[Frequency.Yearly]);
            Console.WriteLine("Indexers value for Megazine#1[Frequency.Montly] = {0}", magazine1[Frequency.Montly]);
            Console.WriteLine("Indexers value for Megazine#1[Frequency.Weekly] = {0}", magazine1[Frequency.Weekly]);
            Console.WriteLine();
          
            
            Article[] listArticles1 = new Article[0];
            Magazine magazine2 = new Magazine();
            magazine2.Title = "About food";
            magazine2.Release = new DateTime(2017, 11, 1);
            magazine2.Circulation = 120;
            magazine2.ListArticles = listArticles1;
            magazine2.Frequency = Frequency.Yearly;
            Console.WriteLine(magazine2.ToString());
            Console.WriteLine();

             
            Article applePie = new Article(author, "Apple Pie", 8.3d);
            magazine2.AddArticles(applePie);
            Console.WriteLine(magazine2.ToString());

        }
    }
}
