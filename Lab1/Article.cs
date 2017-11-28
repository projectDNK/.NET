using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Article
    {
        public Person Author { get; set; }
        public string Title { get; set; }
        public double Rate { get; set; }

        public Article(Person author, string title, double rate)
        {
            Author = author;
            Title = title;
            Rate = rate;
        }
        public Article():this(author:new Person(), title: string.Empty, rate: 0.0d)
        {
        }
        public override string ToString()
        {
            var str = "\n" + Author.ToString() + " Title: " + Title + "; Rate: " + Rate + ";";
            return str;
        }

    }
}
