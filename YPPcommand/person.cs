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
    }
}
