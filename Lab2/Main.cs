using System;
using System.Collections;
using System.Collections.Concurrent;

namespace Lab2
{
    namespace EditionTestDrive
    {
        class MainPrograme
        {
            static void SetTaskMessage(string str)
            {
                Console.WriteLine(str);
            }
            static void Main(string[] args)
            {
                Console.WriteLine("1. Compare two same objects of Edition:\r\n");

                Edition editionFirst = new Edition("Football", 40, new DateTime(1995,9, 1));
                Edition editionSecond = new Edition("Football", 40, new DateTime(1995, 9, 1));

                Console.WriteLine("Edition first: \r\n{0}\r\n", editionFirst.ToString());
                Console.WriteLine("Edition second: \r\n{0}\r\n", editionSecond.ToString());

                if (editionFirst.Equals(editionSecond)) Console.WriteLine("editionFirst == editionSecond \r\n");
                else Console.WriteLine("editionFirst != editionSecond\r\n");

                int hashEditionFirst = editionFirst.GetHashCode();
                int hashEditionSecond = editionSecond.GetHashCode();

                Console.WriteLine("Hash code Edition first:  {0}", hashEditionFirst);
                Console.WriteLine("Hash code Edition second: {0}\r\n", hashEditionSecond);

                Console.WriteLine("2. Set up negative circulation:\r\n");

                try
                {
                    editionFirst.GetSetCirculationEdition = -1;
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message + '\n');
                }

                Console.WriteLine("3. Create Magazine object:\r\n");
        
                Person editor1 = new Person("Artem", "Frankov", new DateTime(1983, 12, 7));
                Person editor2 = new Person("Karina", "Slavovna", new DateTime(1991, 10, 15));

                Article article1 = new Article(editor1, "Fenomen Zizu", 8.9d);
                Article article2 = new Article(editor2, "Top-10 hurts in football", 7.5d);

                ArrayList editors = new ArrayList
                {
                    editor1,
                    editor2
                };

                ArrayList articles = new ArrayList
                {
                    article1,
                    article2
                };

                Magazine magazineFirst = new Magazine("NearFootball", Frequency.Montly, new DateTime(2017,5,15), 50, editors, articles);

                Console.WriteLine(magazineFirst.ToString());

                Console.WriteLine("4. Get statement Edition for Magazine:\r\n");

                Edition edition = magazineFirst.EditionValue;

                Console.WriteLine(edition.ToString() + '\n');

                Console.WriteLine("5. Makes copies for Magazine:\r\n");

                Magazine magazineCopy = magazineFirst.DeepCopy() as Magazine;

                Console.WriteLine("Original magazine:");
                
                Console.WriteLine(magazineFirst.ToString());
                                
                Console.WriteLine("Copy of the magazine: ");
                
                Console.WriteLine(magazineCopy.ToString());

                string title = "Libero";
                Console.WriteLine("Changing original magazine:\r\nSet title \'{0}\'",title);
                           
                magazineFirst.GetSetTitleEdition = title;
                
                Console.WriteLine("Original magazine:");
              
                Console.WriteLine(magazineFirst.ToString());
                               
                Console.WriteLine("A copy of the magazine: ");
              
                Console.WriteLine(magazineCopy.ToString());

                Console.WriteLine("6. Output articles with rating more then 8.5: \r\n");

                double rating = 8.4d;

                 foreach (Article item in magazineFirst.ListArticlesWithRatingMoreThen(rating))
                     Console.WriteLine(item.ToString());
 
                Console.WriteLine();
                Console.WriteLine("7. Output articles with title consist of word \'Zizu\'");
                Console.WriteLine();

                foreach (Article item in magazineFirst.ListArticlesWithSubTitle("Zizu"))
                    Console.WriteLine(item.ToString());

                Console.ReadLine();


            }
        }
    }
}
