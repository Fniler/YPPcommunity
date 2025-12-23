using System;

namespace YPPcommand
{
    class Person : IDateAndCopy
    {
        protected string name;
        protected string last_name;
        protected DateTime birthday;
        protected DateTime date;

        public Person(string name, string last_name, DateTime birthday)
        {
            this.name = name;
            this.last_name = last_name;
            this.birthday = birthday;
            date = DateTime.Now;
        }

        public Person() : this("неизвестно", "неизвестно", DateTime.Now) { }

        public string Name
        {
            get => name;
            set => name = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Last_Name
        {
            get => last_name;
            set => last_name = value ?? throw new ArgumentNullException(nameof(value));
        }

        public DateTime Birthday
        {
            get => birthday;
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentOutOfRangeException();
                birthday = value;
            }
        }

        public DateTime Date
        {
            get => date;
            set => date = value;
        }

        public int Year
        {
            get => birthday.Year;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException();
                birthday = new DateTime(value, birthday.Month, birthday.Day);
            }
        }

        public override string ToString()
        {
            return $"Name:{name}|Last name:{last_name}|Birthday:{birthday}";
        }

        public virtual string ToShortString()
        {
            return $"Name:{name}|Last name:{last_name}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is null || !(obj is Person))
                return false;

            Person other = (Person)obj;

            return name == other.name &&
                   last_name == other.last_name &&
                   birthday == other.birthday;
        }

        public static bool operator ==(Person? p1, Person? p2)
        {
            if (ReferenceEquals(p1, p2)) return true;
            if (p1 is null || p2 is null) return false;
            return p1.Equals(p2);
        }

        public static bool operator !=(Person? p1, Person? p2)
        {
            return !(p1 == p2);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, last_name, birthday);
        }

        public virtual object DeepCopy()
        {
            return new Person(name, last_name, birthday)
            {
                date = this.date
            };
        }
    }
}
