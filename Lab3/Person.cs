﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
	class Person
	{
		private string Name;

		private string Surname;

		private DateTime BirthDate;

		public string _Name
		{
			get
			{
				return Name;
			}
			set
			{
				Name = value;
			}
		}

		public string _SurName
		{
			get
			{
				return Surname;
			}
			set
			{
				Surname = value;
			}
		}

		public DateTime _BirthDate
		{
			get
			{
				return BirthDate;
			}
			set
			{
				BirthDate = value;
			}
		}


		public Person(string name, string surname, DateTime birthDate)
		{
			_Name = name;
			_SurName = surname;
			_BirthDate = birthDate;
		}

		public Person() : this(name: string.Empty, surname: string.Empty, birthDate: new DateTime())
		{
		}
		public int Year
		{
			get { return BirthDate.Year; }
			set { BirthDate = new DateTime(value, BirthDate.Month, BirthDate.Day); }

		}
		public override string ToString()
		{
			string str = " Name: [" + Name + "]  Surname: [" + Surname + "] Birth date: [" + BirthDate.ToShortDateString() + "] ";
			return str;
		}
		public virtual string ToShortString()
		{
			string str = " Name: [" + Name + "]  Surname: [" + Surname + "] ";
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
		public static bool operator ==(Person personFirst, Person personSecond)
		{
			if (System.Object.ReferenceEquals(personFirst, personSecond)) return true;
			if ((object)personFirst == null || (object)personSecond == null) return false;

			return personFirst.Equals(personSecond);
		}
		public static bool operator !=(Person personFirst, Person personSecond)
		{
			return !(personFirst.Equals(personSecond));
		}
		public override int GetHashCode()
		{
			unchecked
			{
				int hash = 13;
				hash = (hash * 7) + (!Object.ReferenceEquals(null, Name) ? Name.GetHashCode() : 0);
				hash = (hash * 7) + (!Object.ReferenceEquals(null, Surname) ? Surname.GetHashCode() : 0);
				hash = (hash * 7) + (!Object.ReferenceEquals(null, BirthDate) ? BirthDate.GetHashCode() : 0);
				return hash;
			}
		}

		public virtual Person DeepCopy()
		{
			Person other = (Person)MemberwiseClone();

			other.Name = string.Copy(Name);
			other.Surname = string.Copy(Surname);
			other.BirthDate = new DateTime(other.BirthDate.Year, other.BirthDate.Month, other.BirthDate.Day);

			return other;
		}


	}
}
