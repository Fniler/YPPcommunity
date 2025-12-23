using System;
using System.Collections.Generic;
using System.Text;

using System;

namespace YPPcommand
{
    class Test : IDateAndCopy
    {
        public string Subject { get; set; }
        public bool IsPassed { get; set; }
        public DateTime Date { get; set; }

        public Test(string subject, bool isPassed)
        {
            Subject = subject;
            IsPassed = isPassed;
            Date = DateTime.Now;
        }

        public Test()
        {
            Subject = "Math";
            IsPassed = true;
            Date = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Subject: {Subject}, Passed: {IsPassed}";
        }

        public object DeepCopy()
        {
            return new Test(Subject, IsPassed)
            {
                Date = this.Date
            };
        }
    }
}

