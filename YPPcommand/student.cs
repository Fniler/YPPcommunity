using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace YPPcommand
{
    class Student 
    {
        private Person info;
        private Education education;
        private int nomergruppi;
        private Exam[] exams;
        private double AVGsum;

        
        public Student(Person info, Education education, int nomergruppi)
        {
            this.info = info;
            this.education = education;
            this.nomergruppi = nomergruppi;
        }

        public Student(Person info, Education education, int nomergruppi,params Exam[] exams):this(info,education,nomergruppi)
        {
            this.exams = exams;
        }
        public Student()
        {
            info = new Person();
            education = Education.Specialist;
            nomergruppi = 4;
            exams = new Exam[0];
        }
        public Exam[] Exams
        {
            get { return exams; }
        }
        public Person Info
        {
            get { return info; }
            set { info = value; }
        }

        public Education Education
        {
            get { return education; }
            set { education = value; }
        }

        public int Nomergruppi
        {
            get { return nomergruppi; }
            set { nomergruppi = value; }
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
                return $"Студент: {info}, Форма обучения: {education}, Группа: {nomergruppi}\nЭкзамены: нет";
            }
            string rez = $"Студент: {info}, Форма обучения: {education}, Группа: {nomergruppi}\n";
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
            return $"Студент: {info}, Форма обучения: {education}, Группа: {nomergruppi}, Средний балл: {AVG}";
        }
    }
}
