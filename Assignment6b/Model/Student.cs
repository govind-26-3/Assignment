namespace Assignment6b.Model
{
    internal class Student
    {
        public string StudentName { get; internal set; }
        public string StudentCourseName { get; internal set; }

        public Student(string name, string courseName)
        {
            this.StudentName = name;
            this.StudentCourseName = courseName;
        }

    }
}