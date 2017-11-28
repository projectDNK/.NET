using System;

namespace Lab1
{
    class Magazine
    {
        private string _title;
        private Frequency _frequency;

        private DateTime _realease;
        private int _circulation;

        private Article[] _listArticles;

        public Magazine(string title, Frequency frequency, DateTime release, int circulation, Article[] listArticles)
        {
            _title = title;
            _frequency = frequency;
            _realease = release;
            _circulation = circulation;
            _listArticles = listArticles;
        }
        public Magazine():this(title: string.Empty,frequency: Frequency.Montly,release:new DateTime(),circulation:0,listArticles: new Article[0])
        {
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public Frequency Frequency
        {
            get { return _frequency; }
            set { _frequency = value; }
        }
        public DateTime Release
        {
            get { return _realease; }
            set { _realease = value; }
        }
        public Article[] ListArticles
        {
            get { return _listArticles; }
            set { _listArticles = value; }
        }
        public int Circulation
        {
            get { return _circulation; }
            set { _circulation = value; }
        }
        public double AverageRate
        {
            get
            {
                double sum = 0;
                if (ListArticles.Length == 0) return sum;

                foreach (Article item in ListArticles)
                {
                    sum += item.Rate;
                }
                return sum / ListArticles.Length;
            }
        }
        public bool this[Frequency f]
        {
            get
            {
                return Frequency == f;

            }
        }
        public void AddArticles(params Article[] articles)
        {
            if (articles.Length == 0) return;
            Article[] newListArticles = new Article[articles.Length + ListArticles.Length];

            int i = 0;
            foreach (Article item in ListArticles)
            {
                newListArticles[i] = item;
                i++;
            }
            foreach (Article item in articles)
            {
                newListArticles[i] = item;
                i++;
            }
            ListArticles = newListArticles;
        }
        public override string ToString()
        {
            string str = "Title: " + Title + "; Frequency: " + Frequency + "; Date of release: " + Release.ToShortDateString() + "; Circulation: " + Circulation + ";";

            foreach (Article item in ListArticles)
            {
                str =  str + item.ToString() + "";

            }
            str = str.Remove(str.Length - 2, 2);
            return str;
        }
        public virtual string ToShortString()
        {
            string str = "Title: " + Title + "; Frequency: " + Frequency + "; Date of release: " + Release.ToShortDateString() + "; Circulation: " + Circulation + "; Average rate: " + AverageRate + ";";
            return str;
        }


    }
}
