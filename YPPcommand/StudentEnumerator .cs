using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace YPPcommand
{
    class StudentEnumerator : IEnumerator
    {
        private ArrayList tests;
        private Exam[] exams;

        private int posTests = -1;
        private int posExams = -1;
        private bool inTests = true;

        public StudentEnumerator(ArrayList tests, Exam[] exams)
        {
            this.tests = tests;
            this.exams = exams;
        }

        public object Current
        {
            get
            {
                if (inTests)
                {
                    return tests[posTests];
                }
                else
                {
                    return exams[posExams];
                }
            }
        }

        public bool MoveNext()
        {
            if (inTests)
            {
                posTests++;
                if (posTests < tests.Count)
                {
                    return true;
                }

                inTests = false;
                posExams = 0;
            }

            if (exams == null)
            {
                return false;
            }

            return posExams < exams.Length;
        }

        public void Reset()
        {
            posTests = -1;
            posExams = -1;
            inTests = true;
        }
    }
    }
