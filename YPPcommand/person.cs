using System;
using System.Collections.Generic;
using System.Text;

namespace YPPcommand
{
    class Person
    {
        protected string name;
        protected string last_name;
        protected DateTime birthday;

        public Person(string name, string last_name, DateTime birthday)
        {
            this.name = name;
            this.last_name = last_name;
            this.birthday = birthday;
        }
        public Person() : this("неизвестно", "неизвестно", DateTime.Now) { }

        public string Name
        {
            get { return name; }
            set
            {
                if (value != null)
                {
                    name = value;
                }
                else
                {
                    throw new Exception("Нет значения");
                }
            }
        }
        public string Last_Name
        {
            get { return last_name; }
            set
            {
                if (value != null)
                {
                    last_name = value;
                }
                else
                {
                    throw new Exception("Нет значения");
                }
            }
        }
        public DateTime Birthday
        {
            get { return birthday; }
            set
            {
                if (value.Year<120)
                {
                    birthday = value;
                }
                else
                {
                    throw new Exception("Неверное значение");
                }
            }
        }
        public int Year
        {
            get { return birthday.Year; }
            set
            {
                if(value > 0 )
                {
                    birthday = new DateTime(value, birthday.Month, birthday.Day);
                }
                else 
                {
                    throw new Exception("Неверное значение");
                }
            }
        }
        public override string ToString()
        {
            return $"Name:{name}|Last name:{last_name}|Birthday:{birthday}";
        }
        public virtual  string ToShortString()
        {
            return $"Name:{name}|Last name:{last_name}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is null || obj is Person) 
            { return false; }
            else 
            {
                Person t = (Person)obj;
                if(this.Name.Equals(t.Name) && this.Last_Name.Equals(t.Last_Name) && this.Birthday.Equals(t.Birthday))
                { return true; }
                else 
                { return false; }
            }
        }
        public static bool operator==(Person? t1 , Person? t2)
        {
            if(t1 is null || t2 is null) 
            { return false; }
            else
            {
                if (t1.Name == t2.Name && t1.Last_Name == t2.Last_Name && t1.Birthday == t2.Birthday)
                { return true; }
                else
                { return false; }
            }
        }
        public static bool operator !=(Person? t1, Person? t2)
        {
            return !(t1 == t2);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Last_Name, Birthday);
        }
        public Person DeepCopy()
        {
            return new Person(Name, Last_Name, Birthday);
        }
    }
}
