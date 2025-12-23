using System;

namespace YPPcommand
{
    class Exam : IDateAndCopy
    {
        public string Namepredmet { get; set; }
        public int Otsenka { get; set; }

        protected DateTime data;

        public DateTime Date
        {
            get => data;
            set => data = value;
        }

        public Exam(string namepredmet, int otsenka, DateTime date)
        {
            Namepredmet = namepredmet;
            Otsenka = otsenka;
            data = date;
        }

        public Exam()
        {
            Namepredmet = "kpiap";
            Otsenka = 10;
            data = new DateTime(2025, 2, 4);
        }

        public override string ToString()
        {
            return $"Предмет: {Namepredmet}, Оценка: {Otsenka}, Дата: {data:d}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is null || !(obj is Exam))
            { return false; }

            Exam other = (Exam)obj;

            return Namepredmet == other.Namepredmet && Otsenka == other.Otsenka && data == other.data;
        }

        public static bool operator ==(Exam? e1, Exam? e2)
        {
            if (ReferenceEquals(e1, e2)) return true;
            if (e1 is null || e2 is null) return false;

            return e1.Equals(e2);
        }

        public static bool operator !=(Exam? e1, Exam? e2)
        {
            return !(e1 == e2);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Namepredmet, Otsenka, data);
        }

        public object DeepCopy()
        {
            return new Exam(Namepredmet, Otsenka, data);
        }
    }
}
