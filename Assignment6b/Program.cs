using Assignment6b.Model;

namespace Assignment6b
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UniversityEvent universityEvent = new UniversityEvent();

            universityEvent.RegisterJavaWorkshop(101,new Student("Raju","Computer Science"));
            universityEvent.RegisterJavaWorkshop(102,new Student("Shaam","Computer Science"));
            universityEvent.RegisterJavaWorkshop(103,new Student("BabuRao","Computer Science"));

            universityEvent.StudentListOfJava();

             universityEvent.RegisterPythonWorkshop(101,new Student("Raju","Computer Science"));
            universityEvent.RegisterPythonWorkshop(102,new Student("Shaam","Computer Science"));
            universityEvent.RegisterPythonWorkshop(103,new Student("BabuRao","Computer Science"));

            universityEvent.StudentListOfPython();
        }
    }
}
