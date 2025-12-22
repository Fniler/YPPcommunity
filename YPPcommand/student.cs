using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

namespace YPPcommand
{
    class Student : Person, IDateAndCopy, IEnumerable
    {
        private Education education;
        private int nomergruppi;
        private Exam[] exams;
        private double AVGsum;
        private DateTime date;
        private ArrayList examslist = new ArrayList();

        
        public Student(string name, string last_name, DateTime birthday, Education education, int nomergruppi, DateTime date, ArrayList examslist):base(name,last_name,birthday)
        {
            this.name = name;
            this.last_name = last_name;
            this.birthday = birthday;
            this.education = education;
            this.nomergruppi = nomergruppi;
            this.date = date;
            this.examslist = examslist;
        }

        public Student(string name, string last_name, DateTime birthday, Education education, int nomergruppi, DateTime date,ArrayList examslist,params Exam[] exams):this(name,last_name,birthday,education,nomergruppi, date, examslist) 
        {
            this.exams = exams;
        }
        public Student()
        {
            Name = name;
            education = Education.Specialist;
            nomergruppi = 4;
            exams = new Exam[0];
            date = DateTime.Now;
        }
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
                if (value.Year < 120)
                {
                    birthday = value;
                }
                else
                {
                    throw new Exception("Неверное значение");
                }
            }
        }
        public Exam[] Exams
        {
            get { return exams; }
        }

        public Education Education
        {
            get { return education; }
            set { education = value; }
        }

        public int Nomergruppi
        {
            get { return nomergruppi; }
            set {
                if (value <= 100 || value > 599)
                {
                    throw new Exception();
                }
                nomergruppi = value; 
            }
        }

        public Person Person
        {
            get { return new Person(name, last_name, birthday); }
            set { name = value.Name; last_name = value.Last_Name; birthday = value.Birthday; }
        }

        public ArrayList Examslist
        {
            get { return examslist; } 
            set {
                if (value == null)
                {
                    throw new Exception();
                }
                examslist = value;
            }
        }

        public double AVG
        {
            get
            {
                if(exams!=null)
                {
                    AVGsum = 0;
                    for (int i = 0; i < exams.Length; i++)
                    {
                        AVGsum += exams[i].Otsenka;
                    }
                    return AVGsum / exams.Length;
                }
                else
                { return 0; }
            }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public object DeepCopy()
        {
            return new Student(name, last_name, birthday, education, nomergruppi, date, examslist);
        }

        public bool this[Education educa]
        {
            get
            {
                return this.education == educa;
            }
        }
        public void AddExams(params Exam[] newexam)
        {
            if (newexam == null || newexam.Length == 0)
            {
                return;
            }
            if (exams == null)
            {
                exams = new Exam[0];
            }
            int oldLength = exams.Length;
            Array.Resize(ref exams, oldLength + newexam.Length);
            for (int i = 0; i < newexam.Length; i++)
            {
                exams[oldLength + i] = newexam[i];
            }
        }
        public override string ToString()
        {
            if (exams == null || exams.Length == 0)
            {
                return $"Форма обучения: {education}, Группа: {nomergruppi}\nЭкзамены: нет";
            }
            string rez = $" Форма обучения: {education}, Группа: {nomergruppi}\n";
            foreach (var exam in exams)
            {
                if(exam != null)
                {
                    rez += exam.ToString()+"\n";
                }
            }
            return rez;
        }
        public virtual string ToShortString()
        {
            return $"Форма обучения: {education}, Группа: {nomergruppi}, Средний балл: {AVG}";
        }

        public IEnumerable GetEnumerable()
        {
            foreach(object obj in examslist)
            {
                yield return obj;
            }
            foreach(Exam ex in exams)
            {
                yield return ex; 
            }    
        }

        public IEnumerable GetExamAndZnach()
        {
            foreach(Exam ex in exams)
            {
                yield return ex;
            }
        }
        public IEnumerator GetEnumerator()
        {
            return new StudentEnumerator(examslist, exams);
        }

        public IEnumerable GetTestsWithPassedExam()
        {
            foreach (object test in examslist)
            {
                foreach (Exam ex in exams)
                {
                    if (test.ToString() == ex.ToString())
                    {
                        yield return test;
                    }
                }
            }
        }
        public IEnumerable GetIntersectionSubjects()
        {
            foreach (object test in examslist)
            {
                foreach (Exam ex in exams)
                {
                    if (test.ToString() == ex.ToString())
                    {
                        yield return ex.ToString();
                    }
                }
            }
        }
    }
}
