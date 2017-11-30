using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    class Edition
    {
        protected string TitleEdition;
        protected int CirculationEdition;
        protected DateTime ReleaseEdition;

        public Edition(string titleEdition, int circulationEdition, DateTime releaseEdition)
        {
            TitleEdition = titleEdition;
            CirculationEdition = circulationEdition;
            ReleaseEdition = releaseEdition;
        }
        public Edition(): this(titleEdition:string.Empty,releaseEdition:new DateTime(),circulationEdition:0)
        {
        }
        public string GetSetTitleEdition
        {
           set {TitleEdition = value; }
            get { return TitleEdition; }
        }
        public DateTime GetSetReleaseEdition
        {
            set { ReleaseEdition = value; }
            get { return ReleaseEdition; }
        }
        public int GetSetCirculationEdition
        {
            set
            { 
                if (value < 0)
                {
                    throw new System.ArgumentOutOfRangeException("Circulation must be positive integer number or 0!");
                }
                CirculationEdition = value;
            }
            get { return CirculationEdition; }
        }
        public virtual object DeepCopy()
        {
            Edition other = (Edition)MemberwiseClone();

            other.GetSetTitleEdition = string.Copy(GetSetTitleEdition);
            other.GetSetReleaseEdition = new DateTime(other.GetSetReleaseEdition.Year, other.GetSetReleaseEdition.Month, other.GetSetReleaseEdition.Day);
            other.GetSetCirculationEdition = GetSetCirculationEdition;
            return other;
        }
        public override bool Equals(object obj)
        {
           Edition edition = obj as Edition;

            return     ((System.Object)edition != null) && 
                       (edition.TitleEdition == TitleEdition) &&
                       (edition.ReleaseEdition == ReleaseEdition) &&
                       (edition.CirculationEdition == CirculationEdition);
        }
        public static bool operator == (Edition editionFirst, Edition editionSecond)
        {
            if (System.Object.ReferenceEquals(editionFirst, editionSecond)) return true;

            if ((object)editionFirst == null || (object)editionSecond == null) return false;

            return editionFirst.Equals(editionSecond);
        }
        public static bool operator !=(Edition editionFirst, Edition editionSecond)
        {
            return !(editionFirst.Equals(editionSecond));
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 24;
                hash = (hash * 97) + (!Object.ReferenceEquals(null, GetSetTitleEdition) ? GetSetTitleEdition.GetHashCode() : 0);
                hash = (hash * 97) + (!Object.ReferenceEquals(null, GetSetCirculationEdition) ? GetSetCirculationEdition.GetHashCode() : 0);
                hash = (hash * 97) + (!Object.ReferenceEquals(null, GetSetReleaseEdition) ? GetSetReleaseEdition.GetHashCode() : 0);
                return hash;
            }
        }
        public override string ToString()
        {
            string str = "Title edition: "+ GetSetTitleEdition + "; Release edition: " + GetSetReleaseEdition.ToShortDateString() + "; Circulation edition: " + GetSetCirculationEdition + ";";
            return str;
        }

    }
}
