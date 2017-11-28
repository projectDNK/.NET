using System;

namespace Lab1
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

        public Person():this(name:string.Empty, surname:string.Empty,birthDate:new DateTime())
        {
        }

        public int Year
        {
            get { return BirthDate.Year; }
            set { BirthDate = new DateTime(BirthDate.Day, BirthDate.Month, value); }

        }
        public override string ToString()
        {
            string str = "Name: " + Name + "; Surname: " + Surname + "; BirthDate: " + BirthDate.ToShortDateString() + ";";
            return str;
        }
        public virtual string ToShortString()
        {
            string str = "Name: " + Name + "; Surname: " + Surname + ";";
            return str;
        }
    }

}
