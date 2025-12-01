using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace YPPcommand
{
    class Student : Exam
    {
        private Person info;
        private Education education;
        private int nomergruppi;
        private Exam[] exams;
        private double AVGsum;

        public Student(Person info, Education education, int nomergruppi, Exam[] exams)
        {
            this.info = info;
            this.education = education;
            this.nomergruppi = nomergruppi;
        }

        public Student()
        {
            info = new Person();
            education = Education.Specialist;
            nomergruppi = 4;
            exams = new Exam[3];
        }

        public Person Info
        {
            get { return info; } 
            set { info = value; }
        }

        public Education Education
        {
            get { return education; }
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
                for (int i = 0; i < exams.Length; i++)
                {
                    AVGsum += exams[i].Otsenka;
                }
                return AVGsum / exams.Length;
            } 
        }
    }
}
