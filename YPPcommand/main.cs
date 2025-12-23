using System.Data.Common;
using YPPcommand;

Main();
static void Main()
{
    // Person Equals
    Person p1 = new Person("Ivan", "Ivanov", new DateTime(2000, 1, 1));
    Person p2 = new Person("Ivan", "Ivanov", new DateTime(2000, 1, 1));

    Console.WriteLine(p1 == p2);
    Console.WriteLine(p1.GetHashCode());
    Console.WriteLine(p2.GetHashCode());

    // Student
    Student st = new Student(p1, Education.Specialist, 201);

    st.Exams.Add(new Exam("Math", 5, DateTime.Now));
    st.Exams.Add(new Exam("Physics", 3, DateTime.Now));

    st.Tests.Add(new Test("Math", true));
    st.Tests.Add(new Test("History", true));

    Console.WriteLine(st);

    // DeepCopy
    Student copy = (Student)st.DeepCopy();
    st.GroupNumber = 301;

    Console.WriteLine("ORIGINAL:");
    Console.WriteLine(st.ToShortString());

    Console.WriteLine("COPY:");
    Console.WriteLine(copy.ToShortString());

    // Exception
    try
    {
        st.GroupNumber = 50;
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    // Итераторы
    Console.WriteLine("Пересечение предметов:");
    foreach (string s in st)
        Console.WriteLine(s);

    Console.WriteLine("Сданные зачеты и экзамены:");
    foreach (object o in st.PassedTestsAndExams())
        Console.WriteLine(o);

    Console.WriteLine("Сданные зачеты с сданным экзаменом:");
    foreach (Test t in st.PassedTestsWithPassedExam())
        Console.WriteLine(t);
}

