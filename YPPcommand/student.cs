using System;
using System.Collections;
using System.Collections.Generic;

namespace YPPcommand
{
    class Student : Person, IDateAndCopy, IEnumerable
    {
        private Education education;
        private int groupNumber;
        private ArrayList exams;   
        private ArrayList tests;   
        private DateTime date;

        public Student(Person p, Education education, int groupNumber)
            : base(p.Name, p.Last_Name, p.Birthday)
        {
            this.education = education;
            GroupNumber = groupNumber;
            exams = new ArrayList();
            tests = new ArrayList();
            date = DateTime.Now;
        }

        public Student(): base()
        {
            education = Education.Specialist;
            groupNumber = 101;
            exams = new ArrayList();
            tests = new ArrayList();
            date = DateTime.Now;
        }


        public Education Education
        {
            get => education;
            set => education = value;
        }

        public int GroupNumber
        {
            get => groupNumber;
            set
            {
                if (value <= 100 || value > 599)
                    throw new ArgumentOutOfRangeException(
                        "GroupNumber",
                        "Номер группы должен быть в диапазоне 101–599"
                    );
                groupNumber = value;
            }
        }

        public ArrayList Exams
        {
            get => exams;
            set => exams = value ?? throw new ArgumentNullException();
        }

        public ArrayList Tests
        {
            get => tests;
            set => tests = value ?? throw new ArgumentNullException();
        }

        public double AverageMark
        {
            get
            {
                if (exams.Count == 0) return 0;
                double sum = 0;
                foreach (Exam e in exams)
                    sum += e.Otsenka;
                return sum / exams.Count;
            }
        }

        public DateTime Date
        {
            get => date;
            set => date = value;
        }

        public Person Person
        {
            get => new Person(name, last_name, birthday);
            set
            {
                name = value.Name;
                last_name = value.Last_Name;
                birthday = value.Birthday;
            }
        }


        public void AddExams(params Exam[] newExams)
        {
            foreach (Exam e in newExams)
                exams.Add(e);
        }

        public override string ToString()
        {
            string s = base.ToString();
            s += $"\nEducation: {education}, Group: {groupNumber}\nExams:\n";
            foreach (Exam e in exams)
                s += e + "\n";
            s += "Tests:\n";
            foreach (Test t in tests)
                s += t + "\n";
            return s;
        }

        public virtual string ToShortString()
        {
            return $"{base.ToShortString()}, Education: {education}, Group: {groupNumber}, Avg: {AverageMark}";
        }

        public override object DeepCopy()
        {
            Student copy = new Student(this.Person, education, groupNumber);
            copy.date = date;

            foreach (Exam e in exams)
                copy.exams.Add(e.DeepCopy());

            foreach (Test t in tests)
                copy.tests.Add(t.DeepCopy());

            return copy;
        }
        public IEnumerable ExamsAbove(int mark)
        {
            foreach (Exam e in exams)
                if (e.Otsenka > mark)
                    yield return e;
        }
        public IEnumerable PassedTestsAndExams()
        {
            foreach (Test t in tests)
                if (t.IsPassed)
                    yield return t;

            foreach (Exam e in exams)
                if (e.Otsenka > 2)
                    yield return e;
        }
        public IEnumerable PassedTestsWithPassedExam()
        {
            foreach (Test t in tests)
            {
                if (!t.IsPassed) continue;

                foreach (Exam e in exams)
                {
                    if (e.Otsenka > 2 && e.Namepredmet == t.Subject)
                    {
                        yield return t;
                        break;
                    }
                }
            }
        }
        public new IEnumerator GetEnumerator()
        {
            foreach (Test t in tests)
            {
                foreach (Exam e in exams)
                {
                    if (t.Subject == e.Namepredmet)
                    {
                        yield return t.Subject;
                        break;
                    }
                }
            }
        }

    }
}
