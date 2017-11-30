using System;
using System.Collections.Generic;
using System.Text;


namespace Lab2
{
    class Person
    {
        private string Name { get; set; }
        private string Surname { get; set; }
        private DateTime BirthDate { get; set; }

        public Person(string name, string surname, DateTime birthDate)
        {
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
        }

        public Person() : this(name:string.Empty,surname: string.Empty, birthDate:new DateTime())
        {
        }
        public int Year
        {
            get { return BirthDate.Year; }
            set { BirthDate = new DateTime(value,BirthDate.Month,BirthDate.Day); }

        }
        public override string ToString()
        {
            string str = "Name: " + Name + "; Surname: " + Surname + "; Birth date: " + BirthDate.ToShortDateString() + ";";
            return str;
        }
        public virtual string ToShortString()
        {
            string str = "Name: " + Name + "; Surname: " + Surname + ";";
            return str;
        }

        public override bool Equals(object obj)
        {
            Person person = obj as Person;
            return ((System.Object)person != null) &&
                    (person.Name == Name) &&
                    (person.Surname == Surname) &&
                    (person.BirthDate == BirthDate);
        }
        public static bool operator == (Person personFirst, Person personSecond)
        {
            if (System.Object.ReferenceEquals(personFirst, personSecond)) return true;
            if ((object)personFirst == null || (object)personSecond == null) return false;

            return personFirst.Equals(personSecond);
        }
        public static bool operator != (Person personFirst, Person personSecond)
        {
            return !(personFirst.Equals(personSecond));
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 24;
                hash = (hash * 97) + (!Object.ReferenceEquals(null, Name) ? Name.GetHashCode() : 0);
                hash = (hash * 97) + (!Object.ReferenceEquals(null,Surname) ? Surname.GetHashCode() : 0);
                hash = (hash * 97) + (!Object.ReferenceEquals(null, BirthDate) ? BirthDate.GetHashCode() : 0);
                return hash;
            }
        }

        public virtual Person DeepCopy()
        {
            Person other = (Person)MemberwiseClone();

            other.Name = string.Copy(Name);
            other.Surname = string.Copy(Surname);
            other.BirthDate = new DateTime(other.BirthDate.Year,other.BirthDate.Month,other.BirthDate.Day);

            return other;
        }


    }
}

