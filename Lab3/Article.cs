using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
	class Article : Edition, IRateAndCopy
	{
		public Person Author { get; set; }
		public string Title { get; set; }
		public double Rate { get; set; }

		public double Rating
		{
			get { return Rate; }
		}



		public Article(Person author, string title, double rate)
		{
			Author = author;
			Title = title;
			Rate = rate;
		}
		public Article() : this(author: new Person(), title: String.Empty, rate: 0.0d)
		{
		}
		public override string ToString()
		{
			string str = Author.ToString() + " Title: [" + Title + "]  Rate: [" + Rate + "] ";
			return str;
		}
		public override bool Equals(object obj)
		{
			Article article = obj as Article;
			return ((System.Object)article != null) &&
					(article.Title == Title) &&
					(article.Rating == Rate) &&
					(article.Author == Author);
		}
		public static bool operator ==(Article articleFirst, Article articleSecond)
		{
			if (System.Object.ReferenceEquals(articleFirst, articleSecond)) return true;
			if ((object)articleFirst == null || (object)articleSecond == null) return false;

			return articleFirst.Equals(articleSecond);
		}
		public static bool operator !=(Article articleFirst, Article articleSecond)
		{
			return !(articleFirst.Equals(articleSecond));
		}
		public override int GetHashCode()
		{
			unchecked
			{
				int hash = 13;
				hash = (hash * 7) + (!Object.ReferenceEquals(null, Title) ? Title.GetHashCode() : 0);
				hash = (hash * 7) + (!Object.ReferenceEquals(null, Rating) ? Rating.GetHashCode() : 0);
				hash = (hash * 7) + (!Object.ReferenceEquals(null, Author) ? Author.GetHashCode() : 0);
				return hash;
			}
		}
		public virtual object DeepCopy()
		{
			Article other = (Article)MemberwiseClone();

			other.Title = string.Copy(Title);
			other.Rate = Rating;
			other.Author = other.Author.DeepCopy();

			return other;
		}

	}
}
