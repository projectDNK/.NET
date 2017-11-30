using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    class Magazine : Edition, IRateAndCopy
    {
        private Frequency FrequencyMagazine;

        private ArrayList ListEditors;
        private ArrayList ListArticles;

        public double Rating { get; }

        public Magazine(string titleMagazine, Frequency frequency, DateTime releaseMagazine, int circulationMagazine, ArrayList listEditors, ArrayList listArticles)
            : base(titleEdition:titleMagazine,releaseEdition:releaseMagazine,circulationEdition:circulationMagazine)
        {
            FrequencyMagazine = frequency;
            GetSetListEditors = listEditors;
            GetSetListArticles = listArticles;
        }
        public Magazine() : this(titleMagazine: string.Empty, frequency:Frequency.Weekly, releaseMagazine: new DateTime(),circulationMagazine: 0, listEditors:new ArrayList(0),listArticles: new ArrayList(0))
        {
        }
        public double AverageRating
        {
            get
            {
                double sum = 0;
                if (GetSetListArticles.Count == 0) return 0;
                foreach (Article article in GetSetListArticles)
                {
                    sum += article.Rating;
                }
                return sum / GetSetListArticles.Count;
            }
        }
        public Frequency GetSetFrequencyMagazine
        {
            get { return FrequencyMagazine; }
            set { FrequencyMagazine = value; }
        }
        public bool this[Frequency f]
        {
            get
            {
                return FrequencyMagazine == f;
            }
        }
        public Edition EditionValue
        {
            get
            {
                return new Edition(GetSetTitleEdition, GetSetCirculationEdition, GetSetReleaseEdition);
            }
            set
            {
                TitleEdition = value.GetSetTitleEdition;
                CirculationEdition = value.GetSetCirculationEdition;
                ReleaseEdition = value.GetSetReleaseEdition;
            }
        }
        public ArrayList GetSetListArticles
        {
            get { return ListArticles; }
            set { ListArticles = value; }
        }
        public ArrayList GetSetListEditors
        {
            get { return ListEditors; }
            set { ListEditors = value; }
        }
        public void AddArticles(params Article[] articles) => GetSetListArticles.Add(articles) ;

        public void AddEditors(params Person[] editors) => GetSetListEditors.Add(editors);

        public override string ToString()
        {
            string str = base.ToString() + " Frequency magazine: " + FrequencyMagazine + ";";

            StringBuilder strNew = new StringBuilder();

            strNew.Append(str);
            strNew.Append("\nList Articles: ");
            foreach (Article item in GetSetListArticles)
            {
                strNew.Append("\n");
                strNew.Append(item.ToString());
            }
            strNew.Append("\n");
            strNew.Append("Editors of magazine: ");
            foreach (Person item in GetSetListEditors)
            {
                strNew.Append("\n");
                strNew.Append(item.ToString());
            }
            strNew.Append("\n");
            return strNew.ToString();
        }
        public virtual string ToShortString()
        {
            string str = " Frequency: " + FrequencyMagazine + "; Average rate: " + AverageRating + ";";
            return str;

        }
        public override bool Equals(object obj)
        { 

            Magazine magazine = obj as Magazine;

            return ((System.Object)magazine != null) &&
                        (magazine.FrequencyMagazine == FrequencyMagazine) &&
                        (magazine.GetSetListArticles == GetSetListArticles) &&
                        (magazine.GetSetListEditors == GetSetListEditors);
        }
        public static bool operator == (Magazine magazineFirst, Magazine magazineSecond)
        {
            if (System.Object.ReferenceEquals(magazineFirst, magazineSecond)) return true;
            if ((object)magazineFirst == null || (object)magazineSecond == null) return false;

            return magazineFirst.Equals(magazineSecond);
        }
        public static bool operator != (Magazine magazineFirst, Magazine magazineSecond) => !(magazineFirst.Equals(magazineSecond));

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 24;
                hash = (hash * 97) + (!Object.ReferenceEquals(null, FrequencyMagazine) ? FrequencyMagazine.GetHashCode() : 0);
                hash = (hash * 97) + (!Object.ReferenceEquals(null, GetSetListArticles) ? GetSetListArticles.GetHashCode() : 0);
                hash = (hash * 97) + (!Object.ReferenceEquals(null, GetSetListEditors) ? GetSetListEditors.GetHashCode() : 0);
                return hash;
            }
        }
        public override object DeepCopy()
        {
            Magazine other = (Magazine)MemberwiseClone();

           
            other.FrequencyMagazine = FrequencyMagazine;
            ArrayList listEditors = new ArrayList();
            ArrayList listArticles = new ArrayList();

            foreach (Article item in GetSetListArticles)
            {
                listArticles.Add(item.DeepCopy());
            }
            foreach (Person item in GetSetListEditors)
            {
                listEditors.Add(item.DeepCopy());
            }

            other.GetSetListArticles = ListArticles;
            other.GetSetListEditors = ListEditors;

            return other;
        }
        public Edition Edition
        {
            get { return this; }
        }
        public IEnumerable<Article> ListArticlesWithRatingMoreThen(double rate)
        {
            foreach(Article item in GetSetListArticles)
            {
                if (item.Rating > rate) yield return item;
            }
        }
        public IEnumerable<Article> ListArticlesWithSubTitle(string str)
        {
            foreach(Article item in GetSetListArticles)
            {
                if (item.Title.IndexOf(str, StringComparison.OrdinalIgnoreCase) >= 0) yield return item;
            }
        }
    }
}